using Library.Support;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Views
{
    interface IView
    {
        event EventHandler<EventArgs> Conn;
        event EventHandler<EventArgs> GetStudents;
        event EventHandler<EventArgs> GetBooks;
        event EventHandler<TextEventArgs> SearchStudent;
        event EventHandler<IdEventArgs> ShowStudentDebt;


        void ShowConnectionStatus(bool st);
        void ShowTable(DataTable reader);
    }
}
