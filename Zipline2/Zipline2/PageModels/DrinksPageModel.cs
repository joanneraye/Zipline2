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
using Zipline2.MyEventArgs;
using Zipline2.Pages;

namespace Zipline2.PageModels
{
    public class DrinksPageModel : BasePageModel
    {
        //******************************NOTE IMBEDDED CLASS************************
        public class DrinkDisplayItem : BasePageModel
        {
            private Drink drink;
            public Drink Drink
            {
                get
                {
                    return drink;
                }
                set
                {
                    SetProperty(ref drink, value);
                }
            }
            private bool isPint;
            public bool IsPint
            {
                get
                {
                    return isPint;
                }
                set
                {
                    SetProperty(ref isPint, value);
                }
            }
            private bool isPitcher;
            public bool IsPitcher
            {
                get
                {
                    return isPitcher;
                }
                set
                {
                    SetProperty(ref isPitcher, value);
                }
            }
            private bool isGlass;
            public bool IsGlass
            {
                get
                {
                    return isGlass;
                }
                set
                {
                    SetProperty(ref isGlass, value);
                }
            }
            private bool isBottle;
            public bool IsBottle
            {
                get
                {
                    return isBottle;
                }
                set
                {
                    SetProperty(ref isBottle, value);
                }
            }
            public int DrinkDisplayItemIndex { get; set; }
            public ICommand MinusButtonCommand { get; set; }
            public ICommand PlusButtonCommand { get; set; }

            public DrinkDisplayItem()
            {
                MinusButtonCommand = new Command(OnMinusButton);
                PlusButtonCommand = new Command(OnPlusButton);
            }

            public void OnMinusButton()
            {
                if (Drink.ItemCount > 0)
                {
                    Drink.ItemCount--;
                }               
            }

            public void OnPlusButton()
            {
                Drink.ItemCount++;
              
            }

           


        }

        //******************************NOTE IMBEDDED CLASS ABOVE************************
        private bool softDrinksSelected;
        private bool draftBeerSelected;
        private bool bottledBeerSelected;
        private bool whiteWineSelected;
        private bool redWineSelected;
        private bool hotDrinksSelected;
        private bool houseWineSelected;
        public bool IsDrinkSelectedForEdit { get; set; }
        public int DrinkForEditIndex { get; set; }

        private DrinkType drinkSelectedForEditDrinkType { get; set; }
        private DrinkCategory currentDrinkCategorySelected;
        private ObservableCollection<DrinkDisplayItem> drinkDisplayItems;
        public ObservableCollection<DrinkDisplayItem> DrinkDisplayItems
        {
            get
            {
                return drinkDisplayItems;
            }
            set
            {
                SetProperty(ref drinkDisplayItems, value);
            }
        }

        public bool SoftDrinksSelected
        {
            get
            {
                return softDrinksSelected;
            }
            set
            {
                SetProperty(ref softDrinksSelected, value);               
            }
        }
        public bool DraftBeerSelected
        {
            get
            {
                return draftBeerSelected;
            }
            set
            {
                SetProperty(ref draftBeerSelected, value);  
            }
        }
        public bool BottledBeerSelected
        {
            get
            {
                return bottledBeerSelected;
            }
            set
            {
                SetProperty(ref bottledBeerSelected, value);
            }
        }
        public bool RedWineSelected
        {
            get
            {
                return redWineSelected;
            }
            set
            {
                SetProperty(ref redWineSelected, value);
            }
        }
        public bool WhiteWineSelected
        {
            get
            {
                return whiteWineSelected;
            }
            set
            {
                SetProperty(ref whiteWineSelected, value);
            }
        }
        public bool HotDrinksSelected
        {
            get
            {
                return hotDrinksSelected;
            }
            set
            {
                SetProperty(ref hotDrinksSelected, value);
            }
        }
        public bool HouseWineSelected
        {
            get
            {
                return houseWineSelected;
            }
            set
            {
                SetProperty(ref houseWineSelected, value);
            }
        }
      
        public ICommand DrinksSelectedCommand { get; set; }
        public ICommand AddDrinksCommand { get; set; }

        public event EventHandler NavigateToOrderPage;
        public event EventHandler ScrollToTopOfList;
        private Dictionary<DrinkCategory, List<DrinkDisplayItem>> drinkDisplayDictionary;
        public Dictionary<DrinkCategory, List<DrinkDisplayItem>> DrinkDisplayDictionary
        {
            get
            {
                return drinkDisplayDictionary;
            }
            set
            {
                SetProperty(ref drinkDisplayDictionary, value);
            }
        }

        public Dictionary<Tuple<DrinkType, DrinkSize>, Drink> DrinksOnTempOrderDictionary { get; set; } 
        public DrinksPageModel(Drink drinkForEdit = null)
        {
            IsDrinkSelectedForEdit = false;
            DrinkDisplayItems = new ObservableCollection<DrinkDisplayItem>();
            DrinksSelectedCommand = new Command<DrinkCategory>(OnDrinksSelected);
            AddDrinksCommand = new Command(OnAddDrinks);
            DrinkDisplayDictionary = new Dictionary<DrinkCategory, List<DrinkDisplayItem>>();
            DrinksOnTempOrderDictionary = new Dictionary<Tuple<DrinkType, DrinkSize>, Drink>();
            if (drinkForEdit == null)
            {
                SoftDrinksSelected = true;
                OnDrinksSelected(DrinkCategory.SoftDrink);
            }
            else
            {
                IsDrinkSelectedForEdit = true;
                drinkSelectedForEditDrinkType = drinkForEdit.DrinkType;
                OnDrinksSelected(drinkForEdit.DrinkCategory);
            }
        }


        private void LoadDrinkCategoryForDisplay(DrinkCategory drinkCategory)
        {
            List<Drink> drinksForDisplay = MenuDrinks.GetDrinksList(drinkCategory);
            var tempDisplayItems = new List<DrinkDisplayItem>();
            for (int i = 0; i < drinksForDisplay.Count; i++)
            {  
                tempDisplayItems.Add(new DrinkDisplayItem()
                {
                    Drink = drinksForDisplay[i],
                    DrinkDisplayItemIndex = i
                });                
            }
            //Display category for this page
            DrinkDisplayItems = new ObservableCollection<DrinkDisplayItem>(tempDisplayItems);
          
            //Save this category so we don't have to recreate if come here again.
            DrinkDisplayDictionary.Add(drinkCategory, tempDisplayItems);
            
        }

       

        public void OnDrinksSelected(DrinkCategory newDrinkCategory)
        {
            if (IsDrinkSelectedForEdit)
            {
                List<Drink> drinksForDisplay = MenuDrinks.GetDrinksList(newDrinkCategory);
                for (int i = 0; i < drinksForDisplay.Count; i++)
                {
                    if (drinksForDisplay[i].DrinkType == drinkSelectedForEditDrinkType)
                    {
                        DrinkForEditIndex = i;
                        break;
                    }
                }
            }           
            else
            {
                ScrollToTopOfList?.Invoke(this, EventArgs.Empty);
            }
            //Load new drinks onto page.
            if (!DrinkDisplayDictionary.ContainsKey(newDrinkCategory))
            {
                LoadDrinkCategoryForDisplay(newDrinkCategory);
            }

            DrinkDisplayItems = new ObservableCollection<DrinkDisplayItem>(DrinkDisplayDictionary[newDrinkCategory]);
            //In case we've already added drinks to this order and are returning to that
            //drink category, we want to show what was added previously.
            LoadPreviousDrinkSelections(newDrinkCategory);
            switch (newDrinkCategory)
            {
                case DrinkCategory.SoftDrink:
                    SoftDrinksSelected = true;
                    BottledBeerSelected = false;
                    DraftBeerSelected = false;
                    RedWineSelected = false;
                    WhiteWineSelected = false;
                    HotDrinksSelected = false;
                    HouseWineSelected = false;
                    break;
                case DrinkCategory.DraftBeer:
                    DraftBeerSelected = true;
                    SoftDrinksSelected = false;
                    BottledBeerSelected = false;
                    RedWineSelected = false;
                    WhiteWineSelected = false;
                    HotDrinksSelected = false;
                    HouseWineSelected = false;
                    break;
                case DrinkCategory.BottledBeer:
                    BottledBeerSelected = true;
                    SoftDrinksSelected = false;
                    DraftBeerSelected = false;
                    RedWineSelected = false;
                    WhiteWineSelected = false;
                    HotDrinksSelected = false;
                    HouseWineSelected = false;
                    break;
                case DrinkCategory.RedWine:
                    RedWineSelected = true;
                    SoftDrinksSelected = false;
                    BottledBeerSelected = false;
                    DraftBeerSelected = false;
                    WhiteWineSelected = false;
                    HotDrinksSelected = false;
                    HouseWineSelected = false;
                    break;
                case DrinkCategory.WhiteWine:
                    WhiteWineSelected = true;
                    SoftDrinksSelected = false;
                    BottledBeerSelected = false;
                    DraftBeerSelected = false;
                    RedWineSelected = false;
                    HotDrinksSelected = false;
                    HouseWineSelected = false;
                    break;
                case DrinkCategory.HotDrink:
                    HotDrinksSelected = true;
                    RedWineSelected = false;
                    SoftDrinksSelected = false;
                    BottledBeerSelected = false;
                    DraftBeerSelected = false;
                    WhiteWineSelected = false;
                    HouseWineSelected = false;
                    break;
                case DrinkCategory.HouseWine:
                    HouseWineSelected = true;
                    HotDrinksSelected = false;
                    RedWineSelected = false;
                    SoftDrinksSelected = false;
                    BottledBeerSelected = false;
                    DraftBeerSelected = false;
                    WhiteWineSelected = false;
                    break;
            }
            currentDrinkCategorySelected = newDrinkCategory;
        }

        public async void OnAddDrinks()
        {
            var drinksToAddToOrder = new List<OrderItem>();
            //Need to check entire Display dictionary (DrinkDisplayDictionary) for
            //any items added.
            foreach (var drinkDisplayList in DrinkDisplayDictionary.Values)
            {
                foreach (var drinkDisplayItem in drinkDisplayList)
                {
                    if (drinkDisplayItem.Drink.ItemCount > 0)
                    {
                        drinkDisplayItem.Drink.UpdateItemTotal();
                        drinksToAddToOrder.Add(drinkDisplayItem.Drink);
                    }
                    else
                    {
                        //Need to see if any items with zero count on the page 
                        //were on the order before and need to be deleted from the order.
                        var drinkKey = Tuple.Create<DrinkType, DrinkSize>(drinkDisplayItem.Drink.DrinkType, drinkDisplayItem.Drink.DrinkSize);
                        if (DrinksOnTempOrderDictionary.ContainsKey(drinkKey))
                        {
                            OrderManager.Instance.RemoveOrderItem(DrinksOnTempOrderDictionary[drinkKey]);
                        }
                      
                    }
                }
            }
        
            await OrderManager.Instance.AddItemsToOrderAsync(drinksToAddToOrder);
            LoadSummaryPage();
        }

        private void LoadSummaryPage()
        {
            NavigateToOrderPage?.Invoke(this, EventArgs.Empty);
        }

        //private void LoadPizzaPage()
        //{
        //    var currentMainPage = (Application.Current.MainPage as MasterDetailPage);
        //    currentMainPage.Detail = new NavigationPage(new PizzaPage());
        //    Application.Current.MainPage = currentMainPage;
        //}

        private void LoadPreviousDrinkSelections(DrinkCategory categoryDisplayed)
        {
            //Get drink Order items and load to current screen category.
            //Will load to DrinkDisplayDictionary with key of categoryDisplayed.
            var currentOrder = OrderManager.Instance.OrderInProgress;
          
            foreach (var orderItem in currentOrder.OrderItems)
            {
                if (orderItem is Drink)
                {
                    var drinkAlreadyOnTempOrder = (Drink)orderItem;

                    //Save items to Dictionary that is on the current order.
                    var drinkKey = Tuple.Create<DrinkType, DrinkSize>(drinkAlreadyOnTempOrder.DrinkType, drinkAlreadyOnTempOrder.DrinkSize);
                    if (DrinksOnTempOrderDictionary.ContainsKey(drinkKey))
                    {
                        DrinksOnTempOrderDictionary[drinkKey] = drinkAlreadyOnTempOrder;
                    }
                    else
                    {
                        DrinksOnTempOrderDictionary.Add(drinkKey, drinkAlreadyOnTempOrder);
                    }

                    //if drink on current order is in category displayed, then we'll want 
                    //to show what the order already has.
                    if (drinkAlreadyOnTempOrder.DrinkCategory == categoryDisplayed)
                    {
                        if (!DrinkDisplayDictionary.ContainsKey(categoryDisplayed))
                        {
                            LoadDrinkCategoryForDisplay(categoryDisplayed);
                        }

                        //Populate current drink items displayed with item count of 
                        //drinks already on the order.  
                        var drinksDisplayed = DrinkDisplayDictionary[categoryDisplayed];                        
                        foreach (var drinkDisplayItem in drinksDisplayed)
                        {
                            if (drinkDisplayItem.Drink.DrinkType == drinkAlreadyOnTempOrder.DrinkType &&
                                drinkDisplayItem.Drink.DrinkSize == drinkAlreadyOnTempOrder.DrinkSize)
                            {
                                drinkDisplayItem.Drink.ItemCount = drinkAlreadyOnTempOrder.ItemCount;
                            }

                            //if (saveDrinkTypeToScrollTo == drinkDisplayItem.Drink.DrinkType)
                            //{
                            //    drinkDisplayIndexToScrollTo = drinkDisplayItem.DrinkDisplayItemIndex;
                            //}
                        } 
                    }
                }
            }
        }
    }
}
