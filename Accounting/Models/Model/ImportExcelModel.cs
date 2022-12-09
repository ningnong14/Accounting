using System.Data;

namespace Accounting.Models.Model
{
    public class ImportExcelModel
    {
        public DateTime Date { get; set; }
        public string Voucher { get; set; }
        public string MainAccount { get; set;}
        public string Description { get; set; }
        public int Debit { get; set; }
        public int Credit { get; set; }
    }
}
