using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Models;

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
                Drink tempDrink = Drink;
                if (tempDrink.ItemCount > 0)
                {
                    tempDrink.ItemCount--;
                    Drink = tempDrink;
                }
            }

            public void OnPlusButton()
            {
                Drink tempDrink = Drink;
                tempDrink.ItemCount++;
                Drink = tempDrink;
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
        private DrinkType currentDrinkTypeSelected;
        private List<Drink> drinkSelections;
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
                if (value)
                {
                    LoadSoftDrinksForDisplay();
                }
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

        //private static readonly string[] softDrinks =
        //{
        //    "Water",
        //    "Water with Lemon",
        //    "Water No Ice",
        //    "Lola Cola",
        //    "Stevie Z-Cal",
        //    "Lennie Lemon Lime",
        //    "Ginnie Ginger Ale",
        //    "Ruby Root Beer",
        //    "Apple Juice",
        //    "Lemonade",
        //    "Sweet Tea",
        //    "Sweet Arnold Palmer",
        //    "Unsweet Arnold Palmer",
        //    "Unsweet Tea",
        //    "Soda Water",
        //    "Milk",
        //    "Bottled Coke",
        //    "Half n Half Tea",
        //    "Diet Coke Can",
        //    "Soda Pitcher",
        //    "Flight",
        //    "Crystal Creme"
         //};

        public DrinksPageModel()
        {
            DrinkDisplayItems = new ObservableCollection<DrinkDisplayItem>();
            DrinksSelectedCommand = new Command<DrinkType>(OnDrinksSelected);
            drinkSelections = new List<Drink>();
            
            SoftDrinksSelected = true;
        }

        private void LoadSoftDrinksForDisplay()
        {
            Drinks.LoadSoftDrinks();
            for (int i = 0; i < Drinks.SoftDrinks.Count; i++)
            {
                var drinkDisplayItem = new DrinkDisplayItem()
                {
                    Drink = Drinks.SoftDrinks[i],
                    DrinkDisplayItemIndex = i
                };
                DrinkDisplayItems.Add(drinkDisplayItem);
            }
        }

        public void OnDrinksSelected(DrinkType drinkType)
        {
            //Load drinks from existing order for this page.
            if (drinkSelections.Count > 0)
            {
                LoadDrinkSelections(drinkType);
            }
            //Add to drink order in progress whatever was entered on the page we are leaving.
            if (currentDrinkTypeSelected != DrinkType.None)
            {
                AddDrinkSelections();
            }

            switch (drinkType)
            {
                case DrinkType.SoftDrinks:
                    SoftDrinksSelected = true;
                    BottledBeerSelected = false;
                    DraftBeerSelected = false;
                    RedWineSelected = false;
                    WhiteWineSelected = false;
                    HotDrinksSelected = false;
                    HouseWineSelected = false;
                    break;
                case DrinkType.DraftBeer:
                    DraftBeerSelected = true;
                    SoftDrinksSelected = false;
                    BottledBeerSelected = false;
                    RedWineSelected = false;
                    WhiteWineSelected = false;
                    HotDrinksSelected = false;
                    HouseWineSelected = false;
                    break;
                case DrinkType.BottledBeer:
                    BottledBeerSelected = true;
                    SoftDrinksSelected = false;
                    DraftBeerSelected = false;
                    RedWineSelected = false;
                    WhiteWineSelected = false;
                    HotDrinksSelected = false;
                    HouseWineSelected = false;
                    break;
                case DrinkType.RedWine:
                    RedWineSelected = true;
                    SoftDrinksSelected = false;
                    BottledBeerSelected = false;
                    DraftBeerSelected = false;
                    WhiteWineSelected = false;
                    HotDrinksSelected = false;
                    HouseWineSelected = false;
                    break;
                case DrinkType.WhiteWine:
                    WhiteWineSelected = true;
                    SoftDrinksSelected = false;
                    BottledBeerSelected = false;
                    DraftBeerSelected = false;
                    RedWineSelected = false;
                    HotDrinksSelected = false;
                    HouseWineSelected = false;
                    break;
                case DrinkType.HotDrinks:
                    HotDrinksSelected = true;
                    RedWineSelected = false;
                    SoftDrinksSelected = false;
                    BottledBeerSelected = false;
                    DraftBeerSelected = false;
                    WhiteWineSelected = false;
                    HouseWineSelected = false;
                    break;
                case DrinkType.HouseWine:
                    HouseWineSelected = true;
                    HotDrinksSelected = false;
                    RedWineSelected = false;
                    SoftDrinksSelected = false;
                    BottledBeerSelected = false;
                    DraftBeerSelected = false;
                    WhiteWineSelected = false;
                    break;
            }
            currentDrinkTypeSelected = drinkType;
        }

        private void AddDrinkSelections()
        {
            foreach (var drinkdisplayitem in DrinkDisplayItems)
            {
                if (drinkdisplayitem.Drink.ItemCount > 0)
                {
                    drinkSelections.Add(drinkdisplayitem.Drink);
                }
            }
        }

        private void LoadDrinkSelections(DrinkType drinkType)
        {
            foreach (var drink in drinkSelections)
            {
                //Only find drinks that are on the page that will be displayed.
                if (drink.DrinkType == drinkType)
                {
                    //Find the drink already selected on this page.
                    foreach (var drinkDisplayItem in DrinkDisplayItems)
                    {
                        if (drinkDisplayItem.Drink.DrinkType == drink.DrinkType)
                        {
                            drinkDisplayItem.Drink.ItemCount = drink.ItemCount;
                            break;
                        }
                    }
                }
            }
        }

        
        //public void OnMinusButton(DrinkName drinkSubtractingFrom)
        //{

        //}

        //public void OnPlusButton(DrinkName drinkAddingTo)
        //{

        //}

        //private void ShowDrinks(DrinkType drinkType)
        //{

        //}
    }
}
