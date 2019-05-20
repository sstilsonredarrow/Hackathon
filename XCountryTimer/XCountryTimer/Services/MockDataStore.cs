using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XCountryTimer.Models;

namespace XCountryTimer.Services
{
    public class MockDataStore : IDataStore<Runner>
    {
        List<Runner> items;

        public MockDataStore()
        {
            items = new List<Runner>();
            var mockItems = new List<Runner>
            {
                new Runner { Name = "Jim Dolan Jr.", Split1="0:00:00", Split2="0:00:00", Finish="0:00:00", Id = Guid.NewGuid().ToString()},
                new Runner { Name = "Usain Bolt II", Split1="0:00:00", Split2="0:00:00", Finish="0:00:00", Id = Guid.NewGuid().ToString() },
                new Runner { Name = "Asafa Powell Jr", Split1="0:00:00", Split2="0:00:00", Finish="0:00:00", Id = Guid.NewGuid().ToString() },
                new Runner { Name = "Justin Gatlin 2", Split1="0:00:00", Split2="0:00:00", Finish="0:00:00", Id = Guid.NewGuid().ToString() },
                new Runner { Name = "Houston McTear III", Split1="0:00:00", Split2="0:00:00", Finish="0:00:00", Id = Guid.NewGuid().ToString() },
                new Runner { Name = "Roger Banister IV", Split1="0:00:00", Split2="0:00:00", Finish="0:00:00", Id = Guid.NewGuid().ToString() }
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Runner item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Runner item)
        {
            var oldItem = items.Where((Runner arg) => arg.Name == item.Name).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Runner arg) => arg.Name == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Runner> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Name == id));
        }

        public async Task<IEnumerable<Runner>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}