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
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Reporting.WinForms;
using System.Reflection;


// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace Stresta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(1250, 650);
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

        public void incrase()
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT IFNULL(MAX(uid),0) FROM inputdatas", conn))
            {
                conn.Open();
                double result = (Convert.ToDouble(cmd.ExecuteScalar()) + 1);
                textBox1.Text = result.ToString();
                conn.Close();

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dataGridView, true, null);
            label4.Text = tavolinat.passingtext;
            label3.Text = tavolinat.passingtext1;
            label5.Text = DateTime.Now.ToString("dd-MM-yyyy");
            try
            {


                mezep.Visible = false;
                donerp.Visible = false;
                pidep.Visible = false;
                grillp.Visible = false;
                kiremitp.Visible = false;
                desertp.Visible = false;
                gentarkep.Visible = false;
             
                DataTable dt = new DataTable();
                MySqlDataAdapter search = new MySqlDataAdapter("SELECT * FROM inputdatas where tavolina='"+label4.Text+"' and tabela='"+label3.Text+"' and data='"+label5.Text+"'", conn);
                conn.Open();
                search.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

                display.PerformClick();
               button1.PerformClick();
                if (dataGridView.Rows.Count >0 )
                {

                   textBox1.Text= dataGridView.Rows[0].Cells["uid"].Value.ToString();
                }
                else
                {
                    incrase();
                }

            }
                catch (Exception) { }



        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            row0 row = new row0();
            row.rowg0(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = dataGridView.CurrentCell.RowIndex;
                dataGridView.Rows.RemoveAt(rowindex);
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

        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int row = 0;
            row = dataGridView.Rows.Count - 1;
            dataGridView["Tavolina", row].Value = label4.Text;
            dataGridView["uid", row].Value = textBox1.Text;
            dataGridView["data", row].Value = dateTimePicker1.Text;
            dataGridView["lloji", row].Value = textBox2.Text;
            dataGridView["tabela", row].Value = label3.Text;
            dataGridView.FirstDisplayedScrollingRowIndex = dataGridView.RowCount - 1;
            dataGridView.Refresh();
            if (dataGridView.Rows.Count > 0)
            {

                //Check if the product Id exists with the same Price
                foreach (DataGridViewRow row1 in dataGridView.Rows)
                {

                    if (Convert.ToString(row1.Cells[7].Value) =="pije")
                    {
                        textBox4.Text = "pije1";
                    }
                    if (Convert.ToString(row1.Cells[7].Value) == "ushqim")
                    {
                        textBox6.Text = "ushqim1";
                    }


                }

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            mezep.Visible = false;
            donerp.Visible = false;
            corbap.Visible = true;
            pidep.Visible = false;
            grillp.Visible = false;
            kiremitp.Visible = false;
            desertp.Visible = false;
            gentarkep.Visible = false;
            searchi kerko = new searchi();
                kerko.srch(button1, dataGridView1);

            button1.BackColor = Color.MediumSeaGreen;
            button4.BackColor = Color.Gainsboro;
            button5.BackColor = Color.Gainsboro;
            button31.BackColor = Color.Gainsboro;
            button48.BackColor = Color.Gainsboro;
            button55.BackColor = Color.Gainsboro;
            button52.BackColor = Color.Gainsboro;
            button57.BackColor = Color.Gainsboro;
         
        }

        private void button7_Click(object sender, EventArgs e)
        {
            row1 row01 = new row1();
            row01.rowg1(dataGridView1, textBox5, textBox3,textBox2, dataGridView, label2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mezep.Visible = true;
            donerp.Visible = false;
            corbap.Visible = false;
            pidep.Visible = false;
            grillp.Visible = false;
            kiremitp.Visible = false;
            desertp.Visible = false;
            gentarkep.Visible = false;

            button1.BackColor = Color.Gainsboro;
            button4.BackColor = Color.MediumSeaGreen;
            button5.BackColor = Color.Gainsboro;
            button31.BackColor = Color.Gainsboro;
            button48.BackColor = Color.Gainsboro;
            button55.BackColor = Color.Gainsboro;
            button52.BackColor = Color.Gainsboro;
            button57.BackColor = Color.Gainsboro;
            searchi kerko = new searchi();
            kerko.srch(button4, dataGridView1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            row0 row00 = new row0();
            row00.rowg0(dataGridView1, textBox5, textBox3,textBox2, dataGridView, label2);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            row1 row01 = new row1();
            row01.rowg1(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            row2 row02 = new row2();
            row02.rowg2(dataGridView1, textBox5, textBox3,textBox2, dataGridView, label2);


        }

        private void button11_Click(object sender, EventArgs e)
        {
            row3 row03 = new row3();
            row03.rowg3(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2); ;

        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mezep.Visible = false;
            donerp.Visible = true;
            corbap.Visible = false;
            pidep.Visible = false;
            grillp.Visible = false;
            kiremitp.Visible = false;
            desertp.Visible = false;
            gentarkep.Visible = false;

            button1.BackColor = Color.Gainsboro;
            button4.BackColor = Color.Gainsboro;
            button5.BackColor = Color.MediumSeaGreen;
            button31.BackColor = Color.Gainsboro;
            button48.BackColor = Color.Gainsboro;
            button55.BackColor = Color.Gainsboro;
            button52.BackColor = Color.Gainsboro;
            button57.BackColor = Color.Gainsboro;
            searchi kerko = new searchi();
            kerko.srch(button5, dataGridView1);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            row0 row00 = new row0();
            row00.rowg0(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);

        }

        private void button13_Click(object sender, EventArgs e)
        {
            row1 row01 = new row1();
            row01.rowg1(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            row2 row02 = new row2();
            row02.rowg2(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            row3 row03 = new row3();
            row03.rowg3(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            row4 row04 = new row4();
            row04.rowg4(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            row5 row05 = new row5();
            row05.rowg5(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            mezep.Visible = false;
            donerp.Visible = false;
            corbap.Visible = false;
            pidep.Visible = true;
            grillp.Visible = false;
            kiremitp.Visible = false;
            desertp.Visible = false;
            gentarkep.Visible = false;

            button1.BackColor = Color.Gainsboro;
            button4.BackColor = Color.Gainsboro;
            button5.BackColor = Color.Gainsboro;
            button31.BackColor = Color.MediumSeaGreen;
            button48.BackColor = Color.Gainsboro;
            button55.BackColor = Color.Gainsboro;
            button52.BackColor = Color.Gainsboro;
            button57.BackColor = Color.Gainsboro;
            searchi kerko = new searchi();
            kerko.srch(button31, dataGridView1);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            row0 row00 = new row0();
            row00.rowg0(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);

        }

        private void button19_Click(object sender, EventArgs e)
        {
            row1 row01 = new row1();
            row01.rowg1(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            row2 row02 = new row2();
            row02.rowg2(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            row3 row03 = new row3();
            row03.rowg3(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);

        }

        private void button22_Click(object sender, EventArgs e)
        {
            row4 row04 = new row4();
            row04.rowg4(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            row5 row05 = new row5();
            row05.rowg5(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            row6 row06 = new row6();
            row06.rowg6(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button25_Click(object sender, EventArgs e)
        {

            row7 row07 = new row7();
            row07.rowg7(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            row8 row08 = new row8();
            row08.rowg8(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button27_Click(object sender, EventArgs e)
        {

            row9 row09 = new row9();
            row09.rowg9(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button28_Click(object sender, EventArgs e)
        {

            row10 row10 = new row10();
            row10.rowg10(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            row11 row11 = new row11();
            row11.rowg11(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            row12 row12 = new row12();
            row12.rowg12(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            row13 row13 = new row13();
            row13.rowg13(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            row14 row14 = new row14();
            row14.rowg14(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            row15 row15 = new row15();
            row15.rowg15(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            row16 row16 = new row16();
            row16.rowg16(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            row17 row17 = new row17();
            row17.rowg17(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button48_Click(object sender, EventArgs e)
        {
            mezep.Visible = false;
            donerp.Visible = false;
            corbap.Visible = false;
            pidep.Visible = false;
            grillp.Visible = true;
            kiremitp.Visible = false;
            desertp.Visible = false;

            button1.BackColor = Color.Gainsboro;
            button4.BackColor = Color.Gainsboro;
            button5.BackColor = Color.Gainsboro;
            button31.BackColor = Color.Gainsboro;
            button48.BackColor = Color.MediumSeaGreen;
            button55.BackColor = Color.Gainsboro;
            button52.BackColor = Color.Gainsboro;
            button57.BackColor = Color.Gainsboro;
            gentarkep.Visible = false; searchi kerko = new searchi();
            kerko.srch(button48, dataGridView1);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            row0 row00 = new row0();
            row00.rowg0(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button38_Click(object sender, EventArgs e)
        {

            row1 row01 = new row1();
            row01.rowg1(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button39_Click(object sender, EventArgs e)
        {
            row2 row02 = new row2();
            row02.rowg2(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);

        }

        private void button40_Click(object sender, EventArgs e)
        {
            row3 row03 = new row3();
            row03.rowg3(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button41_Click(object sender, EventArgs e)
        {
            row4 row04 = new row4();
            row04.rowg4(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button42_Click(object sender, EventArgs e)
        {
            row5 row05 = new row5();
            row05.rowg5(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button43_Click(object sender, EventArgs e)
        {

            row6 row06 = new row6();
            row06.rowg6(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button44_Click(object sender, EventArgs e)
        {
            row7 row07 = new row7();
            row07.rowg7(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button45_Click(object sender, EventArgs e)
        {

            row8 row08 = new row8();
            row08.rowg8(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button46_Click(object sender, EventArgs e)
        {
            row9 row09 = new row9();
            row09.rowg9(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button47_Click(object sender, EventArgs e)
        {
            row10 row10 = new row10();
            row10.rowg10(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }
        public static string passingtext;
        private void button6_Click(object sender, EventArgs e)
        {
          
            try
            {

                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("DELETE FROM inputdatas  WHERE uid='" + textBox1.Text + "'", conn);

                DataSet ds = new DataSet();
                da.Fill(ds, "inputdatas");
                dataGridView.DataSource = ds.Tables["inputdatas"];
                conn.Close();

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    MySqlCommand cmd = new MySqlCommand(@"INSERT into inputdatas(Produkti,Sasia,Cmimi,Total,Tavolina,uid,data,lloji,tabela)VALUES('" + dataGridView.Rows[i].Cells[0].Value + "','" + dataGridView.Rows[i].Cells[1].Value + "','" + dataGridView.Rows[i].Cells[2].Value + "','" + dataGridView.Rows[i].Cells[3].Value + "','" + dataGridView.Rows[i].Cells[4].Value + "','" + dataGridView.Rows[i].Cells[5].Value + "','" + dataGridView.Rows[i].Cells[6].Value + "','" + dataGridView.Rows[i].Cells[7].Value + "','" + dataGridView.Rows[i].Cells[8].Value + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
               
                button6.Enabled = false;
                button6.Text = "Sein Druck...";
                bool Found = false;
                if (textBox4.Text == "pije1" && textBox6.Text == "ushqim1")
                {
                    this.inputdatasTableAdapter.Fill(this.printdata.inputdatas);
                    try
                    {
                        this.inputdatasTableAdapter.FillBy(this.printdata.inputdatas, new System.Nullable<long>(((long)(System.Convert.ChangeType(textBox1.Text, typeof(long))))));
                    }
                    catch (System.Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                    this.reportViewer1.RefreshReport();
                    this.reportViewer1.LocalReport.PrintToPrinter();
                    //pijeprint
                    try
                    {
                        this.inputdatasTableAdapter1.FillBy(this.perpi.inputdatas, new System.Nullable<long>(((long)(System.Convert.ChangeType(textBox1.Text, typeof(long))))));
                    }
                    catch (System.Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                    this.reportViewer1.RefreshReport();
                    this.reportViewer1.LocalReport.PrintToPrinter1();

                   







                }
                else
                {
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (Convert.ToString(row.Cells[7].Value) == "pije")
                        {
                            //fatura pijeve
                            ///
                            try
                            {
                                this.inputdatasTableAdapter1.FillBy(this.perpi.inputdatas, new System.Nullable<long>(((long)(System.Convert.ChangeType(textBox1.Text, typeof(long))))));
                            }
                            catch (System.Exception ex)
                            {
                                System.Windows.Forms.MessageBox.Show(ex.Message);
                            }
                            //this.reportViewer2.RefreshReport();
                            //int milliseconds = 1000;
                            //Thread.Sleep(milliseconds);
                            //SendKeys.Send("{ENTER}");
                            this.reportViewer1.RefreshReport();
                            this.reportViewer1.LocalReport.PrintToPrinter1();
                            Found = true;
                            break;
                        }
                        else
                        {
                            ///fatura e ushqimit
                            ///
                            this.inputdatasTableAdapter.Fill(this.printdata.inputdatas);
                            try
                            {
                                this.inputdatasTableAdapter.FillBy(this.printdata.inputdatas, new System.Nullable<long>(((long)(System.Convert.ChangeType(textBox1.Text, typeof(long))))));
                            }
                            catch (System.Exception ex)
                            {
                                System.Windows.Forms.MessageBox.Show(ex.Message);
                            }
                            this.reportViewer1.RefreshReport();
                            this.reportViewer1.LocalReport.PrintToPrinter();
                            Found = true;
                            break;

                        }


                    }
                }
                if (!Found)
                {
                   
                }


            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    
        private void button49_Click(object sender, EventArgs e)
        {
            row0 row00 = new row0();
            row00.rowg0(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button50_Click(object sender, EventArgs e)
        {
            row1 row01 = new row1();
            row01.rowg1(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button51_Click(object sender, EventArgs e)
        {
            row2 row02 = new row2();
            row02.rowg2(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button55_Click(object sender, EventArgs e)
        {
            mezep.Visible = false;
            donerp.Visible = false;
            corbap.Visible = false;
            pidep.Visible = false;
            grillp.Visible = false;
            kiremitp.Visible = true;
            desertp.Visible = false;

            button1.BackColor = Color.Gainsboro;
            button4.BackColor = Color.Gainsboro;
            button5.BackColor = Color.Gainsboro;
            button31.BackColor = Color.Gainsboro;
            button48.BackColor = Color.Gainsboro;
            button55.BackColor = Color.MediumSeaGreen;
            button52.BackColor = Color.Gainsboro;
            button57.BackColor = Color.Gainsboro;
            gentarkep.Visible = false; searchi kerko = new searchi();
            kerko.srch(button55, dataGridView1);
        }

        private void button53_Click(object sender, EventArgs e)
        {
            row0 row00 = new row0();
            row00.rowg0(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);

        }

        private void button54_Click(object sender, EventArgs e)
        {
            row1 row01 = new row1();
            row01.rowg1(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button56_Click(object sender, EventArgs e)
        {

            row2 row02 = new row2();
            row02.rowg2(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button52_Click(object sender, EventArgs e)
        {
            mezep.Visible = false;
            donerp.Visible = false;
            corbap.Visible = false;
            pidep.Visible = false;
            grillp.Visible = false;
            kiremitp.Visible = false;
            desertp.Visible = true;

            button1.BackColor = Color.Gainsboro;
            button4.BackColor = Color.Gainsboro;
            button5.BackColor = Color.Gainsboro;
            button31.BackColor = Color.Gainsboro;
            button48.BackColor = Color.Gainsboro;
            button55.BackColor = Color.Gainsboro;
            button52.BackColor = Color.MediumSeaGreen;
            button57.BackColor = Color.Gainsboro;
            gentarkep.Visible = false; searchi kerko = new searchi();
            kerko.srch(button52, dataGridView1);
        }

        private void button58_Click(object sender, EventArgs e)
        {
            row0 row00 = new row0();
            row00.rowg0(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);

        }

        private void button59_Click(object sender, EventArgs e)
        {
            row1 row01 = new row1();
            row01.rowg1(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button60_Click(object sender, EventArgs e)
        {
            row2 row02 = new row2();
            row02.rowg2(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button61_Click(object sender, EventArgs e)
        {
            row3 row03 = new row3();
            row03.rowg3(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button62_Click(object sender, EventArgs e)
        {
            row4 row04 = new row4();
            row04.rowg4(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button63_Click(object sender, EventArgs e)
        {
            row6 row06 = new row6();
            row06.rowg6(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button64_Click(object sender, EventArgs e)
        {

            row7 row07 = new row7();
            row07.rowg7(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button65_Click(object sender, EventArgs e)
        {
            row7 row07 = new row7();
            row07.rowg7(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button66_Click(object sender, EventArgs e)
        {

            row11 row11 = new row11();
            row11.rowg11(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button67_Click(object sender, EventArgs e)
        {
            row12 row12 = new row12();
            row12.rowg12(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button68_Click(object sender, EventArgs e)
        {
            row13 row13 = new row13();
            row13.rowg13(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button72_Click(object sender, EventArgs e)
        {
            row5 row05 = new row5();
            row05.rowg5(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button73_Click(object sender, EventArgs e)
        {
            row8 row08 = new row8();
            row08.rowg8(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button74_Click(object sender, EventArgs e)
        {
            row9 row09 = new row9();
            row09.rowg9(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button71_Click(object sender, EventArgs e)
        {
            row10 row10 = new row10();
            row10.rowg10(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);

        }

        private void button69_Click(object sender, EventArgs e)
        {

            row14 row14 = new row14();
            row14.rowg14(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button70_Click(object sender, EventArgs e)
        {
            row15 row15 = new row15();
            row15.rowg15(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button65_Click_1(object sender, EventArgs e)
        {
            row16 row16 = new row16();
            row16.rowg16(dataGridView1, textBox5, textBox3, textBox2, dataGridView, label2);
        }

        private void button57_Click(object sender, EventArgs e)
        {
            mezep.Visible = false;
            donerp.Visible = false;
            corbap.Visible = false;
            pidep.Visible = false;
            grillp.Visible = false;
            kiremitp.Visible = false;
            desertp.Visible = false;
            gentarkep.Visible = true;

            button1.BackColor = Color.Gainsboro;
            button4.BackColor = Color.Gainsboro;
            button5.BackColor = Color.Gainsboro;
            button31.BackColor = Color.Gainsboro;
            button48.BackColor = Color.Gainsboro;
            button55.BackColor = Color.Gainsboro;
            button52.BackColor = Color.Gainsboro;
            button57.BackColor = Color.MediumSeaGreen;
            searchi kerko = new searchi();
            kerko.srch(button57, dataGridView1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Sind Sie sicher, dass Sie den Tisch aufräumen möchten? ", "Aufmerksamkeit!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("UPDATE inputdatas SET tabela='" +""+ "' Where uid='" + textBox1.Text+ "'", conn);
                    DataSet dg = new DataSet();
                    da.Fill(dg, "inputdatas");
                    dataGridView.DataSource = dg.Tables["inputdatas"];
           
                    Form frm = new tavolinat();
                    frm.Show();
                    this.Hide();
                    conn.Close();
                }
                else
                {

                }
            }
            catch (Exception)
            {

            }



        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
           

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i <= dataGridView.Rows.Count; i++)
                {
                    dataGridView.Rows[i].Cells[4].Value = label3.Text;
                }
            }
            catch (Exception) { }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form frm = new tavolinat();
            frm.Show();
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i <= dataGridView.Rows.Count; i++)
                {
                    dataGridView.Rows[i].Cells[8].Value = label4.Text;
                }
            }
            catch (Exception) { }
        }

        private void fillByToolStripButton_Click_1(object sender, EventArgs e)
        {
           

        }

        private void button75_Click(object sender, EventArgs e)
        {
        }

        private void button76_Click(object sender, EventArgs e)
        {
            

       
            
        }

        private void fillByToolStripButton_Click_2(object sender, EventArgs e)
        {
          

        }

        private void button75_Click_1(object sender, EventArgs e)
        {

           
        }

        private void reportViewer2_Print(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
        {
           



        }

        private void reportViewer2_PrintingBegin(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
        {
           
        }

        private void reportViewer2_Load(object sender, EventArgs e)
        {
            
        }

        private void reportViewer2_Enter(object sender, EventArgs e)
        {
            
        }

        private void reportViewer2_PageNavigation(object sender, Microsoft.Reporting.WinForms.PageNavigationEventArgs e)
        {
           
        }

        private void reportViewer2_ReportRefresh(object sender, CancelEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void display_Click(object sender, EventArgs e)
        {
            try
            {


                int n = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (dataGridView1.Rows.Count != n + 1)
                    {
                        dataGridView.Rows.Add();
                        dataGridView.Rows[n].Cells[0].Value = row.Cells[2].Value.ToString();//prod
                        dataGridView.Rows[n].Cells[1].Value = row.Cells[3].Value.ToString();//sasia
                        dataGridView.Rows[n].Cells[2].Value = row.Cells[4].Value.ToString();//cmimi/
                        dataGridView.Rows[n].Cells[3].Value = row.Cells[5].Value.ToString();//total
                        dataGridView.Rows[n].Cells[4].Value = row.Cells[6].Value.ToString();//kamarjeri tav
                        dataGridView.Rows[n].Cells[5].Value = row.Cells[1].Value.ToString();//uid
                        dataGridView.Rows[n].Cells[6].Value = row.Cells[7].Value.ToString();//data
                        dataGridView.Rows[n].Cells[7].Value = row.Cells[8].Value.ToString();//lloji
                        dataGridView.Rows[n].Cells[8].Value = row.Cells[9].Value.ToString();//tavolina
                        
                    }
                    n += 1;


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
