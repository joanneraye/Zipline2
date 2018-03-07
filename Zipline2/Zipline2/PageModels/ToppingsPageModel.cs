using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Models;
using System.Linq;
using System.ComponentModel;
using Zipline2.BusinessLogic.DictionaryKeys;

namespace Zipline2.PageModels
{
    public class ToppingsPageModel : BasePageModel
    {
        #region ToppingSelection Class
        public class ToppingSelection : BasePageModel
        {
            
            public System.Windows.Input.ICommand AButtonCommand { get; set; }
            public System.Windows.Input.ICommand BButtonCommand { get; set; }

            public System.Windows.Input.ICommand WholeButtonCommand { get; set; }
            public ToppingSelection()
            {
                ToppingPickerList = new string[]
                {
                    "Whole",
                    "Half A",
                    "Half B"
                };
                AButtonCommand = new Xamarin.Forms.Command(OnButtonAClick);
                BButtonCommand = new Xamarin.Forms.Command(OnButtonBClick);
                WholeButtonCommand = new Xamarin.Forms.Command(OnButtonWholeClick);
                areWholeHalfColumnsVisible = true;
            }
            void OnButtonAClick()
            {
                ListTopping.ToppingWholeHalf = ToppingWholeHalf.HalfA;
                ListTopping.IsSelected = true;
                ListItemIsSelected = true;
                AColor = Color.CornflowerBlue;
                BColor = Color.Black;
                WholeColor = Color.Black; 
            }

            void OnButtonBClick()
            {
                ListTopping.ToppingWholeHalf = ToppingWholeHalf.HalfB;
                ListItemIsSelected = true;
                ListTopping.IsSelected = true;
                BColor = Color.CornflowerBlue;
                AColor = Color.Black;
                WholeColor = Color.Black;
            }

            void OnButtonWholeClick()
            {
                ListTopping.ToppingWholeHalf = ToppingWholeHalf.Whole;
                ListTopping.IsSelected = true;
                ListItemIsSelected = true;
                WholeColor = Color.CornflowerBlue;
                AColor = Color.Black;
                BColor = Color.Black;
            }
            public Zipline2.Models.Topping ListTopping { get; set; }

            private bool areWholeHalfColumnsVisible;
            public bool AreWholeHalfColumnsVisible
            {
                get
                {
                    return areWholeHalfColumnsVisible;
                }
                set
                {
                    SetProperty(ref areWholeHalfColumnsVisible, value);
                }
            }

            public int ToppingIndex;

            private bool listItemIsSelected = false;

            public bool ListItemIsSelected
            {
                get
                {
                    return listItemIsSelected;
                }
                set
                {
                    SetProperty(ref listItemIsSelected, value);
                    if (listItemIsSelected)
                    {
                        SelectionColor = Color.CornflowerBlue;
                        WholeColor = Color.CornflowerBlue;
                    }
                    else
                    {
                        SelectionColor = Color.Black;
                        AColor = Color.Black;
                        BColor = Color.Black;
                        WholeColor = Color.Black;
                    }
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
            private Color acolor;
            public Color AColor
            {
                get
                {
                    return acolor;
                }
                set
                {
                    SetProperty(ref acolor, value);
                }
            }
            private Color bcolor;
            public Color BColor
            {
                get
                {
                    return bcolor;
                }
                set
                {
                    SetProperty(ref bcolor, value);
                }
            }

            private Color wholecolor;
            public Color WholeColor
            {
                get
                {
                    return wholecolor;
                }
                set
                {
                    SetProperty(ref wholecolor, value);
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
                toppingSelection.AColor = Color.Black;
                toppingSelection.BColor = Color.Black;
                toppingSelection.WholeColor = Color.Black;
                toppingSelection.AreWholeHalfColumnsVisible = true;
                ToppingSelectionsList.Add(toppingSelection);

                //If the pizza type is a slice, don't display whole/halfa/halfb options.
                string pizzaName = OrderManager.GetInstance().OrderItemInProgress.ItemName;
                toppingSelection.AreWholeHalfColumnsVisible = true;
                if (pizzaName.Equals(DisplayNames.DisplayNameDictionary[Key.PIZZA_SLICE]))
                {
                    toppingSelection.AreWholeHalfColumnsVisible = false;
                }
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

        private ToppingSelection selectedItem;
        public ToppingSelection SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                SetProperty(ref selectedItem, value);
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
                item => item.ListItemIsSelected).Select(
                selectedItem => selectedItem.ListTopping).ToList();
        }

    }
}
