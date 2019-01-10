using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Library.Support;

namespace Library.Models
{
    class Model : IModel
    {
        bool Status { get; set; } = false;
        DbProviderFactory fac { get; set; }
        DbConnection conn { get; set; }


        public Model()
        {
            this.fac = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["MyDB"].ProviderName); ;
            this.conn = fac.CreateConnection();
            conn.StateChange += ChangeState;
        }

        public event EventHandler<BoolEventArgs> ConnState;

        /// <summary>
        /// Реагируем на изменение состояния подключения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeState(object sender, StateChangeEventArgs e)
        {
            Status = Status ? false : true;
            ConnState?.Invoke(this, new BoolEventArgs(Status));
        }


        /// <summary>
        /// Подключение или отключение в зависмости от параметра статус
        /// </summary>
        public void Connection()
        {
            if (Status)
            {
                conn.Close();
            }
            else
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
                //Status = true;
                conn.Open();
            }

        }


        /// <summary>
        /// Получить всех студентов.
        /// </summary>
        public async Task<DataTable> GetStudentsAsync()
        {
            var cmd = fac.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Students";
            DataTable data = new DataTable();
            data.Load(await cmd.ExecuteReaderAsync());
            data.TableName = "Student";
            return data;
        }

        /// <summary>
        /// Получить список книг.
        /// </summary>
        /// <returns></returns>
        public async Task<DataTable> GetBooksAsync()
        {
            var cmd = fac.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Books";
            DataTable data = new DataTable();
            data.Load(await cmd.ExecuteReaderAsync());
            data.TableName = "Books"; //задаем имя таблицы
            return data;
        }

        /// <summary>
        /// Получить список долгов по книгам от студента
        /// </summary>
        /// <param name="studentid"></param>
        /// <returns></returns>
        public async Task<DataTable> GetDebtsAsync(int studentid)
        {

            

            var cmd = fac.CreateCommand();
            cmd.Connection = conn;
            var par = cmd.CreateParameter();
            par.ParameterName = "ID";
            par.Value = studentid;
            cmd.Parameters.Add(par);

            //длинная команда обобщеная инфа с трех таблиц.
            cmd.CommandText = @"select S_Cards.Id as 'Card Id',Students.Id,Students.FirstName,
                                Students.LastName,Books.Name as 'Book Name',Books.id as 'Book id',S_Cards.DateOut as 'Выдано',
                                S_Cards.DateIn as 'Возращено'
                                from Students inner join S_Cards 
                                on Students.Id=S_Cards.Id_Student 
                                inner join Books on S_Cards.Id_Book=Books.Id 
                                where Students.id=@ID";

            DataTable data = new DataTable();
            data.Load(await cmd.ExecuteReaderAsync());
            data.TableName = "Debt";
            return data;

        }

        /// <summary>
        /// Апдейтим таблицу
        /// </summary>
        /// <param name="p"></param>
        public void ReturnBook(IdEventArgs p)
        {

            using (var trz = conn.BeginTransaction())
            {

                try
                {
                   

                    var cmd = fac.CreateCommand();


                    cmd.Connection = conn;
                    cmd.Transaction = trz;
                    var par = cmd.CreateParameter();
                    par.ParameterName = "ID";
                    par.Value = p.Id;
                    cmd.Parameters.Add(par);

                    cmd.CommandText = @"update S_Cards 
                                       SET DateIn=GETDATE()
                                       where Id=@ID";
                    cmd.ExecuteNonQuery();
                    trz.Commit();
                }
                catch
                {
                    trz.Rollback();
                }

            }



        }




        /// <summary>
        /// Проверка есть ли книга в библиотеке(просто для себя)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> Checkbook(int id)
        {
            var cmd = fac.CreateCommand();
            cmd.Connection = conn;
            var par = cmd.CreateParameter();
            par.ParameterName = "ID";
            par.Value = id;
            cmd.Parameters.Add(par);
            cmd.CommandText = "select Id from Books where Id=@ID ";
            var name = await cmd.ExecuteScalarAsync();


            return name.ToString();//string.IsNullOrEmpty(name.ToString());
        }
        /// <summary>
        /// Добавляем новую книгу к списку выданных книг
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<bool> WriteNewBook(InfoEventArgs p)
        {
           

            using (var trz = conn.BeginTransaction())
            {
                try
                {
                    var cmd = fac.CreateCommand();
                    cmd.Connection = conn;
                    cmd.Transaction = trz;
                    var par1 = cmd.CreateParameter();
                    par1.ParameterName = "ID";
                    par1.Value = p.Id;
                    var par2 = cmd.CreateParameter();
                    par2.ParameterName = "BID";
                    par2.Value = p.BookId;
                    cmd.Parameters.Add(par1);
                    cmd.Parameters.Add(par2);
                    cmd.CommandText = @"insert into S_Cards (Id_Student,Id_Book,DateOut,DateIn,Id_Lib)
                                                            Values(@ID,@BID,GETDATE(),null,1)";

                    int x=await cmd.ExecuteNonQueryAsync();
                    trz.Commit();
                    return x>0;
                }
                catch
                {

                    //если запись не удалась 
                    trz.Rollback();
                    return false;
                }
            }
        }

        /// <summary>
        /// Фильтрация имен и фамилий по тексту
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public async Task<DataTable> SearchStudent(string text)
        {
            try
            {
                
                var cmd = fac.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"select * from Students where LastName+FirstName like '%"+text+"%'";
                var reader = await cmd.ExecuteReaderAsync();
                DataTable dt = new DataTable();
                dt.TableName = "Student";
                dt.Load(reader);
                return dt;
            }
            catch
            {
                return new DataTable("Student");
            }
           
        }
    }
}
