using System;
using Xchange.ViewModels;
using Xamarin.Forms;

namespace Xchange.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var amount = MainViewModel.GetInstance().Home.Amount;
            if (amount > 0)
            {
                MainViewModel.GetInstance().Home.Convert(amount);
            }
        }
    }
}
