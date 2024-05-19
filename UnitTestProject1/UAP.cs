using NUnit.Extensions.Forms;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace UnitTestProject1
{


    [TestFixture]
    internal class UAP
    {

        private ButtonTester _buttonTester;
        private ButtonTester bt1;

        private TextBoxTester _textBoxTester;
        private TextBoxTester _textBoxTester1;
        private LabelTester _labelTester;
        private LabelTester _labelTester1;
        private LabelTester lb1;

        private ComboBoxTester comboBoxTester;
        private ButtonTester bt2;
        private ButtonTester bt3;
        private TextBoxTester tx1;

        private LabelTester l1;
        private LabelTester l2;
        private LabelTester l3;

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


        private ButtonTester bt4;

        private ButtonTester bt5;

        private ButtonTester bt6;

        private ButtonTester bt7;
        private LabelTester l11;
        private LabelTester l12;
        private LabelTester l13;


        login l;
        admin a;
        billing B;
        setting s;

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
            bt1=new ButtonTester("button1",a);
            bt3=new ButtonTester("button2", a);
            s=new setting();
            lb1=new LabelTester("label5", s);

            bt2 =new ButtonTester("button1", s);
            tx1=new TextBoxTester("textBox2", s);
            comboBoxTester=new ComboBoxTester("comboBox2", s);
            l1=new LabelTester("label9", s);
            l2=new LabelTester("label8", s);
            l3=new LabelTester("label1", a);

            B=new billing();
            bt4= new ButtonTester("button1", B);
            bt5= new ButtonTester("button2", B);
            bt6= new ButtonTester("button3", B);
            bt7= new ButtonTester("button4", B);

            t1= new TextBoxTester("qtytb", B);
            t2=new TextBoxTester("textBox1", B);
            t3=new TextBoxTester("textBox2", B);

            r1=new RadioButtonTester("smallbtn", B);
            r2=new RadioButtonTester("mediumbtn", B);
            r3=new RadioButtonTester("largebtn", B);
            r4=new RadioButtonTester("extralargebtn", B);

            c1=new CheckBoxTester("checkBox1", B);
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

            l11=new LabelTester("label8", B);
            l12=new LabelTester("Grdtotal", B);
            l13=new LabelTester("label1", l);
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
             a.Show();
            bt1.Click();
            Assert.That(lb1.Text, Is.EqualTo("Set The New Price"));
            s.Show();

            comboBoxTester.Select(1);
            tx1.Enter("13");

            bt2.Click();
            Assert.That(l1.Text, Is.EqualTo("Price update!!"));
            l2.Click();
            a.Show();
            bt3.Click();
            B.Show();
            t2.Enter("hirik");
            t3.Enter("8814168");
            bt5.Click();
            Assert.That(l11.Text, Is.EqualTo("Customer is already exist in the databse (20% Discount)"));
            c1.Check();
            t1.Enter("1");
            c11.Check();
            bt4.Click();
            Assert.That(l12.Text, Is.EqualTo("$  12"));


        }



    }
}
