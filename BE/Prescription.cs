using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
     public class Prescription
    {
        public int id { get; set; }
        public long patientId { get; set; }
        public string medicineName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public long doctorId { get; set; }
        public string notes { set; get; }
    }
}



