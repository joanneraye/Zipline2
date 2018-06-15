using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Zipline2.Pages;

namespace Zipline2.PageModels
{
    public class ToppingFooterPageModel : BasePageModel
    {
        public ICommand NoToppingCommand { get; set; }
        public ICommand OnSideToppingCommand { get; set; }

        public ICommand LiteToppingCommand { get; set; }
        public ICommand ExtraToppingCommand { get; set; }

        private bool noToppingSelected;
        public bool NoToppingSelected
        {
            get
            {
                return noToppingSelected;
            }
            set
            {
                SetProperty(ref noToppingSelected, value);
                if (noToppingSelected)
                {
                    OnSideToppingSelected = false;
                    LiteToppingSelected = false;
                    ExtraToppingSelected = false;
                }
            }
        }

        private bool onSideToppingSelected;
        public bool OnSideToppingSelected
        {
            get
            {
                return onSideToppingSelected;
            }
            set
            {
                SetProperty(ref onSideToppingSelected, value);
                if (onSideToppingSelected)
                {
                    NoToppingSelected = false;
                    LiteToppingSelected = false;
                    ExtraToppingSelected = false;
                }
            }
        }

        private bool liteToppingSelected;
        public bool LiteToppingSelected
        {
            get
            {
                return liteToppingSelected;
            }
            set
            {
                SetProperty(ref liteToppingSelected, value);
                if (liteToppingSelected)
                {
                    OnSideToppingSelected = false;
                    NoToppingSelected = false;
                    ExtraToppingSelected = false;
                }
            }
        }

        private bool extraToppingSelected;
        public bool ExtraToppingSelected
        {
            get
            {
                return extraToppingSelected;
            }
            set
            {
                SetProperty(ref extraToppingSelected, value);
                if (extraToppingSelected)
                {
                    NoToppingSelected = false;
                    OnSideToppingSelected = false;
                    LiteToppingSelected = false;
                }
            }
        }

        public ToppingFooterPageModel()
        {
            NoToppingCommand = new Command(OnNoTopping);
            OnSideToppingCommand = new Command(OnOnSideTopping);
            LiteToppingCommand = new Command(OnLiteTopping);
            ExtraToppingCommand = new Command(OnExtraTopping);
        }
       
        void OnNoTopping()
        {
            NoToppingSelected = !NoToppingSelected;
        }
        void OnOnSideTopping()
        {
            OnSideToppingSelected = !OnSideToppingSelected;
        }
        void OnLiteTopping()
        {
            LiteToppingSelected = !LiteToppingSelected;
        }
        void OnExtraTopping()
        {
            ExtraToppingSelected = !ExtraToppingSelected;
        }
      
    }
}
