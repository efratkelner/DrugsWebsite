using BL;
using GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogIn()
        {
           
            return View();
        }

        // POST: Medicine/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(FormCollection collection)//[Bind(Include ="password")] AdministratorViewModel adm) 
        {

            AdminLogic bl = new AdminLogic();
            DoctorAdminLogic bl2 = new DoctorAdminLogic();
            string password = collection["password"];
            if(bl.getPassword()==password)
            {
                //int y=0;
                return View("Index");
            }
            if(IsAllDigits(password))
            {
                var result = (from x in bl2.listDoctors() where x.IdP == Convert.ToInt64(password) select x).FirstOrDefault();
                if(result!=null)
                {
                    return RedirectToAction("Index","Prescription",new { id = password });
                }

            }
            ViewBag.Message = String.Format("The request to access has been failed, try again.");
            return View("LogIn");




        }
        public bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}