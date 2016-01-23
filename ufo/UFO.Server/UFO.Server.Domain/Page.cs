using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFO.Server.Domain
{
    [Serializable]
    public class Page
    {
        public int Offset { get; set; }
        public int Size { get; set; }

        public Page()
        {
            Offset = 0;
            Size = 50;
        }


        public void next()
        {
            Offset += Size;
        }
    }
}
