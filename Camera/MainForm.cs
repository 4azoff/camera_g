using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Camera
{
    public partial class MainForm : Form
    {
        SynchronizationContext sync;
        CancellationTokenSource tokenSource;
        bool isVideoPlaying = false;

        public MainForm()

        {
            InitializeComponent();
            sync = SynchronizationContext.Current;
            RefreshCameras();
        }


        void RefreshCameras()
        {
            lvCameras.Items.Clear();
            XmlDocument config = new XmlDocument();
            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile("http://demo.macroscop.com:8080/configex?login=root", "config");
                webClient.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            config.Load("config");
            foreach(XmlElement node in config.DocumentElement)
            {
                if(node.Name == "Channels")
                {
                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        string id = childNode.Attributes.GetNamedItem("Id").Value;
                        string name = childNode.Attributes.GetNamedItem("Name").Value;

                        Camera camera = new Camera(name, "http://demo.macroscop.com:8080/mobile?login=root&channelid=" + id +
                            "&resolutionX=640&resolutionY=480&fps=25", 1024);

                        ListViewItem item = new ListViewItem(camera.Name);
                        item.Tag = camera;
                        lvCameras.Items.Add(item);

                    }
                }
            }            
        }

        async Task startVideoAsync(PictureBox pb, Camera camera)
        {
            tokenSource = new CancellationTokenSource();
            using (tokenSource)
            {
                try
                {
                    await MJPEGPlayer.StartAsync(
                        image =>
                        {
                            sync.Post(new SendOrPostCallback(_ => pb.Image = image), null);
                        },
                        camera.Url,
                        tokenSource.Token,
                        camera.MaxStreamSize);
                }
                catch (OperationCanceledException ex)
                {
                    Console.WriteLine(ex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    //pbVideo.Image = null;
                }
            }
        }



        private void btStartWatch_Click(object sender, EventArgs e)
        {
            if (lvCameras.SelectedItems.Count == 0)
                MessageBox.Show("Выберите камеру");
            else
            {
                if (isVideoPlaying)
                {

                    tokenSource.Cancel();

                }
                startVideoAsync(pbVideo, (Camera)lvCameras.SelectedItems[0].Tag);
                isVideoPlaying = true;
            }
        }

        private void btRefreshCamers_Click(object sender, EventArgs e)
        {
            RefreshCameras();
        }
        

        private void btStopWatch_Click(object sender, EventArgs e)
        {
            if (isVideoPlaying)
            {
                tokenSource.Cancel();
                isVideoPlaying = false;
            }
        }
    }
}
