using Model;
using System;
using System.Collections.Generic;
using Service;

namespace Controller
{
   public class MedicineController
   {
      public MedicineService medicineService = new MedicineService();

      public List<Medicine> GetAllApprovedMedicines()
      {
         return medicineService.GetAllApprovedMedicines();
      }

      public Medicine GetMedicineById(String id)
      {
            return medicineService.GetMedicineById(id);
      }

      public List<Medicine> SortByName(String medicineStatus)
      {
         return medicineService.SortByName(medicineStatus);
      }

      public List<Medicine> SortByAmountLeft(String medicineStatus)
      {
         return medicineService.SortByAmountLeft(medicineStatus);
      }

      public List<Medicine> SortByPrice(String medicineStatus)
      {
         return medicineService.SortByPrice(medicineStatus);
      }

      public List<Medicine> SearchById(string id, string medicineStatus)
      {
         return medicineService.SearchById(id, medicineStatus);
      }
      
      public List<Medicine> SearchByName(string name, string medicineStatus)
      {
         return medicineService.SearchByName(name, medicineStatus);
      }
      
      public List<Medicine> SearchByManufacturer(string manufacturer, string medicineStatus)
      {
         return medicineService.SearchByManufacturer(manufacturer, medicineStatus);
      }
      
      public List<Medicine> SearchByAmmount(int amount, string medicineStatus)
      {
         return medicineService.SearchByAmmount(amount, medicineStatus);
      }
      
      public List<Medicine> SearchByPriceRange(float from, float to, string medicineStatus)
      {
         return medicineService.SearchByPriceRange(from, to, medicineStatus);
      }
      
      public List<Medicine> SearchByIngridients(List<String> allIngridients, List<List<String>> someIngridients, string medicineStatus)
      {
         return medicineService.SearchByIngridients(allIngridients, someIngridients, medicineStatus);
      }

      public List<Medicine> GetAllMededicinesWaitingForApproval()
      {
          return medicineService.GetAllMededicinesWaitingForApproval();
      }

      public List<Medicine> GetAllRejectedMedicines()
      {
           return medicineService.GetAllRejectedMedicines();
      }

      public List<Medicine> GetAllDeletedMedicines()
      {
           return medicineService.GetAllDeletedMedicines();
      }

      public void AddNewMedicine(Medicine medicine)
      {
            medicineService.AddNewMedicine(medicine);
      }
      
      public void UpdateMedicineList(Medicine medicine)
      {
            medicineService.UpdateMedicineList(medicine);
      }
      
      public void DeleteMedicine(Medicine medicine)
      {
            medicineService.DeleteMedicine(medicine);
      }
   
   
   }
}