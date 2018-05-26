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

        public int mode; // 0일때 방 추가모드, 1일때 객체 추가모드
        int x;
        int y;
        int z;
        string objType;
        string objName;
        

        public FrmMain()
        {
            mode = 0; 
            InitializeComponent();
        }

        Image objimage;

 
        private void btnObjCreate_Click(object sender, EventArgs e)
        {
            DlgObjCreate dlgObjCreate = new DlgObjCreate();
            dlgObjCreate.ShowDialog();

            if(dlgObjCreate.DialogResult == DialogResult.OK)
            {

                objType = dlgObjCreate.TypeGave;
                objName = dlgObjCreate.NameGave;
                if (objType == "문" || objType == "창문")
                {

                }
                else
                {

                    x = dlgObjCreate.XGave;
                    y = dlgObjCreate.YGave;
                    z = dlgObjCreate.ZGave;
                }
                mode = 1;

            }
            else { mode = 0; }

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
        Pen redPen = new Pen(Color.Red);
        Pen bluePen = new Pen(Color.Blue);
        Pen purplePen = new Pen(Color.Purple);
        bool isHold = false;
        Point start, end;
        Walllist rooms = new Walllist();
        ObjList objs = new ObjList();

        

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (mode == 0)
            {
                int panel1Width = panel1.Size.Width;
                int panel1Height = panel1.Size.Height;

                r.Location = e.Location;
                isHold = true;
                start = e.Location;
            }
            else if(mode == 1) // 객체추가모드
            {
                // 일단 비워둔다.
            }
            else if (mode == 2)
            {
                isHold = true;
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
            else if(mode == 2)
            {
                if (isHold)
                {
                    panel1.CreateGraphics().DrawLine(purplePen, start, e.Location);
                    panel1.Invalidate();
                }
            }
        }

        Rectangle srcRect;

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (mode == 0)
            {
                int panel1Width = panel1.Size.Width;
                int panel1Height = panel1.Size.Height;
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
                    // 충돌이 일어나는 지 확인해서, 충돌이 일어나지 않는다면 rooms에 넣는다
                    bool conflict_chk = false;
                    foreach (Wall o in rooms)
                    {

                        if ((o.p2.X <= start.X) || (end.X <= o.p1.X) || (o.p2.Y <= start.Y) || (end.Y <= o.p1.Y))   // 만족하면 충돌이 없다.
                        {
                            continue;
                        }
                        else  // 충돌이 일어날 경우
                        {
                            if (((o.p1.X < start.X) && (o.p1.Y < start.Y) && (o.p2.X > end.X) && (o.p2.Y > end.Y)) || ((o.p1.X > start.X) && (o.p1.Y > start.Y) && (o.p2.X < end.X) && (o.p2.Y < end.Y))) // 방을 품는 좌표일 시, 충돌이 없다.
                            {
                                continue;
                            }
                            conflict_chk = true;
                            break;
                        }
                    }
                    if (!conflict_chk)  // 충돌이 없어야 rooms에 넣는다.
                    {
                        rooms.Add(start, end, 10);
                        listRoom.Items.Add(rooms.LongCount() + " : (" + rooms.Last().p1.X + " " + rooms.Last().p1.Y + ") , (" + rooms.Last().p2.X + " " + rooms.Last().p2.Y + ") " + rooms.Last().height);
                        lblWarn.Text = rooms.Last().p1.X + " " + rooms.Last().p1.Y + " " + rooms.Last().p2.X + " " + rooms.Last().p2.Y + " " + rooms.Last().height;
                    }

                }
                panel1.Invalidate();

            }
            else if (mode == 1)
            {
                isHold = false;

                // 마그네틱을 이용해서 문과 창문을 가까운 벽에 붙여준다.(창문과 문의 크기는 무시한다)
                // 맨하튼 거리를 사용해서 거리를 측정한다.
                // 모두 50보다 멀면 생성되지 않는다.
                if (objType == "문" || objType == "창문")
                {
                    Point nearest_coordinate = new Point();
                    int nearest_dist = 1000000;
                    int temp_dist;
                    foreach (Wall o in rooms)
                    {
                        if (e.Location.Y <= o.p1.Y)
                        {
                            if (e.Location.X <= o.p1.X)
                            {
                                temp_dist = Math.Abs(o.p1.X - e.Location.X) + Math.Abs(o.p1.Y - e.Location.Y);
                                if (nearest_dist >= temp_dist)
                                {
                                    nearest_dist = temp_dist;
                                    nearest_coordinate.X = o.p1.X;
                                    nearest_coordinate.Y = o.p1.Y;
                                }
                            }
                            else if (e.Location.X <= o.p2.X)
                            {
                                temp_dist = Math.Abs(o.p1.Y - e.Location.Y);
                                if (nearest_dist >= temp_dist)
                                {
                                    nearest_dist = temp_dist;
                                    nearest_coordinate.X = e.Location.X;
                                    nearest_coordinate.Y = o.p1.Y;
                                }
                            }
                            else
                            {
                                temp_dist = Math.Abs(o.p2.X - e.Location.X) + Math.Abs(o.p1.Y - e.Location.Y);
                                if (nearest_dist >= temp_dist)
                                {
                                    nearest_dist = temp_dist;
                                    nearest_coordinate.X = o.p2.X;
                                    nearest_coordinate.Y = o.p1.Y;
                                }
                            }
                        }
                        else if (e.Location.Y <= o.p2.Y)
                        {
                            if (e.Location.X <= o.p1.X)
                            {
                                temp_dist = Math.Abs(o.p1.X - e.Location.X);
                                if (nearest_dist >= temp_dist)
                                {
                                    nearest_dist = temp_dist;
                                    nearest_coordinate.X = o.p1.X;
                                    nearest_coordinate.Y = e.Location.Y;
                                }
                            }
                            else if (e.Location.X <= o.p2.X)
                            {
                                temp_dist = Math.Abs(o.p1.Y - e.Location.Y);
                                if (nearest_dist >= temp_dist)
                                {
                                    nearest_dist = temp_dist;
                                    nearest_coordinate.X = e.Location.X;
                                    nearest_coordinate.Y = o.p1.Y;
                                }
                                temp_dist = Math.Abs(o.p2.X - e.Location.X);
                                if (nearest_dist >= temp_dist)
                                {
                                    nearest_dist = temp_dist;
                                    nearest_coordinate.X = o.p2.X;
                                    nearest_coordinate.Y = e.Location.Y;
                                }
                                temp_dist = Math.Abs(o.p2.Y - e.Location.Y);
                                if (nearest_dist >= temp_dist)
                                {
                                    nearest_dist = temp_dist;
                                    nearest_coordinate.X = e.Location.X;
                                    nearest_coordinate.Y = o.p2.Y;
                                }
                                temp_dist = Math.Abs(o.p1.X - e.Location.X);
                                if (nearest_dist >= temp_dist)
                                {
                                    nearest_dist = temp_dist;
                                    nearest_coordinate.X = o.p1.X;
                                    nearest_coordinate.Y = e.Location.Y;
                                }
                            }
                            else
                            {
                                temp_dist = Math.Abs(o.p2.X - e.Location.X);
                                if (nearest_dist >= temp_dist)
                                {
                                    nearest_dist = temp_dist;
                                    nearest_coordinate.X = o.p2.X;
                                    nearest_coordinate.Y = e.Location.Y;
                                }
                            }
                        }
                        else
                        {
                            if (e.Location.X <= o.p1.X)
                            {
                                temp_dist = Math.Abs(o.p1.X - e.Location.X) + Math.Abs(o.p2.Y - e.Location.Y);
                                if (nearest_dist >= temp_dist)
                                {
                                    nearest_dist = temp_dist;
                                    nearest_coordinate.X = o.p1.X;
                                    nearest_coordinate.Y = o.p2.Y;
                                }
                            }
                            else if (e.Location.X <= o.p2.X)
                            {
                                temp_dist = Math.Abs(o.p2.Y - e.Location.Y);
                                if (nearest_dist >= temp_dist)
                                {
                                    nearest_dist = temp_dist;
                                    nearest_coordinate.X = e.Location.X;
                                    nearest_coordinate.Y = o.p2.Y;
                                }
                            }
                            else
                            {
                                temp_dist = Math.Abs(o.p2.X - e.Location.X) + Math.Abs(o.p2.Y - e.Location.Y);
                                if (nearest_dist >= temp_dist)
                                {
                                    nearest_dist = temp_dist;
                                    nearest_coordinate.X = o.p2.X;
                                    nearest_coordinate.Y = o.p2.Y;
                                }
                            }
                        }
                    }
                    objs.Add(objName, nearest_coordinate, 10, 10, 10, objType); // 가장 가까운 점으로 보낸다.
                    listObj.Items.Add(objs.Last().name + " " + nearest_coordinate + " " + objs.Last().objType);
                }
                else // (mode == 1)
                {
                    // 객체가 벽과 충돌을 일으키는가 판단.
                    bool conflict_chk = false;
                    foreach (Wall o in rooms)
                    {
                        if ((o.p2.X <= e.Location.X) || (e.Location.X + x <= o.p1.X) || (o.p2.Y <= e.Location.Y) || (e.Location.Y + y <= o.p1.Y))   // 만족하면 충돌이 없다.
                        {
                            continue;
                        }
                        else  // 충돌이 일어날 경우
                        {
                            if (((o.p1.X < e.Location.X) && (o.p1.Y < e.Location.Y) && (o.p2.X > e.Location.X + x) && (o.p2.Y > e.Location.Y +y))) // 방을 품는 좌표일 시, 충돌이 없다.
                            {
                                continue;
                            }
                            conflict_chk = true;
                            break;
                        }
                    }
                    if (!conflict_chk)  // 충돌이 없어야 objs에 넣는다.
                    {
                        srcRect.Location = e.Location;
                        srcRect.Width = x;
                        srcRect.Height = y;
                        objs.Add(objName, e.Location, x, y, z, objType);
                        listObj.Items.Add(objs.Last().name + " " + e.Location + " " + objs.Last().objType);
                        
                    }

                    
                    //objs.Add(objName, e.Location, x, y, z, objType);
                    //listObj.Items.Add(objs.Last().name + " " + e.Location + " " + objs.Last().objType);
                }

                panel1.Refresh();

                mode = 0;
            }
            else if (mode == 2)
            {
                end = e.Location;
                panel1.Refresh();
                double distance = Math.Sqrt((double)((start.X - end.X) * (start.X - end.X) + (start.Y - end.Y) * (start.Y - end.Y)));
                MessageBox.Show(string.Format("길이 : {0,0:F2}", distance));
                mode = 0;
                isHold = false;
            }
            
        }
        private void btnRoomRemove_Click(object sender, EventArgs e)
        {
            if (listRoom.SelectedIndex >= 0)
            {
                rooms.RemoveAt(listRoom.SelectedIndex);
                listRoom.Items.Remove(listRoom.SelectedItem);

                panel1.Refresh();
            }
        }

        private void btnMeasure_Click(object sender, EventArgs e)
        {
            mode = 2;
        }

        private void 파일ToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            
        }

        private void 새로만들기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rooms.Clear();
            listRoom.Items.Clear();
            objs.Clear();
            listObj.Items.Clear();
            panel1.Refresh();
        }

        private void btnObjRemove_Click(object sender, EventArgs e)
        {
            if (listObj.SelectedIndex >= 0)
            {
                objs.RemoveAt(listObj.SelectedIndex);
                listObj.Items.Remove(listObj.SelectedItem);

                panel1.Refresh();
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Wall o in rooms)
            {
                Rectangle temp = new Rectangle(o.p1.X, o.p1.Y, o.p2.X - o.p1.X, o.p2.Y - o.p1.Y);
                e.Graphics.DrawRectangle(pen, temp);
            }
            foreach (Object o in objs)
            {
                Rectangle temp = new Rectangle(o.locP.X, o.locP.Y, 10, 10);
                if (o.objType == "문")
                    e.Graphics.DrawRectangle(redPen, temp);
                else if (o.objType == "창문")
                    e.Graphics.DrawRectangle(bluePen, temp);
                else
                {
                    if (o.objType == "컴퓨터")
                    {
                        objimage = Properties.Resources.computer;
                    }
                    else if (o.objType == "장롱")
                    {
                        objimage = Properties.Resources.closet;
                    }
                    temp.Width = o.x;
                    temp.Height = o.y;
                    temp.X = o.locP.X;
                    temp.Y = o.locP.Y;
                    Font drawFont = new Font("Arial", 10, FontStyle.Bold);
                    SolidBrush drawBrush = new SolidBrush(Color.Black);
                    Rectangle drawRect = new Rectangle(temp.X, temp.Y+o.y, o.x, o.y);
                    e.Graphics.DrawImage(objimage, temp);
                    e.Graphics.DrawString(o.name, drawFont, drawBrush, drawRect);
                }
            }
        }
    }
}