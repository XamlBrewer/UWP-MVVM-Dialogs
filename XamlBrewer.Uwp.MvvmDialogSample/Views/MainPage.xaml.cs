using Mvvm.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using XamlBrewer.Uwp.MvvmDialogSample.ViewModels;

namespace XamlBrewer.Uwp.MvvmDialogSample
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new MainPageViewModel();
        }

        internal MainPageViewModel ViewModel => DataContext as MainPageViewModel;

        private async void MessageBox_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Message Dialog will be opened.");

            await ModalView.MessageDialogAsync("Ready to go?", "Place a cat, a flask of poison, and a radioactive source in a sealed box.", "Got it");

            Debug.WriteLine("Message Dialog was closed.");
        }
    }
}
