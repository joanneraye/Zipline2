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
using Zipline2.Data;
using System.Threading;

namespace Zipline2.PageModels
{
    class TablesPageModel : BasePageModel
    {
        //******************************NOTE IMBEDDED CLASS************************
        public class TableSelection : BasePageModel
        {
            private TablesPageModel parentTablesPageModel;
            //private Color outsideTableColor;
            //private Color insideTableColor;
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
                }
            }

            private bool insideTableClicked;
            public bool InsideTableClicked
            {
                get
                {
                    return insideTableClicked;
                }
                set
                {
                    SetProperty(ref insideTableClicked, value);
                }
            }

            private bool outsideTableClicked;
            public bool  OutsideTableClicked
            {
                get
                {
                    return outsideTableClicked;
                }
                set
                {
                    SetProperty(ref outsideTableClicked, value);
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
                }
            }

            public int SelectionIndex { get; set; }
            public int IndexInAllTables { get; set; }
            //public Color OutsideTableColor
            //{
            //    get
            //    {
            //        return outsideTableColor;
            //    }
            //    set
            //    {
            //        SetProperty(ref outsideTableColor, value);
            //    }
            //}
            //public Color InsideTableColor
            //{
            //    get
            //    {
            //        return insideTableColor;
            //    }
            //    set
            //    {
            //        SetProperty(ref insideTableColor, value);
            //    }
            //}

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

            
            private async void OnInsideButtonClicked()
            {
                InsideTableClicked = true;
                TableSelection thisRow = parentTablesPageModel.DisplayTables[SelectionIndex];
                Table tableSelected = thisRow.InsideTable;
                await parentTablesPageModel.ProcessSelectedTableAsync(tableSelected);
                InsideTableClicked = false;
               
            }
            private async void OnOutsideButtonClicked()
            {
                OutsideTableClicked = true;
                TableSelection thisRow = parentTablesPageModel.DisplayTables[SelectionIndex];
                Table tableSelected = thisRow.OutsideTable;
                await parentTablesPageModel.ProcessSelectedTableAsync(tableSelected);
                OutsideTableClicked = false;
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

        private bool isBusy;
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                SetProperty(ref isBusy, value);
            }
        }
       
        #endregion
       

        #region Constructor
        public TablesPageModel()
        {
            LoadTablesForDisplay();
        }

        //Not used because gets server data synchronously.
        public void LoadTableData()
        {
            var orderManager = OrderManager.Instance;

            if (orderManager.OrderInProgress != null && orderManager.OrderInProgress.OrderItems.Count > 0)
            {
                Tables.AllTables[orderManager.CurrentTableIndex].OpenOrder = OrderManager.Instance.OrderInProgress;
            }
       
            var watch = System.Diagnostics.Stopwatch.StartNew();
            List<DBTable> tables = WcfServicesProxy.Instance.GetTableInfo();
            watch.Stop();

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
                    Console.WriteLine("***Debug JOANNE***TABLE NOT FOUND FOR TABLE ID: " + table.ID);
                }

                var thisTable = Tables.AllTables[indexInAllTables];
              
                foreach (var guest in table.Guests)
                {
                    if (guest.Items.Count > 0 || guest.ComboItems.Count > 0)
                    {
                        foreach (var item in guest.Items)
                        {
                            tableOccupied = true;
                            if (!item.OrderSent)
                            {
                                hasUnsentItems = true;
                            }
                        }
                        if (!hasUnsentItems)
                        {
                            foreach (var comboitem in guest.ComboItems)
                            {
                                tableOccupied = true;
                                foreach (var guestitem in comboitem.ComboGuestItems)
                                    if (!guestitem.OrderSent)
                                    {
                                        hasUnsentItems = true;
                                    }
                            }
                        }
                    }
                    //no items from server so use local table saved if one exists.
                    else if (thisTable.OpenOrder != null)
                    {
                        if (thisTable.OpenOrder.OrderItems.Count > 0)
                        {
                            tableOccupied = true;
                        }
                        if (!thisTable.OpenOrder.AllItemsSent)
                        {
                            hasUnsentItems = true;
                        }
                    }
                }


                if (tableOccupied)
                {
                    Tables.AllTables[indexInAllTables].IsOccupied = tableOccupied;

                    if (hasUnsentItems)
                    {
                        Tables.AllTables[indexInAllTables].HasUnsentOrder = hasUnsentItems;
                    }
                }
            }
        }
        #endregion

        #region Methods

        //async public Task<List<DBTable>> GetTablesAsync()
        //{
            
        //    return await WcfServicesProxy.Instance.GetTableInfoFromServerAsync();
        //}

        async public Task<bool> TableHasOpenChecks(decimal tableId)
        {
            return await WcfServicesProxy.Instance.HasOpenChecksAsync(tableId);
        }
        
        private async Task ProcessSelectedTableAsync(Table tableSelected)
        {
            tableSelected.IsOccupied = true;
            //Change what the app's current table is.
            OrderManager.Instance.UpdateCurrentTable(tableSelected);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            var dbTable = await WcfServicesProxy.Instance.GetTableAsync((int)tableSelected.TableId);
            watch.Reset();

            //var dbTable = WcfServicesProxy.Instance.GetTable((int)tableSelected.TableId);
           
            tableSelected.DatabaseTable = dbTable;
           
            if (dbTable.Guests != null)
            {
                Tables.AllTables[tableSelected.IndexInAllTables] = tableSelected;
                if (dbTable.Guests.Count > 0)
                {
                    List<GuestItem> guestItems = new List<GuestItem>();
                    List<GuestComboItem> comboGuestItems = new List<GuestComboItem>();

                    decimal[] guestIds = new decimal[2];
                    for (int i = 0; i < dbTable.Guests.Count; i++)
                    {
                        if (i <= 1)
                        {
                            guestIds[i] = dbTable.Guests[i].ID;
                        }
                        guestItems.AddRange(dbTable.Guests[i].Items);
                        comboGuestItems.AddRange(dbTable.Guests[i].ComboItems);
                    }
                   
                    Order openOrder = null;
                    if (guestItems.Count > 0 || comboGuestItems.Count > 0)
                    {
                        openOrder = DataConversion.ConvertDbGuestsToOrder(guestIds, guestItems, comboGuestItems, tableSelected.TableId, tableSelected.IndexInAllTables);
                        OrderManager.Instance.OrderInProgress = openOrder;
                        if (!openOrder.AllItemsSent)
                        {
                            tableSelected.HasUnsentOrder = true;
                        }
                    }

                    //used just during testing so that orders can be looked at without sending to server
                    if (openOrder != null)
                    {
                        Tables.AllTables[tableSelected.IndexInAllTables].OpenOrder = openOrder;
                        DisplayOrderPage();
                        return;
                    }
                }
            }
            watch.Stop();
            //used just during testing so that orders can be looked at without sending to server.
            //Only if no orders on server, see if OpenOrders for this table on this phone...
            var orderForThisTable = Tables.AllTables[tableSelected.IndexInAllTables].OpenOrder;
            if (orderForThisTable != null)
            {
                OrderManager.Instance.OrderInProgress = orderForThisTable;
                DisplayOrderPage();
            }
            else
            //if no open orders out there for this table, start a new order.
            {
                OrderManager.Instance.InitializeOrderInProgress();
                DisplayDrinksPage();
            }
            
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
            //Next 2 statements must be in that order because when table is valued (2nd statement), if there is an
            //unsent order the name of the table is changed to show "unsent".  If the name is set (1st statement) after that,
            //rather than before, it will wipe this out. 
            thisRow.InsideTableName = Tables.AllTables[indexInAllTables].TableName;
            thisRow.InsideTable = Tables.AllTables[indexInAllTables];
            //if (thisRow.InsideTable.HasUnsentOrder)
            //{
            //    thisRow.InsideTableName += " UNSENT";
            //}

            //if (thisRow.InsideTable.IsOccupied)
            //{
            //    thisRow.InsideTableColor = Color.Orange;
            //}
            //else
            //{
            //    thisRow.InsideTableColor = Color.Blue;
            //}
        }


        private void PopulateRowWithOutsideTable(ref TableSelection thisRow, int indexInAllTables)
        {
            //Next 2 statements must be in that order because when table is valued (2nd statement), if there is an
            //unsent order the name of the table is changed to show "unsent".  If the name is set (1st statement) after that,
            //rather than before, it will wipe this out.  
            thisRow.OutsideTableName = Tables.AllTables[indexInAllTables].TableName;
            thisRow.OutsideTable = Tables.AllTables[indexInAllTables];
            //if (thisRow.OutsideTable.HasUnsentOrder)
            //{
            //    thisRow.OutsideTableName += " UNSENT";
            //}
            //if (thisRow.OutsideTable.IsOccupied)
            //{
            //    thisRow.OutsideTableColor = Color.Orange;
            //}
            //else
            //{
            //    thisRow.OutsideTableColor = Color.Blue;
            //}
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
