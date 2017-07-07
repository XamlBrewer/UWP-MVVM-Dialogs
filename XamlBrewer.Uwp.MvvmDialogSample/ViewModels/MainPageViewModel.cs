using Mvvm;
using Mvvm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XamlBrewer.Uwp.MvvmDialogSample.ViewModels
{
    internal class MainPageViewModel : ViewModelBase
    {
        private DelegateCommand confirmationCommand;
        private bool confirmed;

        public MainPageViewModel()
        {
            confirmationCommand = new DelegateCommand(Confirmation_Executed);
        }

        public ICommand ConfirmationCommand => confirmationCommand;

        private async void Confirmation_Executed()
        {
            confirmed = await ModalView.ConfirmationDialogAsync(
                    "Vinde gaa maan gat niet te dik in deze rok?",
                    "Ja",
                    "nee"
                );
        }
    }
}
