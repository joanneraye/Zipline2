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
   public class CalzonePageModel : BasePageModel
    {

        public ICommand AddCalzoneCommand { get; set; }
        public ICommand AddCalzoneHotRopeCommand { get; set; }
        public ICommand AddCalzonePBJCommand { get; set; }
        public ICommand AddCalzoneSteakAndCheeseCommand { get; set; }
        public ICommand AddCalzoneMajorCommand { get; set; }

        public event EventHandler<CalzoneToppingsPageEventArgs> NavigateToCalzoneToppingsPage;

        public CalzonePageModel()
        {
            AddCalzoneCommand = new Command(OnAddCalzone);
            AddCalzoneHotRopeCommand = new Command(OnAddHotRope);
            AddCalzonePBJCommand = new Command(OnAddPBJ);
            AddCalzoneSteakAndCheeseCommand = new Command(OnAddSteakAndCheese);
            AddCalzoneMajorCommand = new Command(OnAddMajor);
        }
      
        public void OnAddCalzone()
        {
            Calzone calzoneSelected = new Calzone()
            {
                CalzoneType = CalzoneType.RicottaMozarella
            };
            AddCalzoneToOrder(calzoneSelected);
        }

        public void OnAddHotRope()
        {
            Calzone calzoneSelected = new Calzone()
            {
                CalzoneType = CalzoneType.HotRope
            };
            AddCalzoneToOrder(calzoneSelected);
        }

        public void OnAddPBJ()
        {
            Calzone calzoneSelected = new Calzone()
            {
                CalzoneType = CalzoneType.PBJ
            };
            AddCalzoneToOrder(calzoneSelected);
        }

        public void OnAddSteakAndCheese()
        {
            Calzone calzoneSelected = new Calzone()
            {
                CalzoneType = CalzoneType.SteakAndCheese
            };
            AddCalzoneToOrder(calzoneSelected);
        }

        public void OnAddMajor()
        {
            Calzone calzoneSelected = new Calzone()
            {
                CalzoneType = CalzoneType.Major,
                MajorMamaInfo = MajorOrMama.Major
            };
            AddCalzoneToOrder(calzoneSelected);
        }

        private void AddCalzoneToOrder(Calzone thisCalzone)
        {
            thisCalzone.ItemCount = 1;
            OrderManager.Instance.AddNewItemInProgress(thisCalzone);
            DisplayCalzoneToppingsPage(thisCalzone);
        }

        private void DisplayCalzoneToppingsPage(Calzone thisCalzone)
        {
            MenuHeaderModel.Instance.ItemTotal = thisCalzone.PricePerItemIncludingToppings;
            NavigateToCalzoneToppingsPage?.Invoke(this, new CalzoneToppingsPageEventArgs(thisCalzone));
        }

    }
}
