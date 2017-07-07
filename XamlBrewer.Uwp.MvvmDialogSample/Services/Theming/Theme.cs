using System;
using System.Collections.Generic;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Mvvm.Services
{
    public class Theme
    {
        private static Dictionary<Type, Color> AccentColors = new Dictionary<Type, Color>();

        // Call this in App OnLaunched.
        // Requires reference to Windows Mobile Extensions for the UWP.
        /// <summary>
        /// Applies to the theme to the Application View.
        /// </summary>
        public static void ApplyToContainer()
        {
            // Custom accent color.
            ApplyAccentColor((Color)Application.Current.Resources["DefaultAccentColor"]);

            // PC customization
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.ApplicationView"))
            {
                var titleBar = ApplicationView.GetForCurrentView().TitleBar;
                if (titleBar != null)
                {
                    titleBar.BackgroundColor = ((SolidColorBrush)Application.Current.Resources["TitlebarBackgroundBrush"]).Color;
                    titleBar.ForegroundColor = Colors.White;
                    titleBar.ButtonBackgroundColor = titleBar.BackgroundColor;
                    titleBar.ButtonForegroundColor = Colors.White;
                    titleBar.ButtonHoverBackgroundColor = ((SolidColorBrush)Application.Current.Resources["TitlebarBackgroundDarkBrush"]).Color;
                    titleBar.ButtonHoverForegroundColor = Colors.White;
                    titleBar.ButtonPressedBackgroundColor = ((SolidColorBrush)Application.Current.Resources["TitlebarBackgroundLightBrush"]).Color;
                    titleBar.ButtonPressedForegroundColor = Colors.White;
                    titleBar.InactiveBackgroundColor = titleBar.BackgroundColor;
                    titleBar.InactiveForegroundColor = titleBar.ForegroundColor;
                    titleBar.ButtonInactiveBackgroundColor = titleBar.BackgroundColor;
                    titleBar.ButtonInactiveForegroundColor = titleBar.ButtonForegroundColor;
                }
            }

            // Mobile customization
            if (!ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar")) return;

            var statusBar = StatusBar.GetForCurrentView();
            if (statusBar == null) return;

            statusBar.BackgroundOpacity = 1;
            statusBar.BackgroundColor = ((SolidColorBrush)Application.Current.Resources["StatusbarBackgroundBrush"]).Color;
            statusBar.ForegroundColor = Colors.White;
        }

        /// <summary>
        /// Applies the accent color.
        /// </summary>
        /// <param name="accentColor">Desired accent color.</param>
        /// <remarks>Ignored when user selected high contrast mode.</remarks>
        public static void ApplyAccentColor(Color accentColor)
        {
            if (!new AccessibilitySettings().HighContrast)
            {
                Application.Current.Resources["SystemAccentColor"] = accentColor;
            }
        }

        public static void ApplyAccentColor(Type pageType)
        {
            if (AccentColors.ContainsKey(pageType))
            {
                ApplyAccentColor(AccentColors[pageType]);
            }
            else
            {
                ApplyAccentColor((Color)Application.Current.Resources["DefaultAccentColor"]);
            }
        }

        public static void RegisterAccentColor(Type pageType, Color accentColor)
        {
            if (AccentColors.ContainsKey(pageType))
            {
                AccentColors.Add(pageType, accentColor);
            }
            else
            {
                AccentColors[pageType] = accentColor;
            }
        }
    }
}