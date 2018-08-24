using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Data;
using Zipline2.Models;

namespace Zipline2.PageModels
{
    public class DessertPageModel : BasePageModel
    {
        //******************************NOTE IMBEDDED CLASS************************
        public class DessertDisplayRow : BasePageModel
        {
            private Dessert[] rowDesserts;
            public Dessert[] RowDesserts
            {
                get
                {
                    return rowDesserts;
                }
                set
                {
                    SetProperty(ref rowDesserts, value);
                }
            }

            private Color[] circleColors;
            public Color[] CircleColors
            {
                get
                {
                    return circleColors;
                }
                set
                {
                    SetProperty(ref circleColors, value);
                }
            }

            private bool[] hideButtons;
            public bool[] HideButtons
            {
                get
                {
                    return hideButtons;
                }
                set
                {
                    SetProperty(ref hideButtons, value);
                }
            }

            public double DessertCircleHeightWidth
            {
                get
                {
                    return App.PlusMinusButtonHeightWidth;
                }
            }

            public double DessertCircleCornerRadius
            {
                get
                {
                    return App.PlusMinusButtonCornerRadius;
                }
            }

            //private Dessert dessert;
            //public Dessert Dessert
            //{
            //    get
            //    {
            //        return dessert;
            //    }
            //    set
            //    {
            //        SetProperty(ref dessert, value);
            //    }
            //}

            public int DessertDisplayRowIndex { get; set; }
            public ICommand MinusButtonCommand { get; set; }
            public ICommand PlusButtonCommand { get; set; }

            public DessertDisplayRow()
            {
                MinusButtonCommand = new Command<string>(OnMinusButton);
                PlusButtonCommand = new Command<string>(OnPlusButton);
                RowDesserts = new Dessert[3] { new Dessert(), new Dessert(), new Dessert() };
                Color whiteColor = new Color();
                whiteColor = Color.White;
                CircleColors = new Color[3] { whiteColor, whiteColor, whiteColor };
                HideButtons = new bool[3] { false, false, false };
            }
            public void OnMinusButton(string columnIndexString)
            {
                int columnIndex = 0;
                int.TryParse(columnIndexString, out columnIndex);
                if (RowDesserts[columnIndex].ItemCount > 0)
                {
                    RowDesserts[columnIndex].ItemCount--;
                }
            }

            public void OnPlusButton(string columnIndexString)
            {
                int columnIndex = 0;
                int.TryParse(columnIndexString, out columnIndex);
                RowDesserts[columnIndex].ItemCount++;
            }
        }

        //******************************NOTE IMBEDDED CLASS ABOVE************************

        private ObservableCollection<DessertDisplayRow> dessertDisplayItems;
        public ObservableCollection<DessertDisplayRow> DessertDisplayItems
        {
            get
            {
                return dessertDisplayItems;
            }
            set
            {
                SetProperty(ref dessertDisplayItems, value);
            }
        }

        private Dictionary<string, List<DessertDisplayRow>> dessertDisplayDictionary;
        public Dictionary<string, List<DessertDisplayRow>> DessertDisplayDictionary
        {
            get
            {
                return dessertDisplayDictionary;
            }
            set
            {
                SetProperty(ref dessertDisplayDictionary, value);
            }
        }

        private bool dessertsSelected;
        public bool DessertsSelected
        {
            get
            {
                return dessertsSelected;
            }
            set
            {
                SetProperty(ref dessertsSelected, value);
            }
        }

        private bool cookiesSelected;
        public bool CookiesSelected
        {
            get
            {
                return cookiesSelected;
            }
            set
            {
                SetProperty(ref cookiesSelected, value);
            }
        }

        public ICommand DessertsSelectedCommand { get; set; }

        public ICommand CookiesSelectedCommand { get; set; }
        public ICommand AddDessertsCommand { get; set; }
        public bool IsDessertSelectedForEdit { get; set; }
        private DessertType dessertSelectedForEditDessertType;
        public Dictionary<DessertType, Dessert> DessertsOnTempOrderDictionary { get; set; }
        public event EventHandler NavigateToOrderPage;

        public DessertPageModel(Dessert dessertForEdit = null)
        {
            DessertDisplayItems = new ObservableCollection<DessertDisplayRow>();
            DessertsSelectedCommand = new Command(OnDessertsSelected);
            CookiesSelectedCommand = new Command(OnCookiesSelected);
            AddDessertsCommand = new Command(OnAddDesserts);
            DessertsOnTempOrderDictionary = new Dictionary<DessertType, Dessert>();
            if (dessertForEdit == null)
            {
                LoadDessertCategoryForDisplay(false);
                LoadPreviousDessertSelections(false);
            }
            else
            {
                IsDessertSelectedForEdit = true;
                dessertSelectedForEditDessertType = dessertForEdit.DessertType;
                LoadDessertCategoryForDisplay(dessertForEdit.IsCookie);
                LoadPreviousDessertSelections(dessertForEdit.IsCookie);
            }
        }

        private void LoadDessertCategoryForDisplay(bool cookies)
        {
            List<Dessert> dessertsForDisplay = new List<Dessert>();
            //string dessertDictionaryKey;
            //dessertDictionaryKey = "Desserts";
            foreach (var dessert in MenuFood.DessertDictionary.Values)
            {
                dessertsForDisplay.Add(dessert.GetClone());
            }


            //if (cookies)
            //{
            //    dessertDictionaryKey = "Cookies";
            //    foreach (var cookieDessert in MenuFood.CookieDictionary.Values)
            //    {
            //        dessertsForDisplay.Add(cookieDessert.GetClone());
            //    }
            //    CookiesSelected = true;
            //}
            //else
            //{
            //    dessertDictionaryKey = "Desserts";
            //    foreach (var dessert in MenuFood.DessertDictionary.Values)
            //    {
            //        dessertsForDisplay.Add(dessert.GetClone());
            //    }
            //    DessertsSelected = true;
            //}
            //if (DessertDisplayDictionary == null)
            //{
            //    DessertDisplayDictionary = new Dictionary<string, List<DessertDisplayRow>>();
            //}

            //var tempDisplayItems = new List<DessertDisplayRow>();
            //if (!DessertDisplayDictionary.ContainsKey(dessertDictionaryKey))
            //{

            //    for (int i = 0; i < dessertsForDisplay.Count; i++)
            //    {
            //        tempDisplayItems.Add(new DessertDisplayRow()
            //        {
            //            Dessert = dessertsForDisplay[i].GetClone(),
            //            DessertDisplayItemIndex = i
            //        });

            //        //Use below if decide to scroll to the dessert item being edited.
            //        //if (dessertsForDisplay[i].DessertType == dessertSelectedForEditDessertType)
            //        //{
            //        //    DessertForEditIndex = i;
            //        //    break;
            //        //}
            //    }

            //    DessertDisplayDictionary.Add(dessertDictionaryKey, tempDisplayItems);
            //}

            //tempDisplayItems = DessertDisplayDictionary[dessertDictionaryKey];   


            var tempDisplayItems = GetDessertDisplayRows(dessertsForDisplay);
            DessertDisplayItems = new ObservableCollection<DessertDisplayRow>(tempDisplayItems);            
        }

        private List<DessertDisplayRow> GetDessertDisplayRows(List<Dessert> dessertsForDisplay)
        {
            List<DessertDisplayRow> rows = new List<DessertDisplayRow>();
            DessertDisplayRow workingRow = new DessertDisplayRow();
            int rowCount = 0;
            int lastItemIndex = dessertsForDisplay.Count - 1;
            for (int i = 0; i < dessertsForDisplay.Count; i++)
            {
                Color circleColor = GetCircleColor(dessertsForDisplay[i].DessertType);
                int column = i % 3;
                if (column == 0)
                {
                    workingRow = new DessertDisplayRow();
                    workingRow.RowDesserts[0] = dessertsForDisplay[i].GetClone();
                    workingRow.CircleColors[0] = circleColor;
                    if (i == lastItemIndex)
                    {
                        workingRow.RowDesserts[1] = new Dessert();
                        workingRow.CircleColors[1] = Color.Black;
                        workingRow.HideButtons[1] = true;
                        workingRow.RowDesserts[2] = new Dessert();
                        workingRow.CircleColors[2] = Color.Black;
                        workingRow.HideButtons[2] = true;
                        workingRow.DessertDisplayRowIndex = rowCount;
                        rows.Add(workingRow);
                        break;
                    }
                }
                else if (column == 1)
                {
                    workingRow.RowDesserts[1] = dessertsForDisplay[i].GetClone();
                    workingRow.CircleColors[1] = circleColor;
                    if (i == lastItemIndex)
                    {
                        workingRow.DessertDisplayRowIndex = rowCount;
                        workingRow.RowDesserts[2] = new Dessert();
                        workingRow.CircleColors[2] = Color.Black;
                        workingRow.HideButtons[2] = true;
                        rows.Add(workingRow);
                        break;
                    }
                }
                else if (column == 2)
                {
                    workingRow.RowDesserts[2] = dessertsForDisplay[i].GetClone();
                    workingRow.CircleColors[2] = circleColor;
                    workingRow.DessertDisplayRowIndex = rowCount;
                    rows.Add(workingRow);
                    rowCount++;
                }
            }
            return rows;
        }

        private Color GetCircleColor(DessertType dessertType)
        {
            if (dessertType.ToString().Contains("Cookie"))
            {
                return Color.Orange;
            }
            else
            {
                return Color.Tan;
            }
        }

        public async void OnAddDesserts()
        {
            var dessertToAddToOrder = new List<OrderItem>();
            //Need to check entire Display dictionary (DrinkDisplayDictionary) for
            //any items added.
            //foreach (var dessertDisplayList in DessertDisplayDictionary.Values)
            //{
                foreach (var dessertDisplayRow in DessertDisplayItems)
                {
                    foreach (var dessert in dessertDisplayRow.RowDesserts)
                    {
                        if (dessert.ItemCount > 0)
                        {
                            dessert.UpdateItemTotal();
                            dessertToAddToOrder.Add(dessert);
                        }
                        else
                        {
                            //Need to see if any items with zero count on the page 
                            //were on the order before and need to be deleted from the order.

                            //OrderManager.Instance.RemoveOrderItem(DrinksOnTempOrderDictionary[drinkKey]);

                        }
                    }
                }
            //}

            await OrderManager.Instance.AddItemsToOrderAsync(dessertToAddToOrder);
            LoadSummaryPage();
        }

        private void LoadSummaryPage()
        {
            try
            {
                NavigateToOrderPage?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                var whatisthis = ex.InnerException;
                throw;
            }
           
        }

        private void OnCookiesSelected()
        {
            CookiesSelected = true;
            DessertsSelected = false;
            LoadDessertCategoryForDisplay(true);
        }

        private void OnDessertsSelected()
        {
            CookiesSelected = false;
            DessertsSelected = true;
            LoadDessertCategoryForDisplay(false);
        }

        private void LoadPreviousDessertSelections(bool cookies)
        {
            //Get dessert Order items and load to current screen category.
            //Will load to DrinkDisplayDictionary with ke of categoryDisplayed.
            var currentOrder = OrderManager.Instance.OrderInProgress;

            foreach (var orderItem in currentOrder.OrderItems)
            {
                if (orderItem is Dessert)
                {
                    var dessertAlreadyOnTempOrder = (Dessert)orderItem;

                    //Save items to Dictionary that is on the current order.
                    if (DessertsOnTempOrderDictionary.ContainsKey(dessertAlreadyOnTempOrder.DessertType))
                    {
                        DessertsOnTempOrderDictionary[dessertAlreadyOnTempOrder.DessertType] = dessertAlreadyOnTempOrder;
                    }
                    else
                    {
                        DessertsOnTempOrderDictionary.Add(dessertAlreadyOnTempOrder.DessertType, dessertAlreadyOnTempOrder);
                    }

                    //if drink on current order is in category displayed, then we'll want 
                    //to show what the order already has.
                    //if (dessertAlreadyOnTempOrder.IsCookie == cookies)
                    //{
                    //    string dictionaryKey;
                    //    if (cookies)
                    //    {
                    //        dictionaryKey = "Cookies";
                    //    }
                    //    else
                    //    {
                    //        dictionaryKey = "Desserts";
                    //    }

                    //    if (!DessertDisplayDictionary.ContainsKey(dictionaryKey))
                    //    {
                    //        LoadDessertCategoryForDisplay(cookies);
                    //    }

                    //    //Populate current drink items displayed with item count of 
                    //    //drinks already on the order.  
                    //    var dessertsDisplayed = DessertDisplayDictionary[dictionaryKey];
                    foreach (var dessertDisplayRow in DessertDisplayItems)
                    {
                        foreach (var dessert in dessertDisplayRow.RowDesserts)
                        {
                            if (dessert.DessertType == dessertAlreadyOnTempOrder.DessertType)
                            {
                                dessert.ItemCount = dessertAlreadyOnTempOrder.ItemCount;
                            }
                        }
                        
                    }
                }
            }
        }
    }
}
