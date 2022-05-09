using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stresta
{
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new tavolinat();
            frm.Show();
            this.Hide();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == "passresto")
                {
                    Form frm = new menu();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    textBox1.Clear();
                }
            }
        }

        private void user_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void user_Load(object sender, EventArgs e)
        {

        }
    }
}
