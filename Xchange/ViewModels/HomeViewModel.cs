using System;
using System.Net.Http;
using GalaSoft.MvvmLight.Command;

namespace Xchange.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private string email;
        public string Email
        {
            get { return email; }
            set { SetValue(ref email, value); }
        }

        public RelayCommand CalculateCommand { get; set; }
        void Calculate()
        {
            
        }

        async System.Threading.Tasks.Task LoadRatesAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org");
            var url = "/api/latest.json?";

            var response = await client.GetAsync(url);
            if(response.IsSuccessStatusCode)
            {
                var results = await response.Content.ReadAsStringAsync();
            } 
        }

        public HomeViewModel()
        {
            CalculateCommand = new RelayCommand(Calculate);
        }
    }
}