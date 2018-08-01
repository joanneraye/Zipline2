using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Zipline2.BusinessLogic;
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

        public event EventHandler NavigateToOrderPage;

        public DessertPageModel()
        {
            DessertDisplayItems = new ObservableCollection<DessertDisplayItem>();
            DessertsSelectedCommand = new Command(OnDessertsSelected);
            CookiesSelectedCommand = new Command(OnCookiesSelected);
            AddDessertsCommand = new Command(OnAddDesserts);
            DessertsSelected = true;
            LoadDrinkCategoryForDisplay(false);
        }

        private void LoadDrinkCategoryForDisplay(bool cookies)
        {
            List<Dessert> dessertsForDisplay = new List<Dessert>();
            string dessertDictionaryKey;
            if (cookies)
            {
                dessertDictionaryKey = "Cookies";
                foreach (var cookieDessert in MenuFood.CookieDictionary.Values)
                {
                    dessertsForDisplay.Add(cookieDessert);
                }
                
            }
            else
            {
                dessertDictionaryKey = "Desserts";
                foreach (var dessert in MenuFood.DessertDictionary.Values)
                {
                    dessertsForDisplay.Add(dessert);
                }
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
                        Dessert = dessertsForDisplay[i],
                        DessertDisplayItemIndex = i
                    });
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
            LoadDrinkCategoryForDisplay(true);
        }

        private void OnDessertsSelected()
        {
            CookiesSelected = false;
            DessertsSelected = true;
            LoadDrinkCategoryForDisplay(false);
        }
    }
}
