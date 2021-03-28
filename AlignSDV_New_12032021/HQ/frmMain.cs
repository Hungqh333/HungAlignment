using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using RTCVision;
using System.IO;
namespace HQ
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        HFramegrabber Framgraber;
        HTuple pattern;
        HTuple socketPLC ;
        HTuple DataBit;
        HTuple DataBitTrigerHE;
        HTuple DataBitTrigerCaLib;
        Thread _threadLive ;
        HImage _Img;
        HWindow _window;
        HTuple ModelID;
        HTuple Campar;
        HTuple Cam_H_Base;
        bool dataerror = false;
        HDevEngine _procderduce = new HDevEngine();
        string path_Procerduce = Application.StartupPath + "/HalconProcerduce";
        bool _isRun = false;
        List<clsLogData> _lstLogData = new List<clsLogData>();

        private void snap()
        {

            if (Framgraber == null) return;
            try
            {
                _Img.Dispose();
            }
            catch
            {

            }
            //_Img = _frameGrabber.GrabImage();
            HOperatorSet.GrabImage(out HObject image, Framgraber);
            //SmartSetPart(image, WindowControl);
            _Img = new HImage(image);
            _Img.DispObj(_window);
            image.Dispose();
        }
        void runprogram()
        {
            HTuple DataBitHome;
            while (true)
            {
                try
                {
                    DataBitHome = clsPlc.GetBitFromPLC(9011, 0, socketPLC);

                    if (DataBitHome == 1)
                    {
                        snap();
                        clsPlc.SendDataFromPLC("Word", 0, 9010, socketPLC);
                        HOperatorSet.TupleRad(360, out HTuple Rad360);
                        //Map Image

                        //
                        HOperatorSet.FindShapeModel(_Img, ModelID, 0, Rad360, 0.5, 1, 0.5, "least_squares", new HTuple(4, -2), 0.9, out HTuple Row, out HTuple Col, out HTuple angle, out HTuple Score);
                        HOperatorSet.GenCrossContourXld(out HObject Cross, Row, Col, 200, 200);

                        
                        HOperatorSet.ImagePointsToWorldPlane(Campar, Cam_H_Base, Row, Col, "m", out HTuple X, out HTuple Y);
                        string x = Lib.ToString(X - 0.007);
                        string y = Lib.ToString(Y);
                        double _yyy = Math.Round(Lib.ToDouble(x) * 1000);
                        double _xxx = Math.Round(Lib.ToDouble(y) * 1000);
                       

                        clsPlc.SendDataFromPLC("Word", Lib.ToInt(_yyy), 9002, socketPLC);
                        clsPlc.SendDataFromPLC("Word", Lib.ToInt(_xxx), 9000, socketPLC);
                        clsPlc.SendDataFromPLC("Word", 1, 9021, socketPLC);
                        _window.DispObj(_Img);
                        _window.DispObj(Cross);
                    }
                    else
                    {

                        clsPlc.SendDataFromPLC("Word", 1, 9010, socketPLC);
                        Thread.Sleep(1000);
                        clsPlc.SendDataFromPLC("Word", 0, 9010, socketPLC);
                        Thread.Sleep(1000);
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }

                Thread.Sleep(1000);
            }
            
        }
        void getdataLog()
        {
            while (true)
            {
                Thread.Sleep(2000);
                _lstLogData.Clear();
                string fileLoad = string.Format(Application.StartupPath + @"\Datalog\{0}.txt", DateTime.Now.ToString("yyyy-MM-dd"));
                if (!File.Exists(fileLoad)) continue;
                string[] arrdata = File.ReadAllLines(fileLoad);
                for (int i = 0; i < arrdata.Length; i++)
                {
                    clsLogData log = new clsLogData();
                    string textforline = arrdata[i];
                    if (string.IsNullOrEmpty(textforline)) continue;
                    string[] data = textforline.Split(';');

                    log.No = Lib.ToInt(data[0]);
                    log.CellID = data[1];
                    log.Datenow = data[2];
                    log.X = Lib.ToDouble( data[3]);
                    log.Y = Lib.ToDouble( data[4]);
                    log.Theta = Lib.ToDouble(data[5]);
                    log.Result = data[6];
                    _lstLogData.Add(log);
                }
                int countAll = _lstLogData.Count;
                int countNG = _lstLogData.Count(o => o.Result == "NG");
                int countOK = countAll - countNG;

                this.Invoke((MethodInvoker)delegate
                {

                    grvDatacurrent.DataSource = null;
                    grvDatacurrent.AutoGenerateColumns = true;
                    grvDatacurrent.DataSource = _lstLogData.OrderByDescending(o => o.No).Take(28).ToList();
                    foreach (DataGridViewRow item in grvDatacurrent.Rows)
                    {
                        if (item.Cells[3].FormattedValue.ToString() == "NG")
                        {
                            item.DefaultCellStyle.BackColor = Color.Red;
                        }
                    }

                    txtTotal.Text = countAll.ToString();
                    txtTotalNG.Text = countNG.ToString();
                    txtTotalOK.Text = countOK.ToString();
                    //.OrderByDescending(o => Lib.ToInt(o.count)).Take(20).ToList();
                });
            }

        }
        private void btnRun_Click(object sender, EventArgs e)
        {

            if (socketPLC == null)
            {
                MessageBox.Show("Please connect to the PLC before Run program.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Framgraber == null)
            {
                MessageBox.Show("Please connect to the CAM before Run program.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_isRun)
            {
                _isRun = true;
                _threadLive = new Thread(new ThreadStart(runprogram));
                _threadLive.IsBackground = true;
                _threadLive.Start();
                btnRun.Image = Image.FromFile(Application.StartupPath + "/Icon/stop_24px.png");
                //btnRun.BackColor = Color.Red;
                //btnConnect.Enabled = false;
                //btnRun.Text = "STOP";
            }
            else
            {
                _isRun = false;
                Thread.Sleep(1000);
                if (_threadLive != null) _threadLive.Abort();
                btnRun.Image = Image.FromFile(Application.StartupPath + "/Icon/play_24px.png");
                //btnRun.BackColor = Color.Green;
                // btnConnect.Enabled = true;
                //btnRun.Text = "RUN";
            }
        }
        string IpPlc ;
        int PortPLC;
        string _interfacename ;
        string _device ;
        void loadPLCSetting()
        {
            DataTable dt = Lib.GetTableData(@"select * from PLCSetting ");
            if (dt.Rows.Count > 0)
            {
                IpPlc = Lib.ToString(dt.Rows[0]["IPAddress"]);
                PortPLC = Lib.ToInt(dt.Rows[0]["Port"]);
            }
        }

        void loadCamera()
        {
            DataTable dt = Lib.GetTableData(@"select * from InterfaceDevice ");
            if (dt.Rows.Count > 0)
            {
                _interfacename = Lib.ToString(dt.Rows[0]["Interface"]);
                _device = Lib.ToString(dt.Rows[0]["Device"]);
            }
        }
        void loadpattern()
        {
            string path = string.Format(@"{0}/Model/{1}.shm", Application.StartupPath, "Model");
            HOperatorSet.ReadShapeModel(path, out pattern);
        }
        void loaddataAling()
        {

            //LOAD Data Align
            
            
            //End

            //LOAD MODEL TRAIN
            HOperatorSet.ReadShapeModel(string.Format(@"{0}/Model/{1}.shm", Application.StartupPath, "Model"),out ModelID);
            //End


        }
        void connectPLC()
        {
            try
            {
                HOperatorSet.OpenSocketConnect(IpPlc, PortPLC, new HTuple("protocol", "timeout"), new HTuple("TCP4", 300.0), out socketPLC);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Connnection PLC Error: "+ ex,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                dataerror = true;
            }
        }

        void connectCam(string _interfacename, string _device)
        {
            if (Framgraber != null)
            {
                Framgraber.Dispose();
            }
            try
            {
                Framgraber = new HFramegrabber(_interfacename, 0, 0, 0, 0, 0, 0, "progressive",
            -1, "default", -1, "default", _interfacename == "File" ? _device : "default", _interfacename == "File" ? "default" : _device, 0, -1);
                if (_interfacename == "GigE")
                {
                    HOperatorSet.SetFramegrabberParam(Framgraber, "ExposureTime", 150000);
                    HOperatorSet.SetFramegrabberParam(Framgraber, "Gain", 1);
                    HOperatorSet.SetFramegrabberParam(Framgraber, "grab_timeout", 60000);
                }
                _Img = Framgraber.GrabImageAsync(1);
                _Img.GetImagePointer1(out HTuple typeImg, out HTuple WidthImg, out HTuple HeightImg);
                HTuple a = 0;
                _window.SetPart(a, a, HeightImg - 1, WidthImg - 1);
                _Img.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Connnection Camera Error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataerror = true;
            }

        }
        void saveDatalog(clsLogData data)
        {
            string fileSaveDataLog_check = string.Format(Application.StartupPath + @"\Datalog");
            string fileSaveDataLog = string.Format(Application.StartupPath + @"\Datalog\{0}.txt", DateTime.Now.ToString("yyyy-MM-dd"));
            if (!File.Exists(fileSaveDataLog_check) && data.CellID != "")
            {
                string value = $"{_lstLogData.Count + 1};{data.CellID };{data.Datenow};{data.X};{data.Y};{data.Theta};{data.Result}";
                File.AppendAllText(fileSaveDataLog, Environment.NewLine + value);
            };
            _lstLogData.Add(data);
        }
        
        private void btnConnect_Click(object sender, EventArgs e)
        {
            dataerror = false;
            if (btnConnect.Text.ToLower() == "connect")
            {
                try
                {
                    connectCam(_interfacename, _device);
                    connectPLC();

                    if (Framgraber == null ||socketPLC ==null)
                    {
                        MessageBox.Show("Error Connect ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if(dataerror == false)
                    {
                        btnConnect.BackColor = Color.Green;
                        btnConnect.Text = "CONNECTED";
                    }    
                    
                }
                catch (Exception ex)
                {
                    
                }
            }
            else
            {
                btnConnect.BackColor = Color.Red;
                btnConnect.Text = "CONNECT";
                try
                {
                    HOperatorSet.CloseFramegrabber(Framgraber);
                    HOperatorSet.CloseSocket(socketPLC);
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            loadPLCSetting();
            loadCamera();
            loadpattern();
            loaddataAling();
            //Load Producer
            _procderduce.SetProcedurePath(path_Procerduce);
        }

        private void btnfrmhandeyecalib_Click(object sender, EventArgs e)
        {
            frmHandeyeCalib _hecalib = new frmHandeyeCalib();
            _hecalib.ShowDialog();
        }

        private void btnfrmSetting_Click(object sender, EventArgs e)
        {
            frmSetting _setting = new frmSetting();
            _setting.ShowDialog();
        }

        private void my_MouseWheel(object sender, MouseEventArgs e)
        {
            Point pt = _WindowControl.Location;
            MouseEventArgs newe = new MouseEventArgs(e.Button, e.Clicks, e.X - pt.X, e.Y - pt.Y, e.Delta);
            _WindowControl.HSmartWindowControl_MouseWheel(sender, newe);
        }
        private void _WindowControl_Load(object sender, EventArgs e)
        {
            _window = _WindowControl.HalconWindow;
            this.MouseWheel += my_MouseWheel;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("Do you want to close this form?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (re == DialogResult.No)
            {
                return;
            }
            this.Close();
        }

        private void btnRunTest_Click(object sender, EventArgs e)
        {
            if (socketPLC == null)
            {
                MessageBox.Show("Please connect to the PLC before Run program.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Framgraber == null)
            {
                MessageBox.Show("Please connect to the CAM before Run program.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            HTuple DataBitHome;
            try
            {
                DataBitHome = clsPlc.GetBitFromPLC(9011, 0, socketPLC);

                if (DataBitHome == 1)
                {
                    //snap();

                    HOperatorSet.GrabImage(out HObject image, Framgraber);
                    image.DispObj(_window);
                    _Img = new HImage(image);
                    //window.DispObj(Img);
                    clsPlc.SendDataFromPLC("Word", 0, 9010, socketPLC);
                    HOperatorSet.TupleRad(360, out HTuple Rad360);
                    HOperatorSet.FindShapeModel(_Img, ModelID, 0, Rad360, 0.5, 1, 0.5, "least_squares", new HTuple(4, -2), 0.9, out HTuple Row, out HTuple Col, out HTuple angle, out HTuple Score);
                    HOperatorSet.GenCrossContourXld(out HObject Cross, Row, Col, 200, 200);

                    HOperatorSet.ReadCamPar(Application.StartupPath + "/calibration/" + "CamPar.dat", out HTuple Campar);
                    HOperatorSet.ReadPose(Application.StartupPath + "/calibration/" + "base_in_cam_pose.dat", out HTuple Cam_H_Base);
                    HOperatorSet.ImagePointsToWorldPlane(Campar, Cam_H_Base, Row, Col, "m", out HTuple X, out HTuple Y);

                    _window.DispObj(Cross);
                    string x = Lib.ToString(X);
                    string y = Lib.ToString(Y);
                    double _yyy = Math.Round(Lib.ToDouble(x) * 1000);
                    double _xxx = Math.Round(Lib.ToDouble(y) * 1000);
                    

                    clsPlc.SendDataFromPLC("Word", Lib.ToInt(_yyy), 9002, socketPLC);
                    clsPlc.SendDataFromPLC("Word", Lib.ToInt(_xxx), 9000, socketPLC);
                    clsPlc.SendDataFromPLC("Word", 1, 9021, socketPLC);

                }
                else
                {

                    clsPlc.SendDataFromPLC("Word", 1, 9010, socketPLC);
                    Thread.Sleep(1000);
                    clsPlc.SendDataFromPLC("Word", 0, 9010, socketPLC);
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTiemcurrent.Text = string.Format(DateTime.Now.ToString("dddd , MMM dd yyyy, HH:mm:ss"));
        }

        private void btnLogData_Click(object sender, EventArgs e)
        {
            frmLogData _showlog = new frmLogData();
            _showlog.ShowDialog();
        }

        List<clsPoseRobot> _lstpose = new List<clsPoseRobot>();

       
    }
}
