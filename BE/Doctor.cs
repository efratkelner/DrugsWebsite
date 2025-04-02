using System;
using System.Collections.Generic;
using System.Text;



namespace BE
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public long IdP { get; set; }
        public string gender { get; set; }
        public long Licensing { get; set; }
        public long PhonNumber { get; set; }
        public string email { get; set; }
        public string Specialty { get; set; }
    }
}

