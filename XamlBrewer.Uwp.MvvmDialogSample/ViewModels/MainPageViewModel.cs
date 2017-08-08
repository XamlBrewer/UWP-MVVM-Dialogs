using Mvvm;
using Mvvm.Services;
using System.Diagnostics;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace XamlBrewer.Uwp.MvvmDialogSample.ViewModels
{
    internal class MainPageViewModel : ViewModelBase
    {
        private DelegateCommand confirmationCommand_2buttons;
        private DelegateCommand confirmationCommand_3buttons;
        private bool? confirmed;
        private string inputString;

        private DelegateCommand inputStringCommand;

        public MainPageViewModel()
        {
            confirmationCommand_2buttons = new DelegateCommand(Confirmation2Buttons_Executed);
            confirmationCommand_3buttons = new DelegateCommand(Confirmation3Buttons_Executed);
            inputStringCommand = new DelegateCommand(InputString_Executed);
        }

        public ICommand ConfirmationCommandYesNo => confirmationCommand_2buttons;

        public ICommand ConfirmationCommandYesNoCancel => confirmationCommand_3buttons;

        public ICommand InputStringCommand => inputStringCommand;

        private async void Confirmation2Buttons_Executed()
        {
            Debug.WriteLine("2-State Confirmation Dialog will be opened.");
            confirmed = await ModalView.ConfirmationDialogAsync(
                    "Are you planning to open the box?",
                    "Sure",
                    "No, thanks"
                );
            Debug.WriteLine("2-State Confirmation Dialog was closed with {0}.", confirmed);
        }

        private async void Confirmation3Buttons_Executed()
        {
            Debug.WriteLine("3-State Confirmation Dialog will be opened.");
            confirmed = await ModalView.ConfirmationDialogAsync(
                    "So, what's the status of the cat?\nHint: use Quantum Mechanics.",
                    "It's alive",
                    "It's dead",
                    "It's both"
                );
            Debug.WriteLine("3-State Confirmation Dialog was closed with {0}.", confirmed);
        }

        private async void InputString_Executed()
        {
            Debug.WriteLine("Opening String Input Dialog.");
            inputString = await ModalView.InputStringDialogAsync(
                "How do you want to call this phenomenon?",
                "Verschränkung",
                "Claim",
                "Forget it"
                );
            Debug.WriteLine(string.Format("String Input Dialog was closed with {0}.", inputString));
        }

        public async void InputText_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Opening Text Input Dialog.");
            var inputText = await ModalView.InputTextDialogAsync(
                "What whas your point actually?",
                "I just wanted to criticize the existing view of quantum mechanics by explaining how one could, in principle, create a superposition in a large-scale system by making it dependent on a quantum particle that was in a superposition, and end up in an ridiculous state.\n\nAnd I hate cats anyway..."
                );
            Debug.WriteLine(string.Format("Text Input Dialog was closed with {0}.", inputText));
        }
    }
}
