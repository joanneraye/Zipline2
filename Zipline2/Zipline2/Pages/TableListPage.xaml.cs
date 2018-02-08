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

        //public static List<Tuple<string, string>> TableRowPairs { get; set; }
        //public static List<TableListRow> Rows { get; set; }
        //public static string[] TableNumbers;
        //public static string Table1 = "1";


        public TableListPage()
        {
           InitializeComponent();
        }


        public void OnTableButtonClicked(object sender, EventArgs e)
        {
            //navigate to menu?
            //put table name on top of menu screen?
        }

        public void InsideOutsideButtonClicked(object sender, EventArgs e)
        {
            if (App.IsInside)
            {
                //switch to outside
                Row0Column0.Text = "Alpha";
                Row1Column0.Text = "Beta";
                Row2Column0.Text = "Charlie";
                Row3Column0.Text = "Snoopy";
                Row4Column0.Text = "Delta";
                Row5Column0.Text = "Elvis";
                Row6Column0.Text = "Van A";
                Row7Column0.Text = "Van A";
                Row0Column1.Text = "X-Ray";
                Row1Column1.Text = "Yoda";
                Row2Column1.Text = "Zulu";
                Row3Column1.Text = "Rocky 1";
                Row4Column1.Text = "Rocky 2";
                Row5Column1.Text = "Rocky 3";
                Row6Column1.Text = "Rocky 4";
                Row7Column1.Text = "Rocky 5";
                App.IsInside = false;
            }
            else
            {
                //switch to inside
                Row0Column0.Text = "1";
                Row1Column0.Text = "2";
                Row2Column0.Text = "3";
                Row3Column0.Text = "4a";
                Row4Column0.Text = "4b";
                Row5Column0.Text = "5";
                Row6Column0.Text = "7a";
                Row7Column0.Text = "7b";
                Row0Column1.Text = "8a";
                Row1Column1.Text = "8b";
                Row2Column1.Text = "10";
                Row3Column1.Text = "11";
                Row4Column1.Text = "12";
                Row5Column1.Text = "Cash";
                Row6Column1.Text = "Paris";
                Row7Column1.Text = "Waldo";
                App.IsInside = true;
            }
        }
    }
}