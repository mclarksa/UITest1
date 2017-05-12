namespace UITestApp1.Models
{
    public class MarketGroup:BaseDataObject
    {
        private string _marketName;

        public string MarketName
        {
            get => _marketName;
            set => SetProperty(ref _marketName, value);
        }
        

        private string _groupType;

        public string GroupType
        {
            get => _groupType;
            set => SetProperty(ref _groupType, value);
        }

        private int _groupId=0;

        public int GroupId
        {
            get => _groupId;
            set => SetProperty(ref _groupId, value);
        }


    }
}