using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Support
{
   public class IdEventArgs:EventArgs
    {
        public IdEventArgs(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
