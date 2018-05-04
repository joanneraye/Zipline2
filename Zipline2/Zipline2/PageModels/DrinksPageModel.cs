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

        private string[] drinkList;

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

        public string[] DrinkList
        {
            get
            {
                return drinkList;
            }
            set
            {
                SetProperty(ref drinkList, value);
            }
        }
        public ICommand DrinksSelectedCommand { get; set; }
        public ICommand AddDrinksCommand { get; set; }

        public Dictionary<DrinkCategory, List<DrinkDisplayItem>> DrinkDisplayDictionary { get; private set; } 
        public Dictionary<DrinkType, Drink> DrinkSelectionDictionary { get; set; } 
        public DrinksPageModel()
        {
            DrinkDisplayItems = new ObservableCollection<DrinkDisplayItem>();
            DrinksSelectedCommand = new Command<DrinkCategory>(OnDrinksSelected);
            AddDrinksCommand = new Command(OnAddDrinks);
            DrinkDisplayDictionary = new Dictionary<DrinkCategory, List<DrinkDisplayItem>>();
            DrinkSelectionDictionary = new Dictionary<DrinkType, Drink>();
            SoftDrinksSelected = true;
            OnDrinksSelected(DrinkCategory.SoftDrinks);
        }


        private void LoadDrinkCategoryForDisplay(DrinkCategory drinkCategory)
        {
            List<DrinkType> drinkTypes = new List<DrinkType>();
            Func<DrinkType, string> methodToGetDisplayName = DisplayNames.GetSoftDrinkDisplayName;

            switch (drinkCategory)
            {
                case DrinkCategory.SoftDrinks:
                    drinkTypes = new List<DrinkType>(DisplayNames.DisplaySoftDrinkNameDictionary.Keys);
                    methodToGetDisplayName = DisplayNames.GetSoftDrinkDisplayName;
                    break;
                case DrinkCategory.DraftBeer:
                    drinkTypes = new List<DrinkType>(DisplayNames.DisplayDraftBeerNameDictionary.Keys);
                    methodToGetDisplayName = DisplayNames.GetDraftBeerDisplayName;
                    break;
                case DrinkCategory.BottledBeer:
                    drinkTypes = new List<DrinkType>(DisplayNames.DisplayBottledBeerNameDictionary.Keys);
                    methodToGetDisplayName = DisplayNames.GetBottledBeerDisplayName;
                    break;
                case DrinkCategory.RedWine:
                    drinkTypes = new List<DrinkType>(DisplayNames.DisplayRedWineNameDictionary.Keys);
                    methodToGetDisplayName = DisplayNames.GetRedWineDisplayName;
                    break;
                case DrinkCategory.WhiteWine:
                    drinkTypes = new List<DrinkType>(DisplayNames.DisplayWhiteWineNameDictionary.Keys);
                    methodToGetDisplayName = DisplayNames.GetWhiteWineDisplayName;
                    break;
                case DrinkCategory.HouseWine:
                    drinkTypes = new List<DrinkType>(DisplayNames.DisplayHouseWineNameDictionary.Keys);
                    methodToGetDisplayName = DisplayNames.GetHouseWineDisplayName;
                    break;
                case DrinkCategory.HotDrinks:
                    drinkTypes = new List<DrinkType>(DisplayNames.DisplayHotDrinksNameDictionary.Keys);
                    methodToGetDisplayName = DisplayNames.GetHotDrinksDisplayName;
                    break;

            }
            int indexOfSoftDrink = 0;
            var drinkDisplayItems = new List<DrinkDisplayItem>();
            foreach (var drinkType in drinkTypes)
            {
                var drinkDisplayItem = new DrinkDisplayItem()
                {
                    DrinkDisplayItemIndex = indexOfSoftDrink,
                    Drink = new Drink(drinkType)
                    {
                        ItemName = methodToGetDisplayName(drinkType),
                        ItemCount = 0,
                        DrinkCategory = drinkCategory
                    }
                };
                drinkDisplayItems.Add(drinkDisplayItem);
            }
            DrinkDisplayDictionary.Add(drinkCategory, drinkDisplayItems);
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
            LoadPreviousDrinkSelections(newDrinkCategory);
            switch (newDrinkCategory)
            {
                case DrinkCategory.SoftDrinks:
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
                case DrinkCategory.HotDrinks:
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
            foreach (var item in DrinkSelectionDictionary.Values)
            {
                OrderManager.Instance.AddDrinksToOrder(item);
            }

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
                    if (DrinkSelectionDictionary.ContainsKey(drinkDisplayItem.Drink.DrinkType))
                    {
                        DrinkSelectionDictionary[drinkDisplayItem.Drink.DrinkType] = drinkDisplayItem.Drink;
                    }
                    else
                    {
                        DrinkSelectionDictionary.Add(drinkDisplayItem.Drink.DrinkType, drinkDisplayItem.Drink);
                    }
                }
            }
        }

        private void LoadPreviousDrinkSelections(DrinkCategory drinkType)
        {
            foreach (var drinkDisplayItem in DrinkDisplayItems)
            {
                if (DrinkSelectionDictionary.ContainsKey(drinkDisplayItem.Drink.DrinkType))
                {
                    drinkDisplayItem.Drink = DrinkSelectionDictionary[drinkDisplayItem.Drink.DrinkType];
                }
            }
        }

    }
}
