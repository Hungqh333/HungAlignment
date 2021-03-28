namespace ConnecterTest
{
    partial class FormTest
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
            this.btnSendData = new System.Windows.Forms.Button();
            this.btnReceiveData = new System.Windows.Forms.Button();
            this.btnConnection = new System.Windows.Forms.Button();
            this.btnDisconnection = new System.Windows.Forms.Button();
            this.txtRecdataWord = new System.Windows.Forms.TextBox();
            this.txtsendDataBit = new System.Windows.Forms.TextBox();
            this.txtRecdataBit = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.nbrDataSend = new System.Windows.Forms.NumericUpDown();
            this.btnConectaCam = new System.Windows.Forms.Button();
            this.btnDisConectCam = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbxInterface = new System.Windows.Forms.ComboBox();
            this.cbxCamera = new System.Windows.Forms.ComboBox();
            this.WindowControl = new HalconDotNet.HSmartWindowControl();
            ((System.ComponentModel.ISupportInitialize)(this.nbrDataSend)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSendData
            // 
            this.btnSendData.Location = new System.Drawing.Point(31, 466);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(123, 33);
            this.btnSendData.TabIndex = 0;
            this.btnSendData.Text = "SendData Data";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // btnReceiveData
            // 
            this.btnReceiveData.Location = new System.Drawing.Point(31, 358);
            this.btnReceiveData.Name = "btnReceiveData";
            this.btnReceiveData.Size = new System.Drawing.Size(123, 35);
            this.btnReceiveData.TabIndex = 1;
            this.btnReceiveData.Text = "Receive Data";
            this.btnReceiveData.UseVisualStyleBackColor = true;
            this.btnReceiveData.Click += new System.EventHandler(this.btnReceiveData_Click);
            // 
            // btnConnection
            // 
            this.btnConnection.Location = new System.Drawing.Point(31, 230);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(123, 33);
            this.btnConnection.TabIndex = 2;
            this.btnConnection.Text = "Connection PLC";
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // btnDisconnection
            // 
            this.btnDisconnection.Location = new System.Drawing.Point(31, 279);
            this.btnDisconnection.Name = "btnDisconnection";
            this.btnDisconnection.Size = new System.Drawing.Size(123, 35);
            this.btnDisconnection.TabIndex = 3;
            this.btnDisconnection.Text = "Disconnection PLC";
            this.btnDisconnection.UseVisualStyleBackColor = true;
            this.btnDisconnection.Click += new System.EventHandler(this.btnDisconnection_Click);
            // 
            // txtRecdataWord
            // 
            this.txtRecdataWord.Location = new System.Drawing.Point(176, 373);
            this.txtRecdataWord.Name = "txtRecdataWord";
            this.txtRecdataWord.Size = new System.Drawing.Size(125, 20);
            this.txtRecdataWord.TabIndex = 7;
            // 
            // txtsendDataBit
            // 
            this.txtsendDataBit.Location = new System.Drawing.Point(176, 453);
            this.txtsendDataBit.Name = "txtsendDataBit";
            this.txtsendDataBit.Size = new System.Drawing.Size(125, 20);
            this.txtsendDataBit.TabIndex = 6;
            // 
            // txtRecdataBit
            // 
            this.txtRecdataBit.Location = new System.Drawing.Point(176, 347);
            this.txtRecdataBit.Name = "txtRecdataBit";
            this.txtRecdataBit.Size = new System.Drawing.Size(125, 20);
            this.txtRecdataBit.TabIndex = 8;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(31, 539);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(123, 33);
            this.btnStop.TabIndex = 10;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // nbrDataSend
            // 
            this.nbrDataSend.Location = new System.Drawing.Point(176, 479);
            this.nbrDataSend.Name = "nbrDataSend";
            this.nbrDataSend.Size = new System.Drawing.Size(125, 20);
            this.nbrDataSend.TabIndex = 11;
            // 
            // btnConectaCam
            // 
            this.btnConectaCam.Location = new System.Drawing.Point(31, 51);
            this.btnConectaCam.Name = "btnConectaCam";
            this.btnConectaCam.Size = new System.Drawing.Size(123, 33);
            this.btnConectaCam.TabIndex = 12;
            this.btnConectaCam.Text = "Connection Cam";
            this.btnConectaCam.UseVisualStyleBackColor = true;
            this.btnConectaCam.Click += new System.EventHandler(this.btnConectaCam_Click);
            // 
            // btnDisConectCam
            // 
            this.btnDisConectCam.Location = new System.Drawing.Point(31, 101);
            this.btnDisConectCam.Name = "btnDisConectCam";
            this.btnDisConectCam.Size = new System.Drawing.Size(123, 35);
            this.btnDisConectCam.TabIndex = 13;
            this.btnDisConectCam.Text = "Disconnect Cam";
            this.btnDisConectCam.UseVisualStyleBackColor = true;
            this.btnDisConectCam.Click += new System.EventHandler(this.btnDisConectCam_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 33);
            this.button1.TabIndex = 15;
            this.button1.Text = "Autodetection";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbxInterface
            // 
            this.cbxInterface.FormattingEnabled = true;
            this.cbxInterface.Location = new System.Drawing.Point(180, 19);
            this.cbxInterface.Name = "cbxInterface";
            this.cbxInterface.Size = new System.Drawing.Size(121, 21);
            this.cbxInterface.TabIndex = 16;
            this.cbxInterface.SelectedIndexChanged += new System.EventHandler(this.cbxInterface_SelectedIndexChanged);
            // 
            // cbxCamera
            // 
            this.cbxCamera.FormattingEnabled = true;
            this.cbxCamera.Location = new System.Drawing.Point(180, 58);
            this.cbxCamera.Name = "cbxCamera";
            this.cbxCamera.Size = new System.Drawing.Size(121, 21);
            this.cbxCamera.TabIndex = 17;
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
            this.WindowControl.Location = new System.Drawing.Point(365, 19);
            this.WindowControl.Margin = new System.Windows.Forms.Padding(0);
            this.WindowControl.Name = "WindowControl";
            this.WindowControl.Size = new System.Drawing.Size(997, 540);
            this.WindowControl.TabIndex = 18;
            this.WindowControl.WindowSize = new System.Drawing.Size(997, 540);
            this.WindowControl.Load += new System.EventHandler(this.WindowControl_Load);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 612);
            this.Controls.Add(this.WindowControl);
            this.Controls.Add(this.cbxCamera);
            this.Controls.Add(this.cbxInterface);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDisConectCam);
            this.Controls.Add(this.btnConectaCam);
            this.Controls.Add(this.nbrDataSend);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.txtRecdataBit);
            this.Controls.Add(this.txtRecdataWord);
            this.Controls.Add(this.txtsendDataBit);
            this.Controls.Add(this.btnDisconnection);
            this.Controls.Add(this.btnConnection);
            this.Controls.Add(this.btnReceiveData);
            this.Controls.Add(this.btnSendData);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.Load += new System.EventHandler(this.FormTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nbrDataSend)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.Button btnReceiveData;
        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.Button btnDisconnection;
        private System.Windows.Forms.TextBox txtRecdataWord;
        private System.Windows.Forms.TextBox txtsendDataBit;
        private System.Windows.Forms.TextBox txtRecdataBit;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.NumericUpDown nbrDataSend;
        private System.Windows.Forms.Button btnConectaCam;
        private System.Windows.Forms.Button btnDisConectCam;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbxInterface;
        private System.Windows.Forms.ComboBox cbxCamera;
        private HalconDotNet.HSmartWindowControl WindowControl;
    }
}

