using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Zipline2.BusinessLogic;
using Zipline2.Models;
using System.Linq;

namespace Zipline2.PageModels
{
    public class ToppingsPageModel : BasePageModel
    {
        #region ToppingSelection Class
        public class ToppingSelection : BasePageModel
        {
            public ToppingSelection()
            {
                ToppingPickerList = new string[]
                {
                    "Whole",
                    "Half A",
                    "Half B"
                };
            }
            public Zipline2.Models.Topping ListTopping { get; set; }

            public int ToppingIndex;

            private bool isSelected = false;

            public bool IsSelected
            {
                get
                {
                    return isSelected;
                }
                set
                {
                    SetProperty(ref isSelected, value);
                }
            }
            private string[] toppingPickerList;
            public string[] ToppingPickerList
            {
                get
                {
                    return toppingPickerList;
                }
                set
                {
                    SetProperty(ref toppingPickerList, value);
                }
            }
            private int toppingPickerSelectedIndex = 0;
            public int ToppingPickerSelectedIndex
            {
                get
                {
                    return toppingPickerSelectedIndex;
                }
                set
                {
                    SetProperty(ref toppingPickerSelectedIndex, value);
                }
            }
            //private bool toppingListSwitch;
            //public bool ToppingListSwitch
            //{
            //    get
            //    {
            //        return toppingListSwitch;
            //    }
            //    set
            //    {
            //        SetProperty(ref toppingListSwitch, value);
            //    }
            //}
            private Color selectionColor;
            public Color SelectionColor
            {
                get
                {
                    return selectionColor;
                }
                set
                {
                    SetProperty(ref selectionColor, value);
                }
            }
        }
        #endregion ToppingsSelection class

        #region Constructor
        public ToppingsPageModel()
        {
            var toppingsList = new List<Topping>()
            {
                new Topping {ToppingName = "Anchovies"},
                new Topping {ToppingName = "Artichokes"},
                new Topping {ToppingName = "Bacon"},
                new Topping {ToppingName = "Banana Peppers"},
                new Topping {ToppingName = "Basil"},
                new Topping {ToppingName = "Beef"},
                new Topping {ToppingName = "Black Olives"},
                new Topping {ToppingName = "Broccoli"},
                new Topping {ToppingName = "Carrots"},
                new Topping {ToppingName = "DAIYA"},
                new Topping {ToppingName = "Extra Cheese"},
                new Topping {ToppingName = "Extra Mozarella (Calzone)"},
                new Topping {ToppingName = "Extra P Sauce O/S"},
                new Topping {ToppingName = "Extra P Sause on Pie"},
                new Topping {ToppingName = "Extra Ricotta (Calzone)"},
                new Topping {ToppingName = "Feta"},
                new Topping {ToppingName = "Garlic"},
                new Topping {ToppingName = "Green Olives"},
                new Topping {ToppingName = "Green Peppers"},
                new Topping {ToppingName = "Half Major"},
                new Topping {ToppingName = "Jalapenos"},
                new Topping {ToppingName = "Meatballs"},
                new Topping {ToppingName = "Mushrooms"},
                new Topping {ToppingName = "NO CHEESE"},
                new Topping {ToppingName = "Onion"},
                new Topping {ToppingName = "Pesto Topping"},
                new Topping {ToppingName = "Pepperoni"},
                new Topping {ToppingName = "Pineapple"},
                new Topping {ToppingName = "Red Onions"},
                new Topping {ToppingName = "Ricotta"},
                new Topping {ToppingName = "RRP"},
                new Topping {ToppingName = "Sausage"},
                new Topping {ToppingName = "Spinach"},
                new Topping {ToppingName = "Steak"},
                new Topping {ToppingName = "Sun-dried Tomatoes"},
                new Topping {ToppingName = "TEESE"},
                new Topping {ToppingName = "Tempeh BBQ"},
                new Topping {ToppingName = "Tomatoes"},
                new Topping {ToppingName = "Zucchini"},
                new Topping {ToppingName = "Cheese"},
                new Topping {ToppingName = "DEEP"},
                new Topping {ToppingName = "LIGHT SAUCE"},
                new Topping {ToppingName = "LIGHT MOZARELLA"},
                new Topping {ToppingName = "LIGHT RICOTTA"},
                new Topping {ToppingName = "NO BUTTER"},
                new Topping {ToppingName = "NO SAUCE"}
            };

            ToppingSelectionsList = new List<ToppingSelection>();
            for (int i = 0; i < toppingsList.Count; i++)
            {
                var toppingSelection = new ToppingSelection();
                toppingSelection.ListTopping = toppingsList[i];
                toppingSelection.ToppingIndex = i;
                toppingSelection.SelectionColor = Color.Black;
                ToppingSelectionsList.Add(toppingSelection);
            }
           
        }
        #endregion
        
        private List<ToppingSelection> toppingSelectionsList;
        public List<ToppingSelection> ToppingSelectionsList
        {
            get
            {
                return toppingSelectionsList;
            }
            set
            {
                SetProperty(ref toppingSelectionsList, value);
            }
        }

        public List<ToppingSelection> SelectedItems = new List<ToppingSelection>();

               public string PizzaName
        {
            get
            {
                return OrderManager.GetInstance().OrderItemInProgress.ItemName;
            }
        }
       
        public List<Topping> GetSelections()
        {
            return SelectedItems.Where(
                item => item.IsSelected).Select(
                selectedItem => selectedItem.ListTopping).ToList();
        }

    }
}
