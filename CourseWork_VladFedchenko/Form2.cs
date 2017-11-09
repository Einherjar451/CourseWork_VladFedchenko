using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Common;

namespace CourseWork_VladFedchenko
{
    public partial class Form2 : Form
    {
        private String pathToDataBase = @"C:\dir\FedchenkoDB.db";
        private SQLiteConnection connect;
        private SQLiteDataReader reader;
        private SQLiteCommand command;
        
        private String number;
        private String name;
        private String email;

        private String sqlComm;

        public Form2()
        {
            InitializeComponent();
        }

        private void dataBConnected() 
        {
            try
            {
                number = textBox1.Text;
                name = textBox2.Text;
                email = textBox3.Text;

                connect = new SQLiteConnection(string.Format("Data Source={0};", pathToDataBase));
                connect.Open();

                sqlComm = "INSERT INTO contacts(number,name,email) Values(" + number + ",'" + name + "','" + email +"');";

                command = new SQLiteCommand(sqlComm, connect);
                command.ExecuteNonQuery();
                connect.Close();

                MessageBox.Show("Контакт успешно записан!");
                Form2.ActiveForm.Close();
            } 
            catch(SQLiteException) 
            {
                MessageBox.Show("Не корректное введение данных!");
            }
            catch(System.FormatException) 
            {
                MessageBox.Show("Не корректное введение данных!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBConnected();
        }

    }
}
