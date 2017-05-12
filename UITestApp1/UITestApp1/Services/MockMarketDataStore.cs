using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITestApp1.Models;
using Xamarin.Forms;
[assembly: Dependency(typeof(UITestApp1.Services.MockMarketDataStore))]
namespace UITestApp1.Services
{
    public class MockMarketDataStore : IDataStore<Market>
    {
        private bool _isInitialized;
        private List<Market> _items;

        public async Task<bool> AddItemAsync(Market item)
        {
            await InitializeAsync();

            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Market item)
        {
            await InitializeAsync();

            var itemToUpdate = _items.FirstOrDefault(arg => arg.Id == item.Id);
            _items.Remove(itemToUpdate);
            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Market item)
        {
            await InitializeAsync();

            var itemToDelete = _items.FirstOrDefault(arg => arg.Id == item.Id);
            _items.Remove(itemToDelete);

            return await Task.FromResult(true);
        }

        public async Task<Market> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(_items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Market>> GetItemsAsync(bool forceRefresh = false)
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

            _items = new List<Market>();
            var items = new List<Market>
            {
                new Market { Id = Guid.NewGuid().ToString(), MarketId="1", MarketDescription="Alaska"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="2", MarketDescription="California--Riverside"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="3", MarketDescription="California--San Jose"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="4", MarketDescription="California--Thousand Oaks"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="5", MarketDescription="California--West Hills"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="6", MarketDescription="Carolina"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="7", MarketDescription="Colorado"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="8", MarketDescription="Corporate"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="9", MarketDescription="Out-of-Area"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="10", MarketDescription="Florida--East/South"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="11", MarketDescription="Florida--Gainesville"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="12", MarketDescription="Florida--Jacksonville"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="13", MarketDescription="Florida--Orlando"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="14", MarketDescription="Florida--Panhandle"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="15", MarketDescription="Florida--Tampa Bay"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="16", MarketDescription="Florida--Treasure Coast"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="17", MarketDescription="Georgia--Atlanta"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="18", MarketDescription="Georgia--Augusta"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="19", MarketDescription="Georgia--Macon"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="20", MarketDescription="Georgia--Rome"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="21", MarketDescription="Idaho--Caldwell"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="22", MarketDescription="Idaho--Idaho Falls"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="23", MarketDescription="Indiana--Terre Haute"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="24", MarketDescription="Kansas--Kansas City"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="25", MarketDescription="Kansas--Wichita"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="26", MarketDescription="Kentucky--Bowling Green"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="27", MarketDescription="Kentucky--Frankfort"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="28", MarketDescription="Louisiana--Central"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="29", MarketDescription="Louisiana--Lafayette"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="30", MarketDescription="Louisiana--New Orleans"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="31", MarketDescription="Mississippi"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="32", MarketDescription="Nevada"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="33", MarketDescription="New Hampshire"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="34", MarketDescription="Oklahoma"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="35", MarketDescription="Tennessee--Chattanooga"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="36", MarketDescription="Tennessee--Nashville"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="37", MarketDescription="Texas--Austin"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="38", MarketDescription="Texas--Corpus Christi"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="39", MarketDescription="Texas--Dallas/Fort Worth"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="40", MarketDescription="Texas--El Paso"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="41", MarketDescription="Texas--Houston"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="42", MarketDescription="Texas--Other Gulf Coast"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="43", MarketDescription="Texas--San Antonio"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="44", MarketDescription="Utah"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="45", MarketDescription="Virginia--Northern"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="46", MarketDescription="Virginia--Richmond"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="47", MarketDescription="Virginia--Southwest"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="48", MarketDescription="Kentucky--Louisville"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="49", MarketDescription="Ohio"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="50", MarketDescription="Missouri--St. Louis"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="51", MarketDescription="California--Riverside-Parallon"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="52", MarketDescription="California--Thousand Oaks-Parallon"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="53", MarketDescription="Florida--Orlando-Parallon"},
                new Market { Id = Guid.NewGuid().ToString(), MarketId="54", MarketDescription="Massachusetts--Boston"}
                


            };

            foreach (var item in items)
            {
                _items.Add(item);
            }

            _isInitialized = true;
        }
    }
}