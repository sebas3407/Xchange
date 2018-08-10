using System;
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

        public HomeViewModel()
        {
            
        }
    }
}