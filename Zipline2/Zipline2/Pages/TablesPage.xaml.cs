using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.BusinessLogic;
using Zipline2.Models;
using Zipline2.PageModels;

namespace Zipline2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TablesPage : ContentPage
	{
        #region Private Variables
        private int NumTablesSeated { get; set; }
        private TablesPageModel TablesPageModel;
        #endregion

        #region Constructor
        public TablesPage()
        {
            TablesPageModel = new TablesPageModel();
            InitializeComponent();
            BindingContext = TablesPageModel;

            //var itemTemplate = TableList.ItemTemplate;
            //var tablesGrid = itemTemplate???;
            //var tablesGrid = TableList.ItemTemplate..FindByName<Grid>("TablesGrid");
            //var rowdefs = tablesGrid.RowDefinitions;
            
            //double heightOfRows = 0.0;
            //foreach (var row in rowdefs)
            //{
            //    var gridLengthStruct = row.Height;
            //    heightOfRows = gridLengthStruct.Value;
            //    break;
            //}
            //TableList.HeightRequest = heightOfRows + 5.0;
        }
        #endregion

        #region Methods
        
        public void OnPrintCheckButtonClicked(object sender, EventArgs e)
        {
        }

        public void OnMoveTableButtonClicked(object sender, EventArgs e)
        {
        }

        public void TakeoutButtonClicked(object sender, EventArgs e)
        {
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            TablesPageModel.NavigateToDrinksPage += HandleNavigateToDrinksPage;
        }
        void HandleNavigateToDrinksPage(object sender, EventArgs e)
        {
            var currentMainPage = (Application.Current.MainPage as MasterDetailPage);
            currentMainPage.Detail = new NavigationPage(new DrinksPage());
            Application.Current.MainPage = currentMainPage;
        }
        //void HandleNavigateToPizzaPage(object sender, EventArgs e)
        //{
        //    var currentMainPage = (Application.Current.MainPage as MasterDetailPage);
        //    currentMainPage.Detail = new NavigationPage(new PizzaPage());
        //    Application.Current.MainPage = currentMainPage;
        //    //await Navigation.PushAsync(new PizzaPage());
        //}

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            TablesPageModel.NavigateToDrinksPage -= HandleNavigateToDrinksPage;
        }
        #endregion
    }
}