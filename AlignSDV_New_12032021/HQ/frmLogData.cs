using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTCVision;
namespace HQ
{
    public partial class frmLogData : Form
    {
        public frmLogData()
        {
            InitializeComponent();
        }
        List<clsLogData> _lstLogData = new List<clsLogData>();
        private void frmLogData_Load(object sender, EventArgs e)
        {
            //dateTimePicker1.Value
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
        void getdataLog()
        { 

                _lstLogData.Clear();
                string fileLoad = string.Format(Application.StartupPath + @"\Datalog\{0}.txt", DateTime.Now.ToString("yyyy-MM-dd"));
                if (!File.Exists(fileLoad)) return;
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
                    log.X = Lib.ToDouble(data[3]);
                    log.Y = Lib.ToDouble(data[4]);
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
                    txtTotalOK.Text = countAll.ToString();
                    txtTotalNG.Text = countNG.ToString();
                    txtTotalOK.Text = countOK.ToString();
                    //.OrderByDescending(o => Lib.ToInt(o.count)).Take(20).ToList();
                });
            

        }
    }
}
