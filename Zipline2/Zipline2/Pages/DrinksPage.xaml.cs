using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.BusinessLogic;
using Zipline2.PageModels;
using static Zipline2.PageModels.DrinksPageModel;

namespace Zipline2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DrinksPage : BasePage
	{
        public DrinksPage ()
		{
			InitializeComponent ();
            BindingContext = new DrinksPageModel();
            Footer.FooterPageModel.IsDrinkPageDisplayed = true;
            string drinkTitle = "TBL " + OrderManager.Instance.CurrentTableName + " Drinks";
            this.ToolbarItems.Add(new ToolbarItem { Text = drinkTitle });
        }
	}
}