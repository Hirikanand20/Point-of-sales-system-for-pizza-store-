using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class billing : Form
    {   SqlConnection customerdb = new SqlConnection(@"Data Source=HIRIK\SQL11;Initial Catalog=customer;Integrated Security=True");


        functions con;
        public billing()
        {
            InitializeComponent();
           con = new functions();
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        int key = 0;
        public int getprice(int key)
        {

            String pizza = "";

            if (key == 1)
            {
                pizza = "Small";

            }
            else if (key == 2)
            {
                pizza = "Medium";

            }
            if (key == 3)
            {
                pizza = "Large";

            }
            if (key == 4)
            {
                pizza = "Extra Large";

            }

            String query = "select * from Pizzatbl where Item = '{0}'";

            query= string.Format(query, pizza);
            int price = Convert.ToInt32(con.GetData(query).Rows[0][1].ToString());
            return price;

        }
        int grdtotal = 0;
        int n = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            string item = "";
            if (smallbtn.Checked == true)
            {
                key =1;
                item = "small pizza";

            }
            else if (mediumbtn.Checked == true)
            {
                key =2;
                item = "Medium pizza";
            }
            else if (largebtn.Checked == true)
            {
                key =3;
                item = "Large pizza";
            }
            else if (extralargebtn.Checked == true)

            {
                key = 4;
                item = "Extra large pizza";
            }
            int qty = 0;
            int price = getprice(key);
            if (qtytb.Text == string.Empty)
            {
                label8.Text="Please enter the number of pizza";
                System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
                timer1.Interval = 3000; // 5 seconds
                timer1.Tick += (s, e) =>
                {
                    label8.Text = ""; // Clear the label text
                    timer1.Stop(); // Stop the timer
                };
                timer1.Start();
                qty = 0;
            }
            else
            {
                qty = Convert.ToInt32(qtytb.Text);
            }
            int total = qty*price;
            total = total -(total*disc/100);
            int top = topping();
            int d = dip();
            total = total + top +d -1;
            
            DataGridViewRow dr = new DataGridViewRow();
            dr.CreateCells(bill);
            dr.Cells[0].Value = n+1;

            dr.Cells[1].Value = item;
            dr.Cells[2].Value = price;
            dr.Cells[3].Value = qty;
            dr.Cells[4].Value = total;

            bill.Rows.Add(dr);
            n++;
            
            grdtotal = grdtotal + total ;
            Grdtotal.Text = "$  " + grdtotal;

            checkBox1.Checked = false;
            checkBox2.Checked = false; 
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;



        }

        private void smallbtn_CheckedChanged(object sender, EventArgs e)
        {

        }
        int prodid, prodprice, prodqty, total, pos = 70;

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void billing_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            setting s = new setting();
            Program.SwitchForms(this, s);
            s.Show();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        int disc = 0;
        private void button2_Click_1(object sender, EventArgs e)
        {
            Boolean B = UserExists(textBox1.Text,textBox2.Text);
            if (textBox1.Text =="" &&textBox2.Text =="") {
                label8.Text="No customer details added";
                System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
                timer1.Interval = 3000; // 5 seconds
                timer1.Tick += (s, e) =>
                {
                    label8.Text = ""; // Clear the label text
                    timer1.Stop(); // Stop the timer
                };
                timer1.Start();
                disc= 0;

            }
            else {
                Boolean B1 = UserExists(textBox1.Text, textBox2.Text);

                if (B == true)
                {
                    label8.Text="Customer is already exist in the databse (20% Discount)";
                    System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
                    timer1.Interval = 3000; // 5 seconds
                    timer1.Tick += (s, e) =>
                    {
                        label8.Text = ""; // Clear the label text
                        timer1.Stop(); // Stop the timer
                    };
                    timer1.Start();
                    disc= 20;
                }
                
                else
                {

                    disc =10;
                    string querry = "INSERT INTO [Table] (name, phone) VALUES ('"+textBox1.Text+"', '"+textBox2.Text+"');";
                    SqlDataAdapter sda = new SqlDataAdapter(querry, customerdb);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    label8.Text="Customer is added in the database (10% Discount)";
                    System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
                    timer1.Interval = 3000; // 5 seconds
                    timer1.Tick += (s, e) =>
                    {
                        label8.Text = ""; // Clear the label text
                        timer1.Stop(); // Stop the timer
                    };
                    timer1.Start();
                }
            }


        }
        public bool UserExists(string username, string phoneNumber)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=HIRIK\SQL11;Initial Catalog=customer;Integrated Security=True"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [Table] WHERE name = @Username AND phone = @PhoneNumber", connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                    int userCount = (int)command.ExecuteScalar();
                    return userCount > 0;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            login l = new login();
            l.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void qtytb_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }
        public int topping() {
            int x = 0;

            if (checkBox1.Checked) {
               
               x=x+1;
            }
            if (checkBox2.Checked)
            {

                x=x+1;
            }
            if (checkBox3.Checked)
            {

                x=x+3;
            }
            if (checkBox4.Checked)
            {

                x=x+2;
            }
            if (checkBox5.Checked)
            {

                x=x+3;
            }
            if (checkBox6.Checked)
            {

                x=x+1;
            }
            if (checkBox7.Checked)
            {

                x=x+1;
            }
            return x;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        public int dip() {

            int z = 0;

            if (checkBox11.Checked) {
                z=z+2;
            }
            if (checkBox8.Checked)
            {
                z=z+2;
            }
            if (checkBox9.Checked)
            {
                z=z+2;
            }
            if (checkBox10.Checked)
            {
                z=z+2;
            }
            return z;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {

        }

        string prodname;
        private void button3_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize= new System.Drawing.Printing.PaperSize("pprnm",285,600);
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK) {

                printDocument1.Print();
            } ;
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) {
            e.Graphics.DrawString("PIZZA ORDERING", new Font("Century Gothic", 12,FontStyle.Bold), Brushes.Red, new Point(80));
            e.Graphics.DrawString("ID PRODUCT PRICE QUANTITY TOTAL", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(20,20));
            foreach (DataGridViewRow row in bill.Rows) 
            {
                prodid =Convert.ToInt32(row.Cells["Column1"].Value);
                prodname=""+row.Cells["Column2"].Value;
                prodprice =Convert.ToInt32(row.Cells["Column3"].Value);
                prodqty =Convert.ToInt32(row.Cells["Column4"].Value);
                total=Convert.ToInt32(row.Cells["Column5"].Value);
                e.Graphics.DrawString("" + prodid, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(26,pos));
                e.Graphics.DrawString("" + prodname, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(45, pos));
                e.Graphics.DrawString("" + prodprice, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(130, pos));
                e.Graphics.DrawString("" + prodqty, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(170, pos));
                e.Graphics.DrawString("" + total, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(235, pos));
                pos = pos +20;

            }
            e.Graphics.DrawString("Grand Total: $" + grdtotal, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Crimson, new Point(50, pos + 50));
            e.Graphics.DrawString("**********PIZZA************", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Crimson, new Point(10, pos + 80));
            bill.Rows.Clear();
            bill.Refresh();
            pos=100;
            grdtotal=0;
            n=0;


        }
    }
}
