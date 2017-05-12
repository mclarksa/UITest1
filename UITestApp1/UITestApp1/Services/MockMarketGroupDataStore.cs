using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITestApp1.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(UITestApp1.Services.MockMarketGroupDataStore))]
namespace UITestApp1.Services
{
    public class MockMarketGroupDataStore : IDataStore<MarketGroup>
    {
        private bool _isInitialized;
        private List<MarketGroup> _items;

        public async Task<bool> AddItemAsync(MarketGroup item)
        {
            await InitializeAsync();

            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(MarketGroup item)
        {
            await InitializeAsync();

            var itemToUpdate = _items.FirstOrDefault(arg => arg.Id == item.Id);
            _items.Remove(itemToUpdate);
            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(MarketGroup item)
        {
            await InitializeAsync();

            var itemToDelete = _items.FirstOrDefault(arg => arg.Id == item.Id);
            _items.Remove(itemToDelete);

            return await Task.FromResult(true);
        }

        public async Task<MarketGroup> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(_items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<MarketGroup>> GetItemsAsync(bool forceRefresh = false)
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

            _items = new List<MarketGroup>();
            var items = new List<MarketGroup>
            {
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Alaska",GroupType="Dental",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Alaska",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Alaska",GroupType="Medical",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Alaska",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="California--Riverside",GroupType="Dental",GroupId=2},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="California--Riverside",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="California--Riverside",GroupType="Medical",GroupId=5},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="California--Riverside",GroupType="Vision",GroupId=3},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="California--Riverside-Parallon",GroupType="Dental",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="California--Riverside-Parallon",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="California--Riverside-Parallon",GroupType="Medical",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="California--Riverside-Parallon",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="California--San Jose",GroupType="Dental",GroupId=3},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="California--San Jose",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="California--San Jose",GroupType="Medical",GroupId=5},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="California--San Jose",GroupType="Vision",GroupId=3},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="California--Thousand Oaks",GroupType="Dental",GroupId=2},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="California--Thousand Oaks",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="California--Thousand Oaks",GroupType="Medical",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="California--Thousand Oaks",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="California--Thousand Oaks-Parallon",GroupType="Dental",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="California--Thousand Oaks-Parallon",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="California--Thousand Oaks-Parallon",GroupType="Medical",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="California--Thousand Oaks-Parallon",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="California--West Hills",GroupType="Dental",GroupId=2},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="California--West Hills",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="California--West Hills",GroupType="Medical",GroupId=5},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="California--West Hills",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Carolina",GroupType="Dental",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Carolina",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Carolina",GroupType="Medical",GroupId=6},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Carolina",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Colorado",GroupType="Dental",GroupId=2},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Colorado",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Colorado",GroupType="Medical",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Colorado",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Corporate",GroupType="Dental",GroupId=5},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Corporate",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Corporate",GroupType="Medical",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Corporate",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--East/South",GroupType="Dental",GroupId=5},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--East/South",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--East/South",GroupType="Medical",GroupId=3},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--East/South",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Gainesville",GroupType="Dental",GroupId=5},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Gainesville",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Gainesville",GroupType="Medical",GroupId=8},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Gainesville",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Jacksonville",GroupType="Dental",GroupId=5},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Jacksonville",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Jacksonville",GroupType="Medical",GroupId=9},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Jacksonville",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Orlando",GroupType="Dental",GroupId=5},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Orlando",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Orlando",GroupType="Medical",GroupId=3},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Orlando",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Orlando--Parallon",GroupType="Dental",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Orlando--Parallon",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Orlando--Parallon",GroupType="Medical",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Orlando--Parallon",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Panhandle",GroupType="Dental",GroupId=5},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Panhandle",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Panhandle",GroupType="Medical",GroupId=9},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Panhandle",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Tampa Bay",GroupType="Dental",GroupId=5},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Tampa Bay",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Tampa Bay",GroupType="Medical",GroupId=3},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Tampa Bay",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Treasure Coast",GroupType="Dental",GroupId=5},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Treasure Coast",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Treasure Coast",GroupType="Medical",GroupId=3},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Florida--Treasure Coast",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Georgia--Atlanta",GroupType="Dental",GroupId=5},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Georgia--Atlanta",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Georgia--Atlanta",GroupType="Medical",GroupId=3},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Georgia--Atlanta",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Georgia--Augusta",GroupType="Dental",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Georgia--Augusta",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Georgia--Augusta",GroupType="Medical",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Georgia--Augusta",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Georgia--Macon",GroupType="Dental",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Georgia--Macon",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Georgia--Macon",GroupType="Medical",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Georgia--Macon",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Georgia--Rome",GroupType="Dental",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Georgia--Rome",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Georgia--Rome",GroupType="Medical",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Georgia--Rome",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Idaho--Caldwell",GroupType="Dental",GroupId=10},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Idaho--Caldwell",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Idaho--Caldwell",GroupType="Medical",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Idaho--Caldwell",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Idaho--Idaho Falls",GroupType="Dental",GroupId=10},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Idaho--Idaho Falls",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Idaho--Idaho Falls",GroupType="Medical",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Idaho--Idaho Falls",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Indiana--Terre Haute",GroupType="Dental",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Indiana--Terre Haute",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Indiana--Terre Haute",GroupType="Medical",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Indiana--Terre Haute",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Kansas--Kansas City",GroupType="Dental",GroupId=6},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Kansas--Kansas City",GroupType="EAP",GroupId=2},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Kansas--Kansas City",GroupType="Medical",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Kansas--Kansas City",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Kansas--Wichita",GroupType="Dental",GroupId=7},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Kansas--Wichita",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Kansas--Wichita",GroupType="Medical",GroupId=11},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Kansas--Wichita",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Kentucky--Bowling Green",GroupType="Dental",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Kentucky--Bowling Green",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Kentucky--Bowling Green",GroupType="Medical",GroupId=3},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Kentucky--Bowling Green",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Kentucky--Frankfort",GroupType="Dental",GroupId=5},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Kentucky--Frankfort",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Kentucky--Frankfort",GroupType="Medical",GroupId=3},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Kentucky--Frankfort",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Kentucky--Louisville",GroupType="Dental",GroupId=5},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Kentucky--Louisville",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Kentucky--Louisville",GroupType="Medical",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Kentucky--Louisville",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Louisiana--Central",GroupType="Dental",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Louisiana--Central",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Louisiana--Central",GroupType="Medical",GroupId=3},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Louisiana--Central",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Louisiana--Lafayette",GroupType="Dental",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Louisiana--Lafayette",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Louisiana--Lafayette",GroupType="Medical",GroupId=3},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Louisiana--Lafayette",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Louisiana--New Orleans",GroupType="Dental",GroupId=2},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Louisiana--New Orleans",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Louisiana--New Orleans",GroupType="Medical",GroupId=3},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Louisiana--New Orleans",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Massachusetts--Boston",GroupType="Dental",GroupId=11},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Massachusetts--Boston",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Massachusetts--Boston",GroupType="Medical",GroupId=13},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Massachusetts--Boston",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Mississippi",GroupType="Dental",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Mississippi",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Mississippi",GroupType="Medical",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Mississippi",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Missouri--St. Louis",GroupType="Dental",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Missouri--St. Louis",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Missouri--St. Louis",GroupType="Medical",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Missouri--St. Louis",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Nevada",GroupType="Dental",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Nevada",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Nevada",GroupType="Medical",GroupId=10},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Nevada",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="New Hampshire",GroupType="Dental",GroupId=8},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="New Hampshire",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="New Hampshire",GroupType="Medical",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="New Hampshire",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Ohio",GroupType="Dental",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Ohio",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Ohio",GroupType="Medical",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Ohio",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Oklahoma",GroupType="Dental",GroupId=2},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Oklahoma",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Oklahoma",GroupType="Medical",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Oklahoma",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Out-of-Area",GroupType="Dental",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Out-of-Area",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Out-of-Area",GroupType="Medical",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Out-of-Area",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Tennessee--Chattanooga",GroupType="Dental",GroupId=5},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Tennessee--Chattanooga",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Tennessee--Chattanooga",GroupType="Medical",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Tennessee--Chattanooga",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Tennessee--Nashville",GroupType="Dental",GroupId=5},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Tennessee--Nashville",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Tennessee--Nashville",GroupType="Medical",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Tennessee--Nashville",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--Austin",GroupType="Dental",GroupId=5},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--Austin",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--Austin",GroupType="Medical",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--Austin",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--Corpus Christi",GroupType="Dental",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--Corpus Christi",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--Corpus Christi",GroupType="Medical",GroupId=3},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--Corpus Christi",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--Dallas/Fort Worth",GroupType="Dental",GroupId=5},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--Dallas/Fort Worth",GroupType="EAP",GroupId=3},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--Dallas/Fort Worth",GroupType="Medical",GroupId=3},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--Dallas/Fort Worth",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--El Paso",GroupType="Dental",GroupId=2},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--El Paso",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--El Paso",GroupType="Medical",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--El Paso",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--Houston",GroupType="Dental",GroupId=5},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--Houston",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--Houston",GroupType="Medical",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--Houston",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--Other Gulf Coast",GroupType="Dental",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--Other Gulf Coast",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--Other Gulf Coast",GroupType="Medical",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--Other Gulf Coast",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--San Antonio",GroupType="Dental",GroupId=5},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--San Antonio",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--San Antonio",GroupType="Medical",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Texas--San Antonio",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Utah",GroupType="Dental",GroupId=2},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Utah",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Utah",GroupType="Medical",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Utah",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Virginia--Northern",GroupType="Dental",GroupId=2},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Virginia--Northern",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Virginia--Northern",GroupType="Medical",GroupId=4},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Virginia--Northern",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Virginia--Richmond",GroupType="Dental",GroupId=2},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Virginia--Richmond",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Virginia--Richmond",GroupType="Medical",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Virginia--Richmond",GroupType="Vision",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Virginia--Southwest",GroupType="Dental",GroupId=9},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Virginia--Southwest",GroupType="EAP",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Virginia--Southwest",GroupType="Medical",GroupId=1},
                new MarketGroup { Id = Guid.NewGuid().ToString(), MarketName="Virginia--Southwest",GroupType="Vision",GroupId=1}
            };

            foreach (MarketGroup item in items)
            {
                this._items.Add(item);
            }

            _isInitialized = true;
        }
    }
}