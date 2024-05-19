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
    internal class Form1Test
    {

        SqlConnection login = new SqlConnection(@"Data Source=HIRIK\SQL11;Initial Catalog=login;Integrated Security=True");


        private ButtonTester _buttonTester;
        private TextBoxTester _textBoxTester;
        private TextBoxTester _textBoxTester1;
        private LabelTester _labelTester;
        private LabelTester _labelTester1;

        Form1 f;
       [SetUp]
        public void SetUp()
        {

            f = new Form1();
            _textBoxTester=new TextBoxTester("textBox1", f);

             _textBoxTester1=new TextBoxTester("textBox2", f);
            _buttonTester =new ButtonTester("button1",f);
            _labelTester=new LabelTester("label2",f);
                
        }

       

        [Test, Category("Unit")]
        public void Nulluser()
        {
            f.Show();
            _textBoxTester.Enter("");
            _textBoxTester1.Enter("");

            _buttonTester.Click();
            Assert.That(_labelTester.Text, Is.EqualTo(" please enter credentials"));
            f.Hide();


        }
        [TestCase("NewUser1","NewPass1")]
        public void NewUser(string x, string y)
        {


            String querry = "DELETE FROM Logintbl WHERE username = '"+x+"' AND password ='"+y+"' ";
            SqlDataAdapter sda = new SqlDataAdapter(querry, login);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            f.Show();
            _textBoxTester.Enter(x);
            _textBoxTester1.Enter(y);

            _buttonTester.Click();
            
            Assert.That(_labelTester.Text, Is.EqualTo("New User added "));
            
            f.Hide();


        }
        [TestCase("admin", "NewPass2"), Category("Unit")]
        public void Duplicateuser(string x, string y)
        {


            String querry = "DELETE FROM Logintbl WHERE username = '"+x+"' AND password ='"+y+"' ";
            SqlDataAdapter sda = new SqlDataAdapter(querry, login);
            DataTable dt = new DataTable();
            sda.Fill(dt);


            f.Show();
            _textBoxTester.Enter(x);
            _textBoxTester1.Enter(y);

            _buttonTester.Click();

            Assert.That(_labelTester.Text, Is.EqualTo("New User added "));

            f.Hide();


        }

        [TestCase("admin", "admin"), Category("Unit")]
        public void ExistingUser(string x, string y)
        {

            f.Show();
            _textBoxTester.Enter(x);
            _textBoxTester1.Enter(y);

            _buttonTester.Click();

            Assert.That(_labelTester.Text, Is.EqualTo("User already exist"));
            f.Hide();


        }




    }
}
