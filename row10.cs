using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stresta
{
    class row10
    {
        public void rowg10(DataGridView dataGridView1, TextBox textBox5, TextBox textBox3, TextBox textBox2, DataGridView dataGridView, Label label2)
        {
            try
            {


                textBox3.Text = dataGridView1.Rows[10].Cells[1].Value.ToString();
                textBox5.Text = dataGridView1.Rows[10].Cells[2].Value.ToString();
                textBox2.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();


                bool Found = false;
                if (dataGridView.Rows.Count > 0)
                {

                    //Check if the product Id exists with the same Price
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {

                        if (Convert.ToString(row.Cells[2].Value) == textBox5.Text && Convert.ToString(row.Cells[0].Value) == textBox3.Text)
                        {
                            //Update the Quantity of the found row
                            row.Cells[1].Value = Convert.ToString(1 + Convert.ToInt16(row.Cells[1].Value));

                            Found = true;

                        }

                    }
                    if (!Found)
                    {
                        //Add the row to grid view

                        dataGridView.Rows.Add(textBox3.Text, 1, textBox5.Text);

                    }

                }
                else
                {
                    //Add the row to grid view for the first time


                    dataGridView.Rows.Add(textBox3.Text, 1, textBox5.Text);


                }

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    row.Cells[dataGridView.Columns["total"].Index].Value = (Convert.ToDouble(row.Cells[dataGridView.Columns["sasia"].Index].Value) * Convert.ToDouble(row.Cells[dataGridView.Columns["cmimi"].Index].Value));
                }



                decimal val = 0;
                foreach (DataGridViewRow item in dataGridView.Rows)
                {
                    if (item.Cells[3] != null && item.Cells[3].Value != null)
                        val += Convert.ToDecimal(item.Cells[3].Value);
                }

                label2.Text = val.ToString("#,0.00");

            }
            catch (Exception)
            {

            }
        }
    }
}
