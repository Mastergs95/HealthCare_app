using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;

namespace Tecno
{
    public partial class Form8 : MetroFramework.Forms.MetroForm
    {
        int screen_height = SystemInformation.VirtualScreen.Height;
        int screen_width = SystemInformation.VirtualScreen.Width;
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            if (Globais.saud == true)
            {
                label6.Visible = true;
            }
            if (Globais.saud1 == true)
            {
                label7.Visible = true;
            }
            if (Globais.saud2 == true)
            {
                label8.Visible = true;
            }
            Globais.rs = Globais.r1 + Globais.r2 + Globais.r3;
            textBox2.Text = Globais.rs.ToString();

            if (Globais.rs>0 && Globais.rs < 8)
            {
                label4.Visible = true;
            }
            if (Globais.rs > 8 && Globais.rs < 16)
            {
                label5.Visible = true;
            }
            if (Globais.rs > 16 && Globais.rs < 24)
            {
                label3.Visible = true;
                label12.Visible = true;
            }
            textBox1.Text = Globais.im.ToString("##.#");
            
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (m.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = m.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }
            base.WndProc(ref m);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            int x = BLL1.Login.insertResult(Convert.ToInt32(textBox2.Text),Convert.ToDecimal(textBox1.Text));
            this.Close();
        }
    }
}
