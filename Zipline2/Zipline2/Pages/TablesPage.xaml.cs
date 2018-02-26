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
        public const string InsideString = "Inside";
        public const string OutsideString = "Outside";
        int NumTablesSeated { get; set; }
        TablesPageModel TablesPageModel;

        public TablesPage()
        {
            TablesPageModel = new TablesPageModel();
            BindingContext = TablesPageModel;
            InitializeComponent();
            InsideOutsideButton.Text = InsideString;
        }


        public async void OnTableSelected(object sender, EventArgs e)
        {
            //Change table selected from open to occupied.
            //Table name should show at top of subsequent ordering screens.
            //Display Pizza menu first.
            ListView tableList = sender as ListView;
            Table selectedTable = (Table)tableList.SelectedItem;
            if (selectedTable.IsTakeOut)
            {
                //what to do here?
            }
            if (Application.Current.Properties.ContainsKey("CurrentTable"))
            {
                Application.Current.Properties["CurrentTable"] = selectedTable.TableName;
            }
            else
            {
                Application.Current.Properties.Add("CurrentTable", selectedTable.TableName);
            }

            await Application.Current.SavePropertiesAsync();

            OrderManager.OrderInProgress = new Order();

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
    }
}