using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml.Serialization;
using System.IO;

using interior.Dialogs;

namespace interior
{
    public partial class FrmMain : Form
    {

        public int mode;

        public FrmMain()
        {
            mode = 0;
            InitializeComponent();
        }

        private void btnObjCreate_Click(object sender, EventArgs e)
        {
            DlgObjCreate dlgObjCreate = new DlgObjCreate();
            dlgObjCreate.ShowDialog();
            if(dlgObjCreate.DialogResult == DialogResult.OK)
            {
                mode = 1;
            }

        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "XML-Files|*.xml";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Wall>));
                    using (StreamWriter sw = new StreamWriter(Path.GetFullPath(sfd.FileName)))
                    {
                        serializer.Serialize(sw, rooms);
                    }
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
        Walllist rooms = new Walllist();
        Point start, end;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (mode == 0)
            {
                int panel1Width = panel1.Size.Width;
                int panel1Height = panel1.Size.Height;

                r.Location = e.Location;
                isHold = true;
                start = e.Location;
            } else if (mode == 2)
            {
                start = e.Location;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mode == 0)
            {
                if (isHold)
                {
                    int panel1Width = panel1.Size.Width;
                    int panel1Height = panel1.Size.Height;

                    //좌표 값이 넘어가게되면 panel의 끝 좌표를 넣어준다.

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
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (mode == 0)
            {
                int panel1Width = panel1.Size.Width;
                int panel1Height = panel1.Size.Height;
                //Console.WriteLine(string.Format("args1: {0} args2: {1}", panel1Width, panel1Height));
                end = e.Location;

                //좌표 값이 넘어가게되면 panel의 끝 좌표를 넣어준다.
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

                isHold = false; // 마우스 클릭 해제

                // 좌에서 우로 그릴 시에만 room과 listRoom에 넣게 해준다.
                if (start.X < end.X && start.Y < end.Y)
                {
                    rooms.Add(start, end, 10);
                    listRoom.Items.Add(rooms.LongCount() + " : (" + rooms.Last().p1.X + " " + rooms.Last().p1.Y + ") , (" + rooms.Last().p2.X + " " + rooms.Last().p2.Y + ") " + rooms.Last().height);


                    //panel1.Invalidate();

                    lblWarn.Text = rooms.Last().p1.X + " " + rooms.Last().p1.Y + " " + rooms.Last().p2.X + " " + rooms.Last().p2.Y + " " + rooms.Last().height;
                }
            }
            else if (mode == 2)
            {
                end = e.Location;

                double distance = Math.Sqrt((double)((start.X - end.X) * (start.X - end.X) + (start.Y - end.Y) * (start.Y - end.Y)));
                MessageBox.Show(string.Format("길이 : {0,0:F2}", distance));
                mode = 0;
            }

            panel1.Invalidate();
        }
        private void btnRoomRemove_Click(object sender, EventArgs e)
        {
            listRoom.Items.Remove(listRoom.SelectedItem);

        }

        private void btnMeasure_Click(object sender, EventArgs e)
        {
            mode = 2;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Wall o in rooms)
            {
                Rectangle temp = new Rectangle(o.p1.X, o.p1.Y, o.p2.X - o.p1.X, o.p2.Y - o.p1.Y);
                e.Graphics.DrawRectangle(pen, temp);
            }
        }
    }
}