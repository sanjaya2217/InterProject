using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;

namespace InterviewApp.Models
{

    public class HelperFile
    {
        //Method to post Data
        public static async Task<APIResult> sendDataToServer(string url, object data, bool isList)
        {
            APIResult? _apiResult = new APIResult();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(data),
                    Encoding.UTF8, "application/json"));
                    _apiResult = JsonConvert.DeserializeObject<APIResult>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (WebException ex)
            {
                
                _apiResult.statuscode = HttpStatusCode.BadRequest;
                _apiResult.timestamp = DateTime.Now;
                _apiResult.message = ex.Message;
            }
            return _apiResult;
        }

    }
}