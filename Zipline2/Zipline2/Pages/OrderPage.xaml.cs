using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.BusinessLogic;
using Zipline2.PageModels;

namespace Zipline2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderPage : BasePage
	{
		public OrderPage ()
		{
            InitializeComponent();
            BindingContext = new OrderPageModel();
            Footer.FooterPageModel.IsOrderPageDisplayed = true;
            string pizzaTitle = "TBL " + OrderManager.Instance.CurrentTableName + " Order";
            this.ToolbarItems.Add(new ToolbarItem { Text = pizzaTitle, Priority = 0 });
           
        }
	}
}