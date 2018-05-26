using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using interior.Dialogs;

namespace interior
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnObjCreate_Click(object sender, EventArgs e)
        {
            DlgObjCreate dlgObjCreate = new DlgObjCreate();
            dlgObjCreate.ShowDialog();
            
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "XML-Files|*.xml";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                }
            }
        }

        private void 이미지로저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "BMP-Files|*.bmp";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int width = panel1.Size.Width;
                    int height = panel1.Size.Height;
                    Bitmap bm = new Bitmap(width, height);
                    panel1.DrawToBitmap(bm, new Rectangle(0, 0, width, height));
                    bm.Save(sfd.FileName);
                }   
            };
        }

        private void 끝내기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 제작ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout frmAbout = new FormAbout();
            frmAbout.ShowDialog();
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "XML-Files|*.xml";
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    
                }
            }
        }

        Pen pen = new Pen(Color.Black);
        Rectangle r = new Rectangle();
        bool isHold = false;
        Objlist rooms = new Objlist();
        Point start, end;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            int panel1Width = panel1.Size.Width;
            int panel1Height = panel1.Size.Height;

            r.Location = e.Location;
            isHold = true;
            start = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isHold)
            {
                int panel1Width = panel1.Size.Width;
                int panel1Height = panel1.Size.Height;

                int width = e.Location.X - r.Location.X;
                if (e.Location.X >= panel1Width)
                    width = panel1Width - r.Location.X;
                int height = e.Location.Y - r.Location.Y;
                if (e.Location.Y >= panel1Height)
                    height = panel1Height - r.Location.Y;

                r.Width = width;
                r.Height = height;

                panel1.Invalidate();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            int panel1Width = panel1.Size.Width;
            int panel1Height = panel1.Size.Height;
            //Console.WriteLine(string.Format("args1: {0} args2: {1}", panel1Width, panel1Height));
            end = e.Location;

            int width = end.X - r.Location.X;
            if (end.X >= panel1Width)
            {
                width = panel1Width - r.Location.X;
                end.X = panel1Width;
            }
                
            int height = end.Y - r.Location.Y;
            if (end.Y >= panel1Height)
            {
                height = panel1Height - r.Location.Y;
                end.Y = panel1Height;
            }

            r.Width = width;
            r.Height = height;

            //Console.WriteLine(string.Format("args1: {0} args2: {1}", end.X, end.Y));

            rooms.Add(start, end, 10);
            isHold = false;
            //panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, r);
        }
    }
}
