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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setting setting = new setting();   
            setting.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            billing b = new billing();
            b.Show();
            this.Hide();    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();   
            form.Show();
            this.Hide();    
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
