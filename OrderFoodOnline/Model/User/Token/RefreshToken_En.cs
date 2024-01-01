namespace OrderFoodOnline.Model.User.Token
{
    public class RefreshToken_En
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Expires { get; set; }
    }
}
