using Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlBrewer.Uwp.MvvmDialogSample.ViewModels
{
    internal class MainPageViewModel: ViewModelBase
    {
        private double someValue;

        public double SomeValue
        {
            get { return someValue; }
            set { SetProperty(ref someValue, value); }
        }

    }
}
