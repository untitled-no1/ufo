using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFO.Server.Domain
{
    public class Page
    {
        private int offset;
        private int size;

        public Page()
        {
            offset = 0;
            size = 50;
        }

        public int getOffset()
        {
            return offset;
        }

        public void setOffset(int o)
        {
            offset = o;
        }

        public int getSize()
        {
            return size;
        }
        

        public void next()
        {
            offset += size;
        }

        public void previous()
        {
            offset -= size;
        }

        public void reset()
        {
            offset = 0;
        }

        public void resize(int s)
        {
            size = s;
        }
    }
}
