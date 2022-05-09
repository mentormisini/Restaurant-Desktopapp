using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Stresta
{
    public partial class pazaret : Form
    {
        public pazaret()
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
        private void pazaret_Load(object sender, EventArgs e)
        {
            dataGridView.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dataGridView, true, null);
            MySqlDataAdapter cb = new MySqlDataAdapter("Select *from perdoruesit", conn);
            conn.Open();
            DataTable cm = new DataTable();
            cb.Fill(cm);
            DataRow row = cm.NewRow();
            comboBox1.DataSource = cm;
            comboBox1.DisplayMember = "userip";
            conn.Close();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form frm = new menu();
            frm.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT  Produkti,Cmimi,Sasia,Total,tavolina,data from inputdatas where tavolina='" + comboBox1.Text + "' and data='" + dateTimePicker1.Text + "'", conn);
                conn.Open();
                da.Fill(dt);
                dataGridView.DataSource = dt;
                conn.Close();

                decimal val = 0;
                foreach (DataGridViewRow item in dataGridView.Rows)
                {
                    if (item.Cells[4] != null && item.Cells[3].Value != null)
                        val += Convert.ToDecimal(item.Cells[3].Value);
                }
                label2.Text = val.ToString("#,0.00");

            }
            catch (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Alles löschen", "Bist du sicher !!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("DELETE FROM inputdatas  WHERE tavolina='" + comboBox1.Text+ "'", conn);

                    DataSet ds = new DataSet();
                    da.Fill(ds, "inputdatas");
                    dataGridView.DataSource = ds.Tables["inputdatas"];
                    MessageBox.Show("Das Löschen war erfolgreich");
                    conn.Close();
                    Form frm = new pazaret();
                    frm.Show();
                    this.Close();
             



                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message.ToString());
            }
        }

        private void pazaret_FormClosing(object sender, FormClosingEventArgs e)
        {
       
        }
    }
}
