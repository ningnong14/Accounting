namespace Accounting.Models.Model
{
    public class ReqAccountRecordModel
    {
        public string dateTime { get; set; }
        public string mainAccount { get; set;}
        public string description { get; set;}
        public int debit { get; set;}
        public int credit { get; set;}
        public string voucher { get; set;}

    }
}
