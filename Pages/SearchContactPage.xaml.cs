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
        private PhoneModel phoneModel = new PhoneModel();
        public ListView()
        {
            this.InitializeComponent();
            this.Loaded += Phonelist_Loaded;
        }

        private void Phonelist_Loaded(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void NoteList_Loaded(object sender, RoutedEventArgs e)
        {
            ListView.ItemsSource = phoneModel.FindAll();
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.SQLite));
        }

        private void SearchHandle(object sender, RoutedEventArgs e)
        {
            var result = phoneModel.SearchByKeyword(txtKeyword.Text);
            Debug.WriteLine(result);
            ListView.ItemsSource = result;
        }
    }
}
