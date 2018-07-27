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
        private bool cheeseSliceSelected;
        private bool panSliceSelected;
        private bool mediumSelected;
        private bool largeSelected;
        private bool indySelected;
        private bool majorSliceSelected;
        private bool majorMediumSelected;
        private bool majorLargeSelected;
        private bool majorIndySelected;
        private bool majorSatchPanSelected;
        private bool majorMfpSelected;

        private bool isEditingPizza = false;
        private Pizza ThisPizza;

        public bool CheeseSliceSelected
        {
            get
            {
                return cheeseSliceSelected;
            }
            set
            {
                SetProperty(ref cheeseSliceSelected, value);
            }
        }

        public bool PanSliceSelected
        {
            get
            {
                return panSliceSelected;
            }
            set
            {
                SetProperty(ref panSliceSelected, value);
            }
        }

        public bool MediumSelected
        {
            get
            {
                return mediumSelected;
            }
            set
            {
                SetProperty(ref mediumSelected, value);
            }
        }

        public bool LargeSelected
        {
            get
            {
                return largeSelected;
            }
            set
            {
                SetProperty(ref largeSelected, value);
            }
        }

        public bool IndySelected
        {
            get
            {
                return indySelected;
            }
            set
            {
                SetProperty(ref indySelected, value);
            }
        }

        public bool MajorSliceSelected
        {
            get
            {
                return majorSliceSelected;
            }
            set
            {
                SetProperty(ref majorSliceSelected, value);
            }
        }

        public bool MajorMediumSelected
        {
            get
            {
                return majorMediumSelected;
            }
            set
            {
                SetProperty(ref majorMediumSelected, value);
            }
        }

        public bool MajorLargeSelected
        {
            get
            {
                return majorLargeSelected;
            }
            set
            {
                SetProperty(ref majorLargeSelected, value);
            }
        }

        public bool MajorIndySelected
        {
            get
            {
                return majorIndySelected;
            }
            set
            {
                SetProperty(ref majorIndySelected, value);
            }
        }

        public bool MajorMfpSelected
        {
            get
            {
                return majorMfpSelected;
            }
            set
            {
                SetProperty(ref majorMfpSelected, value);
            }
        }

        public bool MajorSatchPanSelected
        {
            get
            {
                return majorSatchPanSelected;
            }
            set
            {
                SetProperty(ref majorSatchPanSelected, value);
            }
        }

        public ICommand PizzaSelectionCommand { get; set; }
        public ICommand MajorPizzaSelectionCommand { get; set; }
        public ICommand AddCheeseCommand { get; set; }
        public ICommand AddMajorCommand { get; set; }
        public ICommand AddMfpCommand { get; set; }
        public ICommand AddSatchPanCommand { get; set; }
        public ICommand AddPizzaToOrderCommand { get; set; }

        public event EventHandler<ToppingsPageEventArgs> NavigateToToppingsPage;
        //public event EventHandler NavigateToPizzaPage;


        public PizzaPageModel()
        {
            AddCheeseCommand = new Command(OnAddCheese);
            AddMajorCommand = new Command(OnAddMajor);
            AddMfpCommand = new Command(OnAddMfp);
            AddSatchPanCommand = new Command(OnAddSatchPan);
            PizzaSelectionCommand = new Command<PizzaType>(OnCheeseSelected);
            MajorPizzaSelectionCommand = new Command<PizzaType>(OnMajorSelected);
            CheeseSliceSelected = true;
            MajorSliceSelected = true;
            if (OrderManager.Instance.OrderItemInProgressLoadedForEdit
                && OrderManager.Instance.OrderItemInProgress is Pizza)
            {
                ThisPizza = (Pizza)OrderManager.Instance.OrderItemInProgress;
                isEditingPizza = true;
                CheeseSliceSelected = false;
                MajorSliceSelected = false;
                LoadPizzaToEdit(ThisPizza);
            }
        }

        void LoadPizzaToEdit(Pizza thisPizza)
        {
            if (thisPizza.MajorMamaInfo == MajorOrMama.Major)
            {
                switch (thisPizza.PizzaType)
                {
                    case PizzaType.ThinSlice:
                        MajorSliceSelected = true;
                        break;
                    case PizzaType.PanSlice:
                        MajorSatchPanSelected = true;
                        break;
                    case PizzaType.Medium:
                        MajorMediumSelected = true;
                        break;
                    case PizzaType.Large:
                        MajorLargeSelected = true;
                        break;
                    case PizzaType.Indy:
                        MajorIndySelected = true;
                        break;
                }
            }
            else
            {
                switch (thisPizza.PizzaType)
                {
                    case PizzaType.ThinSlice:
                        CheeseSliceSelected = true;
                        break;
                    case PizzaType.PanSlice:
                        PanSliceSelected = true;
                        break;
                    case PizzaType.Medium:
                        MediumSelected = true;
                        break;
                    case PizzaType.Large:
                        LargeSelected = true;
                        break;
                    case PizzaType.Indy:
                        IndySelected = true;
                        break;
                }
            }
        }

        private void OnCheeseSelected(PizzaType pizzaType)
        {
            switch (pizzaType)
            {
                case PizzaType.ThinSlice:
                    CheeseSliceSelected = true;
                    PanSliceSelected = false;
                    MediumSelected = false;
                    LargeSelected = false;
                    IndySelected = false;
                    break;
                case PizzaType.PanSlice:
                    PanSliceSelected = true;
                    CheeseSliceSelected = false;
                    MediumSelected = false;
                    LargeSelected = false;
                    IndySelected = false;
                    break;
                case PizzaType.Medium:
                    MediumSelected = true;
                    PanSliceSelected = false;
                    CheeseSliceSelected = false;
                    LargeSelected = false;
                    IndySelected = false;
                    break;
                case PizzaType.Large:
                    LargeSelected = true;
                    PanSliceSelected = false;
                    CheeseSliceSelected = false;
                    MediumSelected = false;
                    IndySelected = false;
                    break;
                case PizzaType.Indy:
                    IndySelected = true;
                    CheeseSliceSelected = false;
                    PanSliceSelected = false;
                    MediumSelected = false;
                    LargeSelected = false;
                    break;
            }
        }

        private void OnMajorSelected(PizzaType pizzaType)
        {
            switch (pizzaType)
            {
                case PizzaType.ThinSlice:
                    MajorSliceSelected = true;
                    MajorMediumSelected = false;
                    MajorLargeSelected = false;
                    MajorIndySelected = false;
                    MajorMfpSelected = false;
                    MajorSatchPanSelected = false;
                    break;
                case PizzaType.Medium:
                    MajorMediumSelected = true;
                    MajorSliceSelected = false;
                    MajorLargeSelected = false;
                    MajorIndySelected = false;
                    MajorMfpSelected = false;
                    MajorSatchPanSelected = false;
                    break;
                case PizzaType.Large:
                    MajorLargeSelected = true;
                    MajorSliceSelected = false;
                    MajorMediumSelected = false;
                    MajorIndySelected = false;
                    MajorMfpSelected = false;
                    MajorSatchPanSelected = false;
                    break;
                case PizzaType.Indy:
                    MajorIndySelected = true;
                    MajorSliceSelected = false;
                    MajorMediumSelected = false;
                    MajorLargeSelected = false;
                    MajorMfpSelected = false;
                    MajorSatchPanSelected = false;
                    break;
                case PizzaType.Mfp:
                    MajorMfpSelected = true;
                    MajorSliceSelected = false;
                    MajorMediumSelected = false;
                    MajorLargeSelected = false;
                    MajorIndySelected = false;
                    MajorSatchPanSelected = false;
                    break;
                case PizzaType.SatchPan:
                    MajorSatchPanSelected = true;
                    MajorSliceSelected = false;
                    MajorMediumSelected = false;
                    MajorLargeSelected = false;
                    MajorIndySelected = false;
                    MajorMfpSelected = false;
                    break;
            }
        }
        private void OnAddCheese()
        { 
            PizzaType selectedPizzaType = GetPizzaTypeSelected();
            if (!isEditingPizza)
            {
                ThisPizza = new Pizza()
                {
                    ItemCount = 1
                };

            }
            ThisPizza.PizzaType = selectedPizzaType;
           
            OrderManager.Instance.AddNewItemInProgress(ThisPizza);
            DisplayToppingsPage();
        }

        private PizzaType GetMajorSizeSelected()
        {
            PizzaType sizeSelected = PizzaType.ThinSlice;
            if (MajorSliceSelected)
            {
                sizeSelected = PizzaType.ThinSlice;
            }
            else if (MajorMediumSelected)
            {
                sizeSelected = PizzaType.Medium;
            }
            else if (MajorLargeSelected)
            {
                sizeSelected = PizzaType.Large;
            }
            else if (MajorIndySelected)
            {
                sizeSelected = PizzaType.Indy;
            }
            else if (MajorMfpSelected)
            {
                sizeSelected = PizzaType.Mfp;
            }
            else if (MajorSatchPanSelected)
            {
                sizeSelected = PizzaType.SatchPan;
            }
            return sizeSelected;
        }
        private void OnAddMajor()
        {
            var selectedPizzaType = GetMajorSizeSelected();
            if (!isEditingPizza)
            {
                ThisPizza = new Pizza()
                {
                    ItemCount = 1
                };
            }
            ThisPizza.PizzaType = selectedPizzaType;
            ThisPizza.MajorMamaInfo = MajorOrMama.Major;
            
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
        private PizzaType GetPizzaTypeSelected()
        {
            PizzaType pizzaTypeSelected = PizzaType.None;
            if (CheeseSliceSelected)
            {
                pizzaTypeSelected = PizzaType.ThinSlice;
            }
            else if (MediumSelected)
            {
                pizzaTypeSelected = PizzaType.Medium;
            }
            else if (LargeSelected)
            {
                pizzaTypeSelected = PizzaType.Large;
            }
            else if (PanSliceSelected)
            {
                pizzaTypeSelected = PizzaType.PanSlice;
            }
            else if (IndySelected)
            {
                pizzaTypeSelected = PizzaType.Indy;
            }
            return pizzaTypeSelected;
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
