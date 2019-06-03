using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XCountryCore.Models;
using XCountryCore.ViewModels;

namespace XCountryCore.Services
{
    public class RunnerService : IRunnerService
    {
        HttpClient _client;

        public RunnerService()
        {
            _client = new HttpClient();
        }

      
        public async Task<List<RunnerViewModel>> GetRunners()
        {
            var uri = new Uri(Constants.BASE_URL);
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var runners = JsonConvert.DeserializeObject<List<RunnerViewModel>>(content);
                return runners;
            }

            return await Task.FromResult(new List<RunnerViewModel>());
        }

        public async Task<List<RunnerViewModel>> GetRunnerFauxData()
        {
            var runners = new List<RunnerViewModel>()
            {
                new RunnerViewModel { Name = "Jim Dolan Jr.", Split1=null, Split2=null },
                new RunnerViewModel { Name = "Usain Bolt II", Split1="0:00:00", Split2="0:00:00" },
                new RunnerViewModel { Name = "Asafa Powell Jr", Split1="0:00:00", Split2="0:00:00" },
                new RunnerViewModel { Name = "Justin Gatlin 2", Split1="0:00:00", Split2="0:00:00" },
                new RunnerViewModel { Name = "Houston McTear III", Split1="0:00:00", Split2="0:00:00" },
                new RunnerViewModel { Name = "Roger Banister IV", Split1="0:00:00", Split2="0:00:00" },
            };

            return await Task.FromResult(runners);
        }

        public async Task SaveTimeAsync(RunnerViewModel item)
        {

            string queryString = "?meet=Pittsville&race=VarsityBoys&runner=Garrett&split=mile2&time=4:54:260";
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
