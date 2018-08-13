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
   public class SaladsLunchSpecialPageModel : BasePageModel
    {

        public ICommand AddLunchSpecialSaladCommand { get; set; }
        public ICommand AddSmallSaladCommand { get; set; }
        public ICommand AddLargeSaladCommand { get; set; }
        public ICommand AddLunchSpecialCommand { get; set; }

        public event EventHandler<SaladToppingsPageEventArgs> NavigateToSaladToppingsPage;

        public SaladsLunchSpecialPageModel()
        {
            AddLunchSpecialSaladCommand = new Command(OnAddLunchSpecialSalad);
            AddSmallSaladCommand = new Command(OnAddSmallSalad);
            AddLargeSaladCommand = new Command(OnAddLargeSalad);
            AddLunchSpecialCommand = new Command(OnAddLunchSpecial);
        }
      
        public void OnAddLunchSpecialSalad()
        {
            Salad saladSelected = new Salad(SaladSize.LunchSpecial);
            AddSaladToOrder(saladSelected);
        }

        public void OnAddSmallSalad()
        {
            Salad saladSelected = new Salad(SaladSize.Small);
            AddSaladToOrder(saladSelected);
        }

        public void OnAddLargeSalad()
        {
            Salad saladSelected = new Salad(SaladSize.Large);
            AddSaladToOrder(saladSelected);
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
            {
                PizzaType = PizzaType.LunchSpecialSlice,
                DbItemId = 57M,
                ItemCount = 1,
                PartOfCombo = true,
                ComboId = id
            };
            orderItems[1] = pizzaSpecial;
            OrderManager.Instance.AddNewSpecialItemsInProgress(orderItems);
            DisplaySaladToppingsPage(saladSpecial);
        }


        private void AddSaladToOrder(Salad thisSalad)
        {
            thisSalad.ItemCount = 1;
            OrderManager.Instance.AddNewItemInProgress(thisSalad);
            DisplaySaladToppingsPage(thisSalad);
        }

        private void DisplaySaladToppingsPage(Salad thisSalad)
        {
            MenuHeaderModel.Instance.ItemTotal = thisSalad.PricePerItemIncludingToppings;
            NavigateToSaladToppingsPage?.Invoke(this, new SaladToppingsPageEventArgs(thisSalad));
        }

    }
}
