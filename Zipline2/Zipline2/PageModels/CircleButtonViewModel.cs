using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.PageModels
{
    public class CircleButtonViewModel : BasePageModel
    {
        private string drinkNameDisplayed;
        public string DrinkNameDisplayed
        {
            get
            {
                return drinkNameDisplayed;
            }
            set
            {
                SetProperty(ref drinkNameDisplayed, value);
            }
        }

        private int drinkCount;
        public int DrinkCount
        {
            get
            {
                return drinkCount;
            }
            set
            {
                SetProperty(ref drinkCount, value);
            }
        }

        public CircleButtonViewModel()
        {
            DrinkCount = 0;
        }

        public CircleButtonViewModel(string buttonName)
        {
            DrinkNameDisplayed = buttonName;
        }
    }
}
