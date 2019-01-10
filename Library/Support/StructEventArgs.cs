using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Support
{
    class StructEventArgs:EventArgs
    {
       

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id_group {get;set;}
        public int Term { get; set; }

        public StructEventArgs(int id, string firstName, string lastName, int id_group, int term)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Id_group = id_group;
            Term = term;
        }

    }
}
