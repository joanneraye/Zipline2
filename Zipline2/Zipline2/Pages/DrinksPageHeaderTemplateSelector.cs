using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using static Zipline2.PageModels.DrinksPageModel;
using static Zipline2.PageModels.TablesPageModel;

namespace Zipline2.Pages
{
    public class DrinksPageHeaderTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DrinksPageDraftsHeaderTemplate { get; set; }
        public DataTemplate DrinksPageBlankHeaderTemplate { get; set; }

        public DrinksPageHeaderTemplateSelector()
        {

        }
        //public TablesPageHeaderTemplateSelector(DataTemplate[] templates)
        
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return DrinksPageDraftsHeaderTemplate;
        }
    }
}
