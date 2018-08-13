using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Models;
using Zipline2.MyEventArgs;

namespace Zipline2.PageModels
{
    public class PizzaPageModel : BasePageModel
    {
        private bool isEditingPizza = false;
        private Pizza ThisPizza;

        public ICommand PizzaSelectionCommand { get; set; }      
        public ICommand AddMfpCommand { get; set; }
        public ICommand AddSatchPanCommand { get; set; }
        public ICommand AddCalzoneCommand { get; set; }

        public event EventHandler<ToppingsPageEventArgs> NavigateToToppingsPage;
        public event EventHandler<CalzoneToppingsPageEventArgs> NavigateToCalzoneToppingsPage;


        public PizzaPageModel()
        {
            AddMfpCommand = new Command(OnAddMfp);
            AddSatchPanCommand = new Command(OnAddSatchPan);
            PizzaSelectionCommand = new Command<PizzaType>(OnAddCheese);
            AddCalzoneCommand = new Command(OnAddCalzone);
            
            if (OrderManager.Instance.OrderItemInProgressLoadedForEdit
                && OrderManager.Instance.OrderItemInProgress is Pizza)
            {
                ThisPizza = (Pizza)OrderManager.Instance.OrderItemInProgress;
                isEditingPizza = true;            
            }
        }
        
        private void OnAddCheese(PizzaType pizzaType)
        {
            if (!isEditingPizza)
            {
                ThisPizza = new Pizza()
                {
                    ItemCount = 1
                };

            }
            ThisPizza.PizzaType = pizzaType;
           
            OrderManager.Instance.AddNewItemInProgress(ThisPizza);
            DisplayToppingsPage();
        }


        private void OnAddMfp()
        {
            if (!isEditingPizza)
            {
                ThisPizza = new Pizza()
                {
                    ItemCount = 1
                };

            }
            ThisPizza.PizzaType = PizzaType.Mfp;

            OrderManager.Instance.AddNewItemInProgress(ThisPizza);

            DisplayToppingsPage();
        }

        private void OnAddSatchPan()
        {
            if (!isEditingPizza)
            {
                ThisPizza = new Pizza()
                {
                    ItemCount = 1
                };
            }

            ThisPizza.PizzaType = PizzaType.SatchPan;

            OrderManager.Instance.AddNewItemInProgress(ThisPizza);
          
            DisplayToppingsPage();
        }

        public void OnAddCalzone()
        {
            Calzone calzoneSelected = new Calzone()
            {
                CalzoneType = CalzoneType.RicottaMozarella,
                ItemCount = 1
            };

            OrderManager.Instance.AddNewItemInProgress(calzoneSelected);
            DisplayCalzoneToppingsPage(calzoneSelected);
        }

        private void DisplayCalzoneToppingsPage(Calzone thisCalzone)
        {
            MenuHeaderModel.Instance.ItemTotal = thisCalzone.PricePerItemIncludingToppings;
            NavigateToCalzoneToppingsPage?.Invoke(this, new CalzoneToppingsPageEventArgs(thisCalzone));
        }

      
        void DisplayToppingsPage()
        {
            var orderManager = OrderManager.Instance;
            OrderManager.Instance.MarkCurrentTableOccupied(true);
            MenuHeaderModel.Instance.ItemTotal = ThisPizza.PricePerItemIncludingToppings;
            OnNavigateToToppingsPage();
        }

        void OnNavigateToToppingsPage()
        {
            NavigateToToppingsPage?.Invoke(this, new ToppingsPageEventArgs(ThisPizza));
        }
    }
}
