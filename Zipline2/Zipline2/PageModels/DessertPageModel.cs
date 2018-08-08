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
        public class DessertDisplayItem : BasePageModel
        {
            private Dessert dessert;
            public Dessert Dessert
            {
                get
                {
                    return dessert;
                }
                set
                {
                    SetProperty(ref dessert, value);
                }
            }
           
            public int DessertDisplayItemIndex { get; set; }
            public ICommand MinusButtonCommand { get; set; }
            public ICommand PlusButtonCommand { get; set; }

            public DessertDisplayItem()
            {
                MinusButtonCommand = new Command(OnMinusButton);
                PlusButtonCommand = new Command(OnPlusButton);
            }

            public void OnMinusButton()
            {
                if (Dessert.ItemCount > 0)
                {
                    Dessert.ItemCount--;
                }
            }

            public void OnPlusButton()
            {
                Dessert.ItemCount++;

            }
        }

        //******************************NOTE IMBEDDED CLASS ABOVE************************

        private ObservableCollection<DessertDisplayItem> dessertDisplayItems;
        public ObservableCollection<DessertDisplayItem> DessertDisplayItems
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

        private Dictionary<string, List<DessertDisplayItem>> dessertDisplayDictionary;
        public Dictionary<string, List<DessertDisplayItem>> DessertDisplayDictionary
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
            DessertDisplayItems = new ObservableCollection<DessertDisplayItem>();
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
            string dessertDictionaryKey;
            if (cookies)
            {
                dessertDictionaryKey = "Cookies";
                foreach (var cookieDessert in MenuFood.CookieDictionary.Values)
                {
                    dessertsForDisplay.Add(cookieDessert.GetClone());
                }
                CookiesSelected = true;
            }
            else
            {
                dessertDictionaryKey = "Desserts";
                foreach (var dessert in MenuFood.DessertDictionary.Values)
                {
                    dessertsForDisplay.Add(dessert.GetClone());
                }
                DessertsSelected = true;
            }
            if (DessertDisplayDictionary == null)
            {
                DessertDisplayDictionary = new Dictionary<string, List<DessertDisplayItem>>();
            }

            var tempDisplayItems = new List<DessertDisplayItem>();
            if (!DessertDisplayDictionary.ContainsKey(dessertDictionaryKey))
            {
                
                for (int i = 0; i < dessertsForDisplay.Count; i++)
                {
                    tempDisplayItems.Add(new DessertDisplayItem()
                    {
                        Dessert = dessertsForDisplay[i].GetClone(),
                        DessertDisplayItemIndex = i
                    });
                   
                    //Use below if decide to scroll to the dessert item being edited.
                    //if (dessertsForDisplay[i].DessertType == dessertSelectedForEditDessertType)
                    //{
                    //    DessertForEditIndex = i;
                    //    break;
                    //}
                }

                DessertDisplayDictionary.Add(dessertDictionaryKey, tempDisplayItems);
            }

            tempDisplayItems = DessertDisplayDictionary[dessertDictionaryKey];            
            DessertDisplayItems = new ObservableCollection<DessertDisplayItem>(tempDisplayItems);            
        }

        public async void OnAddDesserts()
        {
            var dessertToAddToOrder = new List<OrderItem>();
            //Need to check entire Display dictionary (DrinkDisplayDictionary) for
            //any items added.
            foreach (var dessertDisplayList in DessertDisplayDictionary.Values)
            {
                foreach (var dessertDisplayItem in dessertDisplayList)
                {
                    if (dessertDisplayItem.Dessert.ItemCount > 0)
                    {
                        dessertDisplayItem.Dessert.UpdateItemTotal();
                        dessertToAddToOrder.Add(dessertDisplayItem.Dessert);
                    }
                    else
                    {
                        //Need to see if any items with zero count on the page 
                        //were on the order before and need to be deleted from the order.
                      
                            //OrderManager.Instance.RemoveOrderItem(DrinksOnTempOrderDictionary[drinkKey]);

                    }
                }
            }

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
                    if (dessertAlreadyOnTempOrder.IsCookie == cookies)
                    {
                        string dictionaryKey;
                        if (cookies)
                        {
                            dictionaryKey = "Cookies";
                        }
                        else
                        {
                            dictionaryKey = "Desserts";
                        }
                            
                        if (!DessertDisplayDictionary.ContainsKey(dictionaryKey))
                        {
                            LoadDessertCategoryForDisplay(cookies);
                        }

                        //Populate current drink items displayed with item count of 
                        //drinks already on the order.  
                        var dessertsDisplayed = DessertDisplayDictionary[dictionaryKey];
                        foreach (var dessertDisplayItem in dessertsDisplayed)
                        {
                            if (dessertDisplayItem.Dessert.DessertType == dessertAlreadyOnTempOrder.DessertType)
                            {
                                dessertDisplayItem.Dessert.ItemCount = dessertAlreadyOnTempOrder.ItemCount;
                            }
                        }
                    }
                }
            }
        }
    }
}
