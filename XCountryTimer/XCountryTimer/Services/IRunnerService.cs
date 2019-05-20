using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using XCountryTimer.Models;

namespace XCountryTimer.Services
{
    public interface IRunnerService
    {
        Task<List<Runner>> GetRunners();
        Task<List<Runner>> GetRunnerFauxData();
        Task SaveTimeAsync(Runner item);
    }
}
