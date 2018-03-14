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
	public partial class TablesPage : BasePage
	{
        #region Private Variables
        private const string InsideString = "Inside";
        private const string OutsideString = "Outside";
        private int NumTablesSeated { get; set; }
        private TablesPageModel TablesPageModel;
        #endregion

        #region Constructor
        public TablesPage()
        {
            TablesPageModel = new TablesPageModel();
            BindingContext = TablesPageModel;
            InitializeComponent();
            InsideOutsideButton.Text = InsideString;
        }
        #endregion

        #region Methods
        public async void OnTableSelected(object sender, EventArgs e)
        {
            //Change table selected from open to occupied.

            ListView tableList = sender as ListView;
            Table selectedTable = (Table)tableList.SelectedItem;
            if (selectedTable.IsTakeOut)
            {
                //what to do here?
            }

            //Change what the app's current table is.
            OrderManager.GetInstance().CurrentTableIndex = selectedTable.IndexInAllTables;

            await Navigation.PushAsync(new PizzaPage());
        }
        
        public void OnPrintCheckButtonClicked(object sender, EventArgs e)
        {
        }

        public void OnMoveTableButtonClicked(object sender, EventArgs e)
        {
        }

        public void InsideOutsideButtonClicked(object sender, EventArgs e)
        {
            if (TablesPageModel.IsInside)
            {
                //If currently inside, change to outside
                TablesPageModel.IsInside = false;
                InsideOutsideButton.Text = OutsideString;
                TablesPageModel.LoadTablesForDisplay(false);
            }
            else
            {
                TablesPageModel.IsInside = true;
                InsideOutsideButton.Text = InsideString;
                TablesPageModel.LoadTablesForDisplay(true);
            }

            TableList.ItemsSource = TablesPageModel.DisplayTables;
        }
        #endregion
    }
}