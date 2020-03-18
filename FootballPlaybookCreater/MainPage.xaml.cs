using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FootballPlaybookCreater
{
    
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void NewPlaybook_Clicked(object sender, EventArgs e)
        {           
            Navigation.PushAsync(new NewPlaybookPage());
        }

        private void LoadPlaybook_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoadPlaybookPage());
        }
        private void Settings_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Settings());
        }
        private void Exit_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
