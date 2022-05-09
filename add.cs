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
    public partial class add : Form
    {
        public add()
        {
            InitializeComponent();
        }

        MySqlConnection conn = new MySqlConnection(connection.dbconnect());
        public void load()
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM perdoruesit", conn);
            conn.Open();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void add_Load(object sender, EventArgs e)
        {
            load();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
               
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                label1.Text = row.Cells[0].Value.ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO perdoruesit (userip)VALUES(@userip)", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@userip", textBox1.Text);
                cmd.ExecuteNonQuery(); 
                conn.Close();
                MessageBox.Show("Erfolgreich eingefügt");
                load();
            }
            catch (Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Alles löschen", "Bist du sicher !!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    MySqlCommand del = new MySqlCommand("DELETE FROM perdoruesit where id='" + label1.Text + "'", conn);
                    conn.Open();
                    del.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Erfolgreich gelöscht");
                    load();

                }
                catch (Exception) { }
            }
            else
            {
                //do something else;
            }
        }

        private void add_FormClosing(object sender, FormClosingEventArgs e)
        {
    
        }
    }
}
