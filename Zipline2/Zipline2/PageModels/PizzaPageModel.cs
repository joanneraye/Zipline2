using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.PageModels
{
    public class PizzaPageModel : BasePageModel
    {
        public PizzaPageModel()
        {
            pizzaPickerList = new List<string>();
            LoadData();
        }

        private void LoadData()
        {
            PizzaPickerList.Add(PizzaSize.Slice.ToString());
            PizzaPickerList.Add(PizzaSize.Indy.ToString());
            PizzaPickerList.Add(PizzaSize.Medium.ToString());
            PizzaPickerList.Add(PizzaSize.Large.ToString());
        }

        private List<string> pizzaPickerList;

        public List<string> PizzaPickerList
        {
            get
            {
                return pizzaPickerList;
            }
            set
            {
                SetProperty(ref pizzaPickerList, value);
            }
        }



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
