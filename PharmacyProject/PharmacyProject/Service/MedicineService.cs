using System;
using Model;
using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Service
{
   public class MedicineService
   {

        public MedicineRepository medicineRepository = new MedicineRepository();

        public List<Medicine> GetAllApprovedMedicines()
        {
            return medicineRepository.GetAllApprovedMedicines();
        }

        public Medicine GetMedicineById (String id)
        {
            return medicineRepository.GetMedicineById(id);
        }
        public List<Medicine> SortByName(String medicineStatus)
        {
            return getListBasedOnMedicineStatus(medicineStatus).OrderBy(medicine => medicine.Name).ToList();
        }


        public List<Medicine> SortByAmountLeft(String medicineStatus)
        {
            return getListBasedOnMedicineStatus(medicineStatus).OrderBy(medicine => medicine.Ammount).ToList();
        }


        public List<Medicine> SortByPrice(String medicineStatus)
        {
            return getListBasedOnMedicineStatus(medicineStatus).OrderBy(medicine => medicine.Price).ToList();
        }


        public List<Medicine> SearchById(string id, String medicineStatus)
        { 
            return getListBasedOnMedicineStatus(medicineStatus).FindAll(i => i.Id == id);
        }
      
        public List<Medicine> SearchByName(string name, String medicineStatus)
        {
            return getListBasedOnMedicineStatus(medicineStatus).FindAll(i => i.Name.ToLower().Contains(name));
        }
      
      public List<Medicine> SearchByManufacturer(string manufacturer, String medicineStatus)
      {
            return getListBasedOnMedicineStatus(medicineStatus).FindAll(i => i.Manufacturer.ToLower().Contains(manufacturer));
      }
      
      public List<Medicine> SearchByAmmount(int amount, String medicineStatus)
      {
            return getListBasedOnMedicineStatus(medicineStatus).FindAll(i => i.Ammount == amount);
      }
      
      public List<Medicine> SearchByPriceRange(float from, float to, String medicineStatus)
      {
            return getListBasedOnMedicineStatus(medicineStatus).FindAll(i => i.Price > --from && i.Price < ++to);
      }
      
      public List<Medicine> SearchByIngridients(List<String> allIngridients, List<List<String>> someIngridients, String medicineStatus)
      {
            List<Medicine> medicinesFound = new List<Medicine>();
            List<Medicine> medicines = getListBasedOnMedicineStatus(medicineStatus);

            foreach (Medicine medicine in medicines)
            {
                if(containsIngridient(medicine, allIngridients) && containsSomeIngridients(medicine, someIngridients))
                {
                    medicinesFound.Add(medicine);
                }
            }
            return medicinesFound;
      }

      public List<Medicine> GetAllMededicinesWaitingForApproval()
        {
            return medicineRepository.GetAllMededicinesWaitingForApproval();
        }

        public List<Medicine> GetAllRejectedMedicines()
        {
            return medicineRepository.GetAllRejectedMedicines();
        }

        public List<Medicine> GetAllDeletedMedicines()
        {
            return medicineRepository.GetAllDeletedMedicines();
        }

        public void AddNewMedicine(Medicine medicine)
        {
            medicineRepository.SaveMedicine(medicine);
        }

        public void DeleteMedicine(Medicine medicine)
        {
            medicineRepository.DeleteMedicine(medicine);
        }
        
        public void UpdateMedicineList(Medicine medicine)
        {
            medicineRepository.UpdateMedicineList(medicine);
        }

        public bool containsIngridient(Medicine medicine, List<String> ingridients)
        {
            return ingridients.All(item => medicine.Ingridients.Keys.Contains(item));
        }

        public bool containsSomeIngridients(Medicine medicine, List<List<String>> ingridients)
        {
            bool hasMatch = false;

            if (ingridients.Count == 0)
                return true;

            foreach (List<String> ingridientList in ingridients)
            {
                if (ingridientList.Any(x => medicine.Ingridients.Keys.Any(y => y.Contains(x))))
                {
                    hasMatch = true;
                }
            }
            return hasMatch;
        }

        public List<Medicine> getListBasedOnMedicineStatus(String medicineStatus)
        {
            if (medicineStatus == "accepted")
                return medicineRepository.GetAllApprovedMedicines();
            return medicineRepository.GetAllRejectedMedicines();
        }


   }
}