using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using BusinessLogicLayer;
using System.IO;
using System.Diagnostics;

namespace Tecno
{
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
        bool adm;
        string p;
        string password;
        string usere;
        string cp;
        DataTable dt;
        int screen_height = SystemInformation.VirtualScreen.Height;
        int screen_width = SystemInformation.VirtualScreen.Width;
        public Form3()
        {
            InitializeComponent();
        }

      


        private void Form3_Load(object sender, EventArgs e)
        {
            metroTextBox2.PasswordChar = '*';
            metroTextBox3.PasswordChar = '*';
            this.MaximumSize = new System.Drawing.Size(screen_width, screen_height);
            this.MinimumSize = new System.Drawing.Size(screen_width, screen_height);
           
            if (Globais.admin == true)
            {
                checkBox1.Visible = true;
            }
          
        }
        public static string getHashSha256(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            // fechar teclado
            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.ProcessName.Equals("osk"))
                {
                    proc.Kill();
                }
            }
            password = getHashSha256(metroTextBox2.Text);
            usere = metroTextBox1.Text;
            p = metroTextBox2.Text;
            cp = metroTextBox3.Text;

           
            if (checkBox1.Checked)
            {
                adm = true;
            }



            dt = BLL1.Logins.queryUser(usere);
            if (usere == "" || p == "" || cp=="")
            {
                    label4.Visible = true;
                    label5.Visible = true;
                    label9.Visible = true;
                MessageBox.Show("Preencha todos os campos obrigatórios (*)");
                
            }
            else if (p==cp && dt.Rows.Count==0)
            {
                int i = BLL1.Logins.insertLogin(password, metroTextBox1.Text,adm);
                 metroTextBox2.Clear();
                 this.Hide();
            }
            else if (p != cp)
            {
                label7.Visible = true;
            }
            else if (dt.Rows.Count > 0)
            {
                label8.Visible = true;
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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            label11.Visible = true;
        }



        private void metroButton4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Close();
        }

        

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
            
        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
            
        }

        private void metroTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // fechar teclado
            //foreach (Process proc in Process.GetProcesses())
            //{
            //    if (proc.ProcessName.Equals("osk"))
            //    {
            //        proc.Kill();
            //    }
            //}
            if (e.KeyCode == Keys.Enter)
            {
                password = getHashSha256(metroTextBox2.Text);
                usere = metroTextBox1.Text;
                p = metroTextBox2.Text;
                // fechar teclado
                foreach (Process proc in Process.GetProcesses())
                {
                    if (proc.ProcessName.Equals("osk"))
                    {
                        proc.Kill();
                    }
                }
                if (usere == "" || p == "" || cp=="")
                {
                    label4.Visible = true;
                    label5.Visible = true;
                    label9.Visible = true;
                    MessageBox.Show("Preencha todos os campos obrigatórios (*)");

                }
                else if (p == cp)
                {
                    int i = BLL1.Logins.insertLogin(password, metroTextBox1.Text,adm);
                    Form2 f3 = new Form2();
                    f3.Show();
                    metroTextBox2.Clear();
                    this.Close();
                }
                else if (p != cp)
                {
                    label7.Visible = true;
                }
            }
        }

        private void metroTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            // fechar teclado
            //foreach (Process proc in Process.GetProcesses())
            //{
            //    if (proc.ProcessName.Equals("osk"))
            //    {
            //        proc.Kill();
            //    }
            //}
            
            if (e.KeyCode == Keys.Enter)
            {

                
                password = getHashSha256(metroTextBox2.Text);
                usere = metroTextBox1.Text;
                p = metroTextBox2.Text;

                // fechar teclado
                foreach (Process proc in Process.GetProcesses())
                {
                    if (proc.ProcessName.Equals("osk"))
                    {
                        proc.Kill();
                    }
                }
                if (usere == "" || p == "" || cp=="")
                {
                    label4.Visible = true;
                    label5.Visible = true;
                    label9.Visible = true;
                    MessageBox.Show("Preencha todos os campos obrigatórios (*)");
                }
                else if(p==cp)
                {
                    int i = BLL1.Logins.insertLogin(password, metroTextBox1.Text,adm);
                    Form2 f3 = new Form2();
                    f3.Show();
                    this.Close();
                }
                 else if (p != cp)
                {
                    label7.Visible = true;
                }
            }
        }

        private void metroButton4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void metroTextBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");

        }
    }
}
