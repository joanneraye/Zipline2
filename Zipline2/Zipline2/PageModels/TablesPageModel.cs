using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using Zipline2.Models;
using Zipline2.BusinessLogic;
using Zipline2.Pages;

namespace Zipline2.PageModels
{
    class TablesPageModel : BasePageModel
    {
        //******************************NOTE IMBEDDED CLASS************************
        public class TableSelection : BasePageModel
        {
            private TablesPageModel parentTablesPageModel;
            private Color outsideTableColor;
            private Color insideTableColor;
            public string InsideTableName { get; set; }
            public Table InsideTable { get; set; }
            public string OutsideTableName { get; set; }
            public Table OutsideTable { get; set; }
            public int SelectionIndex;
            public Color OutsideTableColor
            {
                get
                {
                    return outsideTableColor;
                }
                set
                {
                    SetProperty(ref outsideTableColor, value);
                }
            }
            public Color InsideTableColor
            {
                get
                {
                    return insideTableColor;
                }
                set
                {
                    SetProperty(ref insideTableColor, value);
                }
            }

            #region Command Variables
            public System.Windows.Input.ICommand InsideTableCommand { get; set; }
            public System.Windows.Input.ICommand OutsideTableCommand { get; set; }
            #endregion

            public TableSelection(TablesPageModel referenceToParentClass)
            {
                parentTablesPageModel = referenceToParentClass;
                InsideTableCommand = new Xamarin.Forms.Command(OnInsideButtonClicked);
                OutsideTableCommand = new Xamarin.Forms.Command(OnOutsideButtonClicked);
            }
            #region Methods
            private void OnInsideButtonClicked()
            {
                TableSelection thisRow = parentTablesPageModel.DisplayTables[SelectionIndex];
                Table tableSelected = thisRow.InsideTable;
                tableSelected.IsOccupied = true;
                InsideTableColor = Color.Orange;
                //Change what the app's current table is.
                OrderManager.GetInstance().CurrentTableIndex = tableSelected.IndexInAllTables;
                parentTablesPageModel.DisplayPizzaPage();
            }
            private void OnOutsideButtonClicked()
            {
                TableSelection thisRow = parentTablesPageModel.DisplayTables[SelectionIndex];
                Table tableSelected = thisRow.OutsideTable;
                tableSelected.IsOccupied = true;
                OutsideTableColor = Color.Orange;
                //Change what the app's current table is.
                OrderManager.GetInstance().CurrentTableIndex = tableSelected.IndexInAllTables;
                parentTablesPageModel.DisplayPizzaPage();
            }
            #endregion
        }
        //******************************NOTE IMBEDDED CLASS above ************************
        #region Private Variables
        private List<TableSelection> displayTables;
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
        public INavigation Navigation { get; set; }


        public List<TableSelection> DisplayTables
        {
            get
            {
                return displayTables;
            }

            set
            {
                SetProperty(ref displayTables, value);
            }
        }
       
        #endregion
       

        #region Constructor
        public TablesPageModel(INavigation navigation)
        {
            Navigation = navigation;
            userName = Users.GetInstance().LoggedInUser.UserName;
            IsInside = true;
            LoadTablesForDisplay();
        }
        #endregion

        #region Methods
        public void LoadTablesForDisplay()
        {
            int insideTableCounter = Tables.AllTables.Count / 2;
            int halfOfTablesIndex = insideTableCounter - 1;
            DisplayTables = new List<TableSelection>();
            for (int i = 0; i < halfOfTablesIndex; i++)
            {
                var displayTable = new TableSelection(this);

                displayTable.OutsideTableName = Tables.AllTables[i].TableName;
                displayTable.OutsideTable = Tables.AllTables[i];
                if (displayTable.OutsideTable.IsOccupied)
                {
                    displayTable.OutsideTableColor = Color.Orange;
                }
                else
                {
                    displayTable.OutsideTableColor = Color.Blue;
                }
               

                displayTable.InsideTableName = Tables.AllTables[insideTableCounter].TableName;
                displayTable.InsideTable = Tables.AllTables[insideTableCounter];
                if (displayTable.InsideTable.IsOccupied)
                {
                    displayTable.InsideTableColor = Color.Orange;
                }
                else
                {
                    displayTable.InsideTableColor = Color.Blue;
                }

                displayTable.SelectionIndex = i;
                DisplayTables.Add(displayTable);
                insideTableCounter++;
            }
        }
        private async void DisplayPizzaPage()
        {
            await Navigation.PushAsync(new PizzaPage());
        }

        #endregion
    }
}
