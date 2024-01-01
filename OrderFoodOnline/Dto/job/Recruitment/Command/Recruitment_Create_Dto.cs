namespace OrderFoodOnline.Dto.job.Recruitment.Command
{
    public class Recruitment_Create_Dto
    {
        public string name { get; set; } = null!;

        public string salary { get; set; } = null!;

        public int age { get; set; }

        public string description { get; set; } = null!;

        public string gender { get; set; } = null!;

        public IFormFile? File { get; set; }

    }
}
