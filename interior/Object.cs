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
        public int x;
        public int y;
        public int z;
        public Point locP;
        public string name;
        public string objType;

        // public Image texture;
    }

    public class ObjList : List<Object>
    {
        public void Add(string name, Point locP,int x, int y, int z, string objType)
        {
            var data = new Object
            {
                name = name,
                locP = locP,
                x = x,
                y = y,
                z = z,
                objType = objType 
            };
            this.Add(data);
        }


    }
}
