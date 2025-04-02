using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUI.Models
{
    public class PDP
    {
        public PatientViewModel patient { get; set; }
        public DoctorViewModel doctor { get; set; }
        public List<Prescription> prescriptionList { get; set; }

    }
}