using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using System.Text.Json.Serialization;
using System.Configuration;
 
namespace EmpowerEligiblePatients
{
    public class PostData
    {

        public void PostToClient(ProxyEligiblePatients eligiblePatients)
        {
            var jsonObj = JsonSerializer.Serialize(eligiblePatients);

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://localhost:44328/api/");
            //    //HTTP GET
            //    var responseTask = client.GetAsync("EligiblePatients");
            //    responseTask.Wait();

            //    var result = responseTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {


            //    }
            //}

            Console.WriteLine("**** PREPARING TO SEND THESE PATIENTS TO CLIENT ****");
           Console.WriteLine(jsonObj.ToString());

            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(
                //    new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                //client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ClientBaseAddress"].ToString());
                
                
                client.BaseAddress = new Uri("https://localhost:44328/api/");
                Console.WriteLine("**** CLIENT URI = {0}",client.BaseAddress.ToString());

                var postTask = client.PostAsJsonAsync<ProxyEligiblePatients>("EligiblePatients", eligiblePatients);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine("**** POSTED TO CLIENT SUCCESSFULLY ****");
                }
                else
                {
                    Console.WriteLine("**** ERROR: POST TO CLIENT FAILED!!****");
                    Console.WriteLine("**** {0} ****", result.ToString());  
                }

            }


            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://localhost:44328/api/");
            //    var postTask = client.PostAsJsonAsync("EligiblePatients", new StringContent(jsonObj, Encoding.UTF8, "application/json"));
            //    postTask.Wait();

            //    var result = postTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {

            //    }
            //}


            //var student = "{'Id':'1','Name':'Steve'}";
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:58847/");
            //var response = await client.PostAsync("api/values", new StringContent(student, Encoding.UTF8, "application/json"));
            //if (response != null)
            //{
            //    Console.WriteLine(response.ToString());
            //}

        }
    }
}
