//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;

//namespace KotareMonopoly.Models
//{
//    public class SquareDTO
//    {
//        public SquareInformation GetsquareInfo(int newLocationId)
//        {
//            //Create JSON array with newLocationId
//            //Send to blah.com
//            //Receive result
//            //Create square information with result
//            //Return square information

//            var client = new HttpClient();

//            client.BaseAddress = new Uri("edarealestate.azurewebsites.net");
//            client.DefaultRequestHeaders.Accept.Clear();
//            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//            HttpResponseMessage response = await client.GetAsync(string.Format("/api/v1/properties/{0}", newLocationId));

//            if (response.IsSuccessStatusCode)
//            {
//                string content = await response.Content.ReadAsStringAsync();

//            }
//        }
//    }
//}