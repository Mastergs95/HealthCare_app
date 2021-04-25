using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno
{
    public partial class Form6 : MetroFramework.Forms.MetroForm
    {
        int screen_height = SystemInformation.VirtualScreen.Height;
        int screen_width = SystemInformation.VirtualScreen.Width;
        Boolean pt1 = false;
        Boolean pt2 = false;
        Boolean pt3 = false;
        Boolean pt4 = false;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }


     
        
        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked || checkBox4.Checked && checkBox5.Checked || checkBox7.Checked && checkBox8.Checked || checkBox10.Checked && checkBox11.Checked)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\nSelecione apenas uma opção por pergunta!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (checkBox1.Checked && checkBox3.Checked || checkBox4.Checked && checkBox6.Checked || checkBox7.Checked && checkBox9.Checked || checkBox10.Checked && checkBox12.Checked)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\nSelecione apenas uma opção por pergunta!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (checkBox2.Checked && checkBox3.Checked || checkBox5.Checked && checkBox6.Checked || checkBox8.Checked && checkBox9.Checked || checkBox11.Checked && checkBox12.Checked)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\nSelecione apenas uma opção por pergunta!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (pt1 == true & pt2 == true & pt3 == true & pt4 == true)
            {
                if (checkBox1.Checked)
                {
                    Globais.r1 += 1;
                }
                if (checkBox4.Checked)
                {
                    Globais.r1 += 1;
                    Globais.saud2 = true;
                }
                if (checkBox7.Checked)
                {
                    Globais.r1 += 1;
                }
                if (checkBox10.Checked)
                {
                    Globais.r1 += 1;
                    Globais.saud1 = true;
                }
                //Pontuação Média
                if (checkBox2.Checked)
                {
                    Globais.r2 += 2;
                }
                if (checkBox5.Checked)
                {
                    Globais.r2 += 2;
                }
                if (checkBox8.Checked)
                {
                    Globais.r2 += 2;
                }
                if (checkBox11.Checked)
                {
                    Globais.r2 += 2;
                }
                //Pontuação Máxima
                if (checkBox3.Checked)
                {
                    Globais.r3 += 3;
                }
                if (checkBox6.Checked)
                {
                    Globais.r3 += 3;
                }
                if (checkBox9.Checked)
                {
                    Globais.r3 += 3;
                }
                if (checkBox12.Checked)
                {
                    Globais.r3 += 3;
                }
               
            }
            Form7 f7 = new Form7();
            f7.Show();
            this.Close();
        }
    
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                pt2 = true;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                pt1 = true;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                pt1 = true;
                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                pt1 = true;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
        }

        private void checkBox5_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                pt2 = true;
                checkBox4.Checked = false;
                checkBox6.Checked = false;
            }
        }

        private void checkBox6_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                pt2 = true;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
            }
        }

        private void checkBox7_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                pt3 = true;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
            }
        }

        private void checkBox8_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                pt3 = true;
                checkBox7.Checked = false;
                checkBox9.Checked = false;
            }
        }

        private void checkBox9_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                pt3 = true;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
            }
        }

        private void checkBox10_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                pt4 = true;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
            }
        }

        private void checkBox11_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
            {
                pt4 = true;
                checkBox10.Checked = false;
                checkBox12.Checked = false;
            }
        }

        private void checkBox12_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox12.Checked)
            {
                pt4 = true;
                //checkBox110.Checked = false;
                checkBox12.Checked = false;
            }
        }

        private void metroButton2_Click_1(object sender, EventArgs e)
        {
           
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

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
