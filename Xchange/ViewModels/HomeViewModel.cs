using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using Xchange.Models;
using Xchange.Net;

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

        public ObservableCollection<Rate> ratesList;
        public ObservableCollection<Rate> RatesList
        {
            get { return ratesList; }
            set { SetValue(ref ratesList, value); }
        }

        private Rate rates;
        public Rate Rates
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

        public InternetConnection internetConnection;
        #endregion

        #region Commands
        public RelayCommand ConvertCommand { get; }
        private async void Convert()
        {
            if (Amount <= 0)
            {
               await App.Current.MainPage.DisplayAlert("Error", "Please introduce a valid number", "Ok");
               return;
            }

            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://free.currencyconverterapi.com");
                var controller = "/api/v6/convert?q=" + SourceRate.id + "_"+  TargetRate.id + "&compact=ultra";

                var response = await client.GetAsync(controller);
                if (response.IsSuccessStatusCode)
                {
                    var results = await response.Content.ReadAsStringAsync();
                    String[] parts = results.Split(':');
                    parts[1] = parts[1].Remove(parts[1].Length - 1);
                    Result = parts[1];
                    Result = Amount * Double.Parse(Result) + "";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private async void LoadRates()
        {
            internetConnection = new InternetConnection();
            var isConnection = await internetConnection.CheckConnection();

            if (!isConnection.IsSuccess)
            {
                return;
            }

            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://sebasapi.000webhostapp.com");
                var controller = "/exchange/rates.json";

                var response = await client.GetAsync(controller);
                if (response.IsSuccessStatusCode)
                {
                    var results = await response.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<RootObject>(results);
                    RatesList = new ObservableCollection<Rate>(list.Rate);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Constructor
        public HomeViewModel()
        {
            ConvertCommand = new RelayCommand(Convert);
            LoadRates();
        }
        #endregion
    }
}