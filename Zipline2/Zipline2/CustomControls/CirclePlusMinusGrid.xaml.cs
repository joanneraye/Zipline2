using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Zipline2.CustomControls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CirclePlusMinusGrid : ContentView
	{
       // public CirclePlusMinusPageModel CirclePlusMinusPageModel;
		public CirclePlusMinusGrid ()
		{
            //CirclePlusMinusPageModel = new CirclePlusMinusPageModel();
            InitializeComponent ();
            //BindingContext = CirclePlusMinusPageModel;

		}
	}
}