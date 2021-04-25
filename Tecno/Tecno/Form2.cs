using BusinessLogicLayer;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Tecno
{

    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        bool adm;
        DataTable dt;
        string password;
        char Key;
        int screen_height = SystemInformation.VirtualScreen.Height;
        int screen_width = SystemInformation.VirtualScreen.Width;
        public Form2()
        {

            InitializeComponent();
        }

        public byte[] imgToByteArray(Image img)

        {

            using (MemoryStream mStream = new MemoryStream())

            {

                img.Save(mStream, img.RawFormat);

                return mStream.ToArray();

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


        private void Form2_Enter(object sender, EventArgs e)
        {

        }






        private void metroButton1_Click(object sender, EventArgs e)
        {

            // fechar teclado
            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.ProcessName.Equals("osk"))
                {
                    proc.Kill();
                }
            }
            if (metroTextBox1.Text == "" || metroTextBox2.Text=="")
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\nUsername ou Password Incorretos", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            password = getHashSha256(metroTextBox2.Text);
            dt = BLL1.Logins.queryLogin(password, metroTextBox1.Text);
            adm = (bool)dt.Rows[0][2];
            Globais.admin = adm;

          


            if (dt.Rows.Count > 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\nPressione OK para continuar", "Bem Vindo á Health Care", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (adm)
                {
                    Form3 f3 = new Form3();
                    f3.Show();
                    Globais.ch = true;
                    Form9 f9 = new Form9();
                    f9.Show();
                }
                else
                {
                Form4 f4 = new Form4();
                f4.Show();
                metroTextBox1.Clear();
                metroTextBox2.Clear();
                }
                
               
            }
            else
            {
                
                MetroFramework.MetroMessageBox.Show(this, "\n\nUsername ou Password Incorretos", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
        

     

        private void metroButton2_Click(object sender, EventArgs e)
        {
            metroTextBox1.Clear();
            metroTextBox2.Clear();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            DialogResult Sair = MetroFramework.MetroMessageBox.Show(this, "\n\nDeseja mesmo sair da aplicação?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Sair == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {

            }
        }

       

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            this.MaximumSize = new System.Drawing.Size(screen_width, screen_height);
            this.MinimumSize = new System.Drawing.Size(screen_width, screen_height);
            metroTextBox2.PasswordChar = '*';

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

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void metroTextBox1_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {
                password = getHashSha256(metroTextBox2.Text);
                dt = BLL1.Logins.queryLogin((password), metroTextBox1.Text);
                // fechar teclado
                foreach (Process proc in Process.GetProcesses())
                {
                    if (proc.ProcessName.Equals("osk"))
                    {
                        proc.Kill();
                    }
                }

                password = getHashSha256(metroTextBox2.Text);
                dt = BLL1.Logins.queryLogin(password, metroTextBox1.Text);
                adm = (bool)dt.Rows[0][2];
                Globais.admin = adm;




                if (dt.Rows.Count > 0)
                {
                    MetroFramework.MetroMessageBox.Show(this, "\n\nPressione OK para continuar", "Bem Vindo á Health Care", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    if (adm)
                    {
                        Form3 f3 = new Form3();
                        f3.Show();
                        Globais.ch = true;
                        Form9 f9 = new Form9();
                        f9.Show();
                    }
                    else
                    {
                        Form4 f4 = new Form4();
                        f4.Show();
                        metroTextBox1.Clear();
                        metroTextBox2.Clear();
                    }


                }
                else
                {

                    MetroFramework.MetroMessageBox.Show(this, "\n\nUsername ou Password Incorretos", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            }

        private void metroTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.Enter)
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
                dt = BLL1.Logins.queryLogin(password, metroTextBox1.Text);
                adm = (bool)dt.Rows[0][2];
                Globais.admin = adm;




                if (dt.Rows.Count > 0)
                {
                    MetroFramework.MetroMessageBox.Show(this, "\n\nPressione OK para continuar", "Bem Vindo á Health Care", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    if (adm)
                    {
                        Form3 f3 = new Form3();
                        f3.Show();
                        Globais.ch = true;
                        Form9 f9 = new Form9();
                        f9.Show();
                    }
                    else
                    {
                        Form4 f4 = new Form4();
                        f4.Show();
                        metroTextBox1.Clear();
                        metroTextBox2.Clear();
                    }


                }
                else
                {

                    MetroFramework.MetroMessageBox.Show(this, "\n\nUsername ou Password Incorretos", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
           

        }
       
    }
}
