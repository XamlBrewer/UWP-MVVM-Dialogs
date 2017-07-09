﻿using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Mvvm.Services
{
    /// <summary>
    /// Provides elementary Modal View services: display message, request confirmation, request input.
    /// </summary>
    public static class ModalView
    {
        public static async Task MessageDialogAsync(string title, string message)
        {
            await MessageDialogAsync(title, message, "OK");
        }

        public static async Task MessageDialogAsync(string title, string message, string buttonText)
        {
            var dialog = new ContentDialog
            {
                Title = title,
                Content = message,
                CloseButtonText = buttonText
            };

            await dialog.ShowAsync();
        }
        public static async Task<bool?> ConfirmationDialogAsync(string title)
        {
            return await ConfirmationDialogAsync(title, "OK", string.Empty, "Cancel");
        }

        public static async Task<bool?> ConfirmationDialogAsync(string title, string primaryButtonText, string secondaryButtonText, string closeButtonText)
        {
            var dialog = new ContentDialog
            {
                Title = title,
                //IsPrimaryButtonEnabled = true,
                PrimaryButtonText = primaryButtonText,
                //IsSecondaryButtonEnabled = true,
                SecondaryButtonText = secondaryButtonText,
                CloseButtonText = closeButtonText
            };
            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.None)
            {
                return null;
            }

            return (result == ContentDialogResult.Primary);
        }

        public static async Task<string> InputStringDialogAsync(string title, string defaultText)
        {
            var inputTextBox = new TextBox
            {
                AcceptsReturn = false,
                Height = 32,
                Text = defaultText,
                Opacity = 1,
                BorderThickness = new Thickness(1)
            };
            var dialog = new ContentDialog
            {
                Content = inputTextBox,
                Title = title,
                IsSecondaryButtonEnabled = true,
                PrimaryButtonText = "Ok",
                SecondaryButtonText = "Cancel"
            };

            if (await dialog.ShowAsync() == ContentDialogResult.Primary)
            {
                return inputTextBox.Text;
            }
            else
            {
                return string.Empty;
            }
        }

        public static async Task<string> InputTextDialogAsync(string title)
        {
            return await InputTextDialogAsync(title, string.Empty);
        }

        public static async Task<string> InputTextDialogAsync(string title, string defaultText)
        {
            var inputTextBox = new TextBox
            {
                AcceptsReturn = true,
                Height = 32 * 6,
                Text = defaultText,
                Opacity = 1,
                BorderThickness = new Thickness(1)
            };
            var dialog = new ContentDialog
            {
                Content = inputTextBox,
                Title = title,
                IsSecondaryButtonEnabled = true,
                PrimaryButtonText = "Ok",
                SecondaryButtonText = "Cancel"
            };

            if (await dialog.ShowAsync() == ContentDialogResult.Primary)
            {
                return inputTextBox.Text;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
