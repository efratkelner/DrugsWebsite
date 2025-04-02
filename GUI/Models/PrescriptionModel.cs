using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUI.Models
{
    public class PrescriptionModel
    {
        public List<Prescription> prescriptions { get; set; }
        PrescriptionAdminLogic pl = new PrescriptionAdminLogic();
        public PrescriptionModel()
        {
            prescriptions = pl.listPrescription();
        }
        public List<PrescriptionViewModel> Add(PrescriptionViewModel prescription)
        {
            List<PrescriptionViewModel> result = GetPrescriptions();
            result.Add(prescription);
            return result;
        }

        public Prescription GetPrescription(int id)
        {
            var result = (from p in prescriptions
                          where p.id == id
                          select p).Single<Prescription>();
            return result;

        }
        public List<PrescriptionViewModel> GetPrescriptinsById(int id)
        {
            List<PrescriptionViewModel> pResult = new List<PrescriptionViewModel>();
            PrescriptionViewModel Vm = null;
            foreach (var item in prescriptions)
            {
                if (item.patientId==id)
                {
                    Vm = new PrescriptionViewModel(item);
                    pResult.Add(Vm);
                }
            }
            return pResult;

        }
        public List<PrescriptionViewModel> GetPrescriptions()
        {
            List<PrescriptionViewModel> result = new List<PrescriptionViewModel>();
            PrescriptionViewModel Vm = null;
            foreach (var item in prescriptions)
            {
                Vm = new PrescriptionViewModel(item);
                result.Add(Vm);
            }
            return result;
        }
    }
}
