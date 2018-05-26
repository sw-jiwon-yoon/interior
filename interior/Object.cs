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
        public string name;
        public string objType;

        // public Image texture;
    }

    public class ObjList : List<Object>
    {
        public void Add(string name, int x, int y, int z, string objType)
        {
            var data = new Object
            {
                name = name,
                x = x,
                y = y,
                z = z,
                objType = objType 
            };
            this.Add(data);
        }


    }
}
