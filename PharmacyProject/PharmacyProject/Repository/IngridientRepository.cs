using System;
using Model;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Repository
{
   public class IngridientRepository
   {
        private String path = "Ingridients.json";
        public List<Ingridient> ingridients = new List<Ingridient>();

        public IngridientRepository()
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                if (json != "")
                {
                    ingridients = JsonConvert.DeserializeObject<List<Ingridient>>(json);
                }
            }
        }

        public List<Ingridient> GetAllIngridients()
        {
            return ingridients;
        }

        public Ingridient GetIngridientByName(int id)
        {
            return null;
        }

   }
}