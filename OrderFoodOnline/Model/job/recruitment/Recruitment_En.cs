using OrderFoodOnline.Model.Common.Total;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFoodOnline.Model.job.recruitment
{
    public class Recruitment_En : BaseEn_En
    {
        [Required]
        public int restaurant_id { get; set; }
        [Required]
        [MaxLength(200)]
        public string name { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string salary { get; set; } = null!;
        [Required]
        public int age { get; set; }
        [Required]
        [MaxLength(3000)]
        public string description { get; set; } = null!;
        [Required]
        [MaxLength(20)]
        public string gender { get; set; } = null!;
        [Required]
        [MaxLength(1000)]
        public string file_Name { get; set; } = null!;

        [NotMapped]
        public IFormFile? File { get; set; }
    }
}
