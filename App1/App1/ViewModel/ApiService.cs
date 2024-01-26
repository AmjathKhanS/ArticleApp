using App1.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App1.ViewModel
{
    public class ApiService
    {
        public static ApiService Instance { get { return new ApiService(); } }     
        private ApiService()
        {
            client = new HttpClient();
        }
        private HttpClient client;
        public  async Task<ArticleModels> GetArticlesAsync(int loadcount,string apiUrl)
        {
            var response = await client.GetAsync($"{apiUrl}?limit={loadcount}");
            ///Task.Delay(100000);
            if (response.IsSuccessStatusCode)
            {
                var jsonstring = await response.Content.ReadAsStringAsync();  
                return JsonConvert.DeserializeObject<ArticleModels>(jsonstring);
            }
            return new ArticleModels();
        }
    }
}