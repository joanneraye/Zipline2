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
        #region Private Variables
        private List<Table> displayTables;
        private string userName;
        #endregion

        #region Properties
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
        #endregion

        #region Constructor
        public TablesPageModel()
        {
            userName = Users.GetInstance().LoggedInUser.UserName;
            IsInside = true;
            LoadTablesForDisplay(true);
        }
        #endregion

        #region Methods
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
        #endregion
    }
}
