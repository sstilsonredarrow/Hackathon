using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XCountryTimer.Models;

namespace XCountryTimer.Services
{
    public class RunnerService : IRunnerService
    {
        HttpClient _client;

        public RunnerService()
        {
            _client = new HttpClient();
        }

      
        public async Task<List<Runner>> GetRunners()
        {
            var uri = new Uri(Constants.BASE_URL);
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var runners = JsonConvert.DeserializeObject<List<Runner>>(content);
                return runners;
            }

            return await Task.FromResult(new List<Runner>());
        }

        public async Task<List<Runner>> GetRunnerFauxData()
        {
            var runners = new List<Runner>()
            {
                new Runner { Name = "Jim Dolan Jr.", Split1=null, Split2=null },
                new Runner { Name = "Usain Bolt II", Split1="0:00:00", Split2="0:00:00" },
                new Runner { Name = "Asafa Powell Jr", Split1="0:00:00", Split2="0:00:00" },
                new Runner { Name = "Justin Gatlin 2", Split1="0:00:00", Split2="0:00:00" },
                new Runner { Name = "Houston McTear III", Split1="0:00:00", Split2="0:00:00" },
                new Runner { Name = "Roger Banister IV", Split1="0:00:00", Split2="0:00:00" },
            };

            return await Task.FromResult(runners);
        }

        public async Task SaveTimeAsync(Runner item)
        {

            string queryString = "?meet=Pittsville&race=VarsityBoys&runner=Garrett&split=mile1&time=4:50:190";
            var uri = new Uri($"{Constants.BASE_URL}/{queryString}");

            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(string.Empty, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            response = await _client.PostAsync(uri, content);


            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\tTodoItem successfully saved.");

            }
        }
    }
}
