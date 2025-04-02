using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DrugAdminLogic
    {
        ReadWriteDrugs dal = new ReadWriteDrugs();
        public void AddDrug(string name, string genericName, string producer, string activeIngredients, string description, string ImagePath, string ndc)
        {


            if ((from x in dal.medicineList() where x.Name == name select x).FirstOrDefault() != null)
                throw new Exception("The medicine already exists in the system");
            if ((from x in dal.medicineList() where x.Ndc == ndc select x).FirstOrDefault() != null)
                throw new Exception("The medicine already exists in the system");
            dal.InsertDrug(name, genericName, producer, activeIngredients, description, ImagePath, ndc);

        }

        public int Count(string DrugeName)
        {
            var result = 0;

            DAL.ReadWriteDrugs dal = new DAL.ReadWriteDrugs();

            result = dal.CountMedicine(DrugeName);

            return result;
        }

        public List<Medicine> listMedicine()
        {
            return dal.medicineList();
        }

        public void deleteDrug(int id)
        {
             dal.deleteMedicine(id);
        }

        public void EditDrug(string name, string gn, string producer, string active, string prop, string image, string ndc)
        {
            dal.EditDrug(name, gn, producer,active,prop, image, ndc);
        }
    }
}
