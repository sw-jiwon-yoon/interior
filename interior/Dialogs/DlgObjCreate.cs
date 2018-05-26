using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interior.Dialogs
{
    public partial class DlgObjCreate : Form
    {
        public DlgObjCreate()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtY_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listType_Click(object sender, EventArgs e)
        {
            if(listType.SelectedIndex == 0 || listType.SelectedIndex == 1)
            {
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                txtX.Visible = false;
                txtY.Visible = false;
                txtZ.Visible = false;
            }
            else
            {
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                txtX.Visible = true;
                txtY.Visible = true;
                txtZ.Visible = true;
            }
        }
    }
}
