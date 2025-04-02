using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GUI.Models
{
    public class AdministratorViewModel
    {
        private Administrator Cueernt;
        public int Id
        {
            get { return Cueernt.ID; }
            set { Cueernt.ID = value; }
        }
        [DisplayName("User Name:")]
        public string UserName
        {
            get { return Cueernt.userName; }
            set { Cueernt.userName = value; }
        }
        [DisplayName("Password:")]
       public string Password
       {
            get { return Cueernt.password; }
            set { Cueernt.password = value; }
       }

    }
}