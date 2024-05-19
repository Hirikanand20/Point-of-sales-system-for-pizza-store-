using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class setting : Form
    {

        functions con;
        public setting()
        {
            InitializeComponent();
            con = new functions();
        }

  
        private void label4_Click(object sender, EventArgs e)
        {
            billing OBJ = new billing();
            OBJ.Show();
            this.Hide();

        }


        private void setting_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string key;

            try
            {

                     int  pr = Convert.ToInt32(textBox2.Text);


                if (comboBox2.SelectedIndex == -1)
                {
                    label9.Text="please select a pizza";
                    System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
                    timer1.Interval = 3000; // 5 seconds
                    timer1.Tick += (s, e) =>
                    {
                        label9.Text = ""; // Clear the label text
                        timer1.Stop(); // Stop the timer
                    };
                    timer1.Start();
                }
                else if (comboBox2.SelectedIndex == 0)
                {
                    key ="Small";
                    string query = "Update Pizzatbl set Price ={0} Where Item ='{1}'";
                    query=string.Format(query, pr, key);
                    con.setData(query);
                    label9.Text="Price update!!";
                    System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
                    timer1.Interval = 3000; // 5 seconds
                    timer1.Tick += (s, e) =>
                    {
                        label9.Text = ""; // Clear the label text
                        timer1.Stop(); // Stop the timer
                    };
                    timer1.Start();

                }
                else if (comboBox2.SelectedIndex == 1)
                {
                   key ="Medium";
                    string query = "Update Pizzatbl set Price ={0} Where Item ='{1}'";
                    query=string.Format(query, pr, key);
                    con.setData(query);
                    label9.Text = "Price update!!";
                    System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
                    timer1.Interval = 3000; // 5 seconds
                    timer1.Tick += (s, e) =>
                    {
                        label9.Text = ""; // Clear the label text
                        timer1.Stop(); // Stop the timer
                    };
                    timer1.Start();

                }
                else if (comboBox2.SelectedIndex == 2)
                {
                    key ="Large";
                    string query = "Update Pizzatbl set Price ={0} Where Item ='{1}'";
                    query=string.Format(query, pr, key);
                    con.setData(query);
                    label9.Text = "Price update!!";
                    System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
                    timer1.Interval = 3000; // 5 seconds
                    timer1.Tick += (s, e) =>
                    {
                        label9.Text = ""; // Clear the label text
                        timer1.Stop(); // Stop the timer
                    };
                    timer1.Start();
                }

                else if (comboBox2.SelectedIndex == 3)
                {
                    key ="Extra Large";
                    string query = "Update Pizzatbl set Price ={0} Where Item ='{1}'";
                    query=string.Format(query, pr, key);
                    con.setData(query);
                    label9.Text = "Price update!!";

                    System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
                    timer1.Interval = 3000; // 5 seconds
                    timer1.Tick += (s, e) =>
                    {
                        label9.Text = ""; // Clear the label text
                        timer1.Stop(); // Stop the timer
                    };
                    timer1.Start();
                }
            }
            catch (Exception ex)
            {
                label9.Text = ex.ToString();

                System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
                timer1.Interval = 3000; // 5 seconds
                timer1.Tick += (s, e) =>
                {
                    label9.Text = ""; // Clear the label text
                    timer1.Stop(); // Stop the timer
                };
                timer1.Start();
            }


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            admin a = new admin();
            a.Show();
            this.Hide();
            
        }
    }
}
