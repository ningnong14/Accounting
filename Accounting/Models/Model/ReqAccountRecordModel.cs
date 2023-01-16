namespace Accounting.Models.Model
{
    public class ReqAccountRecordModel
    {
        public DateTime DateTimeTo { get; set; }
        public string MainAccount { get; set;}
        public string Description { get; set;}
        public int Debit { get; set;}
        public int Credit { get; set;}

    }
}
