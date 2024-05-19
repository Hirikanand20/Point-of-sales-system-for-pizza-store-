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
    public partial class login : Form
    { 

        public login()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=HIRIK\SQL11;Initial Catalog=login;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tuser_TextChanged(object sender, EventArgs e)
        {

        }
        public SqlDataAdapter s1(string querry, SqlConnection conn)
        {


            SqlDataAdapter sda = new SqlDataAdapter(querry, conn);



            return sda;
        }
        public Boolean checkcred(String user,string pas) {



            String querry = "SELECT * FROM Logintbl WHERE username = '"+user+"' AND password ='"+pas+"' ";
            SqlDataAdapter sda = new SqlDataAdapter(querry, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else {


                return false; 
            }
        }

        private void logbut_Click(object sender, EventArgs e)
        {
            string user, pass;
            user= tuser.Text;   
            pass= tpass.Text;

            try
            {
                String querry = "SELECT * FROM Logintbl WHERE username = '"+tuser.Text+"' AND password ='"+tpass.Text+"' ";
                SqlDataAdapter sda= new SqlDataAdapter(querry,conn);
                DataTable dt=new DataTable();
                sda.Fill(dt);
                billing b = new billing();
                if (dt.Rows.Count > 0) {


                    if (tuser.Text =="admin" && tpass.Text =="admin")
                    {
                        admin s = new admin();  
                        s.Show();
                        this.Hide();

                    }
                    else if (tuser.Text !="admin" && tpass.Text !="admin")
                    {
                        user= tuser.Text;
                        pass= tpass.Text;


                        b.Show();
                        this.Hide();
                    }
                }
                
                else {
                    MessageBox.Show("Invalid Credentials");
                    tuser.Clear();
                    tpass.Clear();

                    tuser.Focus();
                
                }


            
            }
            catch {
                MessageBox.Show("error");
            
            }
        }
    }
}
