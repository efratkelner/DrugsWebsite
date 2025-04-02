
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReadWriteDoctors
    {
        public bool InsertDoctor(string fname, string lname, string eMail, long id, long lic, long pn, string specialty,string gender)
        {
            bool Result = true;

            using (var ctx = new DrugsContext())
            {
                var doctor = new Doctor { FName = fname, LName = lname, email = eMail, IdP = id, Licensing = lic, PhonNumber = pn, Specialty = specialty, gender=gender };
                ctx.Doctor.Add(doctor);
                ctx.SaveChanges();
            }

            return Result;
        }

        public List<Doctor> DoctorsList()
        {
            List<Doctor> result = null;
            using (var ctx = new DrugsContext())
            {
                result = (from x in ctx.Doctor select x).ToList();
            }

            return result;
        }

        
        public void deleteDoctor(int id)
        {

            using (var ctx = new DrugsContext())
            {
                Doctor d = (from x in ctx.Doctor where x.Id == id select x).FirstOrDefault();
                ctx.Doctor.Remove(d);
                ctx.SaveChanges();
            }

        }

        public void EditDoctor(string fname, string lname, string email, long id, long licening, long pn, string specialty, string gender)
        {
            using (var ctx = new DrugsContext())
            {
                Doctor d = (from x in ctx.Doctor where x.IdP == id select x).FirstOrDefault();
                ctx.Doctor.Remove(d);
                ctx.SaveChanges();
            }
            InsertDoctor(fname, lname, email,  id,  licening, pn,  specialty, gender);
        }
    }
}
