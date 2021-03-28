using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using System.IO;
using RTCVision;
using System.Text.RegularExpressions;
using System.Threading;

namespace HQ
{
    public partial class frmSetting : Form
    {
        HDrawingObject Drawing_Ob;

        Thread _threadlive;

        HWindow WindowTrain;
        HImage _Imgtrain;
        int _width;
        int _height;
        int _exposuretime;
        int _gain;
        int _timeout; 
        HImage _Img;
        HTuple ModelID;
        HFramegrabber Framgraber;
        HImage Img;
        HTuple socketPLC;
        //string _interfacename;
        //string _device;
        double[] arr1;
        double[] arr2;
        double[] arr3;
        double X_ = 0;
        double Y_ = 0;
        double Theta_ = 0;
        string _pathProducerr = Application.StartupPath + "/HalconProcerduce";
        //HDevEngine _producer = new HDevEngine();
        public frmSetting()
        {
            InitializeComponent();
        }

        private List<string> getAvilableInterface()
        {
            List<string> avilabeInterface = new List<string>();

            string halconroot = Environment.GetEnvironmentVariable("HALCONROOT");
            string halconarch = Environment.GetEnvironmentVariable("HALCONARCH");
            string a = halconroot + "/bin/" + halconarch;

            var acquisitionInterface = Directory.EnumerateFiles(a, "hacq*.dll");
            foreach (var item in acquisitionInterface)
            {
                string interfacename = Regex.Match(item, "hAcq(.+)(?:\\.dll)").Groups[1].Value;
                HTuple device;
                try
                {
                    HInfo.InfoFramegrabber(interfacename, "info_boards", out device);

                    if (device.Length > 0)
                    {
                        avilabeInterface.Add(interfacename);
                    }
                }
                catch (Exception ex)
                {

                }

            }
            return avilabeInterface;
        }
        void CreateRegion(double x1, double y1,  double theta, double x2, double y2)
        {
            if (Drawing_Ob!=null)
            {
                Drawing_Ob.Dispose();
            }
            Drawing_Ob = HDrawingObject.CreateDrawingObject(HDrawingObject.HDrawingObjectType.RECTANGLE2, x1, y1, theta, x2, y2);
            Drawing_Ob.SetDrawingObjectParams("color", "green");
            Drawing_Ob.OnDrag(getposistion);
            WindowTrain.AttachDrawingObjectToWindow(Drawing_Ob);
            
        }
        
        private void getposistion(HDrawingObject img , HWindow hwin, string type)
        {
            HRegion region = new HRegion(img.GetDrawingObjectIconic());
            HOperatorSet.RegionFeatures(region , new HTuple(new string[] { "row", "column", "rect2_len1", "rect2_len2", "phi" }), out HTuple values);
            arr1 = values.ToDArr();
            
        }

        private void my_MouseWheel(object sender , MouseEventArgs e)
        {
            Point pt = WindowControl.Location;
            MouseEventArgs newe = new MouseEventArgs(e.Button, e.Clicks, e.X - pt.X, e.Y - pt.Y, e.Delta);
            WindowControl.HSmartWindowControl_MouseWheel(sender, newe);
        }
        private void WindowControl_Load(object sender, EventArgs e)
        {
            WindowTrain = WindowControl.HalconWindow;
            this.MouseWheel += my_MouseWheel;
        }

        private void btnCreatRegion_Click(object sender, EventArgs e)
        {
            CreateRegion(50, 50, 0, 50, 50);
        }

        private void btnLoadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "BMP File|*.bmp| JPG File|*.jpg|PNG File|*.png| All File|*.*";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                HOperatorSet.ReadImage(out HObject Imgtrain, openfile.FileName);
                _Imgtrain = new HImage(Imgtrain);
                _Imgtrain.GetImageSize( out _width,out  _height);
                WindowTrain.SetPart(0, 0, _height - 1, _width - 1);
                _Imgtrain.DispObj(WindowTrain);
            }
        }

        
        private void btnTrainModel_Click(object sender, EventArgs e)
        {

            HOperatorSet.GenRectangle2(out HObject Region, arr1[0], arr1[1], arr1[4], arr1[2], arr1[3]);
            HOperatorSet.ReduceDomain(_Imgtrain, Region, out HObject imgReduced);
            HOperatorSet.CreateShapeModel(imgReduced, "auto", -0.39, 0.79, "auto", "auto", "use_polarity", "auto", "auto", out HTuple ModelID);
            
            string pathModel = Application.StartupPath + "/Model";
            if (!Directory.Exists(pathModel))
            {
                Directory.CreateDirectory(pathModel);
            }
            HOperatorSet.WriteShapeModel(ModelID, string.Format(@"{0}/Model/{1}.shm",Application.StartupPath,"Model"));
            MessageBox.Show("Train Success!!");

        }

        private void btnTestTrain_Click(object sender, EventArgs e)
        {

            HOperatorSet.GenRectangle2(out HObject Region, arr1[0], arr1[1], arr1[4], arr1[2], arr1[3]);
            HOperatorSet.ReduceDomain(_Imgtrain, Region, out HObject imgReduced);
            HOperatorSet.CreateShapeModel(imgReduced, "auto", -0.39, 0.79, "auto", "auto", "use_polarity", "auto", "auto", out HTuple ModelID);
            HOperatorSet.FindShapeModel(_Imgtrain, ModelID, -0.39, 0.79, 0.5, 1, 0.5, "least_squares",new HTuple (4, 0), 0.9, out HTuple Row, out HTuple Column, out HTuple Angle, out HTuple Score);

            //HOperatorSet.CreateScaledShapeModel(imgReduced, 5, -0.39, 0.79, "auto", 0.8, 1.0, "auto", "none", "ignore_global_polarity", 40, 10, out HTuple ModelID);
            //HOperatorSet.FindScaledShapeModel(_Imgtrain, ModelID, -0.39, 0.79, 0.8, 1.0, 0.5, 0, 0.5, "least_squares", new HTuple (4,-2), 0.8, out HTuple Row, out HTuple Column, out HTuple Angle, out HTuple Scales, out HTuple Score);
            //HOperatorSet.HomMat2dIdentity(out HTuple HM2D);
            //HOperatorSet.HomMat2dTranslate(HM2D, Row[0], Column[0], out HTuple HM2DTranslate);
            //HOperatorSet.HomMat2dRotate(HM2DTranslate, Angle[0], Row[0], Column[0], out HTuple Homat2DRotary);
            //HOperatorSet.HomMat2dScale(Homat2DRotary, Scales[0], Scales[0], Row[0], Column[0], out HTuple HM2DALL);
            //HOperatorSet.GetShapeModelContours(out HObject ModelContour, ModelID, 1);
            HOperatorSet.VectorAngleToRigid(0, 0, 0, Row[0], Column[0], Angle[0], out HTuple homMat2DMaster);

            WindowTrain.SetColor("green");
            WindowTrain.SetDraw("margin");
            WindowTrain.SetLineWidth(3);
            HOperatorSet.GetShapeModelContours(out HObject ModelContour, ModelID, 1);
            HOperatorSet.AffineTransContourXld(ModelContour, out HObject ContourAffine, homMat2DMaster);
            WindowTrain.DispObj(ContourAffine);
            X_ = Row[0];
            Y_ = Column[0];
            Theta_ = Angle[0];

        }

        private void frmTrain_Load(object sender, EventArgs e)
        {
            //_producer.SetProcedurePath(_pathProducerr);
            loadPLCSetting();
            loadCamera();
            loadParameterCam();

        }

        void showtrain()
        {
            HOperatorSet.FindScaledShapeModel(_Imgtrain, ModelID, -0.39, 0.79, 0.8, 1.0, 0.5, 0, 0.5, "least_squares", new HTuple(4, -2), 0.8, out HTuple Row, out HTuple Column, out HTuple Angle, out HTuple Scales, out HTuple Score);
            HOperatorSet.HomMat2dIdentity(out HTuple HM2D);
            HOperatorSet.HomMat2dTranslate(HM2D, Row[0], Column[0], out HTuple HM2DTranslate);
            HOperatorSet.HomMat2dRotate(HM2DTranslate, Angle[0], Row[0], Column[0], out HTuple Homat2DRotary);
            HOperatorSet.HomMat2dScale(Homat2DRotary, Scales[0], Scales[0], Row[0], Column[0], out HTuple HM2DALL);
            HOperatorSet.GetShapeModelContours(out HObject ModelContour, ModelID, 1);
            HOperatorSet.AffineTransContourXld(ModelContour, out HObject ContourAffine, HM2DALL);
            WindowTrain.SetColor("green");
            WindowTrain.SetDraw("margin");
            WindowTrain.SetLineWidth(3);
            ContourAffine.DispObj(WindowTrain);
        }
        void saveCamera()
        {
            if (cbxInterface.SelectedItem == null)
            {
                MessageBox.Show("Please choose Dectect Interface before Save!!!");
                return;
            }
            if (cbxCamera.SelectedItem == null)
            {
                MessageBox.Show("Please choose Camera before Save!!!");
                return;
            }
            string _interfacename = cbxInterface.SelectedItem.ToString();
            string _devicename = cbxCamera.SelectedItem.ToString();

            DataTable dt = Lib.GetTableData(@"select * from InterfaceDevice");
            string datasave = "";
            if (dt.Rows.Count > 0)
            {
                datasave = string.Format(@"update InterfaceDevice set Interface = '{0}', Device = '{1}'", _interfacename, _devicename);
            }
            else
            {
                datasave = string.Format(@"insert into InterfaceDevice (Interface, Device) values ({0},{1})", _interfacename, _devicename);
            }

            Lib.ExecuteQuery(datasave);

            MessageBox.Show(" Save Successful!!!");
        }
        void savePLC()
        {
            if (txtIPAddress.Text == "")
            {
                MessageBox.Show("Please Enter IPAddress of PLC before click Save!!!");
                return;
            }
            if (txtPort.Text == "")
            {
                MessageBox.Show("Please Enter Port of PLC before click Save!!!");
                return;
            }
            string ip = txtIPAddress.Text.ToString();
            string port = txtPort.Text.ToString();

            DataTable dt = Lib.GetTableData(@"select * from PLCSetting");
            string datasave = "";
            if (dt.Rows.Count > 0)
            {
                datasave = string.Format(@"update PLCSetting set IPAddress = '{0}', Port = '{1}'", ip, port);
            }
            else
            {
                datasave = string.Format(@"insert into PLCSetting (IPAddress, Port) values ({0},{1})", ip, port);
            }

            Lib.ExecuteQuery(datasave);

        }
        void saveParameterCam()
        {
            if (txtExposuretime.Text == "")
            {
                MessageBox.Show("Please Enter Exposuretime before click Save!!!");
                return;
            }
            if (txtGain.Text == "")
            {
                MessageBox.Show("Please Enter Gain before click Save!!!");
                return;
            }
            if (txtTimeout.Text == "")
            {
                MessageBox.Show("Please Enter Timeout before click Save!!!");
                return;
            }
            string exposuretime = txtExposuretime.Text.ToString();
            string gain = txtGain.Text.ToString();
            string timeout = txtTimeout.Text.ToString();

            DataTable dt = Lib.GetTableData(@"select * from CamParameter");
            string datasave = "";
            if (dt.Rows.Count > 0)
            {
                datasave = string.Format(@"update CamParameter set Exposuretime = '{0}', Gain = '{1}', Timeout ='{2}'", exposuretime, gain, timeout);
            }
            else
            {
                datasave = string.Format(@"insert into CamParameter (Exposuretime, Gain, Timeout) values ({0}, {1})", exposuretime, gain, timeout);
            }

            Lib.ExecuteQuery(datasave);
            
        }
        void autoDetect()
        {
            cbxInterface.Items.Clear();
            List<string> interfacesname = getAvilableInterface();
            foreach (var item in interfacesname)
            {
                cbxInterface.Items.Add(item);
            }
            if (interfacesname.Count > 0)
            {
                cbxInterface.SelectedIndex = interfacesname.Count - 1;
            }
        }

        void connectCam(string _interfacename, string _device)
        {
            if (Framgraber != null)
            {
                Framgraber.Dispose();
            }
           
            Framgraber = new HFramegrabber(_interfacename, 0, 0, 0, 0, 0, 0, "progressive",
            -1, "default", -1, "default", _interfacename == "File" ? _device : "default", _interfacename == "File" ? "default" : _device, 0, -1);
            if (_interfacename == "GigE")
            {
                HOperatorSet.SetFramegrabberParam(Framgraber, "ExposureTime", 150000);
                HOperatorSet.SetFramegrabberParam(Framgraber, "Gain", 1);
                HOperatorSet.SetFramegrabberParam(Framgraber, "grab_timeout", 60000);
            }
            
            Img = Framgraber.GrabImageAsync(1);
            Img.GetImagePointer1(out HTuple typeImg, out HTuple WidthImg, out HTuple HeightImg);
            HTuple a = 0;
            WindowTrain.SetPart(a, a, HeightImg - 1, WidthImg - 1);
            Img.Dispose();
        }

        private void btnAutoDetect_Click(object sender, EventArgs e)
        {
            autoDetect();
        }
        private void btnCurrentConnect_Click(object sender, EventArgs e)
        {
            string _interfacename = cbxInterface.SelectedItem.ToString();
            string _device = cbxCamera.SelectedItem.ToString();
            try
            {
                if (btnCurrentConnect.Text.ToLower() == "test connect camera".ToLower())
                {
                    connectCam(_interfacename, _device);
                    btnCurrentConnect.BackColor = Color.Green;
                    btnCurrentConnect.Text = "Test Connect OK";
                    pnCurrentCam.Enabled = false;
                }
                else
                {
                    HOperatorSet.CloseFramegrabber(Framgraber);
                    btnCurrentConnect.BackColor = Color.Lavender;
                    btnCurrentConnect.Text = "Test Connect Camera";
                    pnCurrentCam.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Conect Error :" + ex);
            }
            
            
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
                cbxCamera.Items.Add(Application.StartupPath + "/images");// SUA LAI
            }
            else
            {
                cbxCamera.SelectedIndex = device.Length - 1;
            }
        }

        private void btnSaveCamera_Click(object sender, EventArgs e)
        {
            saveCamera();
            loadCamera();
        }

        int PortPLC = 0;
        string IpPlc = "";
        void connectPLC()
        {
            PortPLC = Lib.ToInt(txtPort.Text);
            IpPlc = txtIPAddress.Text.ToString();
            HOperatorSet.OpenSocketConnect(IpPlc, PortPLC, new HTuple("protocol", "timeout"), new HTuple("TCP4", 300.0), out socketPLC);
            
        }

        private void btnConnectPLC_Click(object sender, EventArgs e)
        {
            
            try
            {
                //if (btnConnectPLC.Text.ToLower() == "connection".ToLower())
                //{
                //    if (socketPLC!=null)
                //    {
                //        return;
                //    }
                //    connectPLC();
                //    btnConnectPLC.Text = "Connected PLC";
                //    btnConnectPLC.BackColor = Color.Green;
                //    MessageBox.Show(" Test Connect PLC Success!!","Note",MessageBoxButtons.OK,MessageBoxIcon.Information);
                //}
                //else
                //{
                //    btnConnectPLC.Text = "Connection";
                //    btnConnectPLC.BackColor = Color.Red;
                //    HOperatorSet.CloseSocket(socketPLC);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connect PLC Error!!","Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        void loadPLCSetting()
        {
            DataTable dt = Lib.GetTableData(@"select * from PLCSetting ");
            if (dt.Rows.Count>0)
            {
                txtIPAddress.Text = Lib.ToString(dt.Rows[0]["IPAddress"]);
                txtPort.Text = Lib.ToString(dt.Rows[0]["Port"]);
            }
        }
        void loadCamera()
        {
            DataTable dt = Lib.GetTableData(@"select * from InterfaceDevice ");
            if (dt.Rows.Count > 0)
            {
                txtInterface.Text = Lib.ToString(dt.Rows[0]["Interface"]);
                txtDevice.Text = Lib.ToString(dt.Rows[0]["Device"]);
            }
        }
        void loadParameterCam()
        {
            DataTable dt = Lib.GetTableData(@"select * from CamParameter ");
            string exposuretime ;
            string gain ;
            string timeout;


            if (dt.Rows.Count > 0)
            {
                exposuretime = Lib.ToString(dt.Rows[0]["Exposuretime"]); ;
                gain = Lib.ToString(dt.Rows[0]["Gain"]); ;
                timeout = Lib.ToString(dt.Rows[0]["Timeout"]);

                txtExposuretime.Text = exposuretime;
                txtGain.Text = gain;
                txtTimeout.Text = timeout;

                _exposuretime = Lib.ToInt(exposuretime);
                _gain = Lib.ToInt(gain);
                _timeout = Lib.ToInt(timeout);
            }
        }

        private void btnConnectRun_Click(object sender, EventArgs e)
        {
            string _interface = txtInterface.Text;
            string _device = txtDevice.Text;
            try
            {
                if (btnConnectRun.Text.ToLower() == "connection".ToLower())
                {
                    connectCam(_interface, _device);
                    btnConnectRun.BackColor = Color.Green;
                    btnConnectRun.Text = "Connected";
                    pnFindCam.Enabled = false;
                }
                else
                {
                    HOperatorSet.CloseFramegrabber(Framgraber);
                    btnConnectRun.Text = "Connection";
                    pnFindCam.Enabled = true;
                    btnConnectRun.BackColor = Color.Lavender;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Conect Error :" + ex);
            }

        }

        private void btnSavePLC_Click(object sender, EventArgs e)
        {
            savePLC();
            loadPLCSetting();
            MessageBox.Show("Save Success!!","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnSaveParametercam_Click(object sender, EventArgs e)
        {
            saveParameterCam();
            MessageBox.Show("  Save Success!!");
        }
       
        private void btnSnapsetting_Click(object sender, EventArgs e)
        {
            if (Framgraber==null)
            {
                MessageBox.Show("Please connect Camera before Snap.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            HOperatorSet.GrabImage(out HObject image, Framgraber);
            //SmartSetPart(image, WindowControl);
            _Imgtrain = new HImage(image);
            _Imgtrain.DispObj(WindowTrain);
            image.Dispose();
        }
        HImage ImgLive;
        void live()
        {
            if (Framgraber==null)
            {
                MessageBox.Show("Please connect Camera", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            while (true)
            {
                Thread.Sleep(200);
                try
                {
                    HOperatorSet.GrabImage(out HObject ImgLiv, Framgraber);
                    ImgLive = new HImage(ImgLiv);
                    ImgLive.DispObj(WindowTrain);
                }
                catch (Exception)
                {

                }
            }
        }
        private void btnLivesetting_Click(object sender, EventArgs e)
        {
            if (Framgraber == null)
            {
                MessageBox.Show("Please connect Camera before Snap.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (btnLivesetting.Text.ToLower()== "live")
            {
                _threadlive = new Thread(new ThreadStart(live));
                _threadlive.IsBackground = true;
                _threadlive.Start();
                btnLivesetting.Text = "Stop";

            }
            else
            {
                _threadlive.Abort();
                btnLivesetting.Text = "Live";
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControl1.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Red);
                g.FillRectangle(Brushes.LightGray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", 12.0f, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void btnshowModel_Click(object sender, EventArgs e)
        {
            showtrain();
        }

        private void frmSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            HOperatorSet.CloseSocket(socketPLC);
            HOperatorSet.CloseFramegrabber(Framgraber);
        }

        private void btnShowcontrol_Click(object sender, EventArgs e)
        {
           
        }

        private void btnHidecontrol_Click(object sender, EventArgs e)
        {
            usTCP _tcp = new usTCP();
            clsMainUsercontrol.hideControl(_tcp, content);
        }

        private void cbxTypeCommunication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTypeCommunication.SelectedItem.ToString() == "TCP/IP")
            {
                usTCP _tcp = new usTCP();
                clsMainUsercontrol.showControl(_tcp, content);
            }
            else
            {
                usSlmp _slmp = new usSlmp();
                clsMainUsercontrol.showControl(_slmp, content);
            }    
        }
    }
}
