using UITestApp1.Helpers;
using UITestApp1.Models;
using UITestApp1.Services;

using Xamarin.Forms;

namespace UITestApp1.ViewModels
{
    public class BaseViewModel<T> : ObservableObject
    {
        /// <summary>
        /// Get the azure service instance
        /// </summary>
        public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        /// <summary>
        /// Private backing field to hold the title
        /// </summary>
        string title = string.Empty;
        /// <summary>
        /// Public property to set and get the title of the item
        /// </summary>
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}

