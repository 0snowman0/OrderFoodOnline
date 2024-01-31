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
    public class Location_Rep : GenericRepository<Location_En>, ILocation
    {
        private readonly Context_En _context;

        public Location_Rep(Context_En context)
            :base(context)
        {
            _context = context;
        }

        public double Distance(double lat1, double lon1, double lat2, double lon2)
        {
            double radius = 6371; // شعاع زمین در کیلومتر
            double dLat = (lat2 - lat1) * Math.PI / 180;
            double dLon = (lon2 - lon1) * Math.PI / 180;
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return radius * c;
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
