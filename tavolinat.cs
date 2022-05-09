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
    public partial class tavolinat : Form
    {
        public tavolinat()
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
        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = button1.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();

       
        }
        MySqlConnection conn = new MySqlConnection(connection.dbconnect());
        public static string passingtext;
        public static string passingtext1;
        private void tavolinat_Load(object sender, EventArgs e)
        {
            label2.Text = selekto.passo;
            try
            {
                label1.Text = DateTime.Now.ToString("dd-MM-yyyy");
                DataTable dt = new DataTable();
                MySqlDataAdapter display = new MySqlDataAdapter("SELECT *FROM INPUTDATAS Where data='"+label1.Text+"'", conn);
                conn.Open();
                display.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();


                //class
                buttonat bt = new buttonat();
                bt.btn1(button1, dataGridView1, label2);
                bt.btn1(button2, dataGridView1, label2);
                bt.btn1(button3, dataGridView1, label2);
                bt.btn1(button4, dataGridView1, label2);
                bt.btn1(button5, dataGridView1, label2);
                bt.btn1(button6, dataGridView1, label2);
                bt.btn1(button7, dataGridView1, label2);
                bt.btn1(button8, dataGridView1, label2);
                bt.btn1(button9, dataGridView1, label2);
                bt.btn1(button10, dataGridView1, label2);
                bt.btn1(button11, dataGridView1, label2);
                bt.btn1(button12, dataGridView1, label2);
                bt.btn1(button13, dataGridView1, label2);
                bt.btn1(button14, dataGridView1, label2);
                bt.btn1(button15, dataGridView1, label2);
                bt.btn1(button16, dataGridView1, label2);
                bt.btn1(button17, dataGridView1, label2);
                bt.btn1(button18, dataGridView1, label2);
                bt.btn1(button19, dataGridView1, label2);
                bt.btn1(button20, dataGridView1, label2);
                bt.btn1(button21, dataGridView1, label2);
                bt.btn1(button22, dataGridView1, label2);
                bt.btn1(button23, dataGridView1, label2);
                bt.btn1(button24, dataGridView1, label2);
                bt.btn1(button25, dataGridView1, label2);
                bt.btn1(button26, dataGridView1, label2);
                bt.btn1(button27, dataGridView1, label2);
                bt.btn1(button28, dataGridView1, label2);
                bt.btn1(button29, dataGridView1, label2);
                bt.btn1(button30, dataGridView1, label2);
                bt.btn1(button31, dataGridView1, label2);
                bt.btn1(button32, dataGridView1, label2);
                bt.btn1(button33, dataGridView1, label2);
                bt.btn1(button34, dataGridView1, label2);
                bt.btn1(button35, dataGridView1, label2);
                bt.btn1(button36, dataGridView1, label2);
                bt.btn1(button37, dataGridView1, label2);
                bt.btn1(button38, dataGridView1, label2);
                bt.btn1(button39, dataGridView1, label2);
                bt.btn1(button40, dataGridView1, label2);
                bt.btn1(button41, dataGridView1, label2);
                bt.btn1(button42, dataGridView1, label2);
                bt.btn1(button43, dataGridView1, label2);
                bt.btn1(button44, dataGridView1, label2);
                bt.btn1(button45, dataGridView1, label2);
                bt.btn1(button46, dataGridView1, label2);
                bt.btn1(button47, dataGridView1, label2);
                bt.btn1(button48, dataGridView1, label2);
                bt.btn1(button49, dataGridView1, label2);

            }
            catch (Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = button2.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form frm = new selekto();
            frm.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.Text = button3.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label3.Text = button4.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label3.Text = button5.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label3.Text = button6.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label3.Text = button7.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label3.Text = button8.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label3.Text = button9.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            label3.Text = button10.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            label3.Text = button25.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            label3.Text = button26.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            label3.Text = button27.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            label3.Text = button28.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            label3.Text = button29.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            label3.Text = button30.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            label3.Text = button31.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            label3.Text = button32.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            label3.Text = button33.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            label3.Text = button34.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            label3.Text = button35.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            label3.Text = button36.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            label3.Text = button37.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            label3.Text = button38.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            label3.Text = button39.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            label3.Text = button40.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            label3.Text = button41.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            label3.Text = button42.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            label3.Text = button43.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            label3.Text = button44.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            label3.Text = button45.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            label3.Text = button46.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button47_Click(object sender, EventArgs e)
        {
            label3.Text = button47.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            label3.Text = button48.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            label3.Text = button49.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label3.Text = button11.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {

            label3.Text = button12.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {

            label3.Text = button13.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {

            label3.Text = button14.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {

            label3.Text = button15.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {

            label3.Text = button16.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {

            label3.Text = button17.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button18_Click(object sender, EventArgs e)
        {

            label3.Text = button18.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button19_Click(object sender, EventArgs e)
        {

            label3.Text = button19.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button20_Click(object sender, EventArgs e)
        {

            label3.Text = button20.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button21_Click(object sender, EventArgs e)
        {

            label3.Text = button21.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button22_Click(object sender, EventArgs e)
        {

            label3.Text = button22.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button23_Click(object sender, EventArgs e)
        {

            label3.Text = button23.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button24_Click(object sender, EventArgs e)
        {

            label3.Text = button24.Text.ToString();
            passingtext = label2.Text;
            passingtext1 = label3.Text;
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }
    }
}
