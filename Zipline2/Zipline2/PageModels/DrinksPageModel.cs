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
        public class DrinkDisplayRow : BasePageModel
        {
            private Drink[] rowDrinks;
            public Drink[] RowDrinks
            {
                get
                {
                    return rowDrinks;
                }
                set
                {
                    SetProperty(ref rowDrinks, value);
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

            //private bool isPint;
            //public bool IsPint
            //{
            //    get
            //    {
            //        return isPint;
            //    }
            //    set
            //    {
            //        SetProperty(ref isPint, value);
            //    }
            //}
            //private bool isPitcher;
            //public bool IsPitcher
            //{
            //    get
            //    {
            //        return isPitcher;
            //    }
            //    set
            //    {
            //        SetProperty(ref isPitcher, value);
            //    }
            //}
            //private bool isGlass;
            //public bool IsGlass
            //{
            //    get
            //    {
            //        return isGlass;
            //    }
            //    set
            //    {
            //        SetProperty(ref isGlass, value);
            //    }
            //}
            //private bool isBottle;
            //public bool IsBottle
            //{
            //    get
            //    {
            //        return isBottle;
            //    }
            //    set
            //    {
            //        SetProperty(ref isBottle, value);
            //    }
            //}
            public int DrinkDisplayRowIndex { get; set; }
            public ICommand MinusButtonCommand { get; set; }
            public ICommand PlusButtonCommand { get; set; }

            public DrinkDisplayRow()
            {
                MinusButtonCommand = new Command<string>(OnMinusButton);
                PlusButtonCommand = new Command<string>(OnPlusButton);
                RowDrinks = new Drink[3] { new Drink(), new Drink(), new Drink() };
                Color whiteColor = new Color();
                whiteColor = Color.White;
                CircleColors = new Color[3] { whiteColor, whiteColor, whiteColor };
                HideButtons = new bool[3] { false, false, false };
            }

            public void OnMinusButton(string columnIndexString)
            {
                int columnIndex = 0;
                int.TryParse(columnIndexString, out columnIndex);
                if (RowDrinks[columnIndex].ItemCount > 0)
                {
                    RowDrinks[columnIndex].ItemCount--;
                }               
            }

            public void OnPlusButton(string columnIndexString)
            {
                int columnIndex = 0;
                int.TryParse(columnIndexString, out columnIndex);
                RowDrinks[columnIndex].ItemCount++;
            }
        }

        //******************************NOTE IMBEDDED CLASS ABOVE************************
        private bool softDrinksSelected;
        private bool draftBeerSelected;
        private bool bottledBeerSelected;
        private bool bottleWineSelected;
        private bool glassWineSelected;
        public bool IsDrinkSelectedForEdit { get; set; }
        public int DrinkForEditIndex { get; set; }
        public CircleButtonViewModel CircleButtonViewModelTemp { get; set; }
        private DrinkType drinkSelectedForEditDrinkType { get; set; }
        private DrinkCategory currentDrinkCategorySelected;
        private ObservableCollection<DrinkDisplayRow> drinkDisplayItems;
        public ObservableCollection<DrinkDisplayRow> DrinkDisplayItems
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

        private ObservableCollection<CircleButtonViewModel> drinkButtonViewModels;
        public ObservableCollection<CircleButtonViewModel> DrinkButtonViewModels
        {
            get
            {
                return drinkButtonViewModels;
            }
            set
            {
                SetProperty(ref drinkButtonViewModels, value);
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
        public bool GlassWineSelected
        {
            get
            {
                return glassWineSelected;
            }
            set
            {
                SetProperty(ref glassWineSelected, value);
            }
        }
        public bool BottleWineSelected
        {
            get
            {
                return bottleWineSelected;
            }
            set
            {
                SetProperty(ref bottleWineSelected, value);
            }
        }
        //public bool HotDrinksSelected
        //{
        //    get
        //    {
        //        return hotDrinksSelected;
        //    }
        //    set
        //    {
        //        SetProperty(ref hotDrinksSelected, value);
        //    }
        //}
        //public bool HouseWineSelected
        //{
        //    get
        //    {
        //        return houseWineSelected;
        //    }
        //    set
        //    {
        //        SetProperty(ref houseWineSelected, value);
        //    }
        //}
      
        public ICommand DrinksSelectedCommand { get; set; }
        public ICommand AddDrinksCommand { get; set; }

        public event EventHandler NavigateToOrderPage;
        public event EventHandler ScrollToTopOfList;
        private Dictionary<DrinkCategory, List<DrinkDisplayRow>> drinkDisplayDictionary;
        public Dictionary<DrinkCategory, List<DrinkDisplayRow>> DrinkDisplayDictionary
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
            DrinkDisplayItems = new ObservableCollection<DrinkDisplayRow>();
            DrinksSelectedCommand = new Command<DrinkCategory>(OnDrinksSelected);
            AddDrinksCommand = new Command(OnAddDrinks);
            DrinkDisplayDictionary = new Dictionary<DrinkCategory, List<DrinkDisplayRow>>();
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
            try
            {
                List<Drink> drinksForDisplay = MenuDrinks.GetDrinksList(drinkCategory);
                DrinkButtonViewModels = new ObservableCollection<CircleButtonViewModel>();
                var tempDisplayItems = new List<DrinkDisplayRow>();
                DrinkDisplayRow workingRow = new DrinkDisplayRow();
                int rowCount = 0;
                int lastItemIndex = drinksForDisplay.Count - 1;
                
                for (int i = 0; i < drinksForDisplay.Count; i++)
                {
                    Color circleColor = GetCircleColor(drinksForDisplay[i].DrinkType);
                    int column = i % 3;
                    if (column == 0)
                    {
                        workingRow = new DrinkDisplayRow();
                        workingRow.RowDrinks[0] = drinksForDisplay[i].GetClone();
                        workingRow.CircleColors[0] = circleColor;
                        if (i == lastItemIndex)
                        {
                            workingRow.RowDrinks[1] = new Drink();
                            workingRow.CircleColors[1] = Color.Black;
                            workingRow.HideButtons[1] = true;
                            workingRow.RowDrinks[2] = new Drink();
                            workingRow.CircleColors[2] = Color.Black;
                            workingRow.HideButtons[2] = true;
                            workingRow.DrinkDisplayRowIndex = rowCount;
                            tempDisplayItems.Add(workingRow);
                            break;
                        }
                    }
                    else if (column == 1)
                    {
                        workingRow.RowDrinks[1] = drinksForDisplay[i].GetClone();
                        workingRow.CircleColors[1] = circleColor;
                        if (i == lastItemIndex)
                        {
                            workingRow.DrinkDisplayRowIndex = rowCount;
                            workingRow.RowDrinks[2] = new Drink();
                            workingRow.CircleColors[2] = Color.Black;
                            workingRow.HideButtons[2] = true;
                            tempDisplayItems.Add(workingRow);
                            break;
                        }
                    }
                    else if (column == 2)
                    {
                        workingRow.RowDrinks[2] = drinksForDisplay[i].GetClone();
                        workingRow.CircleColors[2] = circleColor;
                        workingRow.DrinkDisplayRowIndex = rowCount;
                        tempDisplayItems.Add(workingRow);
                        rowCount++;
                    }

                }
                //Display category for this page
                DrinkDisplayItems = new ObservableCollection<DrinkDisplayRow>(tempDisplayItems);
                //Save this category so we don't have to recreate if come here again.
                DrinkDisplayDictionary.Add(drinkCategory, tempDisplayItems);
            }
            catch (Exception ex)
            {
                var error = ex.InnerException;
                throw;
            }
           
        }

        private Color GetCircleColor(DrinkType drinkType)
        {
            Color returnColor = Color.White;
            switch (drinkType)
            {
                case DrinkType.AlverdiSangiovese:
                case DrinkType.BodegasLaya:
                case DrinkType.Chianti:
                case DrinkType.ClayhouseRedBlend:
                case DrinkType.GreenTruckPetitiSyrah:
                case DrinkType.LeeseFitchCab:
                case DrinkType.RedZinfandel:
                case DrinkType.YauquenMalbec:
                    returnColor = Color.Red;
                    break;
                case DrinkType.AppleJuice:
                case DrinkType.Lemonade:
                case DrinkType.Milk:
                    returnColor = Color.Yellow;
                    break;
                case DrinkType.Beer12Oz:
                case DrinkType.BottledCoke:
                case DrinkType.Bud:
                case DrinkType.BudLight:
                case DrinkType.DietCokeCan:
                case DrinkType.FirstMagnitude72:
                case DrinkType.Flight:
                case DrinkType.GinnieGingerAle:
                case DrinkType.Guinness:
                case DrinkType.Hefeweizen:
                case DrinkType.NaGenesee:
                case DrinkType.OmissionPaleAle:
                case DrinkType.PilsLagerOrBlondeAle:
                case DrinkType.LennieLemonLime:
                case DrinkType.LolaCola:
                case DrinkType.SwampHeadBigNoseIpa:
                case DrinkType.SpecialSoda:
                case DrinkType.StevieZ:
                case DrinkType.RubyRootBeer:
                case DrinkType.SodaPitcher:
                    returnColor = Color.Orange;
                    break;
                case DrinkType.Chardonnay:
                case DrinkType.CorkageFee:
                case DrinkType.DouglasGreenSb:
                case DrinkType.PinotGrigio:
                case DrinkType.Water:
                case DrinkType.SodaWater:
                case DrinkType.SauvBlanc:
                    returnColor = Color.White;
                    break;
                case DrinkType.DecafCoffee:
                case DrinkType.HalfNHalfTea:
                case DrinkType.HotCocoa:
                case DrinkType.HotTea:
                case DrinkType.RegularCoffee:
                case DrinkType.SweetArnoldPalmer:
                case DrinkType.SweetTea:
                case DrinkType.UnsweetArnoldPalmer:
                case DrinkType.UnsweetTea:
                    returnColor = Color.Tan;
                    break;
                case DrinkType.WhiteZin:
                case DrinkType.Rose:
                    returnColor = Color.LightPink;
                    break;
            }
            return returnColor;
        }

        public void OnDrinksSelected(DrinkCategory newDrinkCategory)
        {
            try
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
            }
            catch (Exception ex)
            {
                var error = ex.InnerException;
                throw;
            }
         

            DrinkDisplayItems = new ObservableCollection<DrinkDisplayRow>(DrinkDisplayDictionary[newDrinkCategory]);
            //In case we've already added drinks to this order and are returning to that
            //drink category, we want to show what was added previously.
            LoadPreviousDrinkSelections(newDrinkCategory);
            switch (newDrinkCategory)
            {
                case DrinkCategory.SoftDrink:
                    SoftDrinksSelected = true;
                    BottledBeerSelected = false;
                    DraftBeerSelected = false;
                    GlassWineSelected = false;
                    BottleWineSelected = false;
                    break;
                case DrinkCategory.DraftBeer:
                    DraftBeerSelected = true;
                    SoftDrinksSelected = false;
                    BottledBeerSelected = false;
                    GlassWineSelected = false;
                    BottleWineSelected = false;
                    break;
                case DrinkCategory.BottledBeer:
                    BottledBeerSelected = true;
                    SoftDrinksSelected = false;
                    DraftBeerSelected = false;
                    GlassWineSelected = false;
                    BottleWineSelected = false;
                    break;
                case DrinkCategory.GlassWine:
                    GlassWineSelected = true;
                    SoftDrinksSelected = false;
                    BottledBeerSelected = false;
                    DraftBeerSelected = false;
                    BottleWineSelected = false;
                    break;
                case DrinkCategory.BottleWine:
                    BottleWineSelected = true;
                    SoftDrinksSelected = false;
                    BottledBeerSelected = false;
                    DraftBeerSelected = false;
                    GlassWineSelected = false;
                    break;               
            }
            currentDrinkCategorySelected = newDrinkCategory;
        }

        public async void OnAddDrinks()
        {
            try
            {
                var drinksToAddToOrder = new List<OrderItem>();
                //Need to check entire Display dictionary (DrinkDisplayDictionary) for
                //any items added.
                foreach (var drinkDisplayList in DrinkDisplayDictionary.Values)
                {
                    foreach (var drinkDisplayItem in drinkDisplayList)
                    {
                        foreach (var drink in drinkDisplayItem.RowDrinks)
                        {
                            if (drink.ItemCount > 0)
                            {
                                drink.UpdateItemTotal();
                                drinksToAddToOrder.Add(drink);
                            }
                            else
                            {
                                //Need to see if any items with zero count on the page 
                                //were on the order before and need to be deleted from the order.
                                var drinkKey = Tuple.Create<DrinkType, DrinkSize>(drink.DrinkType, drink.DrinkSize);
                                if (DrinksOnTempOrderDictionary.ContainsKey(drinkKey))
                                {
                                    OrderManager.Instance.RemoveOrderItem(DrinksOnTempOrderDictionary[drinkKey]);
                                }

                            }
                        }

                    }
                }

                await OrderManager.Instance.AddItemsToOrderAsync(drinksToAddToOrder);
                LoadSummaryPage();
            }
            catch (Exception ex)
            {
                var error = ex.InnerException;
                throw;
            }
           
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
                            foreach (var drink in drinkDisplayItem.RowDrinks)
                            {
                                if (drink.DrinkType == drinkAlreadyOnTempOrder.DrinkType &&
                                drink.DrinkSize == drinkAlreadyOnTempOrder.DrinkSize)
                                {
                                    drink.ItemCount = drinkAlreadyOnTempOrder.ItemCount;
                                }

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
