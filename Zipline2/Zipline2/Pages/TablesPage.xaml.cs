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
using Zipline2.Data;
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
        private bool FirstTimeLoadMenu;
        #endregion

        #region Constructor
        public TablesPage()
        {
            FirstTimeLoadMenu = true;

            //InitializeComponent();
            //TablesPageModel = new TablesPageModel(new DataTemplate[] { takeoutRowTemplate, dividerTemplate, blankTemplate });

            TablesPageModel = new TablesPageModel();
            //CreateTableButtonStyle();
            InitializeComponent();
            BindingContext = TablesPageModel;
            this.ToolbarItems.Clear();
            this.ToolbarItems.Add(new ToolbarItem { Text = "Tables     ", Priority = 2 });          
        }
        #endregion

        #region Methods

       
        public void OnPrintCheckButtonClicked(object sender, EventArgs e)
        {
        }

        public void OnMoveTableButtonClicked(object sender, EventArgs e)
        {
        }



        private async Task OnRefreshing(object sender, EventArgs e)
        {
            try
            {
                await Task.Run(() => DataBaseDictionaries.LoadTableDataAsync());
            }
            finally
            {
                ((ListView)sender).IsRefreshing = false;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            TablesPageModel.NavigateToDrinksPage += HandleNavigateToDrinksPage;
            TablesPageModel.NavigateToOrderPage += HandleNavigateToOrderPage;
            TablesPageModel.DisplayMoveTableDialog += DoMoveTableDialog;
            if (WcfServicesProxy.Instance.ServiceCallConfig != WcfServicesProxy.ServiceCallConfigType.AllServiceCallsOff)
            {
                //Moved to app.xaml.cs
                //if (FirstTimeLoadMenu)
                //{
                //    await DataLoader.LoadToppingsFromFileOrServer();
                //    //var toppingsTask = DataBaseDictionaries.LoadToppingsFromServerAsync();
                //    //var menuTask = WcfServicesProxy.Instance.GetMenuAsync();
                //    //await Task.WhenAll(toppingsTask, menuTask);
                //    FirstTimeLoadMenu = false;
                //}
                TablesPageModel.IsBusy = true;
                var tablesServerTaskSuccess = await DataBaseDictionaries.LoadTableDataAsync();
                if (tablesServerTaskSuccess)
                {
                    TablesPageModel.IsBusy = false;
                }

                //Don't know how to get an exception from the above await.....
                //if (exception != null)
                //{
                //    await DisplayAlert("Warning!", "Loading data from server encountered the exception: " + exception.InnerException.Message, "OK");
                //}
            }
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            TableButtonsListView.IsEnabled = false;
            if (sender is ListView)
            {
                ((ListView)sender).SelectedItem = null;
            }
        }

        void DoMoveTableDialog(object sender, EventArgs e)
        {
            DisplayAlert("Not yet...", "Sorry this button has not been coded yet.", "OK");
        }

        void HandleNavigateToDrinksPage(object sender, EventArgs e)
        {
            try
            {
                if (WcfServicesProxy.Instance.ServiceCallConfig == WcfServicesProxy.ServiceCallConfigType.AllServiceCallsOff)
                {
                    DisplayAlert("Warning", "All connections to server are off.  You may test creating orders only.", "OK");
                }
                var currentMainPage = (Application.Current.MainPage as MasterDetailPage);
                currentMainPage.Detail = new NavigationPage(new DrinksPage());
                Application.Current.MainPage = currentMainPage;
            }
            catch (Exception ex)
            {
                var error = ex.InnerException;
                throw;
            }
           
        }

        void HandleNavigateToOrderPage(object sender, EventArgs e)
        {
            if (WcfServicesProxy.Instance.ServiceCallConfig == WcfServicesProxy.ServiceCallConfigType.AllServiceCallsOff)
            {
                DisplayAlert("Warning", "All connections to server are off.   You may test creating orders only.", "OK");
            }
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
            TablesPageModel.DisplayMoveTableDialog -= DoMoveTableDialog;
        }

        
        #endregion
    }
}