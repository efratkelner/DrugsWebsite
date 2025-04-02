using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUI.Models
{
    public class PrescriptionD
    {
        public PatientViewModel patient { get; set; }
        public DoctorViewModel doctor { get; set; }
        public PrescriptionViewModel prescription { get; set; }

    }
}