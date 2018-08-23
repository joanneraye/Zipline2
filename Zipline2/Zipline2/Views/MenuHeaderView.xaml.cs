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
using Zipline2.BusinessLogic;

namespace Zipline2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuHeaderView : ContentView
    {
        public MenuHeaderView()
		{
            InitializeComponent();
            try
            {
                BindingContext = MenuHeaderModel.Instance;
            }
            catch (Exception ex)
            {
                var thiserror = ex.InnerException;
                throw;
            }
          
        }
        
        async public void TablesButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TablesPage());
        }        
    }
}