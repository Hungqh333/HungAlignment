namespace HQ
{
    partial class frmSetting
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
            this.WindowControl = new HalconDotNet.HSmartWindowControl();
            this.btnCreatRegion = new System.Windows.Forms.Button();
            this.btnLoadImg = new System.Windows.Forms.Button();
            this.btnTrainModel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnModel = new System.Windows.Forms.Button();
            this.btnTestTrain = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDeviceSetting = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.txtGain = new System.Windows.Forms.TextBox();
            this.txtExposuretime = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSaveParametercam = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.pnFindCam = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveCamera = new System.Windows.Forms.Button();
            this.btnCurrentConnect = new System.Windows.Forms.Button();
            this.cbxInterface = new System.Windows.Forms.ComboBox();
            this.cbxCamera = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAutoDetect = new System.Windows.Forms.Button();
            this.pnCurrentCam = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDevice = new System.Windows.Forms.TextBox();
            this.txtInterface = new System.Windows.Forms.TextBox();
            this.btnConnectRun = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPlcSetting = new System.Windows.Forms.TabPage();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.content = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.cbxTypeCommunication = new System.Windows.Forms.ComboBox();
            this.tbVisionSetting = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnshowModel = new System.Windows.Forms.Button();
            this.btnLivesetting = new System.Windows.Forms.Button();
            this.btnSnapsetting = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabDeviceSetting.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnFindCam.SuspendLayout();
            this.pnCurrentCam.SuspendLayout();
            this.tabPlcSetting.SuspendLayout();
            this.tbVisionSetting.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // WindowControl
            // 
            this.WindowControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.WindowControl.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.WindowControl.HDoubleClickToFitContent = true;
            this.WindowControl.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None;
            this.WindowControl.HImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.WindowControl.HKeepAspectRatio = true;
            this.WindowControl.HMoveContent = true;
            this.WindowControl.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;
            this.WindowControl.Location = new System.Drawing.Point(3, 3);
            this.WindowControl.Margin = new System.Windows.Forms.Padding(0);
            this.WindowControl.Name = "WindowControl";
            this.WindowControl.Size = new System.Drawing.Size(981, 700);
            this.WindowControl.TabIndex = 9;
            this.WindowControl.WindowSize = new System.Drawing.Size(981, 700);
            this.WindowControl.Load += new System.EventHandler(this.WindowControl_Load);
            // 
            // btnCreatRegion
            // 
            this.btnCreatRegion.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreatRegion.Location = new System.Drawing.Point(3, 116);
            this.btnCreatRegion.Name = "btnCreatRegion";
            this.btnCreatRegion.Size = new System.Drawing.Size(115, 34);
            this.btnCreatRegion.TabIndex = 10;
            this.btnCreatRegion.Text = "Create Region";
            this.btnCreatRegion.UseVisualStyleBackColor = true;
            this.btnCreatRegion.Click += new System.EventHandler(this.btnCreatRegion_Click);
            // 
            // btnLoadImg
            // 
            this.btnLoadImg.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadImg.Location = new System.Drawing.Point(137, 173);
            this.btnLoadImg.Name = "btnLoadImg";
            this.btnLoadImg.Size = new System.Drawing.Size(115, 34);
            this.btnLoadImg.TabIndex = 11;
            this.btnLoadImg.Text = "Load Image";
            this.btnLoadImg.UseVisualStyleBackColor = true;
            this.btnLoadImg.Click += new System.EventHandler(this.btnLoadImg_Click);
            // 
            // btnTrainModel
            // 
            this.btnTrainModel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrainModel.Location = new System.Drawing.Point(3, 173);
            this.btnTrainModel.Name = "btnTrainModel";
            this.btnTrainModel.Size = new System.Drawing.Size(115, 34);
            this.btnTrainModel.TabIndex = 13;
            this.btnTrainModel.Text = "Train Model";
            this.btnTrainModel.UseVisualStyleBackColor = true;
            this.btnTrainModel.Click += new System.EventHandler(this.btnTrainModel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(137, 229);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 29);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnModel
            // 
            this.btnModel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModel.Location = new System.Drawing.Point(3, 3);
            this.btnModel.Name = "btnModel";
            this.btnModel.Size = new System.Drawing.Size(115, 33);
            this.btnModel.TabIndex = 16;
            this.btnModel.Text = "Model";
            this.btnModel.UseVisualStyleBackColor = true;
            // 
            // btnTestTrain
            // 
            this.btnTestTrain.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestTrain.Location = new System.Drawing.Point(137, 116);
            this.btnTestTrain.Name = "btnTestTrain";
            this.btnTestTrain.Size = new System.Drawing.Size(115, 34);
            this.btnTestTrain.TabIndex = 18;
            this.btnTestTrain.Text = "Test Train";
            this.btnTestTrain.UseVisualStyleBackColor = true;
            this.btnTestTrain.Click += new System.EventHandler(this.btnTestTrain_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.WindowControl);
            this.panel1.Location = new System.Drawing.Point(9, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(991, 707);
            this.panel1.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(1022, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(312, 703);
            this.panel2.TabIndex = 20;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabControl1.Controls.Add(this.tabDeviceSetting);
            this.tabControl1.Controls.Add(this.tabPlcSetting);
            this.tabControl1.Controls.Add(this.tbVisionSetting);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(50, 60);
            this.tabControl1.Location = new System.Drawing.Point(999, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(332, 704);
            this.tabControl1.TabIndex = 19;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tabDeviceSetting
            // 
            this.tabDeviceSetting.Controls.Add(this.panel5);
            this.tabDeviceSetting.Controls.Add(this.pnFindCam);
            this.tabDeviceSetting.Controls.Add(this.pnCurrentCam);
            this.tabDeviceSetting.Location = new System.Drawing.Point(4, 4);
            this.tabDeviceSetting.Name = "tabDeviceSetting";
            this.tabDeviceSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabDeviceSetting.Size = new System.Drawing.Size(264, 696);
            this.tabDeviceSetting.TabIndex = 1;
            this.tabDeviceSetting.Text = "Device Setting";
            this.tabDeviceSetting.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel5.Controls.Add(this.txtTimeout);
            this.panel5.Controls.Add(this.txtGain);
            this.panel5.Controls.Add(this.txtExposuretime);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.btnSaveParametercam);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Location = new System.Drawing.Point(3, 343);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(264, 350);
            this.panel5.TabIndex = 24;
            // 
            // txtTimeout
            // 
            this.txtTimeout.Location = new System.Drawing.Point(119, 107);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(100, 20);
            this.txtTimeout.TabIndex = 27;
            // 
            // txtGain
            // 
            this.txtGain.Location = new System.Drawing.Point(119, 77);
            this.txtGain.Name = "txtGain";
            this.txtGain.Size = new System.Drawing.Size(100, 20);
            this.txtGain.TabIndex = 26;
            // 
            // txtExposuretime
            // 
            this.txtExposuretime.Location = new System.Drawing.Point(119, 48);
            this.txtExposuretime.Name = "txtExposuretime";
            this.txtExposuretime.Size = new System.Drawing.Size(100, 20);
            this.txtExposuretime.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Time Out";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 19);
            this.label7.TabIndex = 23;
            this.label7.Text = "PARAMETER CAM";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Exposure Time";
            // 
            // btnSaveParametercam
            // 
            this.btnSaveParametercam.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveParametercam.Image = global::HQ.Properties.Resources.save_24px;
            this.btnSaveParametercam.Location = new System.Drawing.Point(78, 157);
            this.btnSaveParametercam.Name = "btnSaveParametercam";
            this.btnSaveParametercam.Size = new System.Drawing.Size(111, 40);
            this.btnSaveParametercam.TabIndex = 13;
            this.btnSaveParametercam.UseVisualStyleBackColor = true;
            this.btnSaveParametercam.Click += new System.EventHandler(this.btnSaveParametercam_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Gain";
            // 
            // pnFindCam
            // 
            this.pnFindCam.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnFindCam.Controls.Add(this.label6);
            this.pnFindCam.Controls.Add(this.label2);
            this.pnFindCam.Controls.Add(this.btnSaveCamera);
            this.pnFindCam.Controls.Add(this.btnCurrentConnect);
            this.pnFindCam.Controls.Add(this.cbxInterface);
            this.pnFindCam.Controls.Add(this.cbxCamera);
            this.pnFindCam.Controls.Add(this.label1);
            this.pnFindCam.Controls.Add(this.btnAutoDetect);
            this.pnFindCam.Location = new System.Drawing.Point(0, 160);
            this.pnFindCam.Name = "pnFindCam";
            this.pnFindCam.Size = new System.Drawing.Size(264, 177);
            this.pnFindCam.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 19);
            this.label6.TabIndex = 23;
            this.label6.Text = "FIND CAM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Interface";
            // 
            // btnSaveCamera
            // 
            this.btnSaveCamera.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveCamera.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSaveCamera.Image = global::HQ.Properties.Resources.save_24px;
            this.btnSaveCamera.Location = new System.Drawing.Point(189, 116);
            this.btnSaveCamera.Name = "btnSaveCamera";
            this.btnSaveCamera.Size = new System.Drawing.Size(69, 34);
            this.btnSaveCamera.TabIndex = 13;
            this.btnSaveCamera.UseVisualStyleBackColor = true;
            this.btnSaveCamera.Click += new System.EventHandler(this.btnSaveCamera_Click);
            // 
            // btnCurrentConnect
            // 
            this.btnCurrentConnect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCurrentConnect.Image = global::HQ.Properties.Resources.connected_30px;
            this.btnCurrentConnect.Location = new System.Drawing.Point(98, 117);
            this.btnCurrentConnect.Name = "btnCurrentConnect";
            this.btnCurrentConnect.Size = new System.Drawing.Size(77, 33);
            this.btnCurrentConnect.TabIndex = 11;
            this.btnCurrentConnect.UseVisualStyleBackColor = true;
            this.btnCurrentConnect.Click += new System.EventHandler(this.btnCurrentConnect_Click);
            // 
            // cbxInterface
            // 
            this.cbxInterface.FormattingEnabled = true;
            this.cbxInterface.Location = new System.Drawing.Point(57, 45);
            this.cbxInterface.Name = "cbxInterface";
            this.cbxInterface.Size = new System.Drawing.Size(165, 21);
            this.cbxInterface.TabIndex = 9;
            this.cbxInterface.SelectedIndexChanged += new System.EventHandler(this.cbxInterface_SelectedIndexChanged);
            // 
            // cbxCamera
            // 
            this.cbxCamera.FormattingEnabled = true;
            this.cbxCamera.Location = new System.Drawing.Point(57, 75);
            this.cbxCamera.Name = "cbxCamera";
            this.cbxCamera.Size = new System.Drawing.Size(165, 21);
            this.cbxCamera.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Device";
            // 
            // btnAutoDetect
            // 
            this.btnAutoDetect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoDetect.Image = global::HQ.Properties.Resources.detective_30px;
            this.btnAutoDetect.Location = new System.Drawing.Point(10, 116);
            this.btnAutoDetect.Name = "btnAutoDetect";
            this.btnAutoDetect.Size = new System.Drawing.Size(72, 34);
            this.btnAutoDetect.TabIndex = 12;
            this.btnAutoDetect.UseVisualStyleBackColor = true;
            this.btnAutoDetect.Click += new System.EventHandler(this.btnAutoDetect_Click);
            // 
            // pnCurrentCam
            // 
            this.pnCurrentCam.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnCurrentCam.Controls.Add(this.label5);
            this.pnCurrentCam.Controls.Add(this.txtDevice);
            this.pnCurrentCam.Controls.Add(this.txtInterface);
            this.pnCurrentCam.Controls.Add(this.btnConnectRun);
            this.pnCurrentCam.Controls.Add(this.label3);
            this.pnCurrentCam.Controls.Add(this.label4);
            this.pnCurrentCam.Location = new System.Drawing.Point(-1, 3);
            this.pnCurrentCam.Name = "pnCurrentCam";
            this.pnCurrentCam.Size = new System.Drawing.Size(262, 151);
            this.pnCurrentCam.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 19);
            this.label5.TabIndex = 22;
            this.label5.Text = "CURRENT CAM";
            // 
            // txtDevice
            // 
            this.txtDevice.Location = new System.Drawing.Point(58, 70);
            this.txtDevice.Name = "txtDevice";
            this.txtDevice.Size = new System.Drawing.Size(165, 20);
            this.txtDevice.TabIndex = 21;
            // 
            // txtInterface
            // 
            this.txtInterface.Location = new System.Drawing.Point(58, 40);
            this.txtInterface.Name = "txtInterface";
            this.txtInterface.Size = new System.Drawing.Size(165, 20);
            this.txtInterface.TabIndex = 20;
            // 
            // btnConnectRun
            // 
            this.btnConnectRun.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectRun.Image = global::HQ.Properties.Resources.connected_30px;
            this.btnConnectRun.Location = new System.Drawing.Point(82, 96);
            this.btnConnectRun.Name = "btnConnectRun";
            this.btnConnectRun.Size = new System.Drawing.Size(111, 41);
            this.btnConnectRun.TabIndex = 19;
            this.btnConnectRun.UseVisualStyleBackColor = true;
            this.btnConnectRun.Click += new System.EventHandler(this.btnConnectRun_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Interface";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Device";
            // 
            // tabPlcSetting
            // 
            this.tabPlcSetting.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPlcSetting.Controls.Add(this.txtIPAddress);
            this.tabPlcSetting.Controls.Add(this.txtPort);
            this.tabPlcSetting.Controls.Add(this.content);
            this.tabPlcSetting.Controls.Add(this.label11);
            this.tabPlcSetting.Controls.Add(this.cbxTypeCommunication);
            this.tabPlcSetting.Location = new System.Drawing.Point(4, 4);
            this.tabPlcSetting.Name = "tabPlcSetting";
            this.tabPlcSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlcSetting.Size = new System.Drawing.Size(264, 696);
            this.tabPlcSetting.TabIndex = 0;
            this.tabPlcSetting.Text = "Plc Setting";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(44, 633);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(100, 20);
            this.txtIPAddress.TabIndex = 14;
            this.txtIPAddress.Visible = false;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(44, 607);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 13;
            this.txtPort.Visible = false;
            // 
            // content
            // 
            this.content.Location = new System.Drawing.Point(3, 53);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(261, 528);
            this.content.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 26);
            this.label11.TabIndex = 11;
            this.label11.Text = "Type \r\nCommunication";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbxTypeCommunication
            // 
            this.cbxTypeCommunication.FormattingEnabled = true;
            this.cbxTypeCommunication.Items.AddRange(new object[] {
            "SLMP",
            "TCP/IP"});
            this.cbxTypeCommunication.Location = new System.Drawing.Point(83, 17);
            this.cbxTypeCommunication.Name = "cbxTypeCommunication";
            this.cbxTypeCommunication.Size = new System.Drawing.Size(168, 21);
            this.cbxTypeCommunication.TabIndex = 10;
            this.cbxTypeCommunication.SelectedIndexChanged += new System.EventHandler(this.cbxTypeCommunication_SelectedIndexChanged);
            // 
            // tbVisionSetting
            // 
            this.tbVisionSetting.Controls.Add(this.panel4);
            this.tbVisionSetting.Location = new System.Drawing.Point(4, 4);
            this.tbVisionSetting.Name = "tbVisionSetting";
            this.tbVisionSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tbVisionSetting.Size = new System.Drawing.Size(264, 696);
            this.tbVisionSetting.TabIndex = 2;
            this.tbVisionSetting.Text = "Vision Setting";
            this.tbVisionSetting.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel4.Controls.Add(this.comboBox1);
            this.panel4.Controls.Add(this.btnshowModel);
            this.panel4.Controls.Add(this.btnLivesetting);
            this.panel4.Controls.Add(this.btnSnapsetting);
            this.panel4.Controls.Add(this.btnCreatRegion);
            this.panel4.Controls.Add(this.btnTrainModel);
            this.panel4.Controls.Add(this.btnTestTrain);
            this.panel4.Controls.Add(this.btnSave);
            this.panel4.Controls.Add(this.btnLoadImg);
            this.panel4.Controls.Add(this.btnModel);
            this.panel4.Location = new System.Drawing.Point(3, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(255, 684);
            this.panel4.TabIndex = 19;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(137, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(115, 21);
            this.comboBox1.TabIndex = 23;
            // 
            // btnshowModel
            // 
            this.btnshowModel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnshowModel.Location = new System.Drawing.Point(3, 229);
            this.btnshowModel.Name = "btnshowModel";
            this.btnshowModel.Size = new System.Drawing.Size(115, 29);
            this.btnshowModel.TabIndex = 22;
            this.btnshowModel.Text = "Show Model";
            this.btnshowModel.UseVisualStyleBackColor = true;
            this.btnshowModel.Click += new System.EventHandler(this.btnshowModel_Click);
            // 
            // btnLivesetting
            // 
            this.btnLivesetting.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLivesetting.Location = new System.Drawing.Point(137, 59);
            this.btnLivesetting.Name = "btnLivesetting";
            this.btnLivesetting.Size = new System.Drawing.Size(115, 34);
            this.btnLivesetting.TabIndex = 21;
            this.btnLivesetting.Text = "Live";
            this.btnLivesetting.UseVisualStyleBackColor = true;
            this.btnLivesetting.Click += new System.EventHandler(this.btnLivesetting_Click);
            // 
            // btnSnapsetting
            // 
            this.btnSnapsetting.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnapsetting.Location = new System.Drawing.Point(3, 59);
            this.btnSnapsetting.Name = "btnSnapsetting";
            this.btnSnapsetting.Size = new System.Drawing.Size(115, 34);
            this.btnSnapsetting.TabIndex = 20;
            this.btnSnapsetting.Text = "Snap";
            this.btnSnapsetting.UseVisualStyleBackColor = true;
            this.btnSnapsetting.Click += new System.EventHandler(this.btnSnapsetting_Click);
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 728);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmSetting";
            this.Text = "Setting";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSetting_FormClosed);
            this.Load += new System.EventHandler(this.frmTrain_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabDeviceSetting.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.pnFindCam.ResumeLayout(false);
            this.pnFindCam.PerformLayout();
            this.pnCurrentCam.ResumeLayout(false);
            this.pnCurrentCam.PerformLayout();
            this.tabPlcSetting.ResumeLayout(false);
            this.tabPlcSetting.PerformLayout();
            this.tbVisionSetting.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HalconDotNet.HSmartWindowControl WindowControl;
        private System.Windows.Forms.Button btnCreatRegion;
        private System.Windows.Forms.Button btnLoadImg;
        private System.Windows.Forms.Button btnTrainModel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnModel;
        private System.Windows.Forms.Button btnTestTrain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPlcSetting;
        private System.Windows.Forms.TabPage tabDeviceSetting;
        private System.Windows.Forms.Button btnSaveCamera;
        private System.Windows.Forms.ComboBox cbxInterface;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAutoDetect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxCamera;
        private System.Windows.Forms.Button btnCurrentConnect;
        private System.Windows.Forms.Panel pnFindCam;
        private System.Windows.Forms.Panel pnCurrentCam;
        private System.Windows.Forms.TextBox txtDevice;
        private System.Windows.Forms.TextBox txtInterface;
        private System.Windows.Forms.Button btnConnectRun;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tbVisionSetting;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSaveParametercam;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTimeout;
        private System.Windows.Forms.TextBox txtGain;
        private System.Windows.Forms.TextBox txtExposuretime;
        private System.Windows.Forms.Button btnLivesetting;
        private System.Windows.Forms.Button btnSnapsetting;
        private System.Windows.Forms.Button btnshowModel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbxTypeCommunication;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel content;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.TextBox txtPort;
    }
}