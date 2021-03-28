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
using RTCVision;
using System.Linq;
using System.Threading.Tasks;

namespace HQ
{
    public partial class frmHandeyeCalib : Form
    {
        private HImage Img;
        private HFramegrabber Framgraber;
        private HWindow window;
        HTuple arr1;
        HDrawingObject Drawing_Ob;
        Thread LiveThread;
        //HImage _img;
        HImage ImgLive;
        HImage ImgRun;
        HTuple ModelID;

        //Region find origin
        HObject rg_binary = new HObject();
        HObject rg_first = new HObject();
        HObject rg_second = new HObject();
        
        HDevEngine _procderduce = new HDevEngine();
        string path_Procerduce = Application.StartupPath + "/HalconProcerduce";
        HTuple socketPLC = new HTuple();
        Thread _threadLive;
        Thread _threadTT;
        bool _isRun = false;
        bool _status_connect_cam = false;
        bool _status_connect_plc = false;
        int _useOrigin = 0;
        string _interfacename = "";
        string _device = "";
        public frmHandeyeCalib()
        {
            InitializeComponent();
        }
        // Out Data Align
        HTuple X_TCP_Out;
        HTuple Y_TCP_Out;
        HTuple X_T_Out;
        HTuple Y_T_Out;





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

        private void btnSnap_Click(object sender, EventArgs e)
        {
            if (Img != null)
            {
                Img.Dispose();
            }
            if (true)
            {

            }
            try
            {
                Img = Framgraber.GrabImage();
                Img.DispObj(window);
            }
            catch (Exception)
            {

            }

        }

        void connectCam(string _interfacename, string _device)
        {
            _status_connect_cam = false;
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
            _status_connect_plc = true;

            Img = Framgraber.GrabImageAsync(1);
            Img.GetImagePointer1(out HTuple typeImg, out HTuple WidthImg, out HTuple HeightImg);
            HTuple a = 0;
            window.SetPart(a, a, HeightImg - 1, WidthImg - 1);
            Img.Dispose();

        }
        private void btnConnection_Click(object sender, EventArgs e)
        {
            if (Framgraber != null)
            {
                Framgraber.Dispose();
            }

            if (btnConnection.Text.ToLower() == "CONECT CAMERA".ToLower())
            {
                try
                {
                    connectCam(_interfacename, _device);
                    btnConnection.Text = "DISCONNECT CAMERA";
                    btnlightcam.BackColor = Color.Green;
                    btnSnap.Enabled = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Connect Camera Error!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            else
            {
                btnlightcam.BackColor = Color.Red;
                btnConnection.Text = "CONECT CAMERA";
                HOperatorSet.CloseFramegrabber(Framgraber);
                btnSnap.Enabled = false;
            }

        }

        private void WindowControl_Load(object sender, EventArgs e)
        {
            window = WindowControl.HalconWindow;
            this.MouseWheel += my_mouseWheel;

        }
        void my_mouseWheel(object sender, MouseEventArgs e)
        {
            Point pt = WindowControl.Location;
            MouseEventArgs newe = new MouseEventArgs(e.Button, e.Clicks, e.X - pt.X, e.Y - pt.Y, e.Delta);
            WindowControl.HSmartWindowControl_MouseWheel(sender, e);
        }
        void LoadModelID()
        {
            try
            {
                HOperatorSet.ReadShapeModel(string.Format(@"{0}/Model/{1}.shm", Application.StartupPath, "ModelHandeye"), out ModelID);
            }
            catch (Exception ex)
            {


            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadModelID();
            loadMastertrain();
            loadPLCSetting();
            loadCamera();
            _procderduce.SetProcedurePath(path_Procerduce);
            LoadModel();
            //connectCam(_interfacename, _device);
            //connectPLC();
            //// Status Light
            //if (_status_connect_cam)
            //{
            //    btnlightcam.BackColor = Color.Green;
            //}
            //else
            //{
            //    btnlightcam.BackColor = Color.Green;
            //}
            //if (_status_connect_plc)
            //{
            //    btnlightPLC.BackColor = Color.Green;
            //}
            //else
            //{
            //    btnlightPLC.BackColor = Color.Green;
            //}
            connectPLC();
            ////Thread get bit TT
            _threadTT = new Thread(new ThreadStart(rungetbitfromplc));
            _threadTT.IsBackground = true;
            _threadTT.Start();
        }

        private void btnLive_Click(object sender, EventArgs e)
        {
            LiveThread = new Thread(new ThreadStart(live));
            LiveThread.IsBackground = true;
            LiveThread.Start();
        }
        bool click = false;
        void live()
        {
            while (true)
            {
                //HOperatorSet.SetFramegrabberParam(Framgraber, "ExposureTime", 2700);
                //HOperatorSet.SetFramegrabberParam(Framgraber, "Gain", 1);
                try
                {
                    HOperatorSet.GrabImageAsync(out HObject ImgLiv, Framgraber, 1);
                    ImgLive = new HImage(ImgLiv);
                    ImgLive.DispObj(window);
                }
                catch (Exception)
                {

                }

                if (click)
                {
                    break;
                }
            }

        }

        private void btnStoplive_Click(object sender, EventArgs e)
        {
            click = true;
            Thread.Sleep(100);
            LiveThread.Abort();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            HOperatorSet.CloseFramegrabber(Framgraber);
        }
        void RunProgramOCR(HImage img)
        {
            LoadModelID();
            string pathModel = Application.StartupPath + "/Model/";
            if (!Directory.Exists(pathModel))
            {
                Directory.CreateDirectory(pathModel);
            }
            HOperatorSet.CreateTextModelReader("auto", "Universal_0-9_NoRej", out HTuple textModel);
            HOperatorSet.SetTextModelParam(textModel, "min_stroke_width", 6);
            HOperatorSet.SetTextModelParam(textModel, "text_line_structure", "2 2 2");
            HOperatorSet.FindText(img, textModel, out HTuple textResult);
            HOperatorSet.GetTextObject(out HObject Charater, textResult, "all_lines");
            HOperatorSet.GetTextResult(textResult, "class", out HTuple Classes);
            string[] arrtext = Classes.ToSArr();
            string text = "";
            for (int i = 0; i < Classes.Length; i++)
            {
                text = text + arrtext[i].ToString();
            }

        }

        private void btnLoadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "BMP File|*.bmp| JPG File|*.jpg| PNG File|*.png| ALL File|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                HOperatorSet.ReadImage(out HObject img, open.FileName);
                Img = new HImage(img);
                Img.DispObj(window);
                Img.GetImagePointer1(out HTuple type, out HTuple width, out HTuple heigh);
                window.SetPart(new HTuple(0), new HTuple(0), heigh, width);
                //RunProgram(_img);
            }

        }

        private void btnTrainCam_Click(object sender, EventArgs e)
        {
            frmSetting _frmtrain = new frmSetting();
            _frmtrain.ShowDialog();
        }

        private void btnRunmannual_Click(object sender, EventArgs e)
        {
            HOperatorSet.FindScaledShapeModel(Img, ModelID, -0.39, 0.79, 0.8, 1.0, 0.5, 0, 0.5, "least_squares", 5, 0.8, out HTuple Row, out HTuple Column, out HTuple Angle, out HTuple Scales, out HTuple Score);
            HOperatorSet.HomMat2dIdentity(out HTuple HM2D);
            HOperatorSet.HomMat2dTranslate(HM2D, Row[0], Column[0], out HTuple HM2DTranslate);
            HOperatorSet.HomMat2dRotate(HM2DTranslate, Angle[0], Row[0], Column[0], out HTuple Homat2DRotary);
            HOperatorSet.HomMat2dScale(Homat2DRotary, Scales[0], Scales[0], Row[0], Column[0], out HTuple HM2DALL);
            HOperatorSet.GetShapeModelContours(out HObject ModelContour, ModelID, 1);
            HOperatorSet.AffineTransContourXld(ModelContour, out HObject ContourAffine, HM2DALL);
            window.SetColor("green");
            window.SetDraw("margin");
            window.SetLineWidth(3);
            ContourAffine.DispObj(window);
            //ModelContour.DispObj(window);


            //DataTable dt = Lib.GetTableData(string.Format("select * from TrainModel where Roi = '{0}'", "Roi3"));
            //double _X = Lib.ToDouble(dt.Rows[0]["X"]);
            //double _Y = Lib.ToDouble(dt.Rows[0]["Y"]);
            //double _L1 = Lib.ToDouble(dt.Rows[0]["L1"]);
            //double _L2 = Lib.ToDouble(dt.Rows[0]["L2"]);
            //double _Theta = Lib.ToDouble(dt.Rows[0]["Theta"]);

            datatrain dtRec = lstDataTrain.FirstOrDefault(o => o.Roi == "Roi3");
            double _X = dtRec.X;
            double _Y = dtRec.Y;
            double _L1 = dtRec.L1;
            double _L2 = dtRec.L2;
            double _Theta = dtRec.Theta;



            datatrain dttMaster = lstDataTrain.FirstOrDefault(o => o.Roi == "Master");
            double _XMaster = dttMaster.X;
            double _YMaster = dttMaster.Y;
            double _L1Master = dttMaster.L1;
            double _L2Master = dttMaster.L2;
            double _ThetaMaster = dttMaster.Theta;


            HOperatorSet.GenRectangle2(out HObject RoiCheck, _X, _Y, _Theta, _L1, _L2);

            //HOperatorSet.AffineTransRegion(RoiCheck, out HObject RoicheckAffine, HM2DALL, "nearest_neighbor");
            //HOperatorSet.HomMat2dIdentity(out HTuple Homat2D);
            //HOperatorSet.HomMat2dTranslate(Homat2D, -_X, -_Y, out HTuple Homat2DTrans);
            //HOperatorSet.AffineTransRegion(RoicheckAffine, out HObject RoicheckFinal, Homat2DTrans, "nearest_neighbor");
            //RoicheckFinal.DispObj(window);


            HOperatorSet.VectorAngleToRigid(_XMaster, _YMaster, _ThetaMaster, Row[0], Column[0], Angle[0], out HTuple HM2DMaster);
            HOperatorSet.AffineTransRegion(RoiCheck, out HObject RoiCheckTrans, HM2DMaster, "nearest_neighbor");
            RoiCheck.DispObj(window);
            RoiCheckTrans.DispObj(window);
        }

        string IpPlc;
        int PortPLC;
        ///// Load Data
        void loadPLCSetting()
        {
            DataTable dt = Lib.GetTableData(@"select * from PLCSetting ");
            if (dt.Rows.Count > 0)
            {
                IpPlc = Lib.ToString(dt.Rows[0]["IPAddress"]);
                PortPLC = Lib.ToInt(dt.Rows[0]["Port"]);
                txtplc.Text = IpPlc + " | " + PortPLC.ToString();
            }
        }
        void loadCamera()
        {
            DataTable dt = Lib.GetTableData(@"select * from InterfaceDevice ");
            if (dt.Rows.Count > 0)
            {
                _interfacename = Lib.ToString(dt.Rows[0]["Interface"]);
                _device = Lib.ToString(dt.Rows[0]["Device"]);
                txtcam.Text = _interfacename + " | " + _device;
            }
        }
        void load_region_findOrigin()
        {
            try
            {
                HOperatorSet.ReadRegion(out rg_binary, Application.StartupPath + "/regionOrigin/rg_binary");
                HOperatorSet.ReadRegion(out rg_first, Application.StartupPath + "/regionOrigin/rg_first");
                HOperatorSet.ReadRegion(out rg_second   , Application.StartupPath + "/regionOrigin/rg_second");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load region error : " + ex.ToString(),"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void snap()
        {

            if (Framgraber == null) return;
            try
            {
                Img.Dispose();
            }
            catch
            {

            }
            //_Img = _frameGrabber.GrabImage();
            HOperatorSet.GrabImage(out HObject image, Framgraber);
            //SmartSetPart(image, WindowControl);
            Img = new HImage(image);
            Img.GetImagePointer1(out HTuple type, out HTuple width, out HTuple heigh);
            WindowControl.HalconWindow.SetPart(new HTuple(0), new HTuple(0), heigh, width);
            Img.DispObj(window);
            image.Dispose();
        }
        void connectPLC()
        {
            _status_connect_plc = false;
            try
            {
                HOperatorSet.OpenSocketConnect(IpPlc, PortPLC, new HTuple("protocol", "timeout"), new HTuple("TCP4", 300.0), out socketPLC);
                _status_connect_plc = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Connnection PLC ERROR !!");
            }
        }

        HTuple DataBit;
        HTuple DataBitTrigerHE;
        HTuple DataBitTrigerCaLib;

        async void runcode()
        {
            if (Framgraber == null)
            {
                MessageBox.Show("  CAMERA DISCONNECTION !!");
                return;
            }
            if (socketPLC == null)
            {
                MessageBox.Show("  PLC DISCONNECTION  !!");
                return;
            }
            double Z = 100;
            int _break = 0;

            while (true)
            {

                try
                {
                    int countPointHE = 0;

                    DataBit = clsPlc.GetBitFromPLC(3000, 1, socketPLC);         // Snap
                    DataBitTrigerHE = clsPlc.GetBitFromPLC(4000, 1, socketPLC); // HEB
                    DataBitTrigerCaLib = clsPlc.GetBitFromPLC(5000, 1, socketPLC);

                    Task task1;
                    task1 = Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            //HOperatorSet.GrabImage(out HObject image1, _frameGrabber);

                        }
                        catch (Exception ex)
                        {

                        }
                    });
                    //CALIB
                    // if (DataBitTrigerCaLib == 1)
                    if (DataBitTrigerCaLib == 1)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            btnCalibBit.BackColor = Color.Green;
                        });

                        // Khoi tao Model Calibration cua Halcon
                        HTuple CalibDataID = clsCalib.InitCalib("area_scan_division", "calibration_object", 0.008, 0, 1.85 / 1000000, 1.85 / 1000000, 4024 / 2, 3036 / 2, 4024, 3036, Application.StartupPath + "/calib/" + "caltab_30mm.descr");
                        int countpointCalib = 0;
                        while (true)
                        {
                            DataBit = clsPlc.GetBitFromPLC(3000, 1, socketPLC);

                            if (DataBit == 1)
                            {
                                snap();
                                HOperatorSet.WriteImage(Img, "bmp", 0, Application.StartupPath + "/hand_eye/" + "image_calib_" + countpointCalib);
                                clsPlc.SendDataFromPLC("Word", 2, 4005, socketPLC);
                                Thread.Sleep(100);
                                clsPlc.SendDataFromPLC("Word", 2, 4002, socketPLC); // Send Data OK
                                countpointCalib += 1;
                            }
                            if (countpointCalib == 11)
                            {
                                HTuple Error = clsCalib.Finally();
                                this.Invoke((MethodInvoker)delegate
                                {
                                    string Errorshow = Error.ToString();
                                    txtErrorCalib.Text = Errorshow;
                                }
                                );
                                clsPlc.SetBitFromPLC(4003, 2, 1, socketPLC);
                                // Send Finish
                                MessageBox.Show("  Calib Complete <3");
                                break;
                            }
                            Thread.Sleep(100);
                        }
                    }
                    else
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            btnCalibBit.BackColor = Color.Red;
                        });
                    }
                    //HE
                    if (DataBitTrigerHE == 1) /////////-----HEB------
                    {

                        HTuple lst_row_vs = new HTuple();
                        HTuple lst_col_vs = new HTuple();
                        HTuple lst_agl_vs = new HTuple();

                        HTuple lst_x_rb = new HTuple();
                        HTuple lst_y_rb = new HTuple();
                        HTuple lst_a_rb = new HTuple();

                        int countpointHE = 0;

                        while (true)
                        {
                            _break = 0;
                            try
                            {
                                /// Recieve signal riger Camera
                                DataBit = clsPlc.GetBitFromPLC(3000, 1, socketPLC);

                                if (DataBit == 1)
                                {
                                    this.Invoke((MethodInvoker)delegate
                                    {
                                        btnHandeyeBit.BackColor = Color.Green;
                                    });
                                    window.ClearWindow();
                                    // Call result Shape Model
                                    result rsl = new result();
                                    snap();
                                    HObject newimg = new HObject(Img);
                                    rsl = clsCalib.findshapemodle(newimg, ModelID, window);

                                    ////**** Use Origin 
                                    HTuple row_input = rsl.RowProj;
                                    HTuple col_input = rsl.ColProj;
                                    HTuple agl_input = rsl.Angle_;
                                    if (_useOrigin == 1)
                                    {
                                        HTuple x0 = 0.0, y0 = 0.0, agl0 = 0.0;
                                        HTuple hommat2D_findregion = new HTuple();
                                        HOperatorSet.VectorAngleToRigid(x0, y0, agl0, rsl.lst_cordinate_shapemodel[0], rsl.lst_cordinate_shapemodel[1], rsl.lst_cordinate_shapemodel[2], out hommat2D_findregion);
                                        clsCalib.create_origin(newimg , rg_binary, rg_first, rg_second, hommat2D_findregion);
                                        row_input = rsl.RowProj;
                                        col_input = rsl.ColProj;
                                        agl_input = rsl.Angle_;
                                    }
                                    else
                                    {
                                        row_input = rsl.lst_cordinate_shapemodel[0];
                                        col_input = rsl.lst_cordinate_shapemodel[1];
                                        agl_input = rsl.lst_cordinate_shapemodel[2];
                                    }    
                                    //Add list vision coordinate
                                    HOperatorSet.TupleConcat(lst_row_vs, row_input, out lst_row_vs);
                                    HOperatorSet.TupleConcat(lst_col_vs, col_input, out lst_col_vs);
                                    HOperatorSet.TupleConcat(lst_agl_vs, agl_input, out lst_agl_vs);

                                    // set window
                                    window.SetColor("green");
                                    window.SetDraw("margin");
                                    window.SetLineWidth(3);
                                    rsl.shapemodel_affined.DispObj(window);
                                    window.SetColor("yellow");

                                    //window.DispObj(cross);
                                    //HOperatorSet.WriteImage(Img, "bmp", 0, Application.StartupPath + "/hand_eye/" + "image_calib_" + countpointHE);
                                    clsPlc.SendDataFromPLC("Word", 2, 4005, socketPLC);

                                    // Get coordinate of Robot
                                    HTuple _x = clsPlc.RecDataFromPLC("DWord", 3100, 2, socketPLC);
                                    HTuple _y = clsPlc.RecDataFromPLC("DWord", 3102, 2, socketPLC);
                                    HTuple _angle = clsPlc.RecDataFromPLC("DWord", 3104, 2, socketPLC);
                                    HTuple division = 1000.0;
                                    HTuple _xx = _x / division;
                                    HTuple _xy = _y / division/10;
                                    HTuple _thee = _angle / 10000.0;

                                    // Add list coordinate robot
                                    HOperatorSet.TupleConcat(lst_x_rb, _xx, out lst_x_rb);
                                    HOperatorSet.TupleConcat(lst_y_rb, _xy, out lst_y_rb);
                                    HOperatorSet.TupleConcat(lst_a_rb, _thee, out lst_a_rb);

                                    countpointHE += 1;
                                    HOperatorSet.WriteImage(Img, "bmp", 0, Application.StartupPath + "/hand_eye/" + "image_calib_" + countpointHE);
                                    this.Invoke((MethodInvoker)delegate
                                    {
                                        //timer1.Enabled = true;
                                        //MessageBox.Show($"Next count {countpointHE}...");
                                        //timer1.Enabled = false;
                                        lbCountNumber.Text = countpointHE.ToString();
                                        txtXRobot.Text = _x.ToString();
                                        txtYRobot.Text = _y.ToString();
                                        txtThetaRobot.Text = _angle.ToString();
                                        btnTrigerBit.BackColor = Color.Green;
                                    });
                                    Thread.Sleep(100);

                                    clsPlc.SendDataFromPLC("Word", 2, 4002, socketPLC);

                                }
                                if (DataBit == 0)
                                {
                                    this.Invoke((MethodInvoker)delegate
                                    {
                                        btnTrigerBit.BackColor = Color.Red;
                                    });
                                }
                                if (countpointHE == 11)
                                {
                                    string pathsave = Application.StartupPath + "/Handeye_Hommat";
                                    result rsl = new result();
                                    rsl = clsCalib.handeye11point(lst_row_vs, lst_col_vs, lst_agl_vs, lst_x_rb, lst_y_rb);
                                    // Write list data point
                                    HOperatorSet.WriteTuple(lst_row_vs, pathsave + "/lst_row_vs.tup");
                                    HOperatorSet.WriteTuple(lst_col_vs, pathsave + "/lst_col_vs.tup");
                                    HOperatorSet.WriteTuple(lst_agl_vs, pathsave + "/lst_agl_vs.tup");
                                    HOperatorSet.WriteTuple(lst_x_rb, pathsave + "/lst_x_rb.tup");
                                    HOperatorSet.WriteTuple(lst_y_rb, pathsave + "/lst_y_rb.tup");
                                    // Save Data Handeye
                                    HOperatorSet.WriteTuple(rsl.HomMat_ImgtoWorld, pathsave + "/HomMat_ImgtoWorld.tup");
                                    HOperatorSet.WriteTuple(rsl.HomMat_WorldtoImg, pathsave + "/HomMat_WorldtoImg.tup");
                                    HOperatorSet.WriteTuple(rsl.TCP_to_Tool, pathsave + "/TCP_to_Tool.tup");
                                    HOperatorSet.WriteTuple(rsl.Tool_to_TCP, pathsave + "/Tool_to_TCP.tup");

                                    clsPlc.SendDataFromPLC("Word", 4, 4003, socketPLC);           // Send complete handeye to PLC.
                                    Thread.Sleep(100);
                                    MessageBox.Show($"Complete!!");
                                    countpointHE = 0;
                                    this.Invoke((MethodInvoker)delegate
                                    {
                                        btnTrigerBit.BackColor = Color.Red;
                                    });
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.ToString());
                                _break = 1;
                                break;

                            }
                            Thread.Sleep(100);
                        }

                    }
                    else
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            btnHandeyeBit.BackColor = Color.Red;
                        });
                    }

                    await Task.WhenAll(task1);
                }
                catch (Exception ex)
                {

                }
                if (_break == 1)
                {
                    break;
                }
            }
        }

        void rungetbitfromplc()
        {
            // Get bit tt
            int bit_TT = -1;
            int bit_XT = -1;
            clsPlccontrol _clsplccontrol = new clsPlccontrol();
            _clsplccontrol.plc_device_TT = 7000;
            _clsplccontrol.plc_device_XT = 7000;
            while (true)
            {
                try
                {
                    if (socketPLC == null)
                    {
                        MessageBox.Show(" Please Connect PLC !!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Thread.Sleep(200);
                      
                    }
                    //if (Framgraber == null)
                    //{
                    //    MessageBox.Show(" Please Connect Camera !!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    Thread.Sleep(200);
                        
                    //}
                    else

                    {
                        clsPlc.SetBitFromPLC(6010, 1, 0, socketPLC); // reset bit TT
                        clsPlc.SetBitFromPLC(6010, 2, 0, socketPLC); // reset bit XT
                        bit_TT = clsPlc.GetBitFromPLC(_clsplccontrol.plc_device_TT, 1, socketPLC);
                        bit_XT = clsPlc.GetBitFromPLC(_clsplccontrol.plc_device_XT, 2, socketPLC);
                    }
                    string pathsave = Application.StartupPath + "/TrainTarget/";
                    if (bit_TT ==1)
                    {
                        
                        HTuple Rb_Point = new HTuple();
                        result rsl = new result();
                        snap();
                        // Get Robot Coordinate
                        Rb_Point[0] = clsPlc.RecDataFromPLC("DWord", 3200, 2, socketPLC)/1000.0;
                        Rb_Point[1] = clsPlc.RecDataFromPLC("DWord", 3202, 2, socketPLC) / 10000.0;
                        Rb_Point[2] = clsPlc.RecDataFromPLC("DWord", 3204, 2, socketPLC) / 10000.0;
                        HOperatorSet.WriteTuple(Rb_Point, pathsave + "PointRBMaster.tup");
                        //Get Vision Point 
                        rsl = clsCalib.findshapemodle(Img, ModelID, window);
                        
                        //calTT
                        calTTprocess(rsl.lst_cordinate_shapemodel[0], rsl.lst_cordinate_shapemodel[1], rsl.lst_cordinate_shapemodel[2], Rb_Point[0], Rb_Point[1]);
                        clsPlc.SetBitFromPLC(6010, 1, 1, socketPLC); // send bit TT OK
                        Thread.Sleep(100);
                    }

                    if (bit_XT == 1)
                    {
                        HTuple Rb_Point = new HTuple();
                        HOperatorSet.ReadTuple(pathsave + "PointRBMaster.tup",out Rb_Point);
                        result rsl = new result();
                        snap();
                        //Get Vision Point 
                        rsl = clsCalib.findshapemodle(Img, ModelID, window);
                        
                        //calTT
                        calExcuteTarget(rsl.lst_cordinate_shapemodel[0], rsl.lst_cordinate_shapemodel[1], rsl.lst_cordinate_shapemodel[2],rsl.Agl_Master);

                        HTuple X_Delta = ((X_TCP_Out - Rb_Point[0])*100000).TupleRound();
                        HTuple Y_Delta = ((Y_TCP_Out - Rb_Point[1])*100000).TupleRound();
                        HTuple Agl_Delta = 0;
                        clsPlc.SendDataFromPLC("DWord", X_Delta, 7100, socketPLC);
                        clsPlc.SendDataFromPLC("DWord", Y_Delta, 7102, socketPLC);
                        clsPlc.SendDataFromPLC("DWord", 0, 7104, socketPLC);

                        //clsPlc.SendDataFromPLC("DWord", (X_T_Out*100000).TupleRound(), 7300, socketPLC);
                        //clsPlc.SendDataFromPLC("DWord", (Y_T_Out*100000).TupleRound(), 7302, socketPLC);
                        //clsPlc.SendDataFromPLC("DWord", ((rsl.Agl_Master) * 100000).TupleRound(), 7304, socketPLC);

                        HTuple X_TCP_Send = (X_TCP_Out * 100000).TupleRound();
                        HTuple Y_TCP_Send = (Y_TCP_Out * 100000).TupleRound();
                        clsPlc.SendDataFromPLC("DWord", X_TCP_Send, 7400, socketPLC);
                        clsPlc.SendDataFromPLC("DWord", Y_TCP_Send, 7402, socketPLC);
                        //clsPlc.SendDataFromPLC("DWord", ((rsl.Agl_Master) * 100000).TupleRound(), 7404, socketPLC);


                        clsPlc.SendDataFromPLC("Word", 4, 6010, socketPLC); // send bit XT OK
                        Thread.Sleep(500);

                    }
                    Thread.Sleep(200);
                }
                catch (Exception ex )
                {
                    MessageBox.Show("Connect Plc error !!!" + ex.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }

            }
        }
        List<datatrain> lstDataTrain = new List<datatrain>();
        public void loadMastertrain()
        {
            lstDataTrain.Clear();
            DataTable dttb = Lib.GetTableData("select * from TrainModel");
            try
            {
                for (int i = 0; i < dttb.Rows.Count; i++)
                {
                    datatrain dtget = new datatrain();
                    dtget.Roi = Lib.ToString(dttb.Rows[i]["Roi"]);
                    dtget.X = Lib.ToDouble(dttb.Rows[i]["X"]);
                    dtget.Y = Lib.ToDouble(dttb.Rows[i]["Y"]);
                    dtget.L1 = Lib.ToDouble(dttb.Rows[i]["L1"]);
                    dtget.L2 = Lib.ToDouble(dttb.Rows[i]["L2"]);
                    dtget.Theta = Lib.ToDouble(dttb.Rows[i]["Theta"]);
                    lstDataTrain.Add(dtget);
                }
            }

            catch (Exception ex)
            {

            }
        }
        public class datatrain
        {
            public string Roi { get; set; }
            public double X { get; set; }
            public double Y { get; set; }
            public double L1 { get; set; }
            public double L2 { get; set; }
            public double Theta { get; set; }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (Framgraber == null)
            {
                MessageBox.Show("Please create the CAM connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_isRun)
            {
                _isRun = true;
                _threadLive = new Thread(new ThreadStart(runcode));
                _threadLive.IsBackground = true;
                _threadLive.Start();

                //btnRun.Image = Image.FromFile(Application.StartupPath + "/Images/pause_30px.png");
                btnRun.BackColor = Color.Red;
                //btnConnect.Enabled = false;
            }
            else
            {
                _isRun = false;
                Thread.Sleep(1000);
                if (_threadLive != null) _threadLive.Abort();

                btnRun.BackColor = Color.LightGray;
                //btnRun.Image = Image.FromFile(Application.StartupPath + "/Images/play_30px1.png");
                // btnConnect.Enabled = true;
            }
        }

        private void btnConnectPLC_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnConnectPLC.Text.ToLower() == "connect plc".ToLower())
                {
                    connectPLC();
                    btnConnectPLC.Text = "CONNECTED ";
                    btnlightPLC.BackColor = Color.Green;
                }
                else
                {
                    btnConnectPLC.Text = "CONNECT PLC";
                    btnlightPLC.BackColor = Color.Red;
                    HOperatorSet.CloseSocket(socketPLC);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("  Connect PLC Error!!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SendKeys.Send("{ESC}");
        }

        private void frmHandeyeCalib_FormClosed(object sender, FormClosedEventArgs e)
        {
            HOperatorSet.CloseFramegrabber(Framgraber);
            HOperatorSet.CloseSocket(socketPLC);
            _threadTT.Abort();            
        }

        void createRegion(double x1, double y1, double theta, double x2, double y2)
        {
            if (Drawing_Ob != null)
            {
                Drawing_Ob.Dispose();
            }
            Drawing_Ob = HDrawingObject.CreateDrawingObject(HDrawingObject.HDrawingObjectType.RECTANGLE2, x1, y1, theta, x2, y2);
            Drawing_Ob.SetDrawingObjectParams("color", "green");
            Drawing_Ob.OnDrag(getposistion);
            window.AttachDrawingObjectToWindow(Drawing_Ob);

        }

        private void getposistion(HDrawingObject img, HWindow hwin, string type)
        {
            HRegion region = new HRegion(img.GetDrawingObjectIconic());
            HOperatorSet.RegionFeatures(region, new HTuple(new string[] { "row", "column", "rect2_len1", "rect2_len2", "phi" }), out HTuple values);
            arr1 = values.ToDArr();

        }
        private void btnCreateModel_Click(object sender, EventArgs e)
        {
            createRegion(50, 50, 0, 50, 50);

        }
        void createModel()
        {
            HObject contoursAffine = new HObject();
            if (contoursAffine != null)
            {
                contoursAffine.Dispose();
            }
            HTuple _row = arr1[0];
            HTuple _comlumn = arr1[1];
            HTuple _rec_leng1 = arr1[2];
            HTuple _rec_leng2 = arr1[3];
            HTuple _phi = arr1[4];
            HOperatorSet.GenRectangle2(out HObject rectangleNew, _row, _comlumn, _phi, _rec_leng1, _rec_leng2);
            HOperatorSet.ReduceDomain(Img, rectangleNew, out HObject imgReduced);
            HOperatorSet.CreateShapeModel(imgReduced, "auto", -0.39, 0.79, "auto", "auto", "use_polarity", "auto", "auto", out ModelID);
            HOperatorSet.FindShapeModel(Img, ModelID, -0.39, 0.79, 0.5, 1, 0.5, "least_squares", new HTuple(4, -2), 0.9, out HTuple Row, out HTuple Column, out HTuple Angle, out HTuple Score);
            HOperatorSet.VectorAngleToRigid(0, 0, 0, Row[0], Column[0], Angle[0], out HTuple HomMat2D);
            HOperatorSet.GetShapeModelContours(out HObject ModelContour, ModelID, 1);
            HOperatorSet.AffineTransContourXld(ModelContour, out contoursAffine, HomMat2D);
            window.SetColor("green");
            window.SetDraw("margin");
            window.SetLineWidth(3);
            contoursAffine.DispObj(window);
        }

        private void btnSaveModel_Click(object sender, EventArgs e)
        {
            createModel();

            string pathModel = Application.StartupPath + "/Model";
            if (!Directory.Exists(pathModel))
            {
                Directory.CreateDirectory(pathModel);
            }
            HOperatorSet.WriteShapeModel(ModelID, string.Format(@"{0}/Model/{1}.shm", Application.StartupPath, "ModelHandeye"));
            MessageBox.Show("Train Success!!");
            Drawing_Ob.Dispose();
        }
        void LoadModel()
        {
            string pathModel = Application.StartupPath + "/Model";
            try
            {
                HOperatorSet.ReadShapeModel(string.Format(@"{0}/Model/{1}.shm", Application.StartupPath, "ModelHandeye"), out ModelID);
            }
            catch (Exception ex)
            {

            }
        }
        void getOrigin(HObject Img, HObject Region_Binary, HObject Region_First, HObject Region_Second, HTuple HomMat2D_TransRegion)
        {
            HTuple RowProj = 0;
            HTuple ColProj = 0;
            HTuple Angle_ = 0;

            //Input
            HDevProcedure getOrigin = new HDevProcedure("create_origin_from_region");
            HDevProcedureCall getOriginCall = new HDevProcedureCall(getOrigin);
            getOriginCall.SetInputIconicParamObject("Image", Img);
            getOriginCall.SetInputIconicParamObject("Region_Binary", Region_Binary);
            getOriginCall.SetInputIconicParamObject("Region_First", Region_First);
            getOriginCall.SetInputIconicParamObject("Region_Second", Region_Second);
            getOriginCall.SetInputCtrlParamTuple("HomMat2D_TransRegion", HomMat2D_TransRegion);
            getOriginCall.SetInputCtrlParamTuple("showOrigin", "true");

            getOriginCall.Execute();

            //Output
            RowProj = getOriginCall.GetOutputCtrlParamTuple("RowProj");
            ColProj = getOriginCall.GetOutputCtrlParamTuple("ColProj");
            Angle_ = getOriginCall.GetOutputCtrlParamTuple("Angle");
            window.SetColor("green");
            HOperatorSet.GenCrossContourXld(out HObject cross, RowProj, ColProj, 100000, Angle_);
            cross.DispObj(window);

        }
        void findshapemodel(HObject newimg)
        {
            HOperatorSet.FindShapeModel(newimg, ModelID, -0.39, 0.79, 0.5, 1, 0.3, "least_squares", new HTuple(4, -2), 0.9, out HTuple Row, out HTuple Column, out HTuple Angle, out HTuple Score);
            HOperatorSet.VectorAngleToRigid(0, 0, 0, Row[0], Column[0], Angle[0], out HTuple HomMat2D);
            HOperatorSet.GetShapeModelContours(out HObject ModelContour, ModelID, 1);
            HOperatorSet.AffineTransContourXld(ModelContour, out HObject contoursAffine, HomMat2D);
            HOperatorSet.GenCrossContourXld(out HObject cross, Row[0], Column[0], 20, 90);
        }
        void calTTprocess(double Img_X,double Img_Y,double Img_Agl ,double Rb_X,double Rb_Y)
        {
            string pathsave = Application.StartupPath + "/TrainTarget/";
            string pathsave_Hommat = Application.StartupPath + "/Handeye_Hommat/";
            // Read Hommat ConvertH

            HOperatorSet.ReadTuple(pathsave_Hommat + "HomMat_WorldtoImg.tup", out HTuple Hommat_WorldtoImg);
            //// Convert Point Robot to coordinate Image
            HOperatorSet.AffineTransPoint2d(Hommat_WorldtoImg, Rb_X, Rb_Y, out HTuple Px_Img, out HTuple Py_Img);
            HOperatorSet.CreatePose(Px_Img, Py_Img, 0, 0, 0, 0, "Rp+T", "gba", "point", out HTuple C_H_TCP);     // point robot
            HOperatorSet.CreatePose(Img_X, Img_Y, 0, 0, 0, Img_Agl, "Rp+T", "gba", "point", out HTuple C_H_Pmaster);// point vision
            HOperatorSet.PoseInvert(C_H_Pmaster, out HTuple Pmaster_H_C);
            HOperatorSet.PoseCompose(Pmaster_H_C, C_H_TCP, out HTuple Pmaster_H_TCPmaster);

            ///// Out data P_H_T
            HOperatorSet.WriteTuple(Pmaster_H_TCPmaster, pathsave + "Pmaster_H_TCPmaster.tup");
        }
        void calExcuteTarget(HTuple x , HTuple y , HTuple a , HTuple agl_master)
        {
            string pathsave_Hommat = Application.StartupPath + "/Handeye_Hommat/";
            string pathsave = Application.StartupPath + "/TrainTarget/";
            //// Read data
            HOperatorSet.ReadTuple(pathsave_Hommat + "HomMat_ImgtoWorld.tup", out HTuple Hommat_ImgtoWorld);
            HOperatorSet.ReadTuple(pathsave + "Pmaster_H_TCPmaster.tup", out HTuple Pmaster_H_TCP);
            HOperatorSet.ReadTuple(pathsave + "TCP_to_Ob.tup", out HTuple TCP_to_Ob);

            //// Calculate Point Robot
            HOperatorSet.CreatePose(x, y, 0, 0, 0, 0, "Rp+T", "gba", "point", out HTuple C_H_Pcurrent_TCP); // Point Vision to Pose TCC Robot
            HOperatorSet.PoseCompose(C_H_Pcurrent_TCP, Pmaster_H_TCP, out HTuple C_H_TCP); // Point TCP in Cam Pose
            HTuple _degree = a.TupleDeg();
            HOperatorSet.CreatePose(x, y, 0, 0, 0, _degree, "Rp+T", "gba", "point", out HTuple C_H_Pcurrent_);
            HOperatorSet.PoseCompose(C_H_Pcurrent_, Pmaster_H_TCP, out HTuple C_H_TCP_); // Point TCP in Cam Pose
            HOperatorSet.PoseCompose(C_H_TCP_, TCP_to_Ob, out HTuple C_H_Ob); // Point OB(Tool) in Cam Pose

            //// Calculate Point Send to Robot ****
            //// Point TCP Robot
            HOperatorSet.AffineTransPoint2d(Hommat_ImgtoWorld, C_H_TCP[0], C_H_TCP[1], out  X_TCP_Out, out  Y_TCP_Out); // Point TCP in Base Pose
            HOperatorSet.AffineTransPoint2d(Hommat_ImgtoWorld, C_H_Ob[0], C_H_Ob[1], out  X_T_Out, out  Y_T_Out);  // Point Ob(Tool) in Base Pose

        }
        private void btnTest_Click(object sender, EventArgs e)
        {


            result rs = new result();
            try
            {
                HTuple lst_row =  new HTuple();
                HTuple HomMat_ImgtoWorld = new HTuple();
                HTuple HomMat_WorldtoImg = new HTuple();

                string pathsave = Application.StartupPath + "/Handeye_Hommat";
                // Write list data point
                HOperatorSet.ReadTuple(pathsave + "/lst_row_vs.tup" , out HTuple lst_row_vs);
                HOperatorSet.ReadTuple(pathsave + "/lst_col_vs.tup", out HTuple lst_col_vs);
                HOperatorSet.ReadTuple(pathsave + "/lst_agl_vs.tup", out HTuple lst_agl_vs);
                HOperatorSet.ReadTuple(pathsave + "/lst_x_rb.tup", out HTuple lst_x_rb);
                HOperatorSet.ReadTuple(pathsave + "/lst_y_rb.tup", out HTuple lst_y_rb);
                /// Set procedure for handeye program
                HDevProcedure procedure_handeye = new HDevProcedure("handeye_stationary_camera");
                HDevProcedureCall procedure_handeye_call = new HDevProcedureCall(procedure_handeye);
                procedure_handeye_call.SetInputCtrlParamTuple("listRow_Img", lst_row_vs);
                procedure_handeye_call.SetInputCtrlParamTuple("listCol_Img", lst_col_vs);
                procedure_handeye_call.SetInputCtrlParamTuple("listAgl_Img", lst_agl_vs);
                procedure_handeye_call.SetInputCtrlParamTuple("listX_Robot", lst_x_rb);
                procedure_handeye_call.SetInputCtrlParamTuple("listY_Robot", lst_y_rb);
                procedure_handeye_call.Execute();
                /// Process procedure and read result from out data
                HomMat_ImgtoWorld = procedure_handeye_call.GetOutputCtrlParamTuple("HomMat_ImgtoWorld");
                HomMat_WorldtoImg = procedure_handeye_call.GetOutputCtrlParamTuple("HomMat_WorldtoImg");
                
                HOperatorSet.WriteTuple(HomMat_ImgtoWorld, pathsave + "/HomMat_ImgtoWorld.tup");
                HOperatorSet.WriteTuple(HomMat_WorldtoImg, pathsave + "/HomMat_WorldtoImg.tup");


            }
            catch (Exception ex)
            {

            }
            


        }
    }


    
}
