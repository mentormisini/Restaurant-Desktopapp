using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stresta
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
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
        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new qmimet();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm = new pazaret();
            frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form frm = new add();
            frm.Show();
        }

        private void menu_Leave(object sender, EventArgs e)
        {
           
        }

        private void menu_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form frm = new selekto();
            frm.Show();
            this.Hide();
        }
    }
}
