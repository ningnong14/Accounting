namespace Accounting.Models.Model
{
    public class ResSearchResult
    {
        public string status { get; set; }
        public string messageCode { get; set; }
        public string message { get; set; }
        public List<SearchData> data { get; set; }
        public int? TotalDebit { get; set; }
        public int? TotalCredit { get; set; }
        public int? Balance { get; set; }
    }
    public class SearchData
    {
        public int? BillId { get; set; }
        public string Date { get; set; }
        public string Voucher { get; set; }
        public string MainAccount { get; set; }
        public string Description { get; set; }
        public int? Debit { get; set; }
        public int? Credit { get; set; }
      
    }
}
