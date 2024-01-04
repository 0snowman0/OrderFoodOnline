using OrderFoodOnline.Interface.Itools.HelpFunction;

namespace OrderFoodOnline.Repository.HelpFunction
{
    public class HelpFunction_Rep : IHelpFunction
    {
        public string GenerateRandomString(int length)
        {
            // ایجاد یک آرایه از کاراکترهای قابل استفاده
            char[] characters = new char[] 
            { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            , 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            // ایجاد یک رشته رندوم با طول مشخص
            string randomString = "";
            for (int i = 0; i < length; i++)
            {
                randomString += characters[new Random().Next(characters.Length)];
            }

            // بررسی اینکه رشته تکراری نباشد
            HashSet<string> usedStrings = new HashSet<string>();
            while (usedStrings.Contains(randomString))
            {
                randomString = "";
                for (int i = 0; i < length; i++)
                {
                    randomString += characters[new Random().Next(characters.Length)];
                }
            }

            // بازگشت رشته رندوم
            return randomString;
        }
    }
}
