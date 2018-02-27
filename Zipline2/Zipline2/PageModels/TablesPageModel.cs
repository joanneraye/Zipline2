using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using Zipline2.Models;

namespace Zipline2.PageModels
{
    class TablesPageModel : BasePageModel
    {
        private List<Table> displayTables;
        private string userName;
        public bool IsInside { get; set; }
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {                
                SetProperty(ref userName, value);
            }
        }

        
        public string InsideOutsideButtonText { get; set; }    


        public List<Table> DisplayTables
        {
            get
            {
                return displayTables;
            }

            set
            {
                if (IsInside)
                {
                    LoadTablesForDisplay(true);
                }
                else
                    LoadTablesForDisplay(false);
            }
        }

        public TablesPageModel()
        {
            userName = Users.LoggedInUser.UserName;
            IsInside = true;
            LoadTablesForDisplay(true);
        }

        public void LoadTablesForDisplay(bool insideTables)
        {
            displayTables = new List<Table>
            {
                new Table(true) { TableName = "Takeout", IsTakeOut = true }
            };

            foreach (var table in Tables.AllTables)
            {
                if (insideTables == table.IsInside)
                {
                    displayTables.Add(table);
                }
            }
        }
        
    }
}
