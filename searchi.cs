using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Stresta
{
    class searchi
    {
        public void srch(Button b1, DataGridView d1)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connection.dbconnect());
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter("Select *from produktet where kategoria='"+b1.Text+"'", conn);
                conn.Open(); da.Fill(dt); d1.DataSource = dt; conn.Close();

            }
            catch (Exception) { }
        }
    }
}
