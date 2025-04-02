using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class ReadWriteAdmin
    {
        public string getPassword()
        {
            string password = null;
            using (var ctx = new DrugsContext())
            {
                password = (from x in ctx.Administrators select x.password).FirstOrDefault();
            }
            return password;
        }
       
    }
}
