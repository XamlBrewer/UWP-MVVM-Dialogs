using Mvvm;
using Mvvm.Services;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace XamlBrewer.Uwp.MvvmDialogSample.ViewModels
{
    internal class MainPageViewModel : ViewModelBase
    {
        private DelegateCommand confirmationCommand;
        private bool? confirmed;
        private string inputString;

        private DelegateCommand inputStringCommand;

        public MainPageViewModel()
        {
            confirmationCommand = new DelegateCommand(Confirmation_Executed);
            inputStringCommand = new DelegateCommand(InputString_Executed);
        }

        public ICommand ConfirmationCommand => confirmationCommand;

        public ICommand InputStringCommand => inputStringCommand;

            private async void Confirmation_Executed()
        {
            confirmed = await ModalView.ConfirmationDialogAsync(
                    "What's the status of Schrödinger's cat?",
                    "Alive",
                    "Dead",
                    "Both"
                );
        }

        private async void InputString_Executed()
        {
            inputString = await ModalView.InputStringDialogAsync(
                "What is your favorite beer?",
                "Trappist"
                );
        }

        public async void InputText_Click(object sender, RoutedEventArgs e)
        {
            var bananas = await ModalView.InputTextDialogAsync(
                "Dinges",
                "Danges"
                );
        }
    }
}
