using System;
using Xchange.ViewModels;

namespace Xchange.Infrastructure
{
    public class InstanceLocator
    {
        public MainViewModel Main
        {
            get;
            set;
        }

        public InstanceLocator()
        {
            Main = new MainViewModel();
        }
    }
}