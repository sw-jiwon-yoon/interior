﻿using System;
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
        public string TypeGave
        {
            get
            {
                return listType.SelectedItem.ToString();
            }

        }

        public string NameGave
        {
            get
            {
                return txtObjname.Text; 
            }

        }

        public int XGave
        { //가로
            get
            {
                return int.Parse(txtX.Text);
            }

        }

        public int YGave
        { //세로
            get
            {
                return int.Parse(txtY.Text);
            }

        }

        public int ZGave
        { //높이
            get
            {
                return int.Parse(txtZ.Text);
            }
        }

        public DlgObjCreate()
        {
            InitializeComponent();
            lblName.Visible = false;
            txtObjname.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            txtX.Visible = false;
            txtY.Visible = false;
            txtZ.Visible = false;
            listType.SetSelected(0, true);
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
                lblName.Visible = false;
                txtObjname.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                txtX.Visible = false;
                txtY.Visible = false;
                txtZ.Visible = false;
            }
            else
            {
                lblName.Visible = true;
                txtObjname.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                txtX.Visible = true;
                txtY.Visible = true;
                txtZ.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void listType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnUsrObj_Click(object sender, EventArgs e)
        {
            listType.Items.Add(txtUsrObj.Text);
        }
    }
}
