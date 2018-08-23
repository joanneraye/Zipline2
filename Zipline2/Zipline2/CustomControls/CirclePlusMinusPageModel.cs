using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Zipline2.Models;
using Zipline2.PageModels;
using Zipline2.Pages;
using static Zipline2.PageModels.DrinksPageModel;

namespace Zipline2.CustomControls
{
    public class CirclePlusMinusPageModel : BasePageModel
    {
        public double CirclePlusMinusHeightWidth
        {
            get
            {
                return App.PlusMinusButtonHeightWidth;
            }
        }

        public double CirclePlusMinusCornerRadius
        {
            get
            {
                return App.PlusMinusButtonCornerRadius;
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

        private string[] menuItemNames;
        public string[] MenuItemNames
        {
            get
            {
                return menuItemNames;
            }
            set
            {
                SetProperty(ref menuItemNames, value);
            }
        }

        private int[] menuItemCounts;
        public int[] MenuItemCounts
        {
            get
            {
                return menuItemCounts;
            }
            set
            {
                SetProperty(ref menuItemCounts, value);
            }
        }

        public ICommand MinusButtonCommand { get; set; }
        public ICommand PlusButtonCommand { get; set; }

        public CirclePlusMinusPageModel()
        {
            MinusButtonCommand = new Command<string>(OnMinusButton);
            PlusButtonCommand = new Command<string>(OnPlusButton);
            Color whiteColor = new Color();
            whiteColor = Color.White;
            CircleColors = new Color[3] { whiteColor, whiteColor, whiteColor };
            HideButtons = new bool[3] { false, false, false };
            MenuItemNames = new string[3] { string.Empty, string.Empty, string.Empty };
            MenuItemCounts = new int[3] { 0, 0, 0 };
        }

        public void OnMinusButton(string columnIndexString)
        {
            int columnIndex = 0;
            int.TryParse(columnIndexString, out columnIndex);
            if (MenuItemCounts[columnIndex] > 0)
            {
                MenuItemCounts[columnIndex]--;
            }

            //This does not include all drinks selected.
            //var thisDrink = RowDrinks[columnIndex];
            //MenuHeaderModel.Instance.ItemTotal = thisDrink.BasePriceNoToppings * thisDrink.ItemCount;
            //MenuHeaderModel.Instance.OrderTotal += MenuHeaderModel.Instance.ItemTotal;
        }

        public void OnPlusButton(string columnIndexString)
        {
            int columnIndex = 0;
            int.TryParse(columnIndexString, out columnIndex);
            MenuItemCounts[columnIndex]++;
        }

        //Can't get the following to work.....
        //public static List<IDisplayRow> GetDrinkDisplayRows(List<OrderItem> menuItemsForDisplay)
        //{
        //    List<IDisplayRow> rows;
        //    if (menuItemsForDisplay.Count > 0 && menuItemsForDisplay[0] is Drink)
        //    {
        //        rows = new List<DrinkDisplayRow>();
        //    }
          
        //    DrinkDisplayRow workingRow = new DrinkDisplayRow();
        //    int rowCount = 0;

        //    int lastItemIndex = drinksForDisplay.Count - 1;
        //    for (int i = 0; i < drinksForDisplay.Count; i++)
        //    {
        //        Drink newDrink = drinksForDisplay[i].GetClone();
        //        Color circleColor = GetCircleColor(newDrink.DrinkType);
        //        int column = i % 3;
        //        if (column == 0)
        //        {
        //            workingRow = new DrinkDisplayRow();
        //            workingRow.RowDrinks[0] = newDrink;
        //            workingRow.SpecialCirclePageModel.MenuItemNames[0] = newDrink.ShortName;
        //            workingRow.specialCirclePageModel.CircleColors[0] = circleColor;
        //            if (i == lastItemIndex)
        //            {
        //                workingRow.RowDrinks[1] = new Drink();
        //                workingRow.SpecialCirclePageModel.CircleColors[1] = Color.Black;
        //                workingRow.SpecialCirclePageModel.HideButtons[1] = true;
        //                workingRow.RowDrinks[2] = new Drink();
        //                workingRow.SpecialCirclePageModel.CircleColors[2] = Color.Black;
        //                workingRow.SpecialCirclePageModel.HideButtons[2] = true;
        //                workingRow.DrinkDisplayRowIndex = rowCount;
        //                rows.Add(workingRow);
        //                break;
        //            }
        //        }
        //        else if (column == 1)
        //        {
        //            workingRow.RowDrinks[1] = newDrink;
        //            workingRow.specialCirclePageModel.CircleColors[1] = circleColor;
        //            workingRow.SpecialCirclePageModel.MenuItemNames[0] = newDrink.ShortName;
        //            if (i == lastItemIndex)
        //            {
        //                workingRow.DrinkDisplayRowIndex = rowCount;
        //                workingRow.RowDrinks[2] = new Drink();
        //                workingRow.SpecialCirclePageModel.CircleColors[2] = Color.Black;
        //                workingRow.SpecialCirclePageModel.HideButtons[2] = true;
        //                rows.Add(workingRow);
        //                break;
        //            }
        //        }
        //        else if (column == 2)
        //        {
        //            workingRow.RowDrinks[2] = newDrink;
        //            workingRow.SpecialCirclePageModel.CircleColors[2] = circleColor;
        //            workingRow.SpecialCirclePageModel.MenuItemNames[0] = newDrink.ShortName;
        //            workingRow.DrinkDisplayRowIndex = rowCount;
        //            rows.Add(workingRow);
        //            rowCount++;
        //        }
        //    }
        //    return rows;
        //}
    }
}
