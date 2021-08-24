using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Model;
using PharmacyProject;

namespace Service
{
    public class ReceiptService
    {
        public RecieptRepository receiptRepository = new RecieptRepository();

        public List<Receipt> GetAllReceipts()
        {
            return receiptRepository.GetAllReciepts();
        }

        public void SaveReceipt(Receipt receipt)
        {
            receiptRepository.SaveReceipt(receipt);
        }

        public List<Receipt> GetReceiptsByDate(String dateTime)
        {
            return null;
        }
    }
}
