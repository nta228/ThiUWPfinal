using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ThiUWP.Entities;
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
    public sealed partial class AddContactPage : Page
    {
        private ContactModel contactModel = new ContactModel();
        private object entityEntry;

        public AddContactPage()
        {
            this.InitializeComponent();
            this.Loaded += AddContacts_Loaded;
        }

        public object Users { get; private set; }

        private void AddContacts_Loaded(object sender, RoutedEventArgs e)
        {
            DatabaseMigration.UpdateDatabase();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var contact = new Contact()
            {
                PhoneNumber = txtPhoneNumber.Text,
                Name = txtName.Text
            };
            var resutl = contactModel.Save(contact);
            ContentDialog contentDialog = new ContentDialog();
            if (resutl)
            {
                contentDialog.Title = "Actions success";
                contentDialog.Content = "Contact Saved!";
                contentDialog.PrimaryButtonText = "Ok";
                await contentDialog.ShowAsync();
            }
            else
            {
                contentDialog.Title = "Actions fails";
                contentDialog.Content = "Please try again!";
                contentDialog.PrimaryButtonText = "Ok";
                await contentDialog.ShowAsync();
            }
            public class NotAContactAttribute : ValidationAttribute
            {
            public override bool IsValid(object value)
            {
                var inputValue = value as string;
                var isValid = true;

                if (!string.IsNullOrEmpty(inputValue))
                {
                    isValid = inputValue.ToUpperInvariant() != "Contact";
                }

                return isValid;
            }
            public class Model
            {
                [NotAContact(ErrorMessage = "Contacts are not allowed.")]
                public string FavoriteContact { get; set; }
            }
        

    }
}

