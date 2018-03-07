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
        private bool sliceIsSelected;
        private bool largeIsSelected;
        private bool mediumIsSelected;
        private bool indyIsSelected;
        private Button sliceButton;
        private Button mediumButton;
        private Button largeButton;
        private Button indyButton;
        
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
     
        //PizzaPageModel PizzaPageModel;
        public PizzaPage ()
		{
            //PizzaPageModel = new PizzaPageModel();
            InitializeComponent ();
            sliceButton = PizzaGrid.FindByName<Button>("Slice");
            mediumButton = PizzaGrid.FindByName<Button>("Medium");
            largeButton = PizzaGrid.FindByName<Button>("Large");
            indyButton = PizzaGrid.FindByName<Button>("Indy");
            SliceIsSelected = true;

            //BindingContext = PizzaPageModel;
            //CheesePizzaPicker.SelectedIndex = 0;

            //CheesePizzaPicker.ItemsSource = PizzaPageModel.PizzaPickerList;
            //CheesePizzaRadioButtons.CheckedChanged += CheesePizzaRadioButtons_CheckedChanged;

            var majorTypes = new List<string>
            {
                MajorPizzaType.Slice.ToString(),
                MajorPizzaType.Indy.ToString(),
                MajorPizzaType.Medium.ToString(),
                MajorPizzaType.Large.ToString(),
                MajorPizzaType.Mfp.ToString(),
                MajorPizzaType.SatchPan.ToString()
            };
            
            //MajorPizzaPicker.ItemsSource = majorTypes;
            //MajorPizzaPicker.SelectedIndex = 0;            
		}

        //void CheesePizzaRadioButtons_CheckedChanged(object sender, int e)
        //{
        //    var radio = sender as CustomRadioButton;

        //    if (radio == null || radio.Id == -1) return;
        //}

        async Task DisplayToppingsPage()
        {
            //Update the current table to indicate it is occupied.
            Table currentTable = OrderManager.GetInstance().GetCurrentTable();
            currentTable.IsOccupied = true;
            OrderManager.GetInstance().UpdateCurrentTable(currentTable);

            await Navigation.PushAsync(new ToppingsPage());
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

        async Task OnPlusCheesePizza(object sender, EventArgs e)
        {
            var pizzaSize = GetPizzaSizeSelected();

            //Send info to OrderManager
            var guiData = new CustomerSelections
            {
                MenuItemGeneralCategory = MenuCategory.Pizza,
                PizzaSize = pizzaSize,
                NumberOfItems = 1
            };

            OrderManager.GetInstance().HandleOrderItem(guiData);

            await DisplayToppingsPage();
        }

            
        async void OnPlusMajorPizza(object sender, EventArgs e)
        {
            //Get size chosen from picker.
            //var majorPizzaType = (MajorPizzaType)Enum.Parse(typeof(MajorPizzaType),
            //                        MajorPizzaPicker.SelectedItem.ToString());

            //var guiData = new CustomerSelections
            //{
            //    MenuItemGeneralCategory = MenuCategory.Pizza,
            //    MajorOrMama = MajorOrMama.Major,
            //    NumberOfItems = 1
            //};

            //switch (majorPizzaType)
            //{
            //    case MajorPizzaType.Indy:
            //        guiData.PizzaSize = PizzaSize.Indy;
            //        guiData.PizzaType = PizzaType.RegularThin;
            //        break;
            //    case MajorPizzaType.Large:
            //        guiData.PizzaSize = PizzaSize.Large;
            //        guiData.PizzaType = PizzaType.RegularThin;
            //        break;
            //    case MajorPizzaType.Medium:
            //        guiData.PizzaSize = PizzaSize.Large;
            //        guiData.PizzaType = PizzaType.RegularThin;
            //        break;
            //    case MajorPizzaType.Mfp:
            //        guiData.PizzaSize = PizzaSize.Large;
            //        guiData.PizzaType = PizzaType.Mfp;
            //        break;
            //    case MajorPizzaType.SatchPan:
            //        guiData.PizzaSize = PizzaSize.Large;
            //        guiData.PizzaType = PizzaType.SatchPan;
            //        break;
            //    case MajorPizzaType.Slice:
            //        guiData.PizzaSize = PizzaSize.Slice;
            //        guiData.PizzaType = PizzaType.RegularThin;
            //        break;
            //}

            //OrderManager.GetInstance().HandleOrderItem(guiData);
           
            ////Allow user to modify Major pizza
            await DisplayToppingsPage();

        }

        async Task OnMfpPizza(object sender, EventArgs e)
        {
            //Send info to OrderManager
            var guiData = new CustomerSelections
            {
                MenuItemGeneralCategory = MenuCategory.Pizza,
                PizzaSize = PizzaSize.OneSize,
                PizzaType = PizzaType.Mfp,
                NumberOfItems = 1
            };

            OrderManager.GetInstance().HandleOrderItem(guiData);

            await DisplayToppingsPage();
        }

        async Task OnSatchPanPizza(object sender, EventArgs e)
        {
            //Send info to OrderManager
            var guiData = new CustomerSelections
            {
                MenuItemGeneralCategory = MenuCategory.Pizza,
                PizzaSize = PizzaSize.OneSize,
                PizzaType = PizzaType.SatchPan,
                NumberOfItems = 1
            };

            OrderManager.GetInstance().HandleOrderItem(guiData);

            await DisplayToppingsPage();
        }
    }
}