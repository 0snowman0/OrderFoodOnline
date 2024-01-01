namespace OrderFoodOnline.Interface.Irepository.IImage
{
    public interface IFileService
    {
        public Tuple<int, string> SaveImage(IFormFile imageFile);
        public bool DeleteImage(string imageFileName);

        Tuple<int, string> ReturnImageName(IFormFile imageFile);
    }
}
