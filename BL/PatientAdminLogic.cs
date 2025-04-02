using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PatientAdminLogic
    {
        ReadWritePatient dal = new ReadWritePatient();
        public void addPatient(string fname, string lname, string email, long id, long pn, DateTime birthd, DateTime registration, string gender)
        {
            
            if (birthd > DateTime.Now)
                throw new Exception("not correct date");
            if ((from x in dal.PatientList() where x.IdP == id select x).FirstOrDefault() != null)
                throw new Exception("The ID number already exists in the system");

            dal.addPatient(fname, lname, email, id, pn, birthd, registration, gender);
        }

        public List<Patient> listPatient()
        {
            return dal.PatientList();
        }

        public void deletePatient(int id)
        {
            dal.deletePatient(id);
        }

        public void EditPatient(string fname, string lname, string email, long id, long pn, DateTime dateofbirth, DateTime dateofRegistration, string gender)
        {
            dal.EditPatient(fname,lname,  email,id, pn, dateofbirth, dateofRegistration, gender);
        }
    }
}
