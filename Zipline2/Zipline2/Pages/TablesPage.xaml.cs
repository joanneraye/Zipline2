using Staunch.POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.WcfRemote;
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
            this.ToolbarItems.Clear();
            this.ToolbarItems.Add(new ToolbarItem { Text = "Tables     ", Priority = 2 });

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

        //async public Task<List<DBTable>> GetTablesAsync()
        //{

        //    return await WcfServicesProxy.Instance.GetTableInfoFromServerAsync();
        //}

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
            TablesPageModel.NavigateToOrderPage += HandleNavigateToOrderPage;
        }
        void HandleNavigateToDrinksPage(object sender, EventArgs e)
        {
            var currentMainPage = (Application.Current.MainPage as MasterDetailPage);
            currentMainPage.Detail = new NavigationPage(new DrinksPage());
            Application.Current.MainPage = currentMainPage;
        }

        void HandleNavigateToOrderPage(object sender, EventArgs e)
        {
            var currentMainPage = (Application.Current.MainPage as MasterDetailPage);
            currentMainPage.Detail = new NavigationPage(new OrderPage());
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
            TablesPageModel.NavigateToOrderPage -= HandleNavigateToOrderPage;
        }
        #endregion
    }
}