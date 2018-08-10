namespace Xchange.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region ViewModels
        public HomeViewModel Home
        {
            get;
            set;
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }

        #endregion

        #region Constructor
        public MainViewModel()
        {
            instance = this;
            this.Home = new HomeViewModel();
        }
        #endregion
    }
}