using NUnit.Extensions.Forms;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace UnitTestProject1
{

    [TestFixture]
    internal class Class1
    {

        SqlConnection login = new SqlConnection(@"Data Source=HIRIK\SQL11;Initial Catalog=login;Integrated Security=True");

        private ButtonTester _buttonTester;
        private TextBoxTester _textBoxTester;
        private TextBoxTester _textBoxTester1;
        private LabelTester _labelTester;
        private LabelTester _labelTester1;

        login l;
        admin a;
        billing b;
        [SetUp]
        public void SetUp()
        {
            // Instantiate the Form to be tested and call its Show() method
            l = new login();
            
            // For each control that you will use in the test, create an instance of the appropriate ControlTester
            _buttonTester = new ButtonTester("logbut", l);
            _textBoxTester = new TextBoxTester("tuser", l);

            _textBoxTester1 = new TextBoxTester("tpass", l);
            a=new admin();
            _labelTester=  new LabelTester("label1", a);
            b=new billing();
            _labelTester1=  new LabelTester("label2", b);



        }
        [Test, Category("System")]
        public void loginincorrect()
        {
            String user = "x12";
            String Pass = "X12";


            String querry = "SELECT * FROM Logintbl WHERE username = '"+user+"' AND password ='"+Pass+"' ";
            SqlDataAdapter sda = new SqlDataAdapter(querry, login);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            bool condition;
            if (dt.Rows.Count > 0)
            {
                condition= true;
            }
            else
            {



                condition= false;
            }
            Assert.That(condition, Is.False);


        }

        [Test, Category("Integration")]
        public void logincustomer()
        {
            String user = "user";
            String Pass = "user2";
   
            l.Show();
            _textBoxTester.Enter(user);
            _textBoxTester1.Enter(Pass);
            _buttonTester.Click();


            Assert.That(_labelTester1.Text, Is.EqualTo("Pizza Point Of Sale"));


        }

        [Test, Category("Integration")]
        public void pageswitchadmin()
        {
            string x = "admin";
            string y = "admin";
            l.Show();
            _textBoxTester.Enter(x);
            _textBoxTester1.Enter(y);


            _buttonTester.Click();

           
            Assert.That(_labelTester.Text, Is.EqualTo("Administrator Controls"));

        }


    }
}
