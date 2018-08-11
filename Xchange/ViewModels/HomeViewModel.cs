using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Xchange.Models;

namespace Xchange.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region Properties
        private string result;
        public string Result
        {
            get { return result; }
            set { SetValue(ref result, value); }
        }

        private double amount;
        public double Amount
        {
            get { return amount; }
            set { SetValue(ref amount, value); }
        }

        private ObservableCollection<Rate> rates;
        public ObservableCollection<Rate> Rates
        {
            get { return rates; }
            set { SetValue(ref rates, value); }
        }

        private Rate sourceRate;
        public Rate SourceRate
        {
            get { return sourceRate; }
            set { SetValue(ref sourceRate, value); }
        }

        private Rate targetRate;
        public Rate TargetRate
        {
            get { return targetRate; }
            set { SetValue(ref targetRate, value); }
        }
        #endregion

        #region Commands
        public RelayCommand ConvertCommand { get; }
        void Convert()
        {
            
        }

        async Task LoadRatesAsync()
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
        #endregion

        public HomeViewModel()
        {
            ConvertCommand = new RelayCommand(Convert);
        }
    }
}