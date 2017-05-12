using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITestApp1.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(UITestApp1.Services.MockProviderDataStore))]
namespace UITestApp1.Services
{
    public class MockProviderDataStore : IDataStore<Provider>
    {
        private bool _isInitialized;
        private List<Provider> _items;

        public async Task<bool> AddItemAsync(Provider item)
        {
            await InitializeAsync();

            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Provider item)
        {
            await InitializeAsync();

            var itemToUpdate = _items.FirstOrDefault(arg => arg.Id == item.Id);
            _items.Remove(itemToUpdate);
            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Provider item)
        {
            await InitializeAsync();

            var itemToDelete = _items.FirstOrDefault(arg => arg.Id == item.Id);
            _items.Remove(itemToDelete);

            return await Task.FromResult(true);
        }

        public async Task<Provider> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(_items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Provider>> GetItemsAsync(bool forceRefresh = false)
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

            _items = new List<Provider>();
            var items = new List<Provider>
            {
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=1,Name="Aetna",PhoneNumber="800-222-9215",Title="Provider Directory",Note="string.Empty",Url="http://www.aetnahcahealthcare.com/",Type="Medical"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=3,Name="United Healthcare",PhoneNumber="877-885-8451",Title="Provider Directory",Note="string.Empty",Url="http://welcometouhc.com/hca",Type="Medical"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=4,Name="Cigna",PhoneNumber="800-538-2007",Title="Provider Directory",Note="string.Empty",Url="http://cigna.benefitnation.net/cignadol/hca.asp?employer=3174256",Type="Medical"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=5,Name="Cigna",PhoneNumber="800-538-2007",Title="Provider Directory",Note="string.Empty",Url="http://cigna.benefitnation.net/cignadol/hca.asp?employer=3174256",Type="Medical"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=5,Name="UHC Signature HMO",PhoneNumber="877-314-1224",Title="Provider Directory",Note="string.Empty",Url="https://www.uhcwest.com/",Type="Medical"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=6,Name="Cigna",PhoneNumber="800-538-2007",Title="Provider Directory",Note="string.Empty",Url="http://cigna.benefitnation.net/cignadol/hca.asp?employer=3174256",Type="Medical"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=6,Name="BlueChoice HMO South Carolina",PhoneNumber="800-868-2528",Title="Provider Directory",Note="Choose HMO (Primary Choice, Blue Choice for Kids)",Url="http://www.bluechoicesc.com/members/resources/doctorhospitalfinder.aspx",Type="Medical"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=8,Name="Cigna",PhoneNumber="800-538-2007",Title="Provider Directory",Note="string.Empty",Url="http://cigna.benefitnation.net/cignadol/hca.asp?employer=3174256",Type="Medical"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=8,Name="BlueCross BlueShield of FL",PhoneNumber="800-664-5295",Title="Member Site",Note="Choose BlueOptions (Network Blue)",Url="http://www3.bcbsfl.com/wps/portal/bcbsfl",Type="Medical"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=8,Name="BlueCross BlueShield of FL",PhoneNumber="string.Empty",Title="Provider Directory",Note="string.Empty",Url="http://myportal.bcbsfl.com/wps/portal/opd",Type="Medical"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=9,Name="United Healthcare",PhoneNumber="877-885-8451",Title="Provider Directory",Note="string.Empty",Url="http://welcometouhc.com/hca",Type="Medical"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=9,Name="BlueCross BlueShield of FL",PhoneNumber="800-664-5295",Title="Member Site",Note="Choose BlueOptions (Network Blue)",Url="http://www3.bcbsfl.com/wps/portal/bcbsfl",Type="Medical"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=9,Name="BlueCross BlueShield of FL",PhoneNumber="string.Empty",Title="Provider Directory",Note="string.Empty",Url="http://myportal.bcbsfl.com/wps/portal/opd",Type="Medical"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=10,Name="Aetna",PhoneNumber="800-222-9215",Title="Provider Directory",Note="string.Empty",Url="http://www.aetnahcahealthcare.com/",Type="Medical"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=10,Name="Cigna",PhoneNumber="800-538-2007",Title="Provider Directory",Note="string.Empty",Url="http://cigna.benefitnation.net/cignadol/hca.asp?employer=3174256",Type="Medical"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=11,Name="Aetna",PhoneNumber="800-222-9215",Title="Provider Directory",Note="string.Empty",Url="http://www.aetnahcahealthcare.com/",Type="Medical"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=11,Name="Wichita Preferred",PhoneNumber="877-885-8451",Title="Provider Directory",Note="string.Empty",Url="http://www.aetnahcahealthcare.com/",Type="Medical"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=13,Name="BlueCross BlueShield of Massachusetts",PhoneNumber="string.Empty",Title="Provider Directory",Note="string.Empty",Url="https://www.bluecrossma.com/",Type="Medical"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=1,Name="EyeMed",PhoneNumber="(866) 723-0513",Title="Web site",Note="Choose  Access form the Benefit Provider menu",Url="http://portal.eyemedvisioncare.com/wps/portal/!ut/p/b1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOIt3YxNPL3dDQ38_T3cDIxMA81dzY1CjAxMDPULsh0VAcpgROo!/",Type="Vision"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=2,Name="VSP",PhoneNumber="string.Empty",Title="Web site",Note="(Good Samaritan Hospital, Los Gatos Surgical, Regional Medical Center San Jose)",Url="https://www.vsp.com/",Type="Vision"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=3,Name="EyeMed",PhoneNumber="(866) 723-0513",Title="Web site",Note="Choose  Access form the Benefit Provider menu",Url="http://portal.eyemedvisioncare.com/wps/portal/!ut/p/b1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOIt3YxNPL3dDQ38_T3cDIxMA81dzY1CjAxMDPULsh0VAcpgROo!/",Type="Vision"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=3,Name="VSP",PhoneNumber="string.Empty",Title="Web site",Note="(Good Samaritan Hospital, Los Gatos Surgical, Regional Medical Center San Jose)",Url="https://www.vsp.com/",Type="Vision"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=1,Name="ValueOptions",PhoneNumber="800-434-5100",Title="Web site",Note="string.Empty",Url="https://www.achievesolutions.net/achievesolutions/en/hca/home.do",Type="EAP"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=2,Name="New Directions",PhoneNumber="800-528-5763",Title="Web site",Note="Company Code: HCA",Url="https://www.ndbh.com/",Type="EAP"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=3,Name="ipm",PhoneNumber="888-600-4327",Title="Web site",Note="string.Empty",Url="n/a",Type="EAP"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=1,Name="Delta Dental - Alaska",PhoneNumber="800-223-3104",Title="Web site",Note="Choose DeltaCare network providers ",Url="http://www.deltadentaltn.com",Type="Dental"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=1,Name="MetLife Dental",PhoneNumber="877-638-4422",Title="Web site",Note="string.Empty",Url="https://mybenefits.metlife.com/MyBenefits/ssi/commonAccess.do",Type="Dental"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=2,Name="CIGNA Dental",PhoneNumber="800-244-6224",Title="Provider Directory",Note="string.Empty",Url="http://cigna.benefitnation.net/cignadol/hca.asp?employer=3174256",Type="Dental"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=2,Name="MetLife Dental",PhoneNumber="877-638-4422",Title="Web site",Note="string.Empty",Url="https://mybenefits.metlife.com/MyBenefits/ssi/commonAccess.do",Type="Dental"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=3,Name="CIGNA Dental",PhoneNumber="800-244-6224",Title="Provider Directory",Note="string.Empty",Url="http://cigna.benefitnation.net/cignadol/hca.asp?employer=3174256",Type="Dental"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=3,Name="Delta Premier Dental – California",PhoneNumber="800-765-6003",Title="Web site",Note="Choose DeltaPremier network providers ",Url="https://www.deltadentalins.com/PD/providerDirectory.do?action=s01",Type="Dental"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=3,Name="MetLife Dental",PhoneNumber="877-638-4422",Title="Web site",Note="string.Empty",Url="https://mybenefits.metlife.com/MyBenefits/ssi/commonAccess.do",Type="Dental"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=4,Name="MetLife Dental",PhoneNumber="877-638-4422",Title="Web site",Note="string.Empty",Url="https://mybenefits.metlife.com/MyBenefits/ssi/commonAccess.do",Type="Dental"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=5,Name="CIGNA Dental",PhoneNumber="800-244-6224",Title="Provider Directory",Note="string.Empty",Url="http://cigna.benefitnation.net/cignadol/hca.asp?employer=3174256",Type="Dental"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=5,Name="CompBenefits Dental HMO",PhoneNumber="800-342-5209",Title="Member Site and Provider Directory",Note="string.Empty",Url="http://www.compbenefits.com/custom/HCA/",Type="Dental"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=5,Name="MetLife Dental",PhoneNumber="877-638-4422",Title="Web site",Note="string.Empty",Url="https://mybenefits.metlife.com/MyBenefits/ssi/commonAccess.do",Type="Dental"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=6,Name="Aetna Dental",PhoneNumber="877-238-6200",Title="Provider Directory",Note="string.Empty",Url="http://www.aetnahcahealthcare.com/",Type="Dental"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=6,Name="CIGNA Dental",PhoneNumber="800-244-6224",Title="Provider Directory",Note="string.Empty",Url="http://cigna.benefitnation.net/cignadol/hca.asp?employer=3174256",Type="Dental"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=6,Name="MetLife Dental",PhoneNumber="877-638-4422",Title="Web site",Note="string.Empty",Url="https://mybenefits.metlife.com/MyBenefits/ssi/commonAccess.do",Type="Dental"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=7,Name="Delta Dental DPO – Kansas",PhoneNumber="800-223-3104",Title="Web site",Note="Choose DeltaPreferred network providers ",Url="http://www.deltadentaltn.com",Type="Dental"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=7,Name="MetLife Dental",PhoneNumber="877-638-4422",Title="Web site",Note="string.Empty",Url="https://mybenefits.metlife.com/MyBenefits/ssi/commonAccess.do",Type="Dental"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=8,Name="Delta Dental – New Hampshire",PhoneNumber="800-223-3104",Title="Member Site",Note="Choose DeltaPremier network providers ",Url="http://www.deltadentaltn.com",Type="Dental"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=8,Name="MetLife Dental",PhoneNumber="877-638-4422",Title="Web site",Note="string.Empty",Url="https://mybenefits.metlife.com/MyBenefits/ssi/commonAccess.do",Type="Dental"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=9,Name="Delta Premier Dental – Southwest, VA",PhoneNumber="800-223-3104",Title="Member Site",Note="Choose DeltaPremier network providers ",Url="http://www.deltadentaltn.com",Type="Dental"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=9,Name="MetLife Dental",PhoneNumber="877-638-4422",Title="Web site",Note="string.Empty",Url="https://mybenefits.metlife.com/MyBenefits/ssi/commonAccess.do",Type="Dental"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=10,Name="Delta Dental",PhoneNumber="800-223-3104",Title="Member Site",Note="string.Empty",Url="http://www.deltadentaltn.com",Type="Dental"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=10,Name="MetLife Dental",PhoneNumber="877-638-4422",Title="Web site",Note="string.Empty",Url="https://mybenefits.metlife.com/MyBenefits/ssi/commonAccess.do",Type="Dental"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=11,Name="MetLife Dental",PhoneNumber="877-638-4422",Title="Web site",Note="string.Empty",Url="https://mybenefits.metlife.com/MyBenefits/ssi/commonAccess.do",Type="Dental"},
                new Provider { Id = Guid.NewGuid().ToString(),GroupId=11,Name="Delta Dental - Boston",PhoneNumber="800-223-3104",Title="Web site",Note="Choose DeltaPreferred network providers ",Url="http://www.deltadentalma.com/",Type="Dental"}

            };

            foreach (var item in items)
            {
                _items.Add(item);
            }

            _isInitialized = true;
        }
    }
}