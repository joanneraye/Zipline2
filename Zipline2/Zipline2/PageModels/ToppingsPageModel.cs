using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic;
using Zipline2.Models;

namespace Zipline2.PageModels
{
    class ToppingsPageModel : BasePageModel
    {
        public List<Topping> ToppingsList { get; set; }

        public string PizzaName
        {
            get
            {
                return OrderManager.GetInstance().OrderItemInProgress.ItemName;
            }
        }

        public ToppingsPageModel()
        {
            ToppingsList = new List<Topping>()
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
        }
    }
}
