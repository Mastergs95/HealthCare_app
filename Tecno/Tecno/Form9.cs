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
    public partial class Form9 : MetroFramework.Forms.MetroForm
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            
             textBox1.Text = BLL1.Resultados.queryimc().ToString();
             textBox2.Text = BLL1.Resultados.queryquestionário().ToString();
             textBox3.Text = BLL1.Resultados.queryidade().ToString();
            if (Convert.ToDecimal(textBox1.Text) < 25)
            {
                label6.Visible = true;
            }
            if (Convert.ToDecimal(textBox1.Text) > 25)
            {
                label4.Visible = true;
            }
            if (Convert.ToDecimal(textBox1.Text) == 25)
            {
                label5.Visible = true;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
