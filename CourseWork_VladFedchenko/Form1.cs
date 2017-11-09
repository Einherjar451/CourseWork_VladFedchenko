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
    public partial class Form1 : Form
    {
        private String pathToDataBase = @"C:\dir\FedchenkoDB.db";
        private SQLiteConnection connect;
        private SQLiteDataReader reader;
        private SQLiteCommand command;

        public static String number;
        public static String name;
        public static String email;

        private String testNumber;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                number = textBox1.Text;

                connect = new SQLiteConnection(string.Format("Data Source={0};", pathToDataBase));
                connect.Open();

                command = new SQLiteCommand("SELECT * FROM 'contacts' WHERE number='" + number + "';", connect);
                reader = command.ExecuteReader();
                

                foreach (DbDataRecord record in reader) 
                {
                    testNumber = record["number"].ToString();

                    if (number.Equals(testNumber))
                    {
                        email = record["email"].ToString();
                        name = record["name"].ToString();

                        label3.Text = name;
                    }

                }
            }
            catch(System.FormatException)
            {
                MessageBox.Show("");
            }
            catch(SQLiteException) 
            {
                MessageBox.Show("");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();
        }
    }
}
