using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.PageModels
{
    public class PizzaPageModel : BasePageModel
    {
        
        //Couldn't get buttons to work in grid so did in code behind.
        //public System.Windows.Input.ICommand PizzaSliceButtonCommand { get; set; }
        //public System.Windows.Input.ICommand PizzaMediumButtonCommand { get; set; }
        //public System.Windows.Input.ICommand PizzaLargeButtonCommand { get; set; }
        //public System.Windows.Input.ICommand PizzaIndyButtonCommand { get; set; }

        //private bool sliceIsSelected;
        //public bool SliceIsSelected
        //{
        //    get
        //    {
        //        return sliceIsSelected;
        //    }
        //    set
        //    {
        //        SetProperty(ref sliceIsSelected, value);
        //        if (sliceIsSelected)
        //        {
        //            mediumIsSelected = false;
        //            largeIsSelected = false;
        //            indyIsSelected = false;
        //        }
        //    }
        //}
        //private bool mediumIsSelected;
        //public bool MediumIsSelected
        //{
        //    get
        //    {
        //        return mediumIsSelected;
        //    }
        //    set
        //    {
        //        SetProperty(ref mediumIsSelected, value);
        //        if (mediumIsSelected)
        //        {
        //            sliceIsSelected = false;
        //            largeIsSelected = false;
        //            indyIsSelected = false;
        //        }
        //    }
        //}
        //private bool largeIsSelected;
        //public bool LargeIsSelected
        //{
        //    get
        //    {
        //        return largeIsSelected;
        //    }
        //    set
        //    {
        //        SetProperty(ref largeIsSelected, value);
        //        if (largeIsSelected)
        //        {
        //            sliceIsSelected = false;
        //            mediumIsSelected = false;
        //            indyIsSelected = false;
        //        }
        //    }
        //}
        //private bool indyIsSelected;
        //public bool IndyIsSelected
        //{
        //    get
        //    {
        //        return indyIsSelected;
        //    }
        //    set
        //    {
        //        SetProperty(ref indyIsSelected, value);
        //        if (indyIsSelected)
        //        {
        //            sliceIsSelected = false;
        //            mediumIsSelected = false;
        //            largeIsSelected = false;
        //        }
        //     }
        //}

        public PizzaPageModel()
        {
            //pizzaPickerList = new List<string>();
            //PizzaSliceButtonCommand = new Xamarin.Forms.Command(OnButtonPizzaSliceClick);
            //PizzaMediumButtonCommand = new Xamarin.Forms.Command(OnButtonPizzaMediumClick);
            //PizzaLargeButtonCommand = new Xamarin.Forms.Command(OnButtonPizzaLargeClick);
            //PizzaIndyButtonCommand = new Xamarin.Forms.Command(OnButtonPizzaIndyClick);
            //SliceIsSelected = true;
           
        }
      
        //public PizzaSize GetPizzaSizeSelected()
        //{
        //    PizzaSize sizeSelected = PizzaSize.OneSize;
        //    if (SliceIsSelected)
        //    {
        //        sizeSelected = PizzaSize.Slice;
        //    }
        //    else if (MediumIsSelected)
        //    {
        //        sizeSelected = PizzaSize.Medium;
        //    }
        //    else if (LargeIsSelected)
        //    {
        //        sizeSelected = PizzaSize.Large;
        //    }
        //    else if (IndyIsSelected)
        //    {
        //        sizeSelected = PizzaSize.Indy;
        //    }
        //    return sizeSelected;
        //}

        //void OnButtonPizzaSliceClick()
        //{
        //    SliceIsSelected = true;
        //}
        //void OnButtonPizzaMediumClick()
        //{
        //    MediumIsSelected = true;
        //}
        //void OnButtonPizzaLargeClick()
        //{
        //    LargeIsSelected = true;
        //}
        //void OnButtonPizzaIndyClick()
        //{
        //    IndyIsSelected = true;
        //}
       

        //private List<string> pizzaPickerList;

        //public List<string> PizzaPickerList
        //{
        //    get
        //    {
        //        return pizzaPickerList;
        //    }
        //    set
        //    {
        //        SetProperty(ref pizzaPickerList, value);
        //    }
        //}



        //private List<string> pizzaRadioButtonList;

        //public List<string> PizzaRadioButtonList
        //{
        //    get
        //    {
        //        return pizzaRadioButtonList;
        //    }
        //    set
        //    {
        //        SetProperty(ref pizzaRadioButtonList, value);
        //    }
        //}

        //private int selectedIndex;
        //public int SelectedIndex
        //{
        //    get
        //    {
        //        return selectedIndex;
        //    }
        //    set
        //    {
        //        if (value == selectedIndex)
        //        {
        //            return;
        //        }
        //        SetProperty(ref selectedIndex, value);
        //    }
        //}
    }
}
