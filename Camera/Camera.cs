using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Camera
{
    class Camera 
    {

      

        public Camera(string name, string url, int maxBufferSize)
        {
            Name = name;
            Url = url;
            MaxStreamSize = maxBufferSize;
        }
        public string Name { get; set; }
        public string Url { get; set; }
        public int MaxStreamSize { get; set; }


        
    }
    
    
}
