using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public class AdminLogic
    {
        public string getPassword()
        {
            ReadWriteAdmin dal = new ReadWriteAdmin();
            return dal.getPassword();
        }

    }
}
