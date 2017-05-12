namespace UITestApp1.Models
{
    public class Provider : BaseDataObject
    {
        private string _type = string.Empty;

        public string Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }
        private int _groupId = 0;

        public int GroupId
        {
            get => _groupId;
            set => SetProperty(ref _groupId, value);
        }

        private string _name = string.Empty;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _phoneNumber = string.Empty;

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);

        }

        private string _title = string.Empty;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _note = string.Empty;

        public string Note
        {
            get => _note;
            set => SetProperty(ref _note, value);
        }

        private string _url = string.Empty;

        public string Url
        {
            get => _url;
            set => SetProperty(ref _url, value);
        }

    }
}