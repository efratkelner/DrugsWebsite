using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DoctorAdminLogic
    {
        ReadWriteDoctors dal = new ReadWriteDoctors();
        public void AddDoctor(string fname, string lname, string email, long id, long lic, long pn, string specialty,string gender)
        {
            
           if ((from x in dal.DoctorsList() where x.IdP == id select x).FirstOrDefault() != null)
                throw new Exception("The ID number already exists in the system");
            dal.InsertDoctor(fname, lname, email, id, lic, pn, specialty,gender);
        }

        public List<Doctor> listDoctors()
        {
            return dal.DoctorsList();
        }

        public void deleteDoctor(int id)
        {
            dal.deleteDoctor(id);
        }

        public void EditDoctor(string fname, string lname, string email, long id, long licening, long pn, string specialty, string gender)
        {
            dal.EditDoctor(fname,lname, email, id, licening, pn,specialty, gender);
        }
    }
}
