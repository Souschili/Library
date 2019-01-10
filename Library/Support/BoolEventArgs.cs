using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Support
{
    class BoolEventArgs:EventArgs
    {
        public BoolEventArgs(bool state)
        {
            this.state = state;
        }

        public bool state { get; set; }


    }
}
