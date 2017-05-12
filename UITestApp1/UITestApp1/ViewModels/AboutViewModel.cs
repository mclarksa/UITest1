using System;
using System.Windows.Input;
using UITestApp1.Models;
using Xamarin.Forms;

namespace UITestApp1.ViewModels
{
    public class AboutViewModel : BaseViewModel<Provider>
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        /// <summary>
        /// Command to open browser to xamarin.com
        /// </summary>
        public ICommand OpenWebCommand { get; }
    }
}
