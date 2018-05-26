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
            r.Location = e.Location;
            isHold = true;
            start = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isHold)
            {
                int width = e.Location.X - r.Location.X;
                int height = e.Location.Y - r.Location.Y;
                r.Width = width;
                r.Height = height;

                panel1.Invalidate();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            int width = e.Location.X - r.Location.X;
            int height = e.Location.Y - r.Location.Y;
            if (width > 0 && height > 0)
            {
                r.Width = width;
                r.Height = height;

                end = e.Location;

                rooms.Add(start, end, 10);
            }
            isHold = false;
<<<<<<< HEAD
            panel1.Invalidate();

            listRoom.Items.Add(rooms.LongCount() + " : (" + rooms.Last().p1.X + " " + rooms.Last().p1.Y + ") , (" + rooms.Last().p2.X + " " + rooms.Last().p2.Y + ") " + rooms.Last().height);

=======
            //         panel1.Invalidate();
>>>>>>> 470a54a7ef3ab488e7ebedc50b4cb5612d52616a
            lblWarn.Text = rooms.Last().p1.X + " " + rooms.Last().p1.Y + " " + rooms.Last().p2.X + " " + rooms.Last().p2.Y + " " + rooms.Last().height;
        }

        private void btnRoomRemove_Click(object sender, EventArgs e)
        {
            listRoom.Items.Remove(listRoom.SelectedItem);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach(Object o in rooms)
            {
                Rectangle temp = new Rectangle(o.p1.X, o.p1.Y, o.p2.X - o.p1.X, o.p2.Y - o.p1.Y);
                e.Graphics.DrawRectangle(pen, temp);
            }
        }
    }
}
