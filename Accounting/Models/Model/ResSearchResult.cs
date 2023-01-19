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
        public int? tagVoucher { get; set; }
        public string codeVoucher { get; set; }
        public string MainAccount { get; set; }
        public string Description { get; set; }
        public int? credit { get; set; }
        public int? debit { get; set; }
        public DateTime dateTimeTo { get; set; }
        public DateTime dateTimeFrom { get; set; }
      
    }
}
