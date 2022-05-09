using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Stresta
{
    public partial class selekto : Form
    {
        public selekto()
        {
            InitializeComponent();
            this.Size = new Size(1000, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public static string passo;
        private void button1_Click(object sender, EventArgs e)
        {
            passo = button1.Text;
            Form frm = new tavolinat();
            frm.Show();
            this.Hide();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            passo = button2.Text;
            Form frm = new tavolinat();
            frm.Show();
            this.Hide();
        }
        MySqlConnection conn = new MySqlConnection(connection.dbconnect());
        private void selekto_Load(object sender, EventArgs e)
        {
      
            try
            {

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT userip FROM perdoruesit", conn);
                conn.Open();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    button1.Text = dt.Rows[0].ItemArray[0].ToString();
                    button2.Text = dt.Rows[1].ItemArray[0].ToString();
                    button3.Text = dt.Rows[2].ItemArray[0].ToString();
                    button4.Text = dt.Rows[3].ItemArray[0].ToString();
                    button5.Text = dt.Rows[4].ItemArray[0].ToString();
                    button6.Text = dt.Rows[5].ItemArray[0].ToString();
                    button7.Text = dt.Rows[6].ItemArray[0].ToString();
                    button8.Text = dt.Rows[7].ItemArray[0].ToString();
                    button9.Text = dt.Rows[8].ItemArray[0].ToString();
                    button10.Text = dt.Rows[9].ItemArray[0].ToString();
                }
                conn.Close();

               
               
            }
            
            catch (Exception  ex ) { MessageBox.Show(ex.ToString()); }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form frm = new user();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            passo = button3.Text;
            Form frm = new tavolinat();
            frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            passo = button4.Text;
            Form frm = new tavolinat();
            frm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            passo = button5.Text;
            Form frm = new tavolinat();
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            passo = button6.Text;
            Form frm = new tavolinat();
            frm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            passo = button7.Text;
            Form frm = new tavolinat();
            frm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            passo = button8.Text;
            Form frm = new tavolinat();
            frm.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            passo = button9.Text;
            Form frm = new tavolinat();
            frm.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            passo = button10.Text;
            Form frm = new tavolinat();
            frm.Show();
            this.Hide();
        }
    }
}
