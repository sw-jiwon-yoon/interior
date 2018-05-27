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
    public partial class DlgObjEdit : Form
    {
        public DlgObjEdit()
        {
            InitializeComponent();
        }

        public int XGave
        { //가로
            get
            {
                return int.Parse(textBox1.Text);
            }

        }

        public int YGave
        { //가로
            get
            {
                return int.Parse(textBox2.Text);
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listObjEdit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
