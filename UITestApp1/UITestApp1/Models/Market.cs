namespace UITestApp1.Models
{
    public class Market : BaseDataObject
    {
        private string _marketId = string.Empty;

        public string MarketId
        {
            get => _marketId;
            set => SetProperty(ref _marketId, value);
        }

        private string _marketDescription = string.Empty;

        public string MarketDescription
        {
            get => _marketDescription;
            set => SetProperty(ref _marketDescription, value);
        }
    }
}