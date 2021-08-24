using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace PharmacyProject.DTOs
{
    public class IngridientDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfMedicines { get; set; }
    }
}
