using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WuXiXiao {
    public class Inheritance {
        internal string name { get; set; }
        internal int age { get; set; }

        public Inheritance (string strName, int intAge) { name = strName; age = intAge; }
    }

    class XiaoWu : Inheritance {
        bool honorable { get; set; }
        int spiritlevel { get; set; }

        public XiaoWu(string strName, int intAge, bool bHonor, int intSpirit): base(strName, intAge) { honorable = bHonor; spiritlevel = intSpirit; }

        public override string ToString() {
            return "Name: " + name + " | Age: " + age.ToString() + " | Honorable: " + honorable.ToString() + " | Spirit Level: " + spiritlevel.ToString() ;
        }
    }

    public class WanWan : Inheritance {
        internal string _bark { get; set; }

        public WanWan (string strName, int intAge, string strBark): base(strName, intAge) { _bark = strBark; }

        public virtual void Bark() {
            Console.WriteLine(_bark);
        }
    }

    public class LiWanWan : WanWan {
        string type { get; set; }

        public LiWanWan (string strName, int intAge, string strBark, string strType): base(strName, intAge, strBark) { type = strType; }

        public sealed override void Bark() {
            Console.WriteLine(_bark + "!");
        }
    }
}
