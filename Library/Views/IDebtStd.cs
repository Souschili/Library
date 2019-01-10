using Library.Support;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.Views
{
    interface IDebtStd
    {
         event EventHandler<IdEventArgs> ReturnBook;
         event EventHandler<InfoEventArgs> AddBook;

        //спс буржуям
        DialogResult ShowDialog();

        void Refresh(DataTable data);

    }
}
