using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FootballPlaybookCreater
{

    public class BaseFormation
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }

    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPlaybookPage : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        public NewPlaybookPage()
        {
            InitializeComponent();
            _connection = DependencyService.Get<SQLliteConnections>().GetConnection();

            Offense_Defense_Switch.Text = "Offense";
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            await _connection.CreateTableAsync<BaseFormation>();
            var baseFormations = await _connection.Table<BaseFormation>().ToListAsync();


        }

        private void Offense_Defense_Switch_OnChanged(object sender, ToggledEventArgs e)
        {
            Offense_Defense_Switch.Text = (e.Value) ? "Defense" : "Offense";
        }
    }

    

    
}