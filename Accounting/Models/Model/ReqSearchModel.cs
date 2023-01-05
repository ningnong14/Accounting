namespace Accounting.Models.Model
{
    public class ReqSearchModel
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public DateTime DateTimeTo { get; set; }
        public DateTime DateTimeFrom { get; set; }
    }
}
