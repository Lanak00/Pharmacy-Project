using Model;
using System;
using System.Collections.Generic;
using Service;
using PharmacyProject.DTOs;

namespace Controller
{
   public class IngridientController
   {
        public IngridientService ingridientService = new IngridientService();

      public List<Ingridient> GetAllIngridients()
      {
            return ingridientService.GetAllIngridients();
      }

      public Ingridient GetIngridientByName(String name)
      {
            return ingridientService.GetIngridientByName(name);
      }

      public List<IngridientDTO> GetListOfIngridientDTOs(List<Ingridient> ingridients)
        {
            return ingridientService.GetListOfIngridientDTOs(ingridients);
        }
      public List<IngridientDTO> SortByName()
      {
         return ingridientService.SortByName();
      }
      
      public List<IngridientDTO> SortByOccurence()
      {
         return ingridientService.SortByOccurence();
      }
      
      public List<IngridientDTO> SearchByName(string name)
      {
         return ingridientService.SearchByName(name);
      }
      
      public List<IngridientDTO> SearchByDescription(string description)
      {
         return ingridientService.SearchByDescription(description);
      }
      
      public List<IngridientDTO> SearchByMedicine(string medicine)
      {
         // TODO: implement
         return null;
      }
   
   
   }
}