using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GUI.Data
{
    public class GUIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public GUIContext() : base("name=GUIContext")
        {
        }

        public System.Data.Entity.DbSet<GUI.Models.PatientViewModel> PatientViewModels { get; set; }

        public System.Data.Entity.DbSet<GUI.Models.DoctorViewModel> DoctorViewModels { get; set; }

        public System.Data.Entity.DbSet<GUI.Models.MedicineViewModel> MedicineViewModels { get; set; }

        public System.Data.Entity.DbSet<GUI.Models.PrescriptionViewModel> PrescriptionViewModels { get; set; }

        public System.Data.Entity.DbSet<GUI.Models.DetailsViewModel> DetailsViewModels { get; set; }
    }
}
