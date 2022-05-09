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
    public partial class qmimet : Form
    {
        public qmimet()
        {
            InitializeComponent();
            this.Size = new Size(850, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        //fast
        protected override CreateParams CreateParams
        {

            get
            {
                CreateParams handleparm = base.CreateParams;
                handleparm.ExStyle |= 0x02000000;
                return handleparm;

            }
        }
        Bitmap BackBmp;
        Bitmap BackImg;
        Graphics memoryGraphics;

        private void InitAppearance()
        {
            //Added performance improvements by caching the image.  Only decodes once here at startup

            BackImg = Properties.Resources.Background;
            BackBmp = new Bitmap(BackImg.Width, BackImg.Height);
            memoryGraphics = Graphics.FromImage(BackBmp);

            memoryGraphics.DrawImage(BackImg, 0, 0, BackImg.Width, BackImg.Height);

            // Slow
            //BackgroundImage = Resources.Background;


            // Fast
            BackgroundImage = BackBmp;
        }

        //fast
        MySqlConnection conn = new MySqlConnection(connection.dbconnect());
        private void qmimet_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT *from produktet ", conn);
                conn.Open();
                da.Fill(dt);
                dataGridView.DataSource = dt;
                conn.Close();

            }
            catch (Exception) { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT *from produktet where kategoria='"+comboBox1.Text+"'", conn);
                conn.Open();
                da.Fill(dt);
                dataGridView.DataSource = dt;
                conn.Close();

            }
            catch (Exception) { }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                MySqlDataAdapter SDA = new MySqlDataAdapter("SELECT * FROM produktet  where Produkti LIKE'" + textBox1.Text + "%'", conn);
                conn.Open(); SDA.Fill(dt); dataGridView.DataSource = dt; conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView.Rows[e.RowIndex];
                textBox4.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                comboBox1.Text = row.Cells[3].Value.ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //list of client
                MySqlCommand cmdi = new MySqlCommand("Update produktet set Cmimi=@Cmimi where id=@id", conn);
                cmdi.Parameters.AddWithValue("@id", textBox4.Text);
                cmdi.Parameters.AddWithValue("@Cmimi", textBox3.Text);
                conn.Open();
                cmdi.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Success");

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT *from produktet where kategoria='"+comboBox1.Text+"' ", conn);
                conn.Open();
                da.Fill(dt);
                dataGridView.DataSource = dt;
                conn.Close();
            }
            catch (Exception)
            {

            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form frm = new menu();
            frm.Show();
            this.Close();
        }

        private void qmimet_FormClosing(object sender, FormClosingEventArgs e)
        {
      
        }
    }
}
