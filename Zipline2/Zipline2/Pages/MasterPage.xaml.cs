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
	public partial class MasterPage : ContentPage
	{
        public MasterPage()
		{
            InitializeComponent ();
            BackgroundColor = Color.Black;
            BindingContext = new MasterPageModel();          

        }
	}
}