using System.ComponentModel.DataAnnotations;

namespace Accounting.Models.Model
{
    public class DebitCodeModel
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Discription { get; set; }
    }
}
