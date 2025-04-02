using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUI.Models
{
    public class AdministratorModel
    {
        public List <Administrator> administrator { get; set; }
       AdminLogic dl = new AdminLogic();
        public AdministratorModel()
        {
           // administrators = dl.getPassword();
        }

    }
}
