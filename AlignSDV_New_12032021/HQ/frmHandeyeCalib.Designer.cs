namespace HQ
{
    partial class frmHandeyeCalib
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnConnection = new System.Windows.Forms.Button();
            this.btnSnap = new System.Windows.Forms.Button();
            this.WindowControl = new HalconDotNet.HSmartWindowControl();
            this.btnLive = new System.Windows.Forms.Button();
            this.btnStoplive = new System.Windows.Forms.Button();
            this.btnLoadImg = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnConnectPLC = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtErrorCalib = new System.Windows.Forms.TextBox();
            this.btnTrigerBit = new System.Windows.Forms.Button();
            this.btnHandeyeBit = new System.Windows.Forms.Button();
            this.btnCalibBit = new System.Windows.Forms.Button();
            this.txtXRobot = new System.Windows.Forms.TextBox();
            this.txtYRobot = new System.Windows.Forms.TextBox();
            this.txtThetaRobot = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtplc = new System.Windows.Forms.TextBox();
            this.txtcam = new System.Windows.Forms.TextBox();
            this.btnlightPLC = new System.Windows.Forms.Button();
            this.btnlightcam = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnTest = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbCountNumber = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSaveModel = new System.Windows.Forms.Button();
            this.btnCreateModel = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbRz = new System.Windows.Forms.Label();
            this.Ry = new System.Windows.Forms.Label();
            this.txtRzHe = new System.Windows.Forms.TextBox();
            this.txtRyHe = new System.Windows.Forms.TextBox();
            this.txtRxHe = new System.Windows.Forms.TextBox();
            this.lbRx = new System.Windows.Forms.Label();
            this.txtZHe = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtYHe = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtXHe = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnection
            // 
            this.btnConnection.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnConnection.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnection.Location = new System.Drawing.Point(22, 42);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(119, 36);
            this.btnConnection.TabIndex = 3;
            this.btnConnection.Text = "CONECT CAMERA";
            this.btnConnection.UseVisualStyleBackColor = false;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // btnSnap
            // 
            this.btnSnap.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSnap.Enabled = false;
            this.btnSnap.Location = new System.Drawing.Point(20, 44);
            this.btnSnap.Name = "btnSnap";
            this.btnSnap.Size = new System.Drawing.Size(109, 33);
            this.btnSnap.TabIndex = 7;
            this.btnSnap.Text = "Snap";
            this.btnSnap.UseVisualStyleBackColor = false;
            this.btnSnap.Click += new System.EventHandler(this.btnSnap_Click);
            // 
            // WindowControl
            // 
            this.WindowControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WindowControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.WindowControl.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.WindowControl.HDoubleClickToFitContent = true;
            this.WindowControl.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None;
            this.WindowControl.HImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.WindowControl.HKeepAspectRatio = true;
            this.WindowControl.HMoveContent = true;
            this.WindowControl.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;
            this.WindowControl.Location = new System.Drawing.Point(9, 9);
            this.WindowControl.Margin = new System.Windows.Forms.Padding(0);
            this.WindowControl.Name = "WindowControl";
            this.WindowControl.Size = new System.Drawing.Size(1022, 840);
            this.WindowControl.TabIndex = 8;
            this.WindowControl.WindowSize = new System.Drawing.Size(1022, 840);
            this.WindowControl.Load += new System.EventHandler(this.WindowControl_Load);
            // 
            // btnLive
            // 
            this.btnLive.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLive.Enabled = false;
            this.btnLive.Location = new System.Drawing.Point(20, 92);
            this.btnLive.Name = "btnLive";
            this.btnLive.Size = new System.Drawing.Size(109, 33);
            this.btnLive.TabIndex = 9;
            this.btnLive.Text = "Live";
            this.btnLive.UseVisualStyleBackColor = false;
            this.btnLive.Click += new System.EventHandler(this.btnLive_Click);
            // 
            // btnStoplive
            // 
            this.btnStoplive.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStoplive.Location = new System.Drawing.Point(227, 92);
            this.btnStoplive.Name = "btnStoplive";
            this.btnStoplive.Size = new System.Drawing.Size(109, 33);
            this.btnStoplive.TabIndex = 10;
            this.btnStoplive.Text = "Stop Live";
            this.btnStoplive.UseVisualStyleBackColor = false;
            this.btnStoplive.Click += new System.EventHandler(this.btnStoplive_Click);
            // 
            // btnLoadImg
            // 
            this.btnLoadImg.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLoadImg.Location = new System.Drawing.Point(227, 44);
            this.btnLoadImg.Name = "btnLoadImg";
            this.btnLoadImg.Size = new System.Drawing.Size(109, 33);
            this.btnLoadImg.TabIndex = 12;
            this.btnLoadImg.Text = "Load Image";
            this.btnLoadImg.UseVisualStyleBackColor = false;
            this.btnLoadImg.Click += new System.EventHandler(this.btnLoadImg_Click);
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.Tomato;
            this.btnRun.Location = new System.Drawing.Point(22, 46);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(77, 31);
            this.btnRun.TabIndex = 16;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnConnectPLC
            // 
            this.btnConnectPLC.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnConnectPLC.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectPLC.Location = new System.Drawing.Point(22, 84);
            this.btnConnectPLC.Name = "btnConnectPLC";
            this.btnConnectPLC.Size = new System.Drawing.Size(119, 34);
            this.btnConnectPLC.TabIndex = 17;
            this.btnConnectPLC.Text = "CONNECT PLC";
            this.btnConnectPLC.UseVisualStyleBackColor = false;
            this.btnConnectPLC.Click += new System.EventHandler(this.btnConnectPLC_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Theta";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(278, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Error";
            // 
            // txtErrorCalib
            // 
            this.txtErrorCalib.Location = new System.Drawing.Point(275, 128);
            this.txtErrorCalib.Name = "txtErrorCalib";
            this.txtErrorCalib.Size = new System.Drawing.Size(63, 20);
            this.txtErrorCalib.TabIndex = 27;
            // 
            // btnTrigerBit
            // 
            this.btnTrigerBit.BackColor = System.Drawing.Color.Lavender;
            this.btnTrigerBit.Location = new System.Drawing.Point(50, 394);
            this.btnTrigerBit.Name = "btnTrigerBit";
            this.btnTrigerBit.Size = new System.Drawing.Size(28, 23);
            this.btnTrigerBit.TabIndex = 28;
            this.btnTrigerBit.UseVisualStyleBackColor = false;
            // 
            // btnHandeyeBit
            // 
            this.btnHandeyeBit.BackColor = System.Drawing.Color.Lavender;
            this.btnHandeyeBit.Location = new System.Drawing.Point(161, 394);
            this.btnHandeyeBit.Name = "btnHandeyeBit";
            this.btnHandeyeBit.Size = new System.Drawing.Size(28, 23);
            this.btnHandeyeBit.TabIndex = 29;
            this.btnHandeyeBit.UseVisualStyleBackColor = false;
            // 
            // btnCalibBit
            // 
            this.btnCalibBit.BackColor = System.Drawing.Color.Lavender;
            this.btnCalibBit.Location = new System.Drawing.Point(272, 394);
            this.btnCalibBit.Name = "btnCalibBit";
            this.btnCalibBit.Size = new System.Drawing.Size(28, 23);
            this.btnCalibBit.TabIndex = 30;
            this.btnCalibBit.UseVisualStyleBackColor = false;
            // 
            // txtXRobot
            // 
            this.txtXRobot.Location = new System.Drawing.Point(22, 128);
            this.txtXRobot.Name = "txtXRobot";
            this.txtXRobot.Size = new System.Drawing.Size(63, 20);
            this.txtXRobot.TabIndex = 31;
            // 
            // txtYRobot
            // 
            this.txtYRobot.Location = new System.Drawing.Point(107, 128);
            this.txtYRobot.Name = "txtYRobot";
            this.txtYRobot.Size = new System.Drawing.Size(63, 20);
            this.txtYRobot.TabIndex = 32;
            // 
            // txtThetaRobot
            // 
            this.txtThetaRobot.Location = new System.Drawing.Point(192, 128);
            this.txtThetaRobot.Name = "txtThetaRobot";
            this.txtThetaRobot.Size = new System.Drawing.Size(63, 20);
            this.txtThetaRobot.TabIndex = 33;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(1034, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 921);
            this.panel1.TabIndex = 34;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.txtplc);
            this.panel2.Controls.Add(this.txtcam);
            this.panel2.Controls.Add(this.btnlightPLC);
            this.panel2.Controls.Add(this.btnlightcam);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnConnection);
            this.panel2.Controls.Add(this.btnConnectPLC);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(351, 133);
            this.panel2.TabIndex = 46;
            // 
            // txtplc
            // 
            this.txtplc.Location = new System.Drawing.Point(198, 92);
            this.txtplc.Name = "txtplc";
            this.txtplc.Size = new System.Drawing.Size(140, 20);
            this.txtplc.TabIndex = 21;
            // 
            // txtcam
            // 
            this.txtcam.Location = new System.Drawing.Point(198, 51);
            this.txtcam.Name = "txtcam";
            this.txtcam.Size = new System.Drawing.Size(140, 20);
            this.txtcam.TabIndex = 20;
            // 
            // btnlightPLC
            // 
            this.btnlightPLC.BackColor = System.Drawing.Color.Red;
            this.btnlightPLC.Location = new System.Drawing.Point(154, 90);
            this.btnlightPLC.Name = "btnlightPLC";
            this.btnlightPLC.Size = new System.Drawing.Size(25, 23);
            this.btnlightPLC.TabIndex = 19;
            this.btnlightPLC.UseVisualStyleBackColor = false;
            // 
            // btnlightcam
            // 
            this.btnlightcam.BackColor = System.Drawing.Color.Red;
            this.btnlightcam.Location = new System.Drawing.Point(154, 49);
            this.btnlightcam.Name = "btnlightcam";
            this.btnlightcam.Size = new System.Drawing.Size(25, 23);
            this.btnlightcam.TabIndex = 18;
            this.btnlightcam.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "COMMUNICATION";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel3.Controls.Add(this.btnTest);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnLoadImg);
            this.panel3.Controls.Add(this.btnSnap);
            this.panel3.Controls.Add(this.btnLive);
            this.panel3.Controls.Add(this.btnStoplive);
            this.panel3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3.Location = new System.Drawing.Point(3, 152);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(354, 172);
            this.panel3.TabIndex = 47;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(132, 125);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 49;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(145, 19);
            this.label13.TabIndex = 48;
            this.label13.Text = "CAMERA ADJUST";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, -32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "CAMERA AJUST";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel4.Controls.Add(this.lbCountNumber);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.btnSaveModel);
            this.panel4.Controls.Add(this.btnCreateModel);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.lbRz);
            this.panel4.Controls.Add(this.btnCalibBit);
            this.panel4.Controls.Add(this.btnRun);
            this.panel4.Controls.Add(this.btnHandeyeBit);
            this.panel4.Controls.Add(this.Ry);
            this.panel4.Controls.Add(this.btnTrigerBit);
            this.panel4.Controls.Add(this.txtRzHe);
            this.panel4.Controls.Add(this.txtRyHe);
            this.panel4.Controls.Add(this.txtRxHe);
            this.panel4.Controls.Add(this.lbRx);
            this.panel4.Controls.Add(this.txtXRobot);
            this.panel4.Controls.Add(this.txtZHe);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.txtYRobot);
            this.panel4.Controls.Add(this.txtYHe);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.txtThetaRobot);
            this.panel4.Controls.Add(this.txtXHe);
            this.panel4.Controls.Add(this.txtErrorCalib);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(1034, 351);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(351, 498);
            this.panel4.TabIndex = 48;
            // 
            // lbCountNumber
            // 
            this.lbCountNumber.AutoSize = true;
            this.lbCountNumber.BackColor = System.Drawing.Color.DarkTurquoise;
            this.lbCountNumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountNumber.Location = new System.Drawing.Point(21, 162);
            this.lbCountNumber.Name = "lbCountNumber";
            this.lbCountNumber.Size = new System.Drawing.Size(17, 19);
            this.lbCountNumber.TabIndex = 53;
            this.lbCountNumber.Text = "0";
            this.lbCountNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 442);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 33);
            this.button1.TabIndex = 52;
            this.button1.Text = "TT";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSaveModel
            // 
            this.btnSaveModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveModel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSaveModel.Location = new System.Drawing.Point(255, 46);
            this.btnSaveModel.Name = "btnSaveModel";
            this.btnSaveModel.Size = new System.Drawing.Size(83, 31);
            this.btnSaveModel.TabIndex = 51;
            this.btnSaveModel.Text = "Save";
            this.btnSaveModel.UseVisualStyleBackColor = false;
            this.btnSaveModel.Click += new System.EventHandler(this.btnSaveModel_Click);
            // 
            // btnCreateModel
            // 
            this.btnCreateModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateModel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCreateModel.Location = new System.Drawing.Point(131, 46);
            this.btnCreateModel.Name = "btnCreateModel";
            this.btnCreateModel.Size = new System.Drawing.Size(83, 31);
            this.btnCreateModel.TabIndex = 49;
            this.btnCreateModel.Text = "Create Model";
            this.btnCreateModel.UseVisualStyleBackColor = false;
            this.btnCreateModel.Click += new System.EventHandler(this.btnCreateModel_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(270, 375);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 13);
            this.label16.TabIndex = 50;
            this.label16.Text = "Calib";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(150, 375);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 49;
            this.label15.Text = "Handeye";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(44, 375);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 13);
            this.label14.TabIndex = 48;
            this.label14.Text = "Triger";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 15);
            this.label12.TabIndex = 47;
            this.label12.Text = "RESULT CALIB";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 201);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 15);
            this.label11.TabIndex = 46;
            this.label11.Text = "RESULT HANDEYE";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 19);
            this.label7.TabIndex = 4;
            this.label7.Text = "HANDEYE-CALIB";
            // 
            // lbRz
            // 
            this.lbRz.AutoSize = true;
            this.lbRz.Location = new System.Drawing.Point(195, 337);
            this.lbRz.Name = "lbRz";
            this.lbRz.Size = new System.Drawing.Size(20, 13);
            this.lbRz.TabIndex = 44;
            this.lbRz.Text = "Rz";
            // 
            // Ry
            // 
            this.Ry.AutoSize = true;
            this.Ry.Location = new System.Drawing.Point(193, 293);
            this.Ry.Name = "Ry";
            this.Ry.Size = new System.Drawing.Size(20, 13);
            this.Ry.TabIndex = 42;
            this.Ry.Text = "Ry";
            // 
            // txtRzHe
            // 
            this.txtRzHe.Location = new System.Drawing.Point(240, 334);
            this.txtRzHe.Name = "txtRzHe";
            this.txtRzHe.Size = new System.Drawing.Size(67, 20);
            this.txtRzHe.TabIndex = 45;
            // 
            // txtRyHe
            // 
            this.txtRyHe.Location = new System.Drawing.Point(240, 290);
            this.txtRyHe.Name = "txtRyHe";
            this.txtRyHe.Size = new System.Drawing.Size(67, 20);
            this.txtRyHe.TabIndex = 43;
            // 
            // txtRxHe
            // 
            this.txtRxHe.Location = new System.Drawing.Point(240, 244);
            this.txtRxHe.Name = "txtRxHe";
            this.txtRxHe.Size = new System.Drawing.Size(67, 20);
            this.txtRxHe.TabIndex = 38;
            // 
            // lbRx
            // 
            this.lbRx.AutoSize = true;
            this.lbRx.Location = new System.Drawing.Point(195, 247);
            this.lbRx.Name = "lbRx";
            this.lbRx.Size = new System.Drawing.Size(20, 13);
            this.lbRx.TabIndex = 37;
            this.lbRx.Text = "Rx";
            // 
            // txtZHe
            // 
            this.txtZHe.Location = new System.Drawing.Point(90, 334);
            this.txtZHe.Name = "txtZHe";
            this.txtZHe.Size = new System.Drawing.Size(67, 20);
            this.txtZHe.TabIndex = 41;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 296);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Y";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 337);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Z";
            // 
            // txtYHe
            // 
            this.txtYHe.Location = new System.Drawing.Point(90, 290);
            this.txtYHe.Name = "txtYHe";
            this.txtYHe.Size = new System.Drawing.Size(67, 20);
            this.txtYHe.TabIndex = 40;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 247);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "X";
            // 
            // txtXHe
            // 
            this.txtXHe.Location = new System.Drawing.Point(86, 244);
            this.txtXHe.Name = "txtXHe";
            this.txtXHe.Size = new System.Drawing.Size(67, 20);
            this.txtXHe.TabIndex = 39;
            // 
            // frmHandeyeCalib
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 861);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.WindowControl);
            this.Name = "frmHandeyeCalib";
            this.Text = "Handeye Calib";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmHandeyeCalib_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.Button btnSnap;
        private HalconDotNet.HSmartWindowControl WindowControl;
        private System.Windows.Forms.Button btnLive;
        private System.Windows.Forms.Button btnStoplive;
        private System.Windows.Forms.Button btnLoadImg;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnConnectPLC;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtErrorCalib;
        private System.Windows.Forms.Button btnTrigerBit;
        private System.Windows.Forms.Button btnHandeyeBit;
        private System.Windows.Forms.Button btnCalibBit;
        private System.Windows.Forms.TextBox txtXRobot;
        private System.Windows.Forms.TextBox txtYRobot;
        private System.Windows.Forms.TextBox txtThetaRobot;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbRz;
        private System.Windows.Forms.TextBox txtRzHe;
        private System.Windows.Forms.Label Ry;
        private System.Windows.Forms.TextBox txtRyHe;
        private System.Windows.Forms.Label lbRx;
        private System.Windows.Forms.TextBox txtZHe;
        private System.Windows.Forms.TextBox txtYHe;
        private System.Windows.Forms.TextBox txtXHe;
        private System.Windows.Forms.TextBox txtRxHe;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtplc;
        private System.Windows.Forms.TextBox txtcam;
        private System.Windows.Forms.Button btnlightPLC;
        private System.Windows.Forms.Button btnlightcam;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnSaveModel;
        private System.Windows.Forms.Button btnCreateModel;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbCountNumber;
    }
}

