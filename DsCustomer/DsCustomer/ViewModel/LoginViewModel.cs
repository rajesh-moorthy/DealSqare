using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;
namespace Notes.ViewModels

{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string mobile;
        public string Mobile
        {
            get { return mobile; }
            set
            {
                mobile = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Mobile"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand LoginCommand { protected set; get; }

        public ICommand RegisterCommand { protected set; get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnSubmit);
        }
        public void OnSubmit()
        {
            if (mobile != "macoratti@yahoo.com" || password != "secret")
            {
                DisplayInvalidLoginPrompt();
            }
        }

        

    }
}

