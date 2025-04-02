using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUI.Models
{
    public class PD
    {
      public List<PatientViewModel> patients { get; set; }
      public DoctorViewModel doctor { get; set; }
    }
}