using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Support
{
   public class TextEventArgs:EventArgs
    {
        public TextEventArgs(string text)
        {
            Text = text;
        }

        public string Text { get; set; }
    }
}
