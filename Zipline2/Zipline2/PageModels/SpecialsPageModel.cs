using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Models;
using Zipline2.MyEventArgs;

namespace Zipline2.PageModels
{
   public class SpecialsPageModel : BasePageModel
    {

        public ICommand AddLunchSpecialCommand { get; set; }
        public ICommand AddSpecialSaladCommand { get; set; }

        public event EventHandler<SaladToppingsPageEventArgs> NavigateToSaladToppingsPage;

        public SpecialsPageModel()
        {
            AddLunchSpecialCommand = new Command(OnAddLunchSpecial);
            AddSpecialSaladCommand = new Command(OnAddSpecialSalad);
           
        }
      
        public void OnAddLunchSpecial()
        {
            OrderItem[] orderItems = new OrderItem[2];
            Guid id = Guid.NewGuid();
            Salad saladSpecial = new Salad(SaladSize.LunchSpecial)
            {
                DbItemId = 50M,
                ItemCount = 1,
                PartOfCombo = true,
                ComboId = id
            };
            orderItems[0] = saladSpecial;
           
            Pizza pizzaSpecial = new Pizza()
            { PizzaType = PizzaType.LunchSpecialSlice,
                DbItemId = 57M,
                ItemCount = 1,
                PartOfCombo = true,
                ComboId = id
            };
            orderItems[1] = pizzaSpecial;
            OrderManager.Instance.AddSpecialItemsInProgress(orderItems);
            DisplaySaladToppingsPage(saladSpecial);
        }

        public void OnAddSpecialSalad()
        {
            Salad specialSaladSize = new Salad(SaladSize.LunchSize);
            specialSaladSize.PartOfCombo = false;
            AddSaladToOrder(specialSaladSize);
            DisplaySaladToppingsPage(specialSaladSize);
        }
      
        private void AddSaladToOrder(Salad thisSalad)
        {
            thisSalad.ItemCount = 1;
            OrderManager.Instance.AddItemInProgress(thisSalad);
        }
        private void AddPizzaToOrder(Pizza thisPizza)
        {
            thisPizza.ItemCount = 1;
            OrderManager.Instance.AddItemInProgress(thisPizza);
        }

        private void DisplaySaladToppingsPage(Salad specialSalad)
        {
            MenuHeaderModel.Instance.ItemTotal = specialSalad.PricePerItemIncludingToppings;
            NavigateToSaladToppingsPage?.Invoke(this, new SaladToppingsPageEventArgs(specialSalad));
        }

    }
}
