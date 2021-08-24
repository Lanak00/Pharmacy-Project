
using System;
using System.Collections.Generic;

namespace Model
{
    public class Receipt
    {
        public string Id { get; set; }
        public string Pharmacist { get; set; }
        public string DateTime { get; set; }
        public Dictionary<String, int> Items { get; set; }
        public float TotalPrice { get; set; }

    }
}