using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Administrator
    {
        public string userName { get; set; }
        public int ID { get; set; }
        public string password { get; set; }

        public override string ToString()
        {
            return $"id:{ID} name:{userName} password:{password}";
        }

    }
}
