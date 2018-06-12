using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using Zipline2.Models;
using Zipline2.BusinessLogic;
using Zipline2.Pages;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Zipline2.BusinessLogic.WcfRemote;
using Staunch.POS.Classes;

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
            private string insideTableName;
            public string InsideTableName
            {
                get
                {
                    return insideTableName;
                }
                set
                {
                    SetProperty(ref insideTableName, value);
                }
            }
            private Table insideTable;
            public Table InsideTable
            {
                get
                {
                    return insideTable;
                }
                set
                {
                    SetProperty(ref insideTable, value);
                    if (insideTable.HasUnsentOrder)
                    {
                        insideTableName = insideTable.TableName + " UNSENT ORDER ITEM";
                    }
                    else
                    {
                        insideTableName = insideTable.TableName;
                    }
                }
            }
            private string outsideTableName;
            public string OutsideTableName
            {
                get
                {
                    return outsideTableName;
                }
                set
                {
                    SetProperty(ref outsideTableName, value);
                }
            }
            private Table outsideTable;
            public Table OutsideTable
            {
                get
                {
                    return outsideTable;
                }
                set
                {
                    SetProperty(ref outsideTable, value);
                    if (outsideTable.HasUnsentOrder)
                    {
                        outsideTableName = outsideTable.TableName + " UNSENT ORDER ITEM";
                    }
                    else
                    {
                        outsideTableName = outsideTable.TableName;
                    }
                }
            }
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

            
            private void OnInsideButtonClicked()
            {
                TableSelection thisRow = parentTablesPageModel.DisplayTables[SelectionIndex];
                Table tableSelected = thisRow.InsideTable;
                InsideTableColor = Color.Orange;
                parentTablesPageModel.ProcessSelectedTable(tableSelected);
               
            }
            private void OnOutsideButtonClicked()
            {
                TableSelection thisRow = parentTablesPageModel.DisplayTables[SelectionIndex];
                Table tableSelected = thisRow.OutsideTable;
                OutsideTableColor = Color.Orange;
                parentTablesPageModel.ProcessSelectedTable(tableSelected);
            }
        }
        //******************************NOTE IMBEDDED CLASS above ************************
        #region Private Variables
        private ObservableCollection<TableSelection> displayTables;
        private string userName;
        #endregion

        #region Properties     
        public event EventHandler NavigateToDrinksPage;
        public event EventHandler NavigateToOrderPage;
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
        public ObservableCollection<TableSelection> DisplayTables
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
        public TablesPageModel()
        {
            //First populate list of tables with whether table is occupied and has unsent orders.
            //(Then build the page with that data in LoadTablesForDisplay method.)
            List<DBTable> tables = WcfServicesProxy.Instance.GetTableInfoFromServer();
           
            foreach (var table in tables)
            {
                bool hasUnsentItems = false;
                bool tableOccupied = false;
                int indexInAllTables = 0;
                if (DataBaseDictionaries.TableIdAllTablesIndexDictionary.ContainsKey(table.ID))
                {
                    indexInAllTables = DataBaseDictionaries.TableIdAllTablesIndexDictionary[table.ID];
                }
                else
                {
                    Console.WriteLine("***Debug JOANNE***TABLE NOTE FOUND FOR TABLE ID: " + table.ID);
                }
                foreach (var guest in table.Guests)
                {
                    if (guest.Items.Count > 0 || guest.ComboItems.Count > 0)
                    {
                        tableOccupied = true;
                        foreach (var item in guest.Items)
                        {
                            if (!item.OrderSent)
                            {
                                hasUnsentItems = true;
                            }
                        }
                    }
                }

                if (tableOccupied)
                {
                    Tables.AllTables[indexInAllTables].IsOccupied = tableOccupied;
                }

                if (hasUnsentItems)
                {
                    Tables.AllTables[indexInAllTables].HasUnsentOrder = hasUnsentItems;
                }
            }
            LoadTablesForDisplay();
        }
        #endregion

        #region Methods

        async public Task<bool> TableHasOpenChecks(decimal tableId)
        {
            return await WcfServicesProxy.Instance.HasOpenChecksAsync(tableId);
        }
        
        async private void ProcessSelectedTable(Table tableSelected)
        {
            tableSelected.IsOccupied = true;
            //Change what the app's current table is.
            OrderManager.Instance.UpdateCurrentTable(tableSelected);

            //var result = await WcfServicesProxy.Instance.HasOpenChecksAsync(tableSelected.TableId);
            //var dbTable = await WcfServicesProxy.Instance.GetTableAsync((int)tableSelected.TableId);

            var dbTable = WcfServicesProxy.Instance.GetTableSync((int)tableSelected.TableId);
            tableSelected.DatabaseTable = dbTable;
            Tables.AllTables[tableSelected.IndexInAllTables] = tableSelected;
            if (dbTable.Guests.Count > 0)
            {
                List<GuestItem> guestItems = new List<GuestItem>();
                foreach (var guest in dbTable.Guests)
                {
                    guestItems.AddRange(guest.Items);
                }
                if (guestItems.Count > 0)
                {
                    Order openOrder = DataConversion.ConvertDbGuestsToOrder(guestItems, tableSelected.TableId);
                    OrderManager.Instance.OrderInProgress = openOrder;
                    if (!openOrder.AllItemsSent)
                    {
                        tableSelected.HasUnsentOrder = true;
                    }
                    //Tables.AllTables[tableSelected.IndexInAllTables].OpenOrders = new List<Order>() { openOrder };
                    DisplayOrderPage();
                    return;
                }
            }

            //TODO:  Should this never occur?
            //Only if no orders on server, see if OpenOrders for this table on this phone...
            //var ordersForThisTable = Tables.AllTables[tableSelected.IndexInAllTables].OpenOrders;
            //if (ordersForThisTable.Count > 0)
            //{
            //    OrderManager.Instance.OrderInProgress = ordersForThisTable[0];
            //    DisplayOrderPage();
            //}
            //else
            ////if no open orders out there for this table, start a new order.
            //{ 
                OrderManager.Instance.InitializeOrderInProgress();
                DisplayDrinksPage();
            //}
            
            //else if (await TableHasOpenChecks(tableSelected.TableId))
            //Are there checks on server for that table (not on phone)?  If, so
            //load that order and bring up summary.
            //{
            //    var checks = await WcfServicesProxy.Instance.GetOpenChecksAsync(tableSelected.TableId);
            //    foreach (var check in checks)
            //    {
            //        var openOrder = DataConversion.ConvertDbCheckToOrder(check, tableSelected.TableId);
            //        Tables.AllTables[tableSelected.IndexInAllTables].OpenOrders.Add(openOrder);
            //    }
              
            //    OrderManager.Instance.OrderInProgress = ordersForThisTable[0];
            //    DisplayOrderPage();
            //}
              
        }

        private void PopulateRowWithInsideTable(ref TableSelection thisRow, int indexInAllTables)
        {
            thisRow.InsideTable = Tables.AllTables[indexInAllTables];
            thisRow.InsideTableName = Tables.AllTables[indexInAllTables].TableName;
            if (thisRow.InsideTable.HasUnsentOrder)
            {
                thisRow.InsideTableName += " UNSENT ORDER ITEM";
            }

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
            if (thisRow.OutsideTable.HasUnsentOrder)
            {
                thisRow.OutsideTableName += " UNSENT ORDER ITEM";
            }
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
            DisplayTables = new ObservableCollection<TableSelection>();
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
        void DisplayDrinksPage()
        {
            OnNavigateToDrinksPage();
        }

        void DisplayOrderPage()
        {
            OnNavigateToOrderPage();
        }
       
        void OnNavigateToDrinksPage() => NavigateToDrinksPage?.Invoke(this, EventArgs.Empty);

        void OnNavigateToOrderPage() => NavigateToOrderPage?.Invoke(this, EventArgs.Empty);

        #endregion
    }
}
