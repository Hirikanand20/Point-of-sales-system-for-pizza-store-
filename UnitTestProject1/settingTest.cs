using NUnit.Extensions.Forms;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace UnitTestProject1
{
    [TestFixture]
    internal class settingTest
    {
        string pizza = @"Data Source=HIRIK\SQL11;Initial Catalog=pizzaorderdb;Integrated Security=True";

        private ComboBoxTester comboBoxTester;
        private ButtonTester _buttonTester;
        private TextBoxTester _textBoxTester;

        private LabelTester l1;
        private LabelTester l2;
        private LabelTester l3;

        setting s;
        admin a;
        [SetUp]
        public void SetUp()
        {

            a= new admin();
            s=new setting();
            _buttonTester =new ButtonTester("button1",s);
            _textBoxTester=new TextBoxTester("textBox2",s);
            comboBoxTester=new ComboBoxTester("comboBox2", s);
            l1=new LabelTester("label9",s);
            l2=new LabelTester("label8", s);
            l3=new LabelTester("label1",a);

        }

        [Test]
        public void Stringtest() {
            s.Show();

            comboBoxTester.Select(1);
            _textBoxTester.Enter("abc");

            _buttonTester.Click();
            Assert.That(l1.Text, Is.EqualTo("Price update!!"));


        }
        [Test]
        public void Numerictest()
        {
            s.Show();

            comboBoxTester.Select(1);
            _textBoxTester.Enter("13");

            _buttonTester.Click();
            Assert.That(l1.Text, Is.EqualTo("Price update!!"));


        }


        [Test]
        public void QueryTest()
        {
            string x = "Small";
            string y = "ABC";
            SqlConnection conn = new SqlConnection(pizza);
            string querry = "Update Pizzatbl set Price ='"+y+"' Where Item ='"+x+"'";
            SqlDataAdapter sda = new SqlDataAdapter(querry, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            string query = "SELECT Price FROM Pizzatbl WHERE Item ='"+x+"'";
            sda = new SqlDataAdapter(query, conn);
             dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0) // Check if the DataTable has any rows
            {
                string price = dt.Rows[0]["Price"].ToString(); // Access the price of the first row
            }
            else
            {
                Console.WriteLine("No data found.");
            }



        }
        [Test]
        public void QueryTestnumeric()
        {
            string x = "Small";
            int y = 12;
            SqlConnection conn = new SqlConnection(pizza);
            string querry = "Update Pizzatbl set Price ='"+y+"' Where Item ='"+x+"'";
            SqlDataAdapter sda = new SqlDataAdapter(querry, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            string query = "SELECT Price FROM Pizzatbl WHERE Item ='"+x+"'";
            sda = new SqlDataAdapter(query, conn);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0) // Check if the DataTable has any rows
            {
                string price = dt.Rows[0]["Price"].ToString(); // Access the price of the first row
            }
            else
            {
                Console.WriteLine("No data found.");
            }

           

        }
        [Test]
        public void backb()
        {
            s.Show();
            l2.Click();
            Assert.That(l3.Text, Is.EqualTo("Administrator Controls"));
            

        }





    }
}
