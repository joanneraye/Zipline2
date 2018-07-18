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
	public partial class CalzonePage : BasePage
	{
        CalzonePageModel CalzonePageModel { get; set; }
		public CalzonePage ()
		{
            CalzonePageModel = new CalzonePageModel();
			InitializeComponent ();
            BindingContext = CalzonePageModel;
            string calzoneTitle = "TBL " + OrderManager.Instance.CurrentTableName + " Calzone";
            this.ToolbarItems.Clear();
            this.ToolbarItems.Add(new ToolbarItem { Text = calzoneTitle, Priority = 0 });
        }
	}
}