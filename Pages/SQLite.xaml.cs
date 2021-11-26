using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ThiUWP.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ThiUWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SQLite : Page
    {
        private PhoneModel phoneModel = new PhoneModel();
        public SQLite()
        {
            this.InitializeComponent();
            this.Loaded += SQLite_Loaded;
        }

        private async void SQLite_Loaded(object sender, RoutedEventArgs e)
        {
            DatabaseMigration.UpdateDabase();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Phone phone = new Phone()
            {
                Name = txtName.Text,
                NumberPhone = txtPhone.Text,

            };
            var result = phoneModel.Save(phone);
            ContentDialog contentDialog = new ContentDialog();
            contentDialog.PrimaryButtonText = "OK";
            if (result)
            {
                contentDialog.Title = "Action success!";
                contentDialog.Content = "Phone saved!";
                await contentDialog.ShowAsync();
                this.Frame.Navigate(typeof(Pages.SearchContactPage));
            }
            else
            {
                contentDialog.Title = "Action fails!";
                contentDialog.Content = "Contact not found";
                await contentDialog.ShowAsync();
            }
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.SearchContactPage));
        }
    }
}
