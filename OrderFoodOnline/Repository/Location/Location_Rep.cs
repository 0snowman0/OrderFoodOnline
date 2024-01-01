using Azure.Core;
using Newtonsoft.Json;
using OrderFoodOnline.Dto.Location.Command;
using OrderFoodOnline.Dto.Location.Quesries;
using OrderFoodOnline.generic;
using OrderFoodOnline.Interface.Irepository.ILocation;
using OrderFoodOnline.Model.ConnectionToBank;
using OrderFoodOnline.Model.Location;
using System.Net;

namespace OrderFoodOnline.Repository.Location
{
    public class Location_Rep : GenericRepository<Location_En>   , ILocation
    {
        private readonly Context_En _context;

        public Location_Rep(Context_En context)
            :base(context)
        {
            _context = context;
        }

        public async Task<string> Get_Location_User()
        {
            string apiUrl = "http://127.0.0.1:5000/api/Location";

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    // Make a GET request
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    // Check if the request was successful (status code 200 OK)
                    if (response.IsSuccessStatusCode)
                    {
                        // Read and display the response content
                        string content = await response.Content.ReadAsStringAsync();

                        return content;
                    }
                    else
                    {
                        return "error in try ...";
                    }
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
        }
    }
}
