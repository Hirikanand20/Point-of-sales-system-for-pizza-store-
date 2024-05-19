
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection login = new SqlConnection(@"Data Source=HIRIK\SQL11;Initial Catalog=login;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }
        public Boolean checkuser(string user, string pas) {


            String querry = "SELECT * FROM Logintbl WHERE username = '"+user+"' AND password ='"+pas+"' ";
            SqlDataAdapter sda = new SqlDataAdapter(querry,login);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {


                return false;
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user, pass;
            user= textBox1.Text;
            pass= textBox2.Text;

            if (textBox1.Text =="" && textBox2.Text =="") {
                label2.Text = " please enter credentials";
                System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
                timer1.Interval = 3000; // 5 seconds
                timer1.Tick += (s, e) =>
                {
                    label2.Text = ""; // Clear the label text
                    timer1.Stop(); // Stop the timer
                };
                timer1.Start();
            }
            else if (checkuser(user,pass) == true) {

                label2.Text = "User already exist";
                System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

                timer1.Interval = 3000; // 5 seconds
                timer1.Tick += (s, e) =>
                {
                    label2.Text = ""; // Clear the label text
                    timer1.Stop(); // Stop the timer
                };
                timer1.Start();
                textBox1.Clear();
                textBox2.Clear();

            }
            else {

                string querry = "INSERT INTO Logintbl (Username, Password) VALUES ('"+textBox1.Text+"', '"+textBox2.Text+"');";
                SqlDataAdapter sda = new SqlDataAdapter(querry, login);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                label2.Text = "New User added ";
                System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

                timer1.Interval = 3000; // 5 seconds
                timer1.Tick += (s, e) =>
                {
                    label2.Text = ""; // Clear the label text
                    timer1.Stop(); // Stop the timer
                };
                timer1.Start();

                textBox1.Clear();
                textBox2.Clear();
            }

        }

        private void label8_Click(object sender, EventArgs e)
        {
            admin a = new admin();
            a.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
