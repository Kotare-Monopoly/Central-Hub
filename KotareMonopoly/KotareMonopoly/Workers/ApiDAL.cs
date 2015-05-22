using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Lifetime;
using System.Threading.Tasks;
using System.Web;
using KotareMonopoly.Models;
using Newtonsoft.Json;

namespace KotareMonopoly.Workers
{
    public class ApiDAL
    {
        private Uri BaseURL = new Uri("http://edarealestate.azurewebsites.net");

        public SquareInformation GetSquareInformations(int SquareId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseURL;
                var response = client.GetAsync(string.Format("/api/v1/properties/{0}", SquareId)).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    SquareInformation squareInformation = new SquareInformation();
                    JsonConvert.PopulateObject(responseContent, squareInformation);
                    return squareInformation;
                }

                return null;

            }
        }

        //private List<SquareInformation> ConvertJSONtoSquareInfo(string JSON)
        //{
        //    var squareInformation = JsonConvert.DeserializeObject<dynamic>(JSON);
        //    var squareInformationResult = new List<SquareInformation>();

        //    foreach (var item in squareInformation)
        //    {
        //        squareInformationResult.Add(new SquareInformation(){Hours = item.Hours, Id = item.Id, LocationId = item.LocationId});
        //    }

        //    return squareInformationResult;
        //}
    }
}