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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        string id;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'agendaDataSet.Pessoa' table. You can move, or remove it, as needed.
            //this.TopMost = true;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            dataGridView1.DataSource = BLL.Pessoa.Load();
            button3.Enabled = true;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL.Pessoa.Load();
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    int x = BLL.Pessoa.insertCliente(textBox1.Text, textBox2.Text);
        //    textBox1.Clear();
        //    textBox2.Clear();
        //    dataGridView1.DataSource = BLL.Pessoa.Load();
        //}

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL.Pessoa.queryCliente_Like(textBox3.Text);
        }

      


   

        private void ficheiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form2 f2 = new Form2();
            //f2.MdiParent = this;
            //f2.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
        
            int x = BLL.Pessoa.deleteCliente(id, textBox1.Text, textBox2.Text);
            dataGridView1.DataSource = BLL.Pessoa.Load();
            
        }

        private void Editar_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
    }
