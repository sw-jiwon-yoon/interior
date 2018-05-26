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
        public Point p1;
        public Point p2;
        public int height;

        // public Image texture;
    }

    public class Objlist : List<Object>
    {
        public void Add(Point p1, Point p2, int height)
        {
            var data = new Object
            {
                p1 = p1,
                p2 = p2,
                height = height
            };
            this.Add(data);
        }


    }
}
