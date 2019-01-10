using Library.Support;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    interface IModel
    {
        void Connection();
        Task<DataTable> GetStudentsAsync();
        Task<DataTable> GetBooksAsync();
        void ReturnBook(IdEventArgs p);
        Task<string> Checkbook(int id);

        Task<bool> WriteNewBook(InfoEventArgs p);

        Task<DataTable> SearchStudent(string text);

        Task<DataTable> GetDebtsAsync(int id);
        event EventHandler<BoolEventArgs> ConnState;
        
    }
}
