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
   public class SaladsPageModel : BasePageModel
    {

        public ICommand AddLunchSpecialSaladCommand { get; set; }
        public ICommand AddSmallSaladCommand { get; set; }
        public ICommand AddLargeSaladCommand { get; set; }

        public event EventHandler<SaladToppingsPageEventArgs> NavigateToSaladToppingsPage;

        public SaladsPageModel()
        {
            AddLunchSpecialSaladCommand = new Command(OnAddLunchSpecialSalad);
            AddSmallSaladCommand = new Command(OnAddSmallSalad);
            AddLargeSaladCommand = new Command(OnAddLargeSalad);
           
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
