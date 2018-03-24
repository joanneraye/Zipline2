using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.Models;
using Zipline2.BusinessLogic.Enums;
using Zipline2.BusinessLogic;
using Zipline2.PageModels;
//using Zipline2.CustomControls;

namespace Zipline2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PizzaPage : BasePage
	{
        #region Private Variables
        private bool sliceIsSelected;
        private bool largeIsSelected;
        private bool mediumIsSelected;
        private bool indyIsSelected;

        private bool majorSliceIsSelected;
        private bool majorIndyIsSelected;
        private bool majorMediumIsSelected;
        private bool majorLargeIsSelected;
        private bool majorMfpIsSelected;
        private bool majorSatchPanIsSelected;

        private Button sliceButton;
        private Button mediumButton;
        private Button largeButton;
        private Button indyButton;

        private Button majorSliceButton;
        private Button majorIndyButton;
        private Button majorMediumButton;
        private Button majorLargeButton;
        private Button majorMfpButton;
        private Button majorSatchPanButton;
        private PizzaPageModel pizzaPageModel;
        private PizzaType pizzaType;
        #endregion

        #region Properties
        #region Cheese Options
        public bool SliceIsSelected
        {
            get
            {
                return sliceIsSelected;
            }
            set
            {
                sliceIsSelected = value;
                if (sliceIsSelected)
                {
                    sliceButton.BackgroundColor = Color.Orange;
                    LargeIsSelected = false;
                    MediumIsSelected = false;
                    IndyIsSelected = false;
                }
                else
                {
                    sliceButton.BackgroundColor = Color.Black;
                }
            }
        }
        public bool MediumIsSelected
        {
            get
            {
                return mediumIsSelected;
            }
            set
            {
                mediumIsSelected = value;
                if (mediumIsSelected)
                {
                    mediumButton.BackgroundColor = Color.Orange;
                    LargeIsSelected = false;
                    SliceIsSelected = false;
                    IndyIsSelected = false;
                }
                else
                {
                    mediumButton.BackgroundColor = Color.Black;
                }
            }
        }
        public bool LargeIsSelected
        {
            get
            {
                return largeIsSelected;
            }
            set
            {
                largeIsSelected = value;
                if (largeIsSelected)
                {
                    largeButton.BackgroundColor = Color.Orange;
                    SliceIsSelected = false;
                    MediumIsSelected = false;
                    IndyIsSelected = false;
                }
                else
                {
                    largeButton.BackgroundColor = Color.Black;
                }
            }
        }
        public bool IndyIsSelected
        {
            get
            {
                return indyIsSelected;
            }
            set
            {
                indyIsSelected = value;
                if (indyIsSelected)
                {
                    indyButton.BackgroundColor = Color.Orange;
                    LargeIsSelected = false;
                    MediumIsSelected = false;
                    SliceIsSelected = false;
                }
                else
                {
                    indyButton.BackgroundColor = Color.Black;
                }
            }
        }
        #endregion
        #region Major buttons
        public bool MajorSliceIsSelected
        {
            get
            {
                return majorSliceIsSelected;
            }
            set
            {
                majorSliceIsSelected = value;
                if (majorSliceIsSelected)
                {
                    majorSliceButton.BackgroundColor = Color.Orange;
                    MajorLargeIsSelected = false;
                    MajorMediumIsSelected = false;
                    MajorIndyIsSelected = false;
                    MajorSatchPanIsSelected = false;
                    MajorMfpIsSelected = false;
                }
                else
                {
                    majorSliceButton.BackgroundColor = Color.Black;
                }
            }
        }

        public bool MajorIndyIsSelected
        {
            get
            {
                return majorIndyIsSelected;
            }
            set
            {
                majorIndyIsSelected = value;
                if (majorIndyIsSelected)
                {
                    majorIndyButton.BackgroundColor = Color.Orange;
                    MajorLargeIsSelected = false;
                    MajorMediumIsSelected = false;
                    MajorSliceIsSelected = false;
                    MajorSatchPanIsSelected = false;
                    MajorMfpIsSelected = false;
                }
                else
                {
                    majorIndyButton.BackgroundColor = Color.Black;
                }
            }
        }
        public bool MajorMediumIsSelected
        {
            get
            {
                return majorMediumIsSelected;
            }
            set
            {
                majorMediumIsSelected = value;
                if (majorMediumIsSelected)
                {
                    majorMediumButton.BackgroundColor = Color.Orange;
                    MajorLargeIsSelected = false;
                    MajorSliceIsSelected = false;
                    MajorIndyIsSelected = false;
                    MajorSatchPanIsSelected = false;
                    MajorMfpIsSelected = false;
                }
                else
                {
                    majorMediumButton.BackgroundColor = Color.Black;
                }
            }
        }
        public bool MajorLargeIsSelected
        {
            get
            {
                return majorLargeIsSelected;
            }
            set
            {
                majorLargeIsSelected = value;
                if (majorLargeIsSelected)
                {
                    majorLargeButton.BackgroundColor = Color.Orange;
                    MajorSliceIsSelected = false;
                    MajorMediumIsSelected = false;
                    MajorIndyIsSelected = false;
                    MajorSatchPanIsSelected = false;
                    MajorMfpIsSelected = false;
                }
                else
                {
                    majorLargeButton.BackgroundColor = Color.Black;
                }
            }
        }

        public bool MajorMfpIsSelected
        {
            get
            {
                return majorMfpIsSelected;
            }
            set
            {
                majorMfpIsSelected = value;
                if (majorMfpIsSelected)
                {
                    majorMfpButton.BackgroundColor = Color.Orange;
                    MajorSliceIsSelected = false;
                    MajorMediumIsSelected = false;
                    MajorIndyIsSelected = false;
                    MajorSatchPanIsSelected = false;
                    MajorLargeIsSelected = false;
                }
                else
                {
                    majorMfpButton.BackgroundColor = Color.Black;
                }
            }
        }

        public bool MajorSatchPanIsSelected
        {
            get
            {
                return majorSatchPanIsSelected;
            }
            set
            {
                majorSatchPanIsSelected = value;
                if (majorSatchPanIsSelected)
                {
                    majorSatchPanButton.BackgroundColor = Color.Orange;
                    MajorSliceIsSelected = false;
                    MajorMediumIsSelected = false;
                    MajorLargeIsSelected = false;
                    MajorIndyIsSelected = false;
                    MajorMfpIsSelected = false;
                }
                else
                {
                    majorSatchPanButton.BackgroundColor = Color.Black;
                }
            }
        }

        #endregion
        #endregion

        #region Constructor
        public PizzaPage()
        {
            pizzaPageModel = new PizzaPageModel();
            InitializeComponent();

            sliceButton = PizzaGrid.FindByName<Button>("Slice");
            mediumButton = PizzaGrid.FindByName<Button>("Medium");
            largeButton = PizzaGrid.FindByName<Button>("Large");
            indyButton = PizzaGrid.FindByName<Button>("Indy");
            SliceIsSelected = true;

            majorSliceButton = PizzaGrid.FindByName<Button>("MajorSlice");
            majorIndyButton = PizzaGrid.FindByName<Button>("MajorIndy");
            majorMediumButton = PizzaGrid.FindByName<Button>("MajorMedium");
            majorLargeButton = PizzaGrid.FindByName<Button>("MajorLarge");
            majorMfpButton = PizzaGrid.FindByName<Button>("MajorMfp");
            majorSatchPanButton = PizzaGrid.FindByName<Button>("MajorSatchPan");
            MajorSliceIsSelected = true;
            var menuHeaderModel = MenuHeaderModel.GetInstance();
            menuHeaderModel.PizzaName = string.Empty;
            menuHeaderModel.ItemTotal = 0M;
            menuHeaderModel.OrderTotal = OrderManager.GetInstance().OrderInProgress.Total;
        }
        #endregion

        #region Methods
        async Task DisplayToppingsPage()
        {
            var orderManager = OrderManager.GetInstance();
            //Update the current table to indicate it is occupied.
            Table currentTable = OrderManager.GetInstance().GetCurrentTable();
            currentTable.IsOccupied = true;
            orderManager.UpdateCurrentTable(currentTable);
            ToppingsPage ToppingsPage = new ToppingsPage(orderManager.GetCurrentPizza());
            await Navigation.PushAsync(ToppingsPage);
        }

        void OnPizzaSliceSelected()
        {
            SliceIsSelected = true;
        }

        void OnPizzaMediumSelected()
        {
            MediumIsSelected = true;
        }

        void OnPizzaLargeSelected()
        {
            LargeIsSelected = true;
        }

        void OnPizzaIndySelected()
        {
            IndyIsSelected = true;
        }

        void OnMajorSliceSelected()
        {
            MajorSliceIsSelected = true;
        }

        void OnMajorMediumSelected()
        {
            MajorMediumIsSelected = true;
        }

        void OnMajorLargeSelected()
        {
            MajorLargeIsSelected = true;
        }

        void OnMajorIndySelected()
        {
            MajorIndyIsSelected = true;
        }

        void OnMajorMfpSelected()
        {
            MajorMfpIsSelected = true;
        }

        void OnMajorSatchPanSelected()
        {
            MajorSatchPanIsSelected = true;
        }

        public PizzaSize GetPizzaSizeSelected()
        {
            PizzaSize sizeSelected = PizzaSize.OneSize;
            if (SliceIsSelected)
            {
                sizeSelected = PizzaSize.Slice;
            }
            else if (MediumIsSelected)
            {
                sizeSelected = PizzaSize.Medium;
            }
            else if (LargeIsSelected)
            {
                sizeSelected = PizzaSize.Large;
            }
            else if (IndyIsSelected)
            {
                sizeSelected = PizzaSize.Indy;
            }
            return sizeSelected;
        }

        public PizzaType GetMajorSizeSelected()
        {
            PizzaType sizeSelected = PizzaType.ThinSlice;
            if (MajorSliceIsSelected)
            {
                sizeSelected = PizzaType.ThinSlice;
            }
            else if (MajorMediumIsSelected)
            {
                sizeSelected = PizzaType.Medium;
            }
            else if (MajorLargeIsSelected)
            {
                sizeSelected = PizzaType.Large;
            }
            else if (MajorIndyIsSelected)
            {
                sizeSelected = PizzaType.Indy;
            }
            else if (MajorMfpIsSelected)
            {
                sizeSelected = PizzaType.Mfp;
            }
            else if (MajorSatchPanIsSelected)
            {
                sizeSelected = PizzaType.SatchPan;
            }
            return sizeSelected;
        }

        async Task OnPlusCheesePizza(object sender, EventArgs e)
        {
            var pizzaSize = GetPizzaSizeSelected();
            pizzaType = Pizza.GetPizzaType(pizzaSize, PizzaCrust.RegularThin);
            //Send info to OrderManager
            var guiData = new CustomerSelections(pizzaType)
            {
                MenuItemGeneralCategory = MenuCategory.Pizza,
                PizzaSize = pizzaSize,
                PizzaCrustType = PizzaCrust.RegularThin,
                NumberOfItems = 1
            };

            OrderManager.GetInstance().AddItemInProgress(guiData);

            await DisplayToppingsPage();
        }

            
        async void OnPlusMajorPizza(object sender, EventArgs e)
        {
            pizzaType = GetMajorSizeSelected();
            var guiData = new CustomerSelections(pizzaType)
            {
                MenuItemGeneralCategory = MenuCategory.Pizza,
                MajorOrMama = MajorOrMama.Major,
                NumberOfItems = 1
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

 
            OrderManager.GetInstance().AddItemInProgress(guiData);

            await DisplayToppingsPage();

        }

        async Task OnMfpPizza(object sender, EventArgs e)
        {
            pizzaType = PizzaType.Mfp;
            //Send info to OrderManager
            var guiData = new CustomerSelections(pizzaType)
            {
                MenuItemGeneralCategory = MenuCategory.Pizza,
                PizzaSize = PizzaSize.OneSize,
                NumberOfItems = 1
            };

            OrderManager.GetInstance().AddItemInProgress(guiData);

            await DisplayToppingsPage();
        }

        async Task OnSatchPanPizza(object sender, EventArgs e)
        {
            pizzaType = PizzaType.SatchPan;
            //Send info to OrderManager
            var guiData = new CustomerSelections(pizzaType)
            {
                MenuItemGeneralCategory = MenuCategory.Pizza,
                PizzaSize = PizzaSize.OneSize,
                NumberOfItems = 1
            };

            OrderManager.GetInstance().AddItemInProgress(guiData);

            await DisplayToppingsPage();
        }
        #endregion
    }
}