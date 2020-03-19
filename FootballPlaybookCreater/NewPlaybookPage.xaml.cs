using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FootballPlaybookCreater
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPlaybookPage : ContentPage
    {

        public NewPlaybookPage()
        {
            InitializeComponent();

            Offense_Defense_Switch.Text = "Offense";
        }

        private void Offense_Defense_Switch_OnChanged(object sender, ToggledEventArgs e)
        {
            Offense_Defense_Switch.Text = (e.Value) ? "Defense" : "Offense";
        }
    }
}