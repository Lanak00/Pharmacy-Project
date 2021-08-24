using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Model;
using PharmacyProject;

namespace Controller
{
    public class ReceiptController
    {

        public ReceiptService receiptService = new ReceiptService();

        public List<Receipt> GetAllReceipts()
        {
            return receiptService.GetAllReceipts();
        }

        public void SaveReceipt(Receipt receipt)
        {
            receiptService.SaveReceipt(receipt);
        }

    }
}
