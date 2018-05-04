using CarouselView.FormsPlugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.PageModels;
using Zipline2.Pages;

namespace Zipline2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyCarouselViewControl : ContentView
	{
        private CarouselViewModel CarouselViewModel;
        private int LastPosition;
        public MyCarouselViewControl ()
		{
            CarouselViewModel = CarouselViewModel.GetInstance();
            InitializeComponent ();
            BindingContext = CarouselViewModel;
            LastPosition = 99;
        }
                   
        public async void OnToppingsCarouselScroll(object sender, ValueChangedEventArgs e)
        {
            if (sender is CarouselViewControl)
            {
                CarouselViewControl control = sender as CarouselViewControl;
                if (control.Position != LastPosition)
                {
                    var position = control.Position;
                    switch (position)
                    {
                        case 0:
                            await Navigation.PushAsync(new PizzaBasePage());
                            return;
                        case 1:
                            await Navigation.PushAsync(new ToppingsPage(CarouselViewModel.PizzaType));
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                    }
                    LastPosition = position;
                }
             
            }
        }
    }
}