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
using System.Diagnostics;

namespace Tecno
{
    public partial class Form4 : MetroFramework.Forms.MetroForm
    {
        int screen_height = SystemInformation.VirtualScreen.Height;
        int screen_width = SystemInformation.VirtualScreen.Width;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new System.Drawing.Size(screen_width, screen_height);
            this.MinimumSize = new System.Drawing.Size(screen_width, screen_height);
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text != "" || metroTextBox2.Text != "" || numericUpDown1.Text != "" || numericUpDown2.Text != "" || numericUpDown3.Text != "")
            {
                 int x = BLL.Pessoa.insertCliente(metroTextBox1.Text, metroTextBox2.Text, numericUpDown1.Text, comboBox1.Text, numericUpDown2.Text, numericUpDown3.Text);
                Decimal i = (Convert.ToDecimal(numericUpDown2.Text) * Convert.ToDecimal(numericUpDown2.Text));
                Globais.im =  Convert.ToDecimal(numericUpDown3.Text) / i;
                Form5 f5 = new Form5();
                f5.Show();

                this.Close();

            }
            else
            {
               MessageBox.Show("Preencha todos os campos");
            }
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

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
            
            System.Diagnostics.Process.Start("osk.exe");
            
        }

        private void metroTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // fechar teclado
            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.ProcessName.Equals("osk"))
                {
                    proc.Kill();
                }
            }
           
        }

        private void metroTextBox2_KeyDown(object sender, KeyEventArgs e)
            {
                // fechar teclado
                foreach (Process proc in Process.GetProcesses())
                {
                    if (proc.ProcessName.Equals("osk"))
                    {
                        proc.Kill();
                    }
                }
            
            }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
                {
                    // fechar teclado
                    foreach (Process proc in Process.GetProcesses())
                    {
                        if (proc.ProcessName.Equals("osk"))
                        {
                            proc.Kill();
                        }
                    }
                  
                }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            // fechar teclado
            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.ProcessName.Equals("osk"))
                {
                    proc.Kill();
                }

            }
        }

        private void numericUpDown2_KeyDown(object sender, KeyEventArgs e)
                {
                    // fechar teclado
                    foreach (Process proc in Process.GetProcesses())
                    {
                        if (proc.ProcessName.Equals("osk"))
                        {
                            proc.Kill();
                        }
                 
                }
                    }
        private void numericUpDown3_KeyDown(object sender, KeyEventArgs e)
                {
                    // fechar teclado
                    foreach (Process proc in Process.GetProcesses())
                    {
                        if (proc.ProcessName.Equals("osk"))
                        {
                            proc.Kill();
                        }
                    }
                   
                }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
           

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
            
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
            
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
           
        }
    }
}

