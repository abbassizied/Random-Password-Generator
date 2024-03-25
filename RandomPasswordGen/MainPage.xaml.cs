using PasswordGenerator;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RandomPasswordGen
{

    public partial class MainPage : ContentPage
    {
        int passwordLength = 8;
        bool passwordContainsUppercase = true;
        bool passwordContainsLowercase = true;
        bool passwordContainsNumeric = true;
        bool passwordContainsSpecial = true;

      
        public string GeneratedPassword { get; set; } = "";
         
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnGeneratePasswordClicked(object sender, EventArgs e)
        {

            // Same as above but you can set the length. Must be between 8 and 128
            // Will return a password which only contains lowercase and uppercase characters and is 21 characters long.
            var pwd = new Password(includeLowercase: passwordContainsLowercase, includeUppercase: passwordContainsUppercase, includeNumeric: passwordContainsNumeric, includeSpecial: passwordContainsSpecial, passwordLength: passwordLength);
            GeneratedPassword = pwd.Next(); 

            Navigation.PushAsync(new ResultPage(GeneratedPassword));

        }

        private void OnUppercaseCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            passwordContainsUppercase = e.Value;
        }

        private void OnLowercaseCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            passwordContainsLowercase = e.Value;

        }

        private void OnNumbersCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            passwordContainsNumeric = e.Value;
        }

        private void OnSpecialCharsCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            passwordContainsSpecial = e.Value;
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            passwordLength = (int)e.NewValue;
        }
    }
}