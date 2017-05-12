namespace UITestApp1.Models
{
    public class MedicalPlanOption : BaseDataObject
    {
        private string _optionId = string.Empty;

        public string OptionId
        {
            get => _optionId;
            set => SetProperty(ref _optionId, value);
        }

        private string _optionName = string.Empty;

        public string OptionName
        {
            get => _optionName;
            set => SetProperty(ref _optionName, value);
        }

    }
}