using OrderFoodOnline.Dto.Common.Total;

namespace OrderFoodOnline.Dto.job.Recruitment.Quereies
{
    public class Recruitment_Dto : BaseDto_Dto
    {
        public string name { get; set; } = null!;

        public string salary { get; set; } = null!;

        public int age { get; set; }

        public string description { get; set; } = null!;

        public string gender { get; set; } = null!;

        public string file_Name { get; set; } = null!;


    }
}
