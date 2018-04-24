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
            private DrinksPageModel parentDrinksPageModel;
            private DrinkSelection drinkSelection;
            public DrinkSelection DrinkSelection
            {
                get
                {
                    return drinkSelection;
                }
                set
                {
                    SetProperty(ref drinkSelection, value);
                }
            }
            public int DrinkDisplayItemIndex { get; set; }
            public ICommand MinusButtonCommand { get; set; }
            public ICommand PlusButtonCommand { get; set; }


            public DrinkDisplayItem(DrinksPageModel drinksPageModelReference)
            {
                parentDrinksPageModel = drinksPageModelReference;
                MinusButtonCommand = new Command(OnMinusButton);
                PlusButtonCommand = new Command(OnPlusButton);
            }

            public void OnMinusButton()
            {
                if (DrinkSelection.ItemCount > 0)
                {
                    DrinkSelection.ItemCount--;
                    //DrinkSelection.ItemCount = DrinkSelection.ItemCount - 1;
                }
            }

            public void OnPlusButton()
            {
                DrinkSelection.ItemCount = DrinkSelection.ItemCount + 1;
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
       

        private static readonly string[] softDrinks =
        {
            "Water",
            "Water with Lemon",
            "Water No Ice",
            "Water Light Ice",            
            "Water Extra Ice",
            "Lola Cola",
            "Stevie Z-Cal",
            "Lennie Lemon Lime",
            "Ginnie Ginger Ale",
            "Ruby Root Beer",
            "Apple Juice",
            "Lemonade",
            "Sweet Tea",
            "Sweet Arnold Palmer",
            "Unsweet Arnold Palmer",
            "Unsweet Tea",
            "Soda Water",
            "Milk",
            "Bottled Coke",
            "Half n Half Tea",
            "Diet Coke Can",
            "Soda Pitcher",
            "Flight",
            "Crystal Creme"
         };

        public DrinksPageModel()
        {
            DrinkDisplayItems = new ObservableCollection<DrinkDisplayItem>();
            DrinksSelectedCommand = new Command<DrinkType>(OnDrinksSelected);
            
            SoftDrinksSelected = true;
            for (int i = 0; i < softDrinks.Length; i++)
            {
                var drinkSelection = new DrinkSelection()
                {
                    ItemName = softDrinks[i],
                    ItemCount = 0
                };
                var drinkDisplayItem = new DrinkDisplayItem(this)
                {
                    DrinkSelection = drinkSelection,
                    DrinkDisplayItemIndex = i
                };
                DrinkDisplayItems.Add(drinkDisplayItem);
            }
        }

        public void OnDrinksSelected(DrinkType drinkType)
        {
            switch (drinkType)
            {
                case DrinkType.SoftDrinks:
                    SoftDrinksSelected = true;
                    DrinkList = softDrinks;
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
