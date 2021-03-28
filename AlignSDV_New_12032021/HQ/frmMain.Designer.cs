namespace HQ
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this._WindowControl = new HalconDotNet.HSmartWindowControl();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTiemcurrent = new System.Windows.Forms.Button();
            this.btnRunTest = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.LbModel = new System.Windows.Forms.Label();
            this.cboProgram = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnShowdata = new System.Windows.Forms.Panel();
            this.grvDatacurrent = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CellID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Theta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLogData = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnfrmSetting = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnfrmhandeyecalib = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtTotalNG = new System.Windows.Forms.TextBox();
            this.txtTotalOK = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnShowdata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvDatacurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // _WindowControl
            // 
            this._WindowControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._WindowControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._WindowControl.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this._WindowControl.HDoubleClickToFitContent = true;
            this._WindowControl.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None;
            this._WindowControl.HImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this._WindowControl.HKeepAspectRatio = true;
            this._WindowControl.HMoveContent = true;
            this._WindowControl.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;
            this._WindowControl.Location = new System.Drawing.Point(4, 3);
            this._WindowControl.Margin = new System.Windows.Forms.Padding(0);
            this._WindowControl.Name = "_WindowControl";
            this._WindowControl.Size = new System.Drawing.Size(820, 643);
            this._WindowControl.TabIndex = 9;
            this._WindowControl.WindowSize = new System.Drawing.Size(820, 643);
            this._WindowControl.Load += new System.EventHandler(this._WindowControl_Load);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.btnTiemcurrent);
            this.panel1.Controls.Add(this.btnRunTest);
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.LbModel);
            this.panel1.Controls.Add(this.cboProgram);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1433, 49);
            this.panel1.TabIndex = 10;
            // 
            // btnTiemcurrent
            // 
            this.btnTiemcurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTiemcurrent.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnTiemcurrent.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTiemcurrent.Location = new System.Drawing.Point(894, 0);
            this.btnTiemcurrent.Margin = new System.Windows.Forms.Padding(0);
            this.btnTiemcurrent.Name = "btnTiemcurrent";
            this.btnTiemcurrent.Size = new System.Drawing.Size(259, 49);
            this.btnTiemcurrent.TabIndex = 10;
            this.btnTiemcurrent.UseVisualStyleBackColor = false;
            // 
            // btnRunTest
            // 
            this.btnRunTest.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunTest.Location = new System.Drawing.Point(477, 6);
            this.btnRunTest.Name = "btnRunTest";
            this.btnRunTest.Size = new System.Drawing.Size(99, 35);
            this.btnRunTest.TabIndex = 9;
            this.btnRunTest.Text = "RUN TEST";
            this.btnRunTest.UseVisualStyleBackColor = true;
            this.btnRunTest.Click += new System.EventHandler(this.btnRunTest_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(170, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(93, 39);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "CONNECT";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Khaki;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 50);
            this.button1.TabIndex = 5;
            this.button1.Text = "RTC Alingment";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Image = ((System.Drawing.Image)(resources.GetObject("btnRun.Image")));
            this.btnRun.Location = new System.Drawing.Point(269, 5);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(72, 38);
            this.btnRun.TabIndex = 4;
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Tan;
            this.btnExit.Location = new System.Drawing.Point(1389, 11);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(31, 29);
            this.btnExit.TabIndex = 3;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // LbModel
            // 
            this.LbModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LbModel.AutoSize = true;
            this.LbModel.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.LbModel.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbModel.ForeColor = System.Drawing.Color.Firebrick;
            this.LbModel.Location = new System.Drawing.Point(1175, 12);
            this.LbModel.Name = "LbModel";
            this.LbModel.Size = new System.Drawing.Size(78, 26);
            this.LbModel.TabIndex = 2;
            this.LbModel.Text = "Model";
            // 
            // cboProgram
            // 
            this.cboProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProgram.FormattingEnabled = true;
            this.cboProgram.Location = new System.Drawing.Point(1259, 11);
            this.cboProgram.Name = "cboProgram";
            this.cboProgram.Size = new System.Drawing.Size(121, 28);
            this.cboProgram.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.pnShowdata);
            this.panel2.Controls.Add(this._WindowControl);
            this.panel2.Location = new System.Drawing.Point(1, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1433, 649);
            this.panel2.TabIndex = 11;
            // 
            // pnShowdata
            // 
            this.pnShowdata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnShowdata.Controls.Add(this.button2);
            this.pnShowdata.Controls.Add(this.grvDatacurrent);
            this.pnShowdata.Controls.Add(this.btnLogData);
            this.pnShowdata.Controls.Add(this.dataGridView2);
            this.pnShowdata.Controls.Add(this.btnfrmSetting);
            this.pnShowdata.Controls.Add(this.label1);
            this.pnShowdata.Controls.Add(this.label2);
            this.pnShowdata.Controls.Add(this.label3);
            this.pnShowdata.Controls.Add(this.btnfrmhandeyecalib);
            this.pnShowdata.Controls.Add(this.txtTotal);
            this.pnShowdata.Controls.Add(this.txtTotalNG);
            this.pnShowdata.Controls.Add(this.txtTotalOK);
            this.pnShowdata.Location = new System.Drawing.Point(827, 5);
            this.pnShowdata.Name = "pnShowdata";
            this.pnShowdata.Size = new System.Drawing.Size(606, 646);
            this.pnShowdata.TabIndex = 23;
            // 
            // grvDatacurrent
            // 
            this.grvDatacurrent.AllowUserToDeleteRows = false;
            this.grvDatacurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grvDatacurrent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvDatacurrent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.CellID,
            this.Date,
            this.X,
            this.Y,
            this.Z,
            this.Theta,
            this.Result});
            this.grvDatacurrent.Location = new System.Drawing.Point(3, 176);
            this.grvDatacurrent.Name = "grvDatacurrent";
            this.grvDatacurrent.ReadOnly = true;
            this.grvDatacurrent.Size = new System.Drawing.Size(599, 365);
            this.grvDatacurrent.TabIndex = 10;
            // 
            // No
            // 
            this.No.HeaderText = "No.";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 65;
            // 
            // CellID
            // 
            this.CellID.HeaderText = "Cell ID";
            this.CellID.Name = "CellID";
            this.CellID.ReadOnly = true;
            this.CellID.Width = 120;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 120;
            // 
            // X
            // 
            this.X.HeaderText = "Y";
            this.X.Name = "X";
            this.X.ReadOnly = true;
            this.X.Width = 50;
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            this.Y.ReadOnly = true;
            this.Y.Width = 50;
            // 
            // Z
            // 
            this.Z.HeaderText = "Z";
            this.Z.Name = "Z";
            this.Z.ReadOnly = true;
            this.Z.Width = 50;
            // 
            // Theta
            // 
            this.Theta.HeaderText = "Theta";
            this.Theta.Name = "Theta";
            this.Theta.ReadOnly = true;
            this.Theta.Width = 50;
            // 
            // Result
            // 
            this.Result.HeaderText = "Result";
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            this.Result.Width = 50;
            // 
            // btnLogData
            // 
            this.btnLogData.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogData.Location = new System.Drawing.Point(496, 2);
            this.btnLogData.Name = "btnLogData";
            this.btnLogData.Size = new System.Drawing.Size(95, 23);
            this.btnLogData.TabIndex = 22;
            this.btnLogData.Text = "LogData";
            this.btnLogData.UseVisualStyleBackColor = true;
            this.btnLogData.Click += new System.EventHandler(this.btnLogData_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 547);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(599, 96);
            this.dataGridView2.TabIndex = 11;
            // 
            // btnfrmSetting
            // 
            this.btnfrmSetting.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfrmSetting.Location = new System.Drawing.Point(260, 3);
            this.btnfrmSetting.Name = "btnfrmSetting";
            this.btnfrmSetting.Size = new System.Drawing.Size(95, 23);
            this.btnfrmSetting.TabIndex = 21;
            this.btnfrmSetting.Text = "Setting";
            this.btnfrmSetting.UseVisualStyleBackColor = true;
            this.btnfrmSetting.Click += new System.EventHandler(this.btnfrmSetting_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "TOTAL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 22);
            this.label2.TabIndex = 13;
            this.label2.Text = "TOTAL OK";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 22);
            this.label3.TabIndex = 14;
            this.label3.Text = "TOTAL NG";
            // 
            // btnfrmhandeyecalib
            // 
            this.btnfrmhandeyecalib.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfrmhandeyecalib.Location = new System.Drawing.Point(8, 2);
            this.btnfrmhandeyecalib.Name = "btnfrmhandeyecalib";
            this.btnfrmhandeyecalib.Size = new System.Drawing.Size(95, 23);
            this.btnfrmhandeyecalib.TabIndex = 18;
            this.btnfrmhandeyecalib.Text = "HE-Calib";
            this.btnfrmhandeyecalib.UseVisualStyleBackColor = true;
            this.btnfrmhandeyecalib.Click += new System.EventHandler(this.btnfrmhandeyecalib_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(124, 53);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 26);
            this.txtTotal.TabIndex = 15;
            // 
            // txtTotalNG
            // 
            this.txtTotalNG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalNG.Location = new System.Drawing.Point(124, 134);
            this.txtTotalNG.Name = "txtTotalNG";
            this.txtTotalNG.Size = new System.Drawing.Size(100, 26);
            this.txtTotalNG.TabIndex = 17;
            // 
            // txtTotalOK
            // 
            this.txtTotalOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalOK.Location = new System.Drawing.Point(124, 90);
            this.txtTotalOK.Name = "txtTotalOK";
            this.txtTotalOK.Size = new System.Drawing.Size(100, 26);
            this.txtTotalOK.TabIndex = 16;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(260, 111);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "Setting";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1433, 712);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnShowdata.ResumeLayout(false);
            this.pnShowdata.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvDatacurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private HalconDotNet.HSmartWindowControl _WindowControl;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label LbModel;
        private System.Windows.Forms.ComboBox cboProgram;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnfrmhandeyecalib;
        private System.Windows.Forms.TextBox txtTotalNG;
        private System.Windows.Forms.TextBox txtTotalOK;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView grvDatacurrent;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnfrmSetting;
        private System.Windows.Forms.Button btnLogData;
        private System.Windows.Forms.Panel pnShowdata;
        private System.Windows.Forms.Button btnRunTest;
        private System.Windows.Forms.Button btnTiemcurrent;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn CellID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Z;
        private System.Windows.Forms.DataGridViewTextBoxColumn Theta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.Button button2;
    }
}