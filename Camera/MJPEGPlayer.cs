using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Camera
{
    class MJPEGPlayer
    {

       
        const byte picMarker = 0xFF;
        const byte picStart = 0xD8;
        const byte picEnd = 0xD9;

       
        public async static Task StartAsync(Action<Image> action, string url , CancellationToken token, int chunkMaxSize = 1024, int frameBufferSize = 1024 * 1024)
        {           

            using (var client = new HttpClient())
            {               
                using (var stream = await client.GetStreamAsync(url).ConfigureAwait(false))
                {

                    var streamBuffer = new byte[chunkMaxSize];      
                    var frameBuffer = new byte[frameBufferSize];   

                    var frameIdx = 0;    
                    var inPicture = false;  
                    byte current = 0x00;  
                    byte previous = 0x00;   

                   
                    while (true)
                    {                        
                        var streamLength = await stream.ReadAsync(streamBuffer, 0, chunkMaxSize, token).ConfigureAwait(false);
                        parseStreamBuffer(action, frameBuffer, ref frameIdx, streamLength, streamBuffer, ref inPicture, ref previous, ref current);
                    };
                }
            }
        }

       

        static void parseStreamBuffer(Action<Image> action, byte[] frameBuffer, ref int frameIdx, int streamLength, byte[] streamBuffer, ref bool inPicture, ref byte previous, ref byte current)
        {
            var idx = 0;
            while (idx < streamLength)
            {
                if (inPicture)
                {
                    parsePicture(action, frameBuffer, ref frameIdx, ref streamLength, streamBuffer, ref idx, ref inPicture, ref previous, ref current);
                }
                else
                {
                    searchPicture(frameBuffer, ref frameIdx, ref streamLength, streamBuffer, ref idx, ref inPicture, ref previous, ref current);
                }
            }
        }

      
        static void searchPicture(byte[] frameBuffer, ref int frameIdx, ref int streamLength, byte[] streamBuffer, ref int idx, ref bool inPicture, ref byte previous, ref byte current)
        {
            do
            {
                previous = current;
                current = streamBuffer[idx++];

             
                if (previous == picMarker && current == picStart)
                {
                    frameIdx = 2;
                    frameBuffer[0] = picMarker;
                    frameBuffer[1] = picStart;
                    inPicture = true;
                    return;
                }
            } while (idx < streamLength);
        }

        

        static void parsePicture(Action<Image> action, byte[] frameBuffer, ref int frameIdx, ref int streamLength, byte[] streamBuffer, ref int idx, ref bool inPicture, ref byte previous, ref byte current)
        {
            do
            {
                previous = current;
                current = streamBuffer[idx++];
                frameBuffer[frameIdx++] = current;

            
                if (previous == picMarker && current == picEnd)
                {
                    Image img = null;

                    
                    using (var s = new MemoryStream(frameBuffer, 0, frameIdx))
                    {
                        try
                        {
                            img = Image.FromStream(s);
                        }
                        catch
                        {
                           
                        }
                    }

                   
                    Task.Run(() => action(img));
                    inPicture = false;
                    return;
                }
            } while (idx < streamLength);
        }
    }
}
