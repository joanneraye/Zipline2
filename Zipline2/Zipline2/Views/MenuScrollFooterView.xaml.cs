using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.PageModels;

namespace Zipline2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuScrollFooterView : ContentView
	{
        public MenuButtonFooterModel FooterPageModel;
        public MenuScrollFooterView()
		{
			InitializeComponent ();
            FooterPageModel = MenuButtonFooterModel.Instance;
            BindingContext = FooterPageModel;
		}
	}
}