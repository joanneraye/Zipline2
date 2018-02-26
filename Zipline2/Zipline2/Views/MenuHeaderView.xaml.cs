using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zipline2.PageModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.Models;
using Zipline2.Pages;

namespace Zipline2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuHeaderView : ContentView
	{
        public MenuHeaderModel MenuHeaderModel { get; set; }
        public MenuHeaderView()
		{
            InitializeComponent();

            MenuHeaderModel = MenuHeaderModel.GetInstance();
            BindingContext = MenuHeaderModel;


            UserName.Text = Users.LoggedInUser.UserName;

            if (Application.Current.Properties.ContainsKey("CurrentTable"))
            {
                TableName.Text = "- Table: " + Application.Current.Properties["CurrentTable"];
            }
        }
       
        async public void TButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TablesPage());
        }
    }
}