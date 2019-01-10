using Library.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.Views
{
    public partial class StudentDebt : Form, IDebtStd
    {
        AddBookToCard ADB;
        private DataTable debttable; // таблица студента
        private int id { get; set; } //айди студента
       
        private int BookId = 0;


        //закрыть задолжность, по айди книги
        public event EventHandler<IdEventArgs> ReturnBook;
        public event EventHandler<InfoEventArgs> AddBook;

      
        public StudentDebt(DataTable debttable,int Id)
        {
            this.debttable = debttable;
            this.id = Id;
            ADB = new AddBookToCard();
            InitializeComponent();
        }

        /// <summary>
        /// Показ данных при загрузке.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentDebt_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AllowUserToAddRows = false;
            
            
            dataGridView1.DataSource = debttable;
            dataGridView1.ClearSelection();
            if(dataGridView1.Rows.Count==0)
            {
                clsbookbtn.Enabled = false;
            }
            else
            {
                clsbookbtn.Enabled = true;
            }
        }


        /// <summary>
        /// Вернуть книгу и закрыть задолжность
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clsbookbtn_Click(object sender, EventArgs e)
        {
            
            if(this.dataGridView1.SelectedRows.Count==0)
            {
                MessageBox.Show("Select Row !","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if(this.dataGridView1.CurrentRow.Cells[7].Value.ToString()=="")
            {
                // Забираем айди записи и апдейтим строку добавляя текущую дату вместо Null
                var p = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                //MessageBox.Show(p, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReturnBook?.Invoke(this, new IdEventArgs(Int32.Parse(p)));
                dataGridView1.CurrentRow.Cells[7].Value = System.DateTime.Now;
               
            }
        }


        /// <summary>
        /// Выдать новую книгу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Addbokbtn_Click(object sender, EventArgs e)
        {
            //Вызываем форму для добавления книги и получаем айди книги
            ADB.ShowDialog();
            BookId = ADB.id;

            //Имея айди студента и айди книги выполняем запрос
            AddBook?.Invoke(this, new InfoEventArgs(id, this.BookId));
            

        }

        /// <summary>
        /// Обновить текущую таблицу 
        /// </summary>
        /// <param name="data"></param>
        public void Refresh(DataTable data)
        {

            dataGridView1.DataSource = data; ;
            
            dataGridView1.ClearSelection();
            if (dataGridView1.Rows.Count == 0)
            {
                clsbookbtn.Enabled = false;
            }
            else
            {
                clsbookbtn.Enabled = true;
            }
        }
    }
}
