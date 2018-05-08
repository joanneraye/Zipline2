using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Models;
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
        private DrinkCategory currentDrinkTypeSelected;
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

        public Dictionary<Tuple<DrinkType, DrinkSize>, Drink> DrinkSelectionDictionary { get; set; } 
        public DrinksPageModel()
        {
            DrinkDisplayItems = new ObservableCollection<DrinkDisplayItem>();
            DrinksSelectedCommand = new Command<DrinkCategory>(OnDrinksSelected);
            AddDrinksCommand = new Command(OnAddDrinks);
            DrinkDisplayDictionary = new Dictionary<DrinkCategory, List<DrinkDisplayItem>>();
            DrinkSelectionDictionary = new Dictionary<Tuple<DrinkType, DrinkSize>, Drink>();
            SoftDrinksSelected = true;
            OnDrinksSelected(DrinkCategory.SoftDrink);
        }


        private void LoadDrinkCategoryForDisplay(DrinkCategory drinkCategory)
        {
            List<Drink> drinksForDisplay = Drinks.GetDrinksList(drinkCategory);
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
            //Add to drink order in progress whatever was entered on the page we are leaving.
            if (currentDrinkTypeSelected != DrinkCategory.None)
            {
                AddDrinkSelections(currentDrinkTypeSelected);
            }

            //Load new drinks onto page.
            if (!DrinkDisplayDictionary.ContainsKey(newDrinkCategory))
            {
                LoadDrinkCategoryForDisplay(newDrinkCategory);
            }
            DrinkDisplayItems = new ObservableCollection<DrinkDisplayItem>(DrinkDisplayDictionary[newDrinkCategory]);
            if (currentDrinkTypeSelected != DrinkCategory.None)
            {
                LoadPreviousDrinkSelections(newDrinkCategory);
            }
               
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
            currentDrinkTypeSelected = newDrinkCategory;
        }

        private void OnAddDrinks()
        {
            AddDrinkSelections(currentDrinkTypeSelected);
            var drinkList = new List<Drink>();
            foreach (var item in DrinkSelectionDictionary.Values)
            {
                drinkList.Add(item);
            }

            OrderManager.Instance.AddDrinksToOrder(drinkList);
            LoadPizzaPage();
        }

        private void LoadPizzaPage()
        {
            var currentMainPage = (Application.Current.MainPage as MasterDetailPage);
            currentMainPage.Detail = new NavigationPage(new PizzaPage());
            Application.Current.MainPage = currentMainPage;
        }


        private void AddDrinkSelections(DrinkCategory drinkCategory)
        {
            //Check all of the drinks displayed to see if the drink
            //has an item count greater than 0.  If so, see if the 
            //drink has already been added to selections previously.  
            //If not, add it.
            foreach (var drinkDisplayItem in DrinkDisplayItems)
            {
                if (drinkDisplayItem.Drink.ItemCount > 0)
                {
                    drinkDisplayItem.Drink.UpdateItemTotal();
                    Tuple<DrinkType, DrinkSize> thisKey = Tuple.Create(drinkDisplayItem.Drink.DrinkType, drinkDisplayItem.Drink.DrinkSize);
                    if (DrinkSelectionDictionary.ContainsKey(thisKey))
                    {
                        DrinkSelectionDictionary[thisKey] = drinkDisplayItem.Drink;
                    }
                    else
                    {
                        DrinkSelectionDictionary.Add(thisKey, drinkDisplayItem.Drink);
                    }
                }
            }
        }

        private void LoadPreviousDrinkSelections(DrinkCategory drinkType)
        {
           
            foreach (var drinkDisplayItem in DrinkDisplayItems)
            {
                Tuple<DrinkType, DrinkSize> thisKey = Tuple.Create(drinkDisplayItem.Drink.DrinkType, drinkDisplayItem.Drink.DrinkSize);
                if (DrinkSelectionDictionary.ContainsKey(thisKey))
                {
                    drinkDisplayItem.Drink = DrinkSelectionDictionary[thisKey];
                }
            }
        }

    }
}
