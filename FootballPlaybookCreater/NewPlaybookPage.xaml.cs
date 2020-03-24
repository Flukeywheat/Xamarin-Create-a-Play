using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        #region Properties and Constructors
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<BaseFormation> baseFormations;
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
            baseFormations = new ObservableCollection<BaseFormation>(await _connection.Table<BaseFormation>().ToListAsync());
            GetBaseFormations();
        }
        #endregion
        #region Event Handlers

        private void Offense_Defense_Switch_OnChanged(object sender, ToggledEventArgs e)
        {
            Offense_Defense_Switch.Text = (e.Value) ? "Defense" : "Offense";
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            BaseFormation newPlaybook = new BaseFormation {Name = playbookNameEntryCell.Text };


            await _connection.InsertAsync(newPlaybook);
            baseFormations.Add(newPlaybook);
            BaseFormationsPicker.Items.Add(newPlaybook.Name);
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            RemoveAllBaseFormations();
        }

        #endregion

        #region HelperFunctions
        private void GetBaseFormations()
        {
            if (baseFormations != null)
            {
                foreach (var formation in baseFormations)
                {
                    BaseFormationsPicker.Items.Add(formation.Name);
                }
            }           
        }

        private async void RemoveAllBaseFormations()
        {
            await _connection.DeleteAllAsync<BaseFormation>();


            if (baseFormations != null)
            {
                foreach (var formation in baseFormations)
                {
                    BaseFormationsPicker.Items.Remove(formation.Name);
                }
            }
        }
        #endregion

        
    }




}