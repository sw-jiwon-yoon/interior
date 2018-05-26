using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace interior
{
    public class Object
    {
        public int width;
        public int height;
        public string name;

        // public Image texture;
    }

    public class ObjList : List<Object>
    {
        public void Add(Point p1, Point p2, int height)
        {
            var data = new Object
            {
            };
            this.Add(data);
        }


    }
}
