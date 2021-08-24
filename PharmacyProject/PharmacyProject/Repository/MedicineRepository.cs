using System;
using Model;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace Repository
{
   public class MedicineRepository
   {

        private String path = "Medicines.json";
        public List<Medicine> medicines = new List<Medicine>();

        public MedicineRepository()
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                if (json != "")
                {
                    this.medicines = JsonConvert.DeserializeObject<List<Medicine>>(json);
                }
            }
        }

      public void SaveMedicine(Medicine medicine)
      {
            medicines.Add(medicine);
            String json = JsonConvert.SerializeObject(medicines, Formatting.Indented);
            File.WriteAllText(path, json);
      }

      public void DeleteMedicine(Medicine medicine)
      {
            foreach (Medicine med in medicines)
            {
                if (med.Id == medicine.Id)
                {
                    med.IsDeleted = true;
                }
            }
            String json = JsonConvert.SerializeObject(medicines, Formatting.Indented);
            File.WriteAllText(path, json);
        }
      
        public List<Medicine> GetAllApprovedMedicines()
        {    
            return medicines.FindAll(i => i.IsAccepted == true && i.IsDeleted == false);
        }


       public List<Medicine> GetAllMededicinesWaitingForApproval()
       {
           return medicines.FindAll(i => i.IsAccepted == false && i.IsRejected == false && i.IsDeleted == false);
       }

       public List<Medicine> GetAllRejectedMedicines()
       {
           return medicines.FindAll(i => i.IsRejected == true && i.IsDeleted == false);
       }

       public List<Medicine> GetAllDeletedMedicines()
       {
           return medicines.FindAll(i => i.IsDeleted == true); 
       }

        public void UpdateMedicineList(Medicine medicine)
        {
            foreach (Medicine med in medicines)
            {
                if (med.Id == medicine.Id)
                {
                    med.IsAccepted = medicine.IsAccepted;
                    med.IsRejected = medicine.IsRejected;
                    med.IsDeleted = medicine.IsDeleted;
                    med.DoctorsReport = medicine.DoctorsReport;
                    med.Ammount = medicine.Ammount;
                }
            }
            String json = JsonConvert.SerializeObject(medicines, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public Medicine GetMedicineById(string id)
      {
         foreach (Medicine medicine in medicines)
            {
                if (medicine.Id == id)
                    return medicine;
            }
         return null;
      }
   
   }
}