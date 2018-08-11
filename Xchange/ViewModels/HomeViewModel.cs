using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
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

        public ObservableCollection<Rate> Rates { get; set; }

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

        async void LoadRates()
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://apiexchangerates.azurewebsites.net");
                var controller = "/api/Rates";

                var response = await client.GetAsync(controller);
                if(response.IsSuccessStatusCode)
                {
                    var results = await response.Content.ReadAsStringAsync();
                    var rates = JsonConvert.DeserializeObject<List<Rate>>(Result);
                    Rates = new ObservableCollection<Rate>(rates);
                } 
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        public HomeViewModel()
        {
            ConvertCommand = new RelayCommand(Convert);
            LoadRates();
        }
    }
}