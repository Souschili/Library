using Library.Support;
using Library.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class View : Form, IView
    {
        public View()
        {
            InitializeComponent();
           
        }

        public event EventHandler<EventArgs> Conn;
        public event EventHandler<EventArgs> GetStudents;
        public event EventHandler<EventArgs> GetBooks;
        public event EventHandler<IdEventArgs> ShowStudentDebt;
        public event EventHandler<TextEventArgs> SearchStudent;


        /// <summary>
        /// Показать статус подключения.
        /// </summary>
        /// <param name="msg"></param>
        public void ShowConnectionStatus(bool msg)
        {

            this.label1.Text = msg ? "Connected" : "Disconnected";
            this.booksbtn.Enabled = msg;
            this.studbtn.Enabled = msg;
            if(!msg)
            {
                
                this.debtbtn.Enabled = msg;
               
                this.searchtxt.Enabled = msg;
               
            }
           
            
           

        }

        /// <summary>
        /// Показать таблицу студенты.
        /// </summary>
        /// <param name="reader"></param>
        public void ShowTable(DataTable reader)
        {
            
            dataGridView1.DataSource = reader;
            this.booksbtn.Enabled = true;
            this.studbtn.Enabled = true;
            //Активируем кнопку при получении таблицы студенты. Имена таблицам даны в модели см. методы.
            if (reader.TableName == "Student")
            {
                this.debtbtn.Enabled = true;
                
                this.searchtxt.Enabled = true;
                
               
                
            } 
            else
            {
                this.debtbtn.Enabled = false;
                
                this.searchtxt.Enabled = false;
                


            }
            

        }

        /// <summary>
        /// Подключиться/Отключиться от сервера.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Conn?.Invoke(this, e);
        }

        /// <summary>
        /// Запросить список студентов у сервера.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void srudbtn_Click(object sender, EventArgs e)
        {
            GetStudents?.Invoke(this, e);
            this.booksbtn.Enabled = false;
            this.studbtn.Enabled = false;
            this.debtbtn.Enabled = false;
        }

        /// <summary>
        /// Запросить список книг у сервера.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shbooksbtn_Click(object sender, EventArgs e)
        {
            GetBooks?.Invoke(this, e);
            this.booksbtn.Enabled = false;
            this.studbtn.Enabled = false;
            this.debtbtn.Enabled = false;
        }

        /// <summary>
        /// Показываем задолжность выделеного студента.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void debtbtn_Click(object sender, EventArgs e)
        {
            //Если есть выделеная строка в таблице,передаем Id студента
            //Переделать чуток  даном случае именно вся строка выделена должна быть,что неверно.
            if(dataGridView1.SelectedRows.Count==1)
            {
                //int index = dataGridView1.CurrentRow.Index;//исправить тут получается индекс
                
                var p = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
               
                //Console.WriteLine("Student Id"+dataGridView1.CurrentRow.Cells[0].Value.ToString());
                ShowStudentDebt?.Invoke(this, new IdEventArgs(p));
           
              
            }
            
        }

        private void searchtxt_TextChanged(object sender, EventArgs e)
        {
            
            var p = this.searchtxt.Text;
           

            SearchStudent?.Invoke(this, new TextEventArgs(p));
        }

    }
        
           
}
