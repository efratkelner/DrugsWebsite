using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;


namespace DAL
{
    public class ReadWriteDrugs
    {
        public bool InsertDrug(string name, string genericName, string producer, string activeIngredients, string properties, string ImagePath, string ndc)
        {
            bool Result = true;

            using (var ctx = new DrugsContext())
            {
                var drug = new Medicine { Properties = properties, MImage = ImagePath, ActiveIngredients = activeIngredients, GenericName = genericName, Name = name, Producer = producer, Ndc = ndc };
                ctx.Drugs.Add(drug);
                ctx.SaveChanges();
            }
            
            //ImportDataFromExcel();
            return Result;

        }

        public int CountMedicine(string drugeName)
        {
            int result = 0;
            using (var ctx = new DrugsContext())
            {
                result = (from x in ctx.Drugs
                          where x.Name == drugeName
                          select x).Count();
            }

            return result;
        }

        public List<Medicine> medicineList()
        {
            List<Medicine> result = null;
            using (var ctx = new DrugsContext())
            {
                result = (from x in ctx.Drugs select x).ToList();
            }

            return result;
        }

        public void EditDrug(string name, string gn, string producer, string active, string prop, string image, string ndc)
        {
            using (var ctx = new DrugsContext())
            {
                Medicine m = (from x in ctx.Drugs where x.Ndc == ndc select x).FirstOrDefault();
                ctx.Drugs.Remove(m);
                ctx.SaveChanges();
            }

            InsertDrug(name, gn, producer, active, prop,  image, ndc);
        }

        public void deleteMedicine(int id)
        {
           
            using (var ctx = new DrugsContext())
            {
                Medicine m = (from x in ctx.Drugs where x.Id==id select x).FirstOrDefault();
                ctx.Drugs.Remove(m);
                ctx.SaveChanges();
            }

        }

        

        public void ImportDataFromExcel()//put the  medicines-data from the excel file in the database
        {
            string FilePath = "C:\\Users\\User\\Downloads\\GUI\\GUI\\excel\\medicine.xlsx"; 
            _Application excel = new _Excel.Application();
            Workbook wb = excel.Workbooks.Open(FilePath);
            Worksheet ws = wb.Worksheets[1];
            string name = string.Empty, genericName = string.Empty, producer = string.Empty, active = string.Empty, proparties = string.Empty, ndc = string.Empty;
            for (int i = 2; i < 1001; i++)
            {
                name = Convert.ToString(ws.Cells[1][i].Value2);
                genericName = Convert.ToString(ws.Cells[2][i].Value2);
                producer = Convert.ToString(ws.Cells[3][i].Value2);
                active = Convert.ToString(ws.Cells[4][i].Value2);
                proparties = Convert.ToString(ws.Cells[5][i].Value2);
                ndc = Convert.ToString(ws.Cells[7][i].Value2);
                using (var ctx = new DrugsContext())
                {
                    var drug = new Medicine { Properties = proparties, ActiveIngredients = active, GenericName = genericName, Name = name, Producer = producer, Ndc = ndc };
                    ctx.Drugs.Add(drug);
                    ctx.SaveChanges();
                }
            }



        }

        public static implicit operator ReadWriteDrugs(ReadWriteDoctors v)
        {
            throw new NotImplementedException();
        }
    }
    public class DrugsContext : DbContext
    {
        public DrugsContext() : base("DrugsContext")
        {

        }


        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicine> Drugs { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }

    public class DrugInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DrugsContext>
    {
        protected override void Seed(DrugsContext context)
        {
            var Drugs = new List<Medicine>
            {
                new Medicine {Properties="acamol",MImage="1.jpg", Name="ll", Producer="kk", GenericName="ll", ActiveIngredients="kk", Id=0},
                new Medicine {Properties="acamol",MImage="1.jpg"}
            };
            Drugs.ForEach(d => context.Drugs.Add(d));
            context.SaveChanges();
        }
    }
}
