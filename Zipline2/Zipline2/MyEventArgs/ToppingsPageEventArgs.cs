using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.Models;

namespace Zipline2.MyEventArgs
{
    public class ToppingsPageEventArgs : EventArgs
    {
        private Pizza _currentPizza;
        public Pizza CurrentPizza
        {
            get
            {
                return _currentPizza;
            }
        }
        public ToppingsPageEventArgs(Pizza thisPizza)
        {
            _currentPizza = thisPizza;   
        }
        
    }
}
