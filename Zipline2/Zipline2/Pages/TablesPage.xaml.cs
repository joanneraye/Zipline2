using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.BusinessLogic;
using Zipline2.Models;
using Zipline2.PageModels;

namespace Zipline2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TablesPage : BasePage
	{
        #region Private Variables
        private int NumTablesSeated { get; set; }
        private TablesPageModel TablesPageModel;
        #endregion

        #region Constructor
        public TablesPage()
        {
            TablesPageModel = new TablesPageModel(Navigation);
            BindingContext = TablesPageModel;
            InitializeComponent();
        }
        #endregion

        #region Methods
       
        
        public void OnPrintCheckButtonClicked(object sender, EventArgs e)
        {
        }

        public void OnMoveTableButtonClicked(object sender, EventArgs e)
        {
        }

        public void TakeoutButtonClicked(object sender, EventArgs e)
        {
        }
        #endregion
    }
}