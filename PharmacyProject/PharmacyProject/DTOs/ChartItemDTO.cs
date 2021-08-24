using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyProject.DTOs
{
    public class ChartItemDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public float PricePerUnit { get; set; }
        public int Amount { get; set; }
        public float ItemPrice { get; set; }
    }
}
