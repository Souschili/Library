using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Support
{
    //непригодилось
    public class InfoEventArgs : EventArgs
    {
        public InfoEventArgs(int id, int bookId)
        {
            Id = id;
            BookId = bookId;
        }

        public int Id { get; set; }
        public int BookId {get;set ;}
        

    }
}
