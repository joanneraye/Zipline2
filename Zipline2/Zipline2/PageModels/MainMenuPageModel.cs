using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2
{
    class MainMenuPageModel : BasePageModel
    {
        public List<MenuItem> MainMenu;

        public MainMenuPageModel()
        {
            var emptyItemChoicesList = new List<string>();

            MainMenu = new List<MenuItem>
                {
                       new MenuItem {ItemName = "Drinks", ItemChoices = emptyItemChoicesList},
                       new MenuItem {ItemName = "Pizza", ItemChoices = emptyItemChoicesList},
                       new MenuItem {ItemName = "Special", ItemChoices = emptyItemChoicesList},
                       new MenuItem {ItemName = "Drinks", ItemChoices = emptyItemChoicesList},
                       new MenuItem {ItemName = "Sides", ItemChoices = emptyItemChoicesList},
                       new MenuItem {ItemName = "Salads", ItemChoices = emptyItemChoicesList},
                       new MenuItem {ItemName = "Dessert", ItemChoices = emptyItemChoicesList},
                       new MenuItem {ItemName = "Merchandise", ItemChoices = emptyItemChoicesList},
                };

        }

        //public override void Init(object initData)
        //{
        //    base.Init(initData);

        //    var emptyItemChoicesList = new List<string>();

        //    MainMenu = new List<MenuItem>
        //    {
        //           new MenuItem {ItemName = "Drinks", ItemChoices = emptyItemChoicesList},
        //           new MenuItem {ItemName = "Pizza", ItemChoices = emptyItemChoicesList},
        //           new MenuItem {ItemName = "Special", ItemChoices = emptyItemChoicesList},
        //           new MenuItem {ItemName = "Drinks", ItemChoices = emptyItemChoicesList},
        //           new MenuItem {ItemName = "Sides", ItemChoices = emptyItemChoicesList},
        //           new MenuItem {ItemName = "Salads", ItemChoices = emptyItemChoicesList},
        //           new MenuItem {ItemName = "Dessert", ItemChoices = emptyItemChoicesList},
        //           new MenuItem {ItemName = "Merchandise", ItemChoices = emptyItemChoicesList},
        //    };
        //}

        //protected override void ViewIsAppearing(object sender, EventArgs e)
        //{
        //    base.ViewIsAppearing(sender, e);

        //    CoreMethods.DisplayAlert("Wired", "Done", "OK");
        //}
    }
}
