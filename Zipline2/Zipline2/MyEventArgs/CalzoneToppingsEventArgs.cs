using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.Models;

namespace Zipline2.MyEventArgs
{
    public class CalzoneToppingsPageEventArgs : EventArgs
    {
        private Calzone currentCalzone;
        public Calzone CurrentCalzone
        {
            get
            {
                return currentCalzone;
            }
        }
        public CalzoneToppingsPageEventArgs(Calzone thisCalzone)
        {
            currentCalzone = thisCalzone;
        }

    }
}
