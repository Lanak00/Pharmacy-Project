using Model;
using System;
using System.Collections.Generic;
using Repository;
using PharmacyProject.DTOs;
using System.Linq;

namespace Service
{
   public class IngridientService
   {

        public IngridientRepository ingridientRepository = new IngridientRepository();
        public MedicineRepository medicineRepository = new MedicineRepository();
 

        public List<Ingridient> GetAllIngridients()
        {
            return ingridientRepository.GetAllIngridients();
        }

        public Ingridient GetIngridientByName(String name)
        {
            return GetAllIngridients().Find(i => i.Name == name); 
        }
      
        public List<IngridientDTO> SortByName()
        {
            List<Ingridient> ingridients = ingridientRepository.GetAllIngridients();
            return GetListOfIngridientDTOs(ingridients).OrderBy(ingridient => ingridient.Name).ToList(); 
        }

      
      public List<IngridientDTO> SortByOccurence()
      {
            List<Ingridient> ingridients = ingridientRepository.GetAllIngridients();
            return GetListOfIngridientDTOs(ingridients).OrderBy(ingridient => ingridient.NumberOfMedicines).ToList();
      }
      
      public List<IngridientDTO> SearchByName(string name)
      {
            List<Ingridient> ingridients = ingridientRepository.GetAllIngridients();
            return GetListOfIngridientDTOs(ingridients).FindAll(i => i.Name.ToLower().Contains(name));
      }
      
      public List<IngridientDTO> SearchByDescription(string description)
      {
            List<Ingridient> ingridients = ingridientRepository.GetAllIngridients();
            return GetListOfIngridientDTOs(ingridients).FindAll(i => i.Description.ToLower().Contains(description));
      }
      
      public List<IngridientDTO> SearchByMedicine(string medicine)
      {
            // TODO: implement
            return null;
      }

      public List<IngridientDTO> GetListOfIngridientDTOs(List<Ingridient> ingridients)
      {
            List<IngridientDTO> ingridientDTOs = new List<IngridientDTO>();

            foreach (Ingridient ingridient in ingridients)
            {
                IngridientDTO ingridientDTO = new IngridientDTO();
                ingridientDTO.Name = ingridient.Name;
                ingridientDTO.Description = ingridient.Description;
                ingridientDTO.NumberOfMedicines = CalculateNumberOfMedicines(ingridient);
                ingridientDTOs.Add(ingridientDTO);
            }

            return ingridientDTOs;
      }
        public int CalculateNumberOfMedicines(Ingridient ingridient)
        {
            List<Medicine> medicines = medicineRepository.GetAllApprovedMedicines();
            int counter = 0;
            foreach(Medicine medicine in medicines)
            {
                if (medicine.Ingridients.ContainsKey(ingridient.Name))
                {
                    counter++;
                }
            }
            return counter;
        }
  
   }
}