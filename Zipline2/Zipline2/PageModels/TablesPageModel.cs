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
            private Table[] tablePageRow;
            public Table[] TablePageRow
            {
                get
                {
                    return tablePageRow;
                }
                set
                {
                    SetProperty(ref tablePageRow, value);
                }
            }
                       
            private bool col1TableClicked;
            public bool Col1TableClicked
            {
                get
                {
                    return col1TableClicked;
                }
                set
                {
                    SetProperty(ref col1TableClicked, value);
                }
            }
            private bool col2TableClicked;
            public bool Col2TableClicked
            {
                get
                {
                    return col2TableClicked;
                }
                set
                {
                    SetProperty(ref col2TableClicked, value);
                }
            }
            private bool col3TableClicked;
            public bool Col3TableClicked
            {
                get
                {
                    return col3TableClicked;
                }
                set
                {
                    SetProperty(ref col3TableClicked, value);
                }
            }
            private bool col4TableClicked;
            public bool Col4TableClicked
            {
                get
                {
                    return col4TableClicked;
                }
                set
                {
                    SetProperty(ref col4TableClicked, value);
                }
            }

            

            public int SelectionIndex { get; set; }
           
            #region Command Variables
            public ICommand TableCommand { get; set; }
           

            #endregion

            public TableSelection(TablesPageModel referenceToParentClass)
            {;
                parentTablesPageModel = referenceToParentClass;
                TablePageRow = new Table[4];
                TableCommand = new Command<int>(OnTableClicked);
             
                                   
            }

          
            private async void OnTableClicked(int columnIndex)
            {
                //TableSelection thisRow = parentTablesPageModel.DisplayTables[SelectionIndex];
                //Table tableSelected = TablePageRow[columnIndex];   
                //await parentTablesPageModel.ProcessSelectedTableAsync(tableSelected);
            }
        }
        //******************************NOTE IMBEDDED CLASS above ************************

        public class TableGroup : ObservableCollection<TableSelection>
        {
           
            public string GroupHeaderText { get; set; }

            public enum GroupHeaderSelector
            {
                BlankHeader,
                DividerHeader,
                TakeoutRow
            }

            public GroupHeaderSelector HeaderType { get; set; }
            
        }

        //******************************NOTE IMBEDDED CLASS above ************************
       

        #region Private Variables

        private string userName;
        #endregion

        #region Properties     
        public event EventHandler NavigateToDrinksPage;
        public event EventHandler NavigateToOrderPage;
        public ICommand TakeoutCommand { get; set; }
        public ICommand MoveTableCommand { get; set; }
        public ICommand PrintTicketCommand { get; set; }
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
        
        //private ObservableCollection<TableSelection> displayTablesGroup1;
        //public ObservableCollection<TableSelection> DisplayTablesGroup1
        //{
        //    get
        //    {
        //        return displayTablesGroup1;
        //    }

        //    set
        //    {
        //        SetProperty(ref displayTablesGroup1, value);
        //    }
        //}
        //private ObservableCollection<TableSelection> displayTablesGroup2;
        //public ObservableCollection<TableSelection> DisplayTablesGroup2
        //{
        //    get
        //    {
        //        return displayTablesGroup2;
        //    }

        //    set
        //    {
        //        SetProperty(ref displayTablesGroup2, value);
        //    }
        //}

        //private ObservableCollection<TableSelection> displayTablesGroup3;
        //public ObservableCollection<TableSelection> DisplayTablesGroup3
        //{
        //    get
        //    {
        //        return displayTablesGroup3;
        //    }

        //    set
        //    {
        //        SetProperty(ref displayTablesGroup3, value);
        //    }
        //}

        private ObservableCollection<TableGroup> tableGroups;
        public ObservableCollection<TableGroup> TableGroups
        {
            get
            {
                return tableGroups;
            }

            set
            {
                SetProperty(ref tableGroups, value);
            }
        }

        //private TablesPageHeaderTemplateSelector headerTemplateSelector;
        //public TablesPageHeaderTemplateSelector HeaderTemplateSelector
        //{
        //    get
        //    {
        //        return headerTemplateSelector;
        //    }
        //    set
        //    {
        //        SetProperty(ref headerTemplateSelector, value);
        //    }
        //}

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
        //public TablesPageModel(DataTemplate[] templates)
        //{
        //    TakeoutCommand = new Command(OnTakeoutClicked);
        //    MoveTableCommand = new Command(OnMoveTableClicked);
        //    PrintTicketCommand = new Command(OnPrintTicketClicked);
        //    LoadTablesForDisplay();
        //   // HeaderTemplateSelector = new TablesPageHeaderTemplateSelector(templates);
        //}

        public TablesPageModel()
        {
            TakeoutCommand = new Command(OnTakeoutClicked);
            MoveTableCommand = new Command(OnMoveTableClicked);
            PrintTicketCommand = new Command(OnPrintTicketClicked);
            LoadTablesForDisplay();
        }

        private void OnPrintTicketClicked(object obj)
        {
            throw new NotImplementedException();
        }

        private void OnMoveTableClicked(object obj)
        {
            throw new NotImplementedException();
        }

        private void OnTakeoutClicked(object obj)
        {
            throw new NotImplementedException();
        }


        //Not used because gets server data synchronously.
        public void LoadTableData()
        {
            var orderManager = OrderManager.Instance;

            if (orderManager.OrderInProgress != null && orderManager.OrderInProgress.OrderItems.Count > 0)
            {
                Tables.AllTables[orderManager.CurrentTableIndex].OpenOrder = OrderManager.Instance.OrderInProgress;
            }
       
            List<DBTable> tables = WcfServicesProxy.Instance.GetTableInfo();

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
       
        async public Task<bool> TableHasOpenChecks(decimal tableId)
        {
            return await WcfServicesProxy.Instance.HasOpenChecksAsync(tableId);
        }
        
        private async Task ProcessSelectedTableAsync(Table tableSelected)
        {
            tableSelected.IsOccupied = true;

            //Change what the app's current table is.
            OrderManager.Instance.UpdateCurrentTable(tableSelected);

            var dbTable = await WcfServicesProxy.Instance.GetTableAsync((int)tableSelected.TableId);
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
     
        public void LoadTablesForDisplay()
        {
            TableGroups = new ObservableCollection<TableGroup>();
            TableGroup group1 = new TableGroup();
            group1.GroupHeaderText = "Group 1";
            group1.HeaderType = TableGroup.GroupHeaderSelector.BlankHeader;
            TableGroups.Add(group1);
            //DisplayTablesGroup1 = new ObservableCollection<TableSelection>();
            TableSelection tableRow = null;
            for (int i = 0; i < 16; i++)
            {
                int rowIndex = i % 4;
                if (rowIndex == 0)
                {
                    tableRow = new TableSelection(this);
                }

                tableRow.TablePageRow[rowIndex] = Tables.AllTables[i];

                if (rowIndex == 3)
                {
                    group1.Add(tableRow);
                }
            }

            TableGroup group2 = new TableGroup();
            group2.GroupHeaderText = "Group 2";
            group2.HeaderType = TableGroup.GroupHeaderSelector.TakeoutRow;
            TableGroups.Add(group2);
            for (int j = 16; j < 24; j++)
            {
                int rowIndex2 = j % 4;
                if (rowIndex2 == 0)
                {
                    tableRow = new TableSelection(this);
                }

                tableRow.TablePageRow[rowIndex2] = Tables.AllTables[j];

                if (rowIndex2 == 3)
                {
                    group2.Add(tableRow);
                }
            }

            TableGroup group3 = new TableGroup();
            group3.GroupHeaderText = "Group 3";
            group3.HeaderType = TableGroup.GroupHeaderSelector.DividerHeader;
            TableGroups.Add(group3);
            for (int k = 24; k < Tables.AllTables.Count; k++)
            {
                int rowIndex3 = k % 4;
                if (rowIndex3 == 0)
                {
                    tableRow = new TableSelection(this);
                }

                tableRow.TablePageRow[rowIndex3] = Tables.AllTables[k];

                if (rowIndex3 == 3)
                {
                    group3.Add(tableRow);
                }
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
