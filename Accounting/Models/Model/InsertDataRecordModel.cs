namespace Accounting.Models.Model
{
    public class InsertDataRecordModel : ReqAccountRecordModel
    {
        public DateTime DateTimeFrom { get; set; }
        public string TagVoucher { get; set; }
        public string TagVoucherCode { get; set; }
    }
}
