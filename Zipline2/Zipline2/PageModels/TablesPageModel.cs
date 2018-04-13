﻿using System;
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
            //public System.Windows.Input.ICommand InsideTableCommand { get; set; }
            //public System.Windows.Input.ICommand OutsideTableCommand { get; set; }
            #endregion

            public TableSelection(TablesPageModel referenceToParentClass)
            {
                parentTablesPageModel = referenceToParentClass;
                //InsideTableCommand = new Xamarin.Forms.Command(OnInsideButtonClicked);
                //OutsideTableCommand = new Xamarin.Forms.Command(OnOutsideButtonClicked);
            }
            #region Methods
            //private void OnInsideButtonClicked()
            //{
            //    TableSelection thisRow = parentTablesPageModel.DisplayTables[SelectionIndex];
            //    Table tableSelected = thisRow.InsideTable;
            //    tableSelected.IsOccupied = true;
            //    InsideTableColor = Color.Orange;
            //    //Change what the app's current table is.
            //    OrderManager.Instance.CurrentTableIndex = tableSelected.IndexInAllTables;
            //    parentTablesPageModel.DisplayPizzaPage();
            //}
            //private void OnOutsideButtonClicked()
            //{
            //    TableSelection thisRow = parentTablesPageModel.DisplayTables[SelectionIndex];
            //    Table tableSelected = thisRow.OutsideTable;
            //    tableSelected.IsOccupied = true;
            //    OutsideTableColor = Color.Orange;
            //    //Change what the app's current table is.
            //    OrderManager.Instance.CurrentTableIndex = tableSelected.IndexInAllTables;
            //    parentTablesPageModel.DisplayPizzaPage();
            //}
            #endregion
        }
        //******************************NOTE IMBEDDED CLASS above ************************
        #region Private Variables
        private List<TableSelection> displayTables;
        private string userName;
        #endregion

        #region Properties
        //public bool IsInside { get; set; }

        
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
        
        //public string InsideOutsideButtonText { get; set; }
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
            //userName = Users.Instance.LoggedInUser.UserName;
            LoadTablesForDisplay();
        }
        #endregion

        #region Methods

        private void PopulateRowWithInsideTable(ref TableSelection thisRow, int indexInAllTables)
        {
            thisRow.InsideTableName = Tables.AllTables[indexInAllTables].TableName;
            thisRow.InsideTable = Tables.AllTables[indexInAllTables];
            if (thisRow.InsideTable.IsOccupied)
            {
                thisRow.InsideTableColor = Color.Orange;
            }
            else
            {
                thisRow.InsideTableColor = Color.Blue;
            }
        }

        private void PopulateRowWithOutsideTable(ref TableSelection thisRow, int indexInAllTables)
        {
            thisRow.OutsideTableName = Tables.AllTables[indexInAllTables].TableName;
            thisRow.OutsideTable = Tables.AllTables[indexInAllTables];
            if (thisRow.OutsideTable.IsOccupied)
            {
                thisRow.OutsideTableColor = Color.Orange;
            }
            else
            {
                thisRow.OutsideTableColor = Color.Blue;
            }
        }
        public void LoadTablesForDisplay()
        {
            DisplayTables = new List<TableSelection>();
            decimal halfOfTableCount = Tables.AllTables.Count / 2;
            int outsideTableIndex = Convert.ToInt32(Math.Ceiling(halfOfTableCount));
            int insideTableIndex = 0;

            while (Tables.AllTables[insideTableIndex].IsInside &&
                     outsideTableIndex < Tables.AllTables.Count)            //Create all full rows
            {
                var displayTableRow = new TableSelection(this);
                PopulateRowWithInsideTable(ref displayTableRow, insideTableIndex);
                PopulateRowWithOutsideTable(ref displayTableRow, outsideTableIndex);
                displayTableRow.SelectionIndex = insideTableIndex;
                DisplayTables.Add(displayTableRow);
                outsideTableIndex++;
                insideTableIndex++;
            }
            while (Tables.AllTables[insideTableIndex].IsInside)
            {
                var displayTableRow = new TableSelection(this);
                PopulateRowWithInsideTable(ref displayTableRow, insideTableIndex);
                displayTableRow.OutsideTable = new Table();
                displayTableRow.OutsideTableName = string.Empty;
                displayTableRow.OutsideTableColor = Color.Black;
                displayTableRow.SelectionIndex = insideTableIndex;
                DisplayTables.Add(displayTableRow);
                insideTableIndex++;
            }
            int currentRowIndex = insideTableIndex;
            while (outsideTableIndex < Tables.AllTables.Count)
            {
                var displayTableRow = new TableSelection(this);
                PopulateRowWithOutsideTable(ref displayTableRow, outsideTableIndex);
                displayTableRow.InsideTable = new Table();
                displayTableRow.InsideTableName = string.Empty;
                displayTableRow.InsideTableColor = Color.Black;
                displayTableRow.SelectionIndex = currentRowIndex;
                DisplayTables.Add(displayTableRow);
                outsideTableIndex++;
                currentRowIndex++;
            }
        }
        private async void DisplayPizzaPage()
        {
            await Navigation.PushAsync(new PizzaPage());
        }

        #endregion
    }
}
