using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.Models;

namespace Zipline2.MyEventArgs
{
    public class SaladToppingsPageEventArgs : EventArgs
    {
        private Salad currentSalad;
        public Salad CurrentSalad
        {
            get
            {
                return currentSalad;
            }
        }
        public SaladToppingsPageEventArgs(Salad thisSalad)
        {
            currentSalad = thisSalad;
        }

    }
}
