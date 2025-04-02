using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReadWritePatient
    {
        public bool addPatient(string fname, string lname, string eMail, long id, long pn, DateTime birthd, DateTime registration, string Gender)
        {
            bool Result = true;

            using (var ctx = new DrugsContext())
            {
                var patient = new Patient { FName = fname, LName = lname, email = eMail, DateOfBirthd = birthd, DateOfRegistration = registration, IdP = id, PhonNumber = pn, gender = Gender };
                ctx.Patients.Add(patient);
                ctx.SaveChanges();
            }

            return Result;
        }

        public List<Patient> PatientList()
        {
            List<Patient> result = null;
            using (var ctx = new DrugsContext())
            {
                result = (from x in ctx.Patients select x).ToList();
            }

            return result;
        }

        public void deletePatient(int id)
        {

            using (var ctx = new DrugsContext())
            {
                Patient p = (from x in ctx.Patients where x.Id == id select x).FirstOrDefault();
                ctx.Patients.Remove(p);
                ctx.SaveChanges();
            }

        }

        public void EditPatient(string fname, string lname, string email, long id, long pn, DateTime dateofbirth, DateTime dateofRegistration, string gender)
        {
            using (var ctx = new DrugsContext())
            {
                Patient p = (from x in ctx.Patients where x.IdP== id select x).FirstOrDefault();
                ctx.Patients.Remove(p);
                ctx.SaveChanges();
            }
            addPatient(fname, lname, email, id, pn, dateofbirth,  dateofRegistration,  gender);
        }
    }
}
