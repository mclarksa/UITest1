using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UITestApp1.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(UITestApp1.Services.MockItemDataStore))]
namespace UITestApp1.Services
{
    public class MockItemDataStore : IDataStore<Item>
    {
        private bool _isInitialized;
        private List<Item> _items;

        public async Task<bool> AddItemAsync(Item item)
        {
            await InitializeAsync();

            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            await InitializeAsync();

            var itemToUpdate = _items.FirstOrDefault(arg => arg.Id == item.Id);
            _items.Remove(itemToUpdate);
            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            await InitializeAsync();

            var itemToRemove = _items.FirstOrDefault(arg => arg.Id == item.Id);
            _items.Remove(itemToRemove);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(_items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(_items);
        }

        public Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }


        public Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

        public async Task InitializeAsync()
        {
            if (_isInitialized)
                return;

            _items = new List<Item>();
            var items = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Buy some cat food", Description="The cats are hungry"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Learn F#", Description="Seems like a functional idea"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Learn to play guitar", Description="Noted"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Buy some new candles", Description="Pine and cranberry for that winter feel"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Complete holiday shopping", Description="Keep it a secret!"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Finish a todo list", Description="Done"},
            };
            
            foreach (var item in items)
            {
                _items.Add(item);
            }

            _isInitialized = true;
        }
    }
}
