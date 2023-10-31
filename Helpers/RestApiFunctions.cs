using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;
using UserTests.Models;

namespace UserTests.Helpers
{
    public class RestApiFunctions
    {
        private HttpClient _httpClient = new HttpClient();

        public async Task<Dictionary<string, string>> PostCreateAccount(string relativePath, CreateAccountModel data)
        {
           
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                      
            var userRecords = new List<CreateAccountModel>();
            userRecords.Add(data);

            var requestContent = new StringContent(JsonConvert.SerializeObject(userRecords), Encoding.UTF8, "application/json");

            var result = await _httpClient.PostAsync(relativePath, requestContent);
            Dictionary<string, string> output = new Dictionary<string, string>
            {
                { "StatusCode", "" + result.StatusCode },
                { "response", result.Content.ReadAsStringAsync().Result}
                
            };
            return output;
        }

        public async Task<Dictionary<string, string>> PatchWithdrawAndDepositAmount(string relativePath, CreateAccountModel data)
        {

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var userRecords = new List<CreateAccountModel>();
            userRecords.Add(data);

            var requestContent = new StringContent(JsonConvert.SerializeObject(userRecords), Encoding.UTF8, "application/json");

            var result = await _httpClient.PatchAsync(relativePath, requestContent);
            Dictionary<string, string> output = new Dictionary<string, string>
            {
                { "StatusCode", "" + result.StatusCode },
                { "response", result.Content.ReadAsStringAsync().Result}

            };
            return output;
        }

        public async Task<Dictionary<string, string>> DeleteAccount(string accountNumber, string accountname, string accounttype, string relativePath)
        {

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("AccountNumber", accountNumber);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("AccountName", accountname);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("AccountType", accounttype);

            var result = await _httpClient.DeleteAsync(relativePath);
            Dictionary<string, string> output = new Dictionary<string, string>
            {
                { "StatusCode", "" + result.StatusCode },
                { "response", result.Content.ReadAsStringAsync().Result}

            };
            return output;
        }

    }
}
