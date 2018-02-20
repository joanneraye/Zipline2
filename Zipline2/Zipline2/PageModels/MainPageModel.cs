using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Zipline2.Models;

namespace Zipline2
{
    class MainPageModel : BasePageModel
    {
        public List<Table> OutsideTableList { get; set; }
        public List<Table> InsideTableList { get; set; }

        public MainPageModel()
        {

        }
       
        //public override void Init(object initData)
        //{
        //    base.Init(initData);

        //    OutsideTableList = new List<Table>
        //    {
        //        new Table {TableName = "Alpha"},
        //        new Table {TableName = "Beta"},
        //        new Table {TableName = "Charlie"},
        //        new Table {TableName = "Snoopy"},
        //        new Table {TableName = "Delta"},
        //        new Table {TableName = "Elvis"},
        //        new Table {TableName = "Van A"},
        //        new Table {TableName = "Van B"},
        //        new Table {TableName = "X-Ray"},
        //        new Table {TableName = "Yoda"},
        //        new Table {TableName = "Zulu"},
        //        new Table {TableName = "Rocky 1"},
        //        new Table {TableName = "Rocky 2"},
        //        new Table {TableName = "Rocky 3"},
        //        new Table {TableName = "Rocky 4"},
        //        new Table {TableName = "Rocky 5"}
        //    };

        //    InsideTableList = new List<Table>
        //    {
        //        new Table {TableName = "Table 1"},
        //        new Table {TableName = "Table 2"},
        //        new Table {TableName = "Table 3"},
        //        new Table {TableName = "Table 4a"},
        //        new Table {TableName = "Table 4b"},
        //        new Table {TableName = "Table 5"},
        //        new Table {TableName = "Table 7a"},
        //        new Table {TableName = "Table 7b"},
        //        new Table {TableName = "Table 8a"},
        //        new Table {TableName = "Table 8b"},
        //        new Table {TableName = "Table 10"},
        //        new Table {TableName = "Table 11"},
        //        new Table {TableName = "Table 12"},
        //        new Table {TableName = "Cash"},
        //        new Table {TableName = "Paris"},
        //        new Table {TableName = "Waldo"}
        //    };
        //}

        //public Table SelectedTable
        //{
        //    get { return null; }  //JRAYE - leave this or change?

        //    set
        //    {
        //        CoreMethods.PushPageModel<MainMenuPageModel>(value);
        //        RaisePropertyChanged();
        //    }
        //}
    }
}
