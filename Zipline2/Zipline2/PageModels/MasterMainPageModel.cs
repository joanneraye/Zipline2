using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.Pages;

namespace Zipline2.PageModels
{
    public class MasterMainPageModel : BasePageModel
    {
        public List<MasterPageItem> masterPageItemList;
        public List<MasterPageItem> MasterPageItemList
        { 
            get
            {
                return masterPageItemList;
            }
            set
            {
                SetProperty(ref masterPageItemList, value);
            }  
        }

public MasterMainPageModel()
        {
            MasterPageItemList = new List<MasterPageItem>
            {
                new MasterPageItem
                {
                    Title = "Tables",
                    IconSource = "blue_square.png",
                    TargetType = typeof(TablesPage)
                },
                new MasterPageItem
                {
                    Title = "Pizzas",
                    IconSource = "orange_square.png",
                    TargetType = typeof(PizzaPage)
                }
            };
        }
    }
}
