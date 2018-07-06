using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.PageModels;

namespace Zipline2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SaladsPage : BasePage
	{
		public SaladsPage ()
		{
			InitializeComponent();
            BindingContext = new SaladsPageModel();
            string saladTitle = "TBL " + BusinessLogic.OrderManager.Instance.CurrentTableName + " Salads";
            this.ToolbarItems.Add(new ToolbarItem { Text = saladTitle });
        }
	}
}