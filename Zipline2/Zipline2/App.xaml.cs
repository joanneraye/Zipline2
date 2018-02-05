using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Zipline2
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        public static List<Table> OutsideTableList { get; set; }
        public static List<Table> InsideTableList { get; set; }

        public App()
        {
            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage())
                {
                    BarBackgroundColor = Color.White
                };
            }
            else
            {
                MainPage = new NavigationPage(new TableListPage());
            }
        }

        protected override void OnStart()
        {
            OutsideTableList = new List<Table>
                {
                    new Table {TableName = "Alpha"},
                    new Table {TableName = "Beta"},
                    new Table {TableName = "Charlie"},
                    new Table {TableName = "Snoopy"},
                    new Table {TableName = "Delta"},
                    new Table {TableName = "Elvis"},
                    new Table {TableName = "Van A"},
                    new Table {TableName = "Van B"},
                    new Table {TableName = "X-Ray"},
                    new Table {TableName = "Yoda"},
                    new Table {TableName = "Zulu"},
                    new Table {TableName = "Rocky 1"},
                    new Table {TableName = "Rocky 2"},
                    new Table {TableName = "Rocky 3"},
                    new Table {TableName = "Rocky 4"},
                    new Table {TableName = "Rocky 5"}
                };

            InsideTableList = new List<Table>
                {
                    new Table {TableName = "1"},
                    new Table {TableName = "2"},
                    new Table {TableName = "3"},
                    new Table {TableName = "4a"},
                    new Table {TableName = "4b"},
                    new Table {TableName = "5"},
                    new Table {TableName = "7a"},
                    new Table {TableName = "7b"},
                    new Table {TableName = "8a"},
                    new Table {TableName = "8b"},
                    new Table {TableName = "10"},
                    new Table {TableName = "11"},
                    new Table {TableName = "12"},
                    new Table {TableName = "Cash"},
                    new Table {TableName = "Paris"},
                    new Table {TableName = "Waldo"}
                };

        }

        protected override void OnSleep()
        {
            //save data and app state
        }

        protected override void OnResume()
        {
            
            //when wakes up from idle state...refresh screen if data has changed from when it 
            //went to sleep
        }
    }
}
