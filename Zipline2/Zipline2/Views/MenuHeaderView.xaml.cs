using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Zipline2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuHeaderView : ContentView
	{
		public MenuHeaderView()
		{
            InitializeComponent();


            //BindingContext = new TopOfMenuModel();
            ItemTotal.Text = "0.0";
            OrderTotal.Text = "0.0";
            if (App.PizzaInProgress != null)
            {
                ItemTotal.Text = App.PizzaInProgress.Total.ToString();
            }

            if (App.OrderInProgress != null)
            {
                OrderTotal.Text = App.OrderInProgress.Total.ToString();
            }
            if (Application.Current.Properties.ContainsKey("CurrentUser"))
            {
                UserName.Text = Application.Current.Properties["CurrentUser"].ToString();
            }

            if (Application.Current.Properties.ContainsKey("CurrentTable"))
            {
                TableName.Text = "- Table: " + Application.Current.Properties["CurrentTable"];
            }
        }
        public void TButtonClicked(object sender, EventArgs e)
        {

        }
    }
}