using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace interior
{
    public class @object
    {
        public Point p1;
        public Point p2;
        public Size s1;
        public int height;

        // public Image texture;
    }

    public class objlist : List<@object>
    {
        public void Add(Point p1, Point p2, Size s1, int height)
        {
            var data = new @object
            {
                p1 = p1,
                p2 = p2,
                s1 = s1,
                height = height
            };
            this.Add(data);
        }


    }
}
