using NUnit.Extensions.Forms;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace UnitTestProject1
{
    [TestFixture]
    internal class BillingTest
    {
        SqlConnection customerdb = new SqlConnection(@"Data Source=HIRIK\SQL11;Initial Catalog=customer;Integrated Security=True");


        private ButtonTester bt1;

        private ButtonTester bt2;

        private ButtonTester bt3;

        private ButtonTester bt4;

        private TextBoxTester t1;
        private TextBoxTester t2;
        private TextBoxTester t3;
        
        

        private RadioButtonTester r1;
        private RadioButtonTester r2;
        private RadioButtonTester r3;
        private RadioButtonTester r4;
        private CheckBoxTester c1;
        private CheckBoxTester c2;
        private CheckBoxTester c3;
        private CheckBoxTester c4;
        private CheckBoxTester c5;
        private CheckBoxTester c6;
        private CheckBoxTester c7;
        private CheckBoxTester c8;
        private CheckBoxTester c9;
        private CheckBoxTester c10;
        private CheckBoxTester c11;

        private LabelTester l1;
        private LabelTester l2;
        private LabelTester l3;

        billing B;
        login l;
        [SetUp]
        public void SetUp()
        {
            B=new billing();
            l=new login();
            bt1= new ButtonTester("button1", B);
            bt2= new ButtonTester("button2", B);
            bt3= new ButtonTester("button3", B);
            bt4= new ButtonTester("button4", B);

            t1= new TextBoxTester("qtytb",B);
            t2=new TextBoxTester("textBox1", B);
            t3=new TextBoxTester("textBox2", B);

            
            r1=new RadioButtonTester("smallbtn",B);
            r2=new RadioButtonTester("mediumbtn", B);
            r3=new RadioButtonTester("largebtn", B);
            r4=new RadioButtonTester("extralargebtn", B);

            c1=new CheckBoxTester("checkBox1",B);
            c2=new CheckBoxTester("checkBox2", B);
            c3=new CheckBoxTester("checkBox3", B);
            c4=new CheckBoxTester("checkBox4", B);
            c5=new CheckBoxTester("checkBox5", B);
            c6=new CheckBoxTester("checkBox6", B);
            c7=new CheckBoxTester("checkBox7", B);
            c8=new CheckBoxTester("checkBox8", B);
            c9=new CheckBoxTester("checkBox9", B);
            c10=new CheckBoxTester("checkBox10", B);
            c11=new CheckBoxTester("checkBox11", B);

            l1=new LabelTester("label8",B);
            l2=new LabelTester("Grdtotal",B);
            l3=new LabelTester("label1",l);
            B.Show();

        }
        [Test]
        public void Errormessagevalidation1()
        {
            B.Show();
            t1.Enter("");
            bt1.Click();
            Assert.That(l1.Text,Is.EqualTo("Please enter the number of pizza"));
            B.Hide();
        }
        [Test]
        public void Errormessagevalidation2()
        {
            B.Show();
            t2.Enter("");
            t3.Enter("");
            bt2.Click();
            Assert.That(l1.Text, Is.EqualTo("No customer details added"));
            B.Hide();
        }
        [Test]
        public void Errormessagevalidation3()
        {

            String x = "Rishi";
            String y = "rishi";
            B.Show();
            t2.Enter(x);
            t3.Enter(y);
            bt2.Click();
            Assert.That(l1.Text, Is.EqualTo("No customer details added"));
            B.Hide();
            String querry = "DELETE FROM Logintbl WHERE username = '"+x+"' AND password ='"+y+"' ";
            SqlDataAdapter sda = new SqlDataAdapter(querry, customerdb);
            DataTable dt = new DataTable();
            sda.Fill(dt);

        }
        [Test]
        public void DiscountValidation()
        {
            B.Show();
            t2.Enter("hirik");
            t3.Enter("8814168");
            bt2.Click();
            Assert.That(l1.Text, Is.EqualTo("Customer is already exist in the databse (20% Discount)"));
            c1.Check();
            t1.Enter("1");
            c11.Check();
            bt1.Click();
            Assert.That(l2.Text, Is.EqualTo("$  12"));

            B.Hide();
        }

        [Test]
        public void Errormessagevalidation4()
        {
            B.Show();
            t1.Enter("abc");
            bt1.Click();
            Assert.That(l1.Text, Is.EqualTo("Please enter the number of pizza"));
            B.Hide();
        }

        [Test]
        public void LogoutTest()
        {
            B.Show();
            bt4.Click();
            Assert.That(l3.Text, Is.EqualTo("Pizza Point Of Sale"));
            B.Hide();
        }
        [Test]
        public void NewCustomerTest()
        {
            String x ="Alex" , y= "8817168";


            B.Show();
            t2.Enter(x);
            t3.Enter(y);
            bt2.Click();
            Assert.That(l1.Text, Is.EqualTo("Customer is added in the database (10% Discount)"));
            String querry = "DELETE FROM Logintbl WHERE username = '"+x+"' AND password ='"+y+"' ";
            SqlDataAdapter sda = new SqlDataAdapter(querry, customerdb);
            DataTable dt = new DataTable();
            sda.Fill(dt);


        }

    }
}
