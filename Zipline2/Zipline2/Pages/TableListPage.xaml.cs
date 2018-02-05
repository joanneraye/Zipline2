using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Zipline2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TableListPage : BasePage
	{
		public TableListPage ()
		{
            InitializeComponent();
            TableList.ItemsSource = App.InsideTableList;
        }

        public void OnTableSelected(object sender, EventArgs e)
        {
            //navigate to menu?
            //put table name on top of menu screen?
        }
    }
}