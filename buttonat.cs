using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stresta
{
    class buttonat
    {
        public void btn1 (Button b1, DataGridView dataGridView1, Label label2 ){
       
            if (b1.Text == b1.Text.ToString())
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if ((String)dataGridView1.Rows[i].Cells[6].Value == label2.Text && (String)dataGridView1.Rows[i].Cells[9].Value == b1.Text.ToString())
                    {
                        b1.BackColor = Color.FromArgb(164, 128, 20);
                        b1.ForeColor = Color.Black;


                    }


                    if ((String)dataGridView1.Rows[i].Cells[6].Value != label2.Text && (String)dataGridView1.Rows[i].Cells[9].Value == b1.Text.ToString())
                    {

                        b1.BackColor = Color.Maroon;
                        b1.Enabled = false;
                    }

                }
            }
        }


        

    }
}
