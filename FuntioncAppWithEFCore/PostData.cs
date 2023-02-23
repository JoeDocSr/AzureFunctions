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
using Microsoft.Extensions.Logging;

namespace EmpowerEligiblePatients
{
    public class PostData
    {

        public void PostToClient(ProxyEligiblePatients eligiblePatients, ILogger log)
        {
            var jsonObj = JsonSerializer.Serialize(eligiblePatients);

            log.LogInformation("**** PREPARING TO SEND THESE PATIENTS TO CLIENT ****");
            log.LogInformation(jsonObj.ToString());

            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(
                //    new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                //client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ClientBaseAddress"].ToString());


                client.BaseAddress = new Uri("https://localhost:44328/api/");
                log.LogInformation("**** CLIENT URI = {0}", client.BaseAddress.ToString());

                var postTask = client.PostAsJsonAsync<ProxyEligiblePatients>("EligiblePatients", eligiblePatients);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    log.LogInformation("**** POSTED TO CLIENT SUCCESSFULLY ****");
                    log.LogInformation("**** {0} ****", result.ToString());
                }
                else
                {
                    log.LogInformation("**** ERROR: POST TO CLIENT FAILED!!****");
                    log.LogInformation("**** {0} ****", result.ToString());
                }

            }           


            //var student = "{'Id':'1','Name':'Steve'}";
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:58847/");
            //var response = await client.PostAsync("api/values", new StringContent(student, Encoding.UTF8, "application/json"));
            //if (response != null)
            //{
            //   log.LogInformation(response.ToString());
            //}

        }
    }
}
