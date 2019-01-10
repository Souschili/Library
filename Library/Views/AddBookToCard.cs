using Library.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.Views
{
    public partial class AddBookToCard : Form
    {
        public int id { get; private set; } = 0;
        
        public AddBookToCard()
        {
           
           
            InitializeComponent();
        }




        private void cnclbn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Добавляем книгу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addbtn_Click(object sender, EventArgs e)
        {
            //Если все контролы коректны 
            if(this.ValidateChildren())
            {
                id = Int32.Parse(textBox1.Text);
               
                this.Close();
            }
            else 
            {
                //вызываем окно с ошибками(лишнее но пусть будет ,чтоб знать и помнить как )
                var listerror= this.errorProvider1.ContainerControl.Controls.Cast<Control>()
                               .Select(c => this.errorProvider1.GetError(c))
                               .Where(s => !string.IsNullOrEmpty(s))
                               .ToList();

                MessageBox.Show("Введи айди книги:\n - " +
           string.Join("\n - ", listerror.ToArray()),
           "Error",
           MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        /// <summary>
        /// Проверка на ошибки .
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            int i=0;
            if(string.IsNullOrEmpty(this.textBox1.Text))
            {
                e.Cancel=true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Введите айди");
            }
            else if(!Int32.TryParse(textBox1.Text,out i))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Должно быть число !!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}
