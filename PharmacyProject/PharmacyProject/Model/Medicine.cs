
using System;
using System.Collections.Generic;

namespace Model
{
   public class Medicine
   {
      public string Id { get; set; }
      public string Name { get; set; }
        public string Manufacturer { get; set; }
        public float Price { get; set; }
        public int Ammount { get; set; }
        public String DoctorsReport { get; set; }
        public Dictionary<string, float> Ingridients { get; set; } 
        public bool IsAccepted { get; set; }
        public bool IsRejected { get; set; }
        public bool IsDeleted { get; set; }


    }
}