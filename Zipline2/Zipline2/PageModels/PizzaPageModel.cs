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
        private bool mediumSelected;
        private bool largeSelected;
        private bool indySelected;
        private bool majorSliceSelected;
        private bool majorMediumSelected;
        private bool majorLargeSelected;
        private bool majorIndySelected;
        private bool majorSatchPanSelected;
        private bool majorMfpSelected;

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
        public event EventHandler<ToppingsPageEventArgs> NavigateToToppingsPage;

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
        }

        private void OnCheeseSelected(PizzaType pizzaType)
        {
            switch (pizzaType)
            {
                case PizzaType.ThinSlice:
                    CheeseSliceSelected = true;
                    MediumSelected = false;
                    LargeSelected = false;
                    IndySelected = false;
                    break;
                case PizzaType.Medium:
                    MediumSelected = true;
                    CheeseSliceSelected = false;
                    LargeSelected = false;
                    IndySelected = false;
                    break;
                case PizzaType.Large:
                    LargeSelected = true;
                    CheeseSliceSelected = false;
                    MediumSelected = false;
                    IndySelected = false;
                    break;
                case PizzaType.Indy:
                    IndySelected = true;
                    CheeseSliceSelected = false;
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
            var pizzaSize = GetPizzaSizeSelected();
            var pizzaType = Pizza.GetPizzaType(pizzaSize, PizzaCrust.RegularThin);
            //Send info to OrderManager
            var guiData = new PizzaSelection(pizzaType)
            {
                MenuItemGeneralCategory = MenuCategory.Pizza,
                PizzaSize = pizzaSize,
                PizzaCrustType = PizzaCrust.RegularThin,
                ItemCount = 1
            };

            OrderManager.Instance.AddItemInProgress(guiData);
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
            var pizzaType = GetMajorSizeSelected();
            var guiData = new PizzaSelection(pizzaType)
            {
                MenuItemGeneralCategory = MenuCategory.Pizza,
                MajorOrMama = MajorOrMama.Major,
                ItemCount = 1
            };

            switch (pizzaType)
            {
                case PizzaType.Indy:
                    guiData.PizzaSize = PizzaSize.Indy;
                    guiData.PizzaCrustType = PizzaCrust.RegularThin;
                    break;
                case PizzaType.Large:
                    guiData.PizzaSize = PizzaSize.Large;
                    guiData.PizzaCrustType = PizzaCrust.RegularThin;
                    break;
                case PizzaType.Medium:
                    guiData.PizzaSize = PizzaSize.Medium;
                    guiData.PizzaCrustType = PizzaCrust.RegularThin;
                    break;
                case PizzaType.Mfp:
                    guiData.PizzaSize = PizzaSize.OneSize;
                    guiData.PizzaCrustType = PizzaCrust.Mfp;
                    break;
                case PizzaType.SatchPan:
                    guiData.PizzaSize = PizzaSize.OneSize;
                    guiData.PizzaCrustType = PizzaCrust.SatchPan;
                    break;
                case PizzaType.ThinSlice:
                    guiData.PizzaSize = PizzaSize.Slice;
                    guiData.PizzaCrustType = PizzaCrust.RegularThin;
                    break;
            }

            OrderManager.Instance.AddItemInProgress(guiData);

            DisplayToppingsPage();
        }

        private void OnAddMfp()
        {
            var pizzaType = PizzaType.Mfp;
            //Send info to OrderManager
            var guiData = new PizzaSelection(pizzaType)
            {
                MenuItemGeneralCategory = MenuCategory.Pizza,
                PizzaSize = PizzaSize.OneSize,
                ItemCount = 1
            };

            OrderManager.Instance.AddItemInProgress(guiData);

            DisplayToppingsPage();
        }

        private void OnAddSatchPan()
        {
            var pizzaType = PizzaType.SatchPan;
            //Send info to OrderManager
            var guiData = new PizzaSelection(pizzaType)
            {
                MenuItemGeneralCategory = MenuCategory.Pizza,
                PizzaSize = PizzaSize.OneSize,
                ItemCount = 1
            };

            OrderManager.Instance.AddItemInProgress(guiData);
          
            DisplayToppingsPage();
        }
        private PizzaSize GetPizzaSizeSelected()
        {
            PizzaSize sizeSelected = PizzaSize.OneSize;
            if (CheeseSliceSelected)
            {
                sizeSelected = PizzaSize.Slice;
            }
            else if (MediumSelected)
            {
                sizeSelected = PizzaSize.Medium;
            }
            else if (LargeSelected)
            {
                sizeSelected = PizzaSize.Large;
            }
            else if (IndySelected)
            {
                sizeSelected = PizzaSize.Indy;
            }
            return sizeSelected;
        }
        void DisplayToppingsPage()
        {
            var orderManager = OrderManager.Instance;
            OrderManager.Instance.MarkCurrentTableOccupied(true);
            var currentPizza = orderManager.GetCurrentPizza();
            MenuHeaderModel.Instance.ItemTotal = currentPizza.PricePerItem;

            OnNavigateToToppingsPage(currentPizza);
        }

        void OnNavigateToToppingsPage(Pizza currentPizza)
        {
            NavigateToToppingsPage?.Invoke(this, new ToppingsPageEventArgs(currentPizza));
        }
    }
}
