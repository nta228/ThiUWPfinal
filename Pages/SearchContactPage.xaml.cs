using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public sealed partial class SearchContactPage : Page
    {
        private ContactModel contactModel = new ContactModel();
        public SearchContactPage()
        {
            this.InitializeComponent();
            this.Loaded += SearchContact_Loaded;
        }

        private void SearchContact_Loaded(object sender, RoutedEventArgs e)
        {
            MyListView.ItemsSource = contactModel.FindAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = contactModel.SearchByKeyword(txtPhoneNumber.Text);

            MyListView.ItemsSource = result;
        }
        private void validateUserEntry()
        {
            if (TxtPhoneNumber.Text.Length == 0)
            {
                string message = "Contact not found.";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                    this.Close();
                }
            }
        }


    }
}
