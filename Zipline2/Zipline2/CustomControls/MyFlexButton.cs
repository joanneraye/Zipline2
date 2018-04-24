using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Flex.Controls;
using Xamarin.Forms;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.CustomControls
{
    class MyFlexButton : FlexButton
    {
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
            nameof(CommandParameter),
            typeof(PizzaType),
            typeof(MyFlexButton),
            string.Empty,
            propertyChanging: (bindable, oldValue, newValue) =>
            {
                var ctrl = (MyFlexButton)bindable;
                ctrl.CommandParameter = (PizzaType)newValue;
            },
            defaultBindingMode: BindingMode.OneWay);

        private PizzaType _commandParameter;

        public PizzaType CommandParameter
        {
            get { return _commandParameter; }
            set
            {
                _commandParameter = value;
                OnPropertyChanged();
            }
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            "Command",
            typeof(ICommand),
            typeof(MyFlexButton),
            null,
            propertyChanging: (bindable, oldValue, newValue) =>
            {
                var ctrl = (MyFlexButton)bindable;
                ctrl.Command = (ICommand)newValue;
            },
            defaultBindingMode: BindingMode.OneWay);

        private ICommand _command;

        public ICommand Command
        {
            get { return _command; }
            set
            {
                _command = value;
                OnPropertyChanged();
            }
        }
    }
}
