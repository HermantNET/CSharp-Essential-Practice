using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Stack
    {
        int position;
        object[] data = new object[10];
        public void Push (object obj) { data[position++] = obj; }
        public object Pop() {
            if (position > data.GetLowerBound(0) & position < data.GetUpperBound(0)) { 
            return data[--position];
            } else { return "End of Stack"; }
        }
    }
}
