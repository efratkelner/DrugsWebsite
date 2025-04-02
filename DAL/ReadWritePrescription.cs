using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReadWritePrescription
    {
        public bool AddPrescription(string medicine, string Notes, long doctor, long patient, DateTime start, DateTime end)
        {
            bool Result = true;

            using (var ctx = new DrugsContext())
            {
                var prescription = new Prescription { doctorId = doctor, patientId = patient, medicineName = medicine, notes = Notes, End = end, Start = start };
                ctx.Prescriptions.Add(prescription);
                ctx.SaveChanges();
            }
            return Result;

        }

        public List<Prescription> PrescriptionList()
        {
            List<Prescription> result = null;
            using (var ctx = new DrugsContext())
            {
                result = (from x in ctx.Prescriptions select x).ToList();
            }

            return result;
        }
    }
}
