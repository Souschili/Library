using Library.Models;
using Library.Support;
using Library.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.Presenter
{
    class Presenter
    {
        IView view;
        IModel model;
        IDebtStd DebtStudentForm;
        

        public Presenter(IView view, IModel model)
        {
            this.view = view;
            this.model = model;
           
            view.Conn += Connect;
            view.GetStudents += Get_Students;
            view.GetBooks += Get_Books;
            view.SearchStudent += Search_Students;
            model.ConnState += Show_Status;
            view.ShowStudentDebt += Call_Debt_Tables;
            
            
        }

        /// <summary>
        /// Поиск студентов по имени и фамилии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Search_Students(object sender, TextEventArgs e)
        {
           
           var dt=await model.SearchStudent(e.Text);
            view.ShowTable(dt);
            
        }

        private async void Call_Debt_Tables(object sender, IdEventArgs e)
        {
           var reader = await model.GetDebtsAsync(e.Id);
            //вызываем нащу модальную форму
            DebtStudentForm = new StudentDebt(reader,e.Id);

            DebtStudentForm.ReturnBook += ReturBook;
            DebtStudentForm.AddBook += Add_Book;
            DebtStudentForm.ShowDialog();
            //Console.WriteLine("я тут и мой статус {0}",StudentDebt.Status.ToString());
          
            

           
        }

        private async void Add_Book(object sender, InfoEventArgs e)
        {
            //если запись прошла успешно меняем статус
            if (await model.WriteNewBook(e) && DebtStudentForm != null)
            {
                Console.WriteLine("я тут");
                //если транзакция прошла обновляем текущую таблицу
                var table = await model.GetDebtsAsync(e.Id);
                this.DebtStudentForm.Refresh(table);
            }
            
        }

        /// <summary>
        /// Вернули книгу 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturBook(object sender, IdEventArgs e)
        {
            model.ReturnBook(e);
        }



        /// <summary>
        /// Список книг.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Get_Books(object sender, EventArgs e)
        {
           var reader = await model.GetBooksAsync();
           view.ShowTable(reader);
        }


        /// <summary>
        /// Получить список студентов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Get_Students(object sender, EventArgs e)
        {
            
           var reader= await model.GetStudentsAsync();
            view.ShowTable(reader);
        }



        /// <summary>
        /// Показать статус подключения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Show_Status(object sender, BoolEventArgs e)
        {
           // Console.WriteLine(e.state);
           // string msg = e.state ? "Connected" : "Disconnected";
            view.ShowConnectionStatus(e.state);
        }

        private void Connect(object sender, EventArgs e)
        {
            
            model.Connection();
           
        }
    }
}
