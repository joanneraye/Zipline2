using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using static Zipline2.PageModels.TablesPageModel;

namespace Zipline2.Pages
{
    public class TablesPageHeaderTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TablePageTakeoutRowTemplate { get; set; }
        public DataTemplate TablePageDividerTemplate { get; set; }
        public DataTemplate TablePageBlankTemplate { get; set; }

        public TablesPageHeaderTemplateSelector()
        {
         
           

        }
      
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is TableGroup)
            {
                TableGroup thisGroup = (TableGroup)item;
                switch (thisGroup.HeaderType)
                {
                    case TableGroup.GroupHeaderSelector.BlankHeader:
                        return TablePageBlankTemplate;
                    case TableGroup.GroupHeaderSelector.DividerHeader:
                        return TablePageDividerTemplate;
                    case TableGroup.GroupHeaderSelector.TakeoutRow:
                        return TablePageTakeoutRowTemplate;
                }
            }
            
            return TablePageBlankTemplate;
        }
    }
}
