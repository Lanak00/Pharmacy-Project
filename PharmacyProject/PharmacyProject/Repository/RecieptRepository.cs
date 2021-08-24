using System;
using Model;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Repository
{
   public class RecieptRepository
   {

        private String path = "Receipts.json";
        public List<Receipt> receipts = new List<Receipt>();

        public RecieptRepository()
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                if (json != "")
                {
                    this.receipts = JsonConvert.DeserializeObject<List<Receipt>>(json);
                }
            }
        }
        public void SaveReceipt(Receipt receipt)
        {
            receipts.Add(receipt);
            String json = JsonConvert.SerializeObject(receipts, Formatting.Indented);
            File.WriteAllText(path, json);
        }
      
        public List<Receipt> GetAllReciepts()
        {
            return receipts;
        }
   
   }
}