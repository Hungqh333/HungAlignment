using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace ConnecterTest
{
    public partial class FormTest : Form
    {
        HTuple _plcSocket;
        string hostName = "192.168.3.39";
        HTuple port = 3000;
        Thread _threadAuto ;
        bool static_recdata = false;
        bool static_senddata = false;
        string procerducePath = @"E:\Vision\HalconProcerduce";
        HDevEngine _producerEngin = new HDevEngine();
        string getdataBarcode;
        HFramegrabber Framgraber;
        private HWindow window;
        HImage Img;
        HObject _Img;
        
        public FormTest()
        {
            InitializeComponent();
        }

        // lay ve Interface theo list
        private List<string> getAvailableInterfaces()
        {
            // Detect the HALCON binary folder
            List<string> availableInterfaces = new List<string>();
            string halconRoot = Environment.GetEnvironmentVariable("HALCONROOT");
            string halconArch = Environment.GetEnvironmentVariable("HALCONARCH");


            string a = halconRoot + "/bin/" + halconArch;

            // Querry all available interfaces
            var acquisitionInterfaces = Directory.EnumerateFiles(a, "hacq*.dll");

            // For each Interface (check for non XL version) we test with InfoFramegrabber if devices are connected
            foreach (string item in acquisitionInterfaces)
            {
                // Extract the interface name with an regular expression
                string interfaceName = Regex.Match(item, "hAcq(.+)(?:\\.dll)").Groups[1].Value;

                // only check non XL interfaces
                if (!interfaceName.EndsWith("xl"))
                {
                    try
                    {
                        // Querry available devices
                        HTuple devices;
                        HInfo.InfoFramegrabber(interfaceName, "info_boards", out devices);
                        // In case that devices were found add it to the available interfaces
                        if (devices.Length > 0)
                        {
                            availableInterfaces.Add(interfaceName);
                        }
                    }
                    catch (Exception ex)
                    { }
                }
            }

            return availableInterfaces;
        }




        private void btnConnection_Click(object sender, EventArgs e)
        {
            connectionPLC();
        }

        void connectionPLC()
        {
            HOperatorSet.OpenSocketConnect(hostName, port, new HTuple("protocol","timeout"), new HTuple("TCP4", 300.0), out _plcSocket);
            btnConnection.Text = "Connected";
            MessageBox.Show("Connection Success!!");
        }

        private void btnDisconnection_Click(object sender, EventArgs e)
        {
            HOperatorSet.CloseSocket(_plcSocket);
            btnConnection.Text = "Connection";
        }

        void conectioncCamera()
        {

        }


        HTuple databit = new HTuple();
        HTuple dataWord = new HTuple();
        HTuple dataWord_Send = new HTuple();
        string dataType = "String";
        HTuple device_getWord = 4000;
        HTuple device_getBit = 2000;
        async void getDataLive()
        {
            while(true)
            {
                try
                {
                    string a;
                    HTuple b = 1000;
                    
                    // get data from PLC
                    if (btnConnection.Text == "Connected")
                    {
                        
                        dataWord = clsPlc.RecDataFromPLC(dataType, device_getWord, 10, _plcSocket);
                        databit = clsPlc.GetBitFromPLC(device_getBit, 1, _plcSocket);
                        //getdataBarcode = clsPlc.RecDataFromPLC("String", 3000, 10, _plcSocket);
                        this.Invoke((MethodInvoker)delegate
                        {
                            
                            txtRecdataBit.Text = databit.ToString();
                            txtRecdataWord.Text = dataWord.ToString();
                        });
                        b = Lib.ToDouble(nbrDataSend.Value);
                    }

                    HTuple bb = Lib.ToDouble( nbrDataSend.Value);
                    // rec data to PLC
                    if (btnConnection.Text == "Connected")
                    {

                        clsPlc.SendDataFromPLC("Word", bb, 4000, _plcSocket);
                        
                    }
                    if (databit ==1)
                    {
                        Img.Dispose();
                        Img = Framgraber.GrabImage();
                        Img.DispObj(window);
                    }
                    if (static_senddata == true)
                    {
                        clsPlc.SetBitFromPLC(3000, 1, 1, _plcSocket);
                        clsPlc.SetBitFromPLC(3000, 0, 1, _plcSocket);
                    }

                }
                catch (Exception ex)
                {

                    
                }
            }
        }
        
        private void FormTest_Load(object sender, EventArgs e)
        {
            _threadAuto = new Thread(new ThreadStart(getDataLive));
            _threadAuto.IsBackground = true;
            _threadAuto.Start();

            _producerEngin.SetProcedurePath(procerducePath);

        }
        
        private void btnReceiveData_Click(object sender, EventArgs e)
        {
            static_recdata = true;
        }

        private void btnSendData_Click(object sender, EventArgs e)
        {
            static_senddata = true;
            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            static_recdata = false;
            static_senddata = false;
           
           


        }
        string _interfacename;
        string _device;
        private void btnConectaCam_Click(object sender, EventArgs e)
        {
            if (Framgraber != null)
            {
                Framgraber.Dispose();
            }
            _interfacename = cbxInterface.SelectedItem.ToString();
            _device = cbxCamera.SelectedItem.ToString();
            Framgraber = new HFramegrabber(_interfacename, 0, 0, 0, 0, 0, 0, "progressive",
                -1, "default", -1, "default", _interfacename == "File" ? _device : "default", _interfacename == "File" ? "default" : _device, 0, -1);


            //Framgraber = new HFramegrabber(_interfacename, 0, 0, 0, 0, 0, 0, "progressive", -1, "default", -1, "default",
            //   _interfacename == "file" ? "default" : _device, _interfacename == "file" ? _device : "default", 0, -1);

            Img = Framgraber.GrabImageAsync(1);
            Img.GetImagePointer1(out HTuple typeImg, out HTuple WidthImg, out HTuple HeightImg);
            HTuple a = 0;
            //Window.SetPart(a , a, WidthImg - 1, HeightImg - 1);
            window.SetPart(a, a, WidthImg - 1, HeightImg - 1);
            Img.Dispose();

        }

        private void cbxInterface_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxCamera.Items.Clear();
            string interfacename = cbxInterface.SelectedItem.ToString();
            HTuple device;
            HInfo.InfoFramegrabber(interfacename, "device", out device);

            for (int i = 0; i < device.Length; i++)
            {
                cbxCamera.Items.Add(device[i].S);
            }
            if (cbxCamera.Items.Count == 0)
            {
                cbxCamera.Items.Add(Application.StartupPath + "/images/barcode/code128");
            }
            else
            {
                cbxCamera.SelectedIndex = device.Length - 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbxInterface.Items.Clear();
            List<string> interfacesname = getAvailableInterfaces();
            foreach (var item in interfacesname)
            {
                cbxInterface.Items.Add(item);
            }
            if (interfacesname.Count > 0)
            {
                cbxInterface.SelectedIndex = interfacesname.Count - 1;
            }
        }

        private void WindowControl_Load(object sender, EventArgs e)
        {
            window = WindowControl.HalconWindow;
        }

        private void btnDisConectCam_Click(object sender, EventArgs e)
        {
            HOperatorSet.CloseFramegrabber(Framgraber);
        }
    }
}
