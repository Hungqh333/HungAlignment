using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HQ
{
    public partial class usTCP : UserControl
    {
        public usTCP()
        {
            InitializeComponent();
        }

        private void btnListionTcp_Click(object sender, EventArgs e)
        {
            if (btnListionTcp.Text.ToLower() == "listen")
            {
                btnListionTcp.Text = "Close";
                btnListionTcp.Image = Image.FromFile(@"E:\13.ImgtoCode\delete_16px.png");
            } 
            else
            {
                btnListionTcp.Text = "Listen";
                btnListionTcp.Image = Image.FromFile(@"E:\13.ImgtoCode\running_16px.png");
            }    
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (btnDetail.Text.ToLower() == "detail")
            {
                grbDetail.Visible = true;
                btnDetail.Text = "Hide";
                btnDetail.Image = Image.FromFile(@"E:\13.ImgtoCode\hide_16px.png");
            }
            else
            {
                grbDetail.Visible = false;
                btnDetail.Text = "Detail";
                btnDetail.Image = Image.FromFile(@"E:\13.ImgtoCode\more_details_16px.png");

            }    
            
        }

        private void toolTipcontrol()
        {
            toolTip_Save.SetToolTip(btnSaveall, "Save All");
            toolTip_Edit.SetToolTip(btnEdit, "Edit");
        }

        private void UsTCP_Load(object sender, EventArgs e)
        {
            toolTipcontrol();

        }

        private void btnSaveall_Click(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text.ToLower() == "run")
            {
                btnConnect.Text = "Stop";
                btnConnect.Image = Image.FromFile(@"E:\13.ImgtoCode\delete_16px.png");
            }
            else
            {
                btnConnect.Text = "Run";
                btnConnect.Image = Image.FromFile(@"E:\13.ImgtoCode\running_16px.png");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            pnEdit.Enabled = true;
        }
    }
}
