using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stresta.PRINT
{
    public partial class printushqim : Form
    {
        public printushqim()
        {
            InitializeComponent();
        }

        private void printushqim_Load(object sender, EventArgs e)
        {
         
            // TODO: This line of code loads data into the 'printdata.inputdatas' table. You can move, or remove it, as needed.
            this.inputdatasTableAdapter.Fill(this.printdata.inputdatas);
            label1.Text = Form1.passingtext;

            try
            {
                this.inputdatasTableAdapter.FillBy1(this.printdata.inputdatas, new System.Nullable<long>(((long)(System.Convert.ChangeType(label1.Text, typeof(long))))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            this.reportViewer1.RefreshReport();
            //reportViewer1.LocalReport.Print();
            button1.PerformClick();
            button1.PerformClick();



        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
           

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
          

        }

        private void printushqim_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SendKeys.Send("{TAB}");
            SendKeys.Send("{ENTER}");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
