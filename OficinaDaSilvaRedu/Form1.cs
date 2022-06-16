using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OficinaDaSilvaRedu
{
    public partial class Form1 : Form
    {
        private int _indexRow;
        public Form1()
        {
            InitializeComponent();
        }

        //SALVAR
        private void button1_Click(object sender, EventArgs e)
        {
            Salvar();
            dataGridView1.Rows.Add(textBoxNome.Text, textBoxEmail.Text, textBoxTelefone.Text, textBoxPlaca.Text);
            textBoxNome.Text = "";
            textBoxEmail.Text = "";
            textBoxTelefone.Text = "";
            textBoxPlaca.Text = "";
        }

        private void Salvar()
        {
            StreamWriter file = new StreamWriter("Clientes.txt", true);
            file.WriteLine(textBoxNome.Text);
            file.WriteLine(textBoxEmail.Text);
            file.WriteLine(textBoxTelefone.Text);
            file.WriteLine(textBoxPlaca.Text);
            file.Close();
        }

        //CARREGAR AUTOMATICO
        private void Form1_Load(object sender, EventArgs e)
        {
            
            if (!File.Exists("Clientes.txt"))
            {
                StreamWriter file = new StreamWriter("Clientes.txt");
                file.Close();
            }
            else
            {
                StreamReader file = new StreamReader("Clientes.txt");
                while (!file.EndOfStream)
                {
                    String Nome = file.ReadLine();
                    String Email = file.ReadLine();
                    String Telefone = file.ReadLine();
                    String Placa = file.ReadLine();
                    dataGridView1.Rows.Add(Nome, Email, Telefone, Placa);
                }
                file.Close();
            }
        }

        //APAGAR COM O NOME
        private void button2_Click(object sender, EventArgs e)
        {
            for (int f = 0; f < dataGridView1.Rows.Count; f++)
            {
                if (textBoxNome.Text == dataGridView1.Rows[f].Cells[0].Value.ToString())
                {
                    dataGridView1.Rows.RemoveAt(f);
                    SalvarApagado();
                    MessageBox.Show("Cadastro apagado");
                }
            }
        }

        private void SalvarApagado()
        {
            StreamWriter file = new StreamWriter("Clientes.txt");
            for (int f = 0; f < dataGridView1.Rows.Count; f++)
            {
                file.WriteLine(dataGridView1.Rows[f].Cells[0].Value.ToString());
                file.WriteLine(dataGridView1.Rows[f].Cells[1].Value.ToString());
                file.WriteLine(dataGridView1.Rows[f].Cells[2].Value.ToString());
                file.WriteLine(dataGridView1.Rows[f].Cells[3].Value.ToString());
            }
            file.Close();
        }

        //MOSTRAR NO TB
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _indexRow = e.RowIndex;
            if (e.RowIndex == -1) return;
            DataGridViewRow row = dataGridView1.Rows[_indexRow];

            textBoxNome.Text = row.Cells["Nome"].Value.ToString();
            textBoxEmail.Text = row.Cells["Email"].Value.ToString();
            textBoxTelefone.Text = row.Cells["Telefone"].Value.ToString();
            textBoxPlaca.Text = row.Cells["Placa"].Value.ToString();
        }

        //EDITAR
        private void button3_Click(object sender, EventArgs e)
        {
            for (int f = 0; f < dataGridView1.Rows.Count; f++)
            {
                if (textBoxNome.Text == dataGridView1.Rows[f].Cells[0].Value.ToString() || textBoxPlaca.Text == dataGridView1.Rows[f].Cells[3].Value.ToString())
                {
                    dataGridView1.Rows.RemoveAt(f);
                    dataGridView1.Rows.InsertRange(f);
                    SalvarEditar();
                    MessageBox.Show("Cadastro Atualizado");
                }
            }
        }

        private void SalvarEditar()
        {
            StreamWriter file = new StreamWriter("Clientes.txt");
            for (int f = 0; f < dataGridView1.Rows.Count; f++)
            {
                file.WriteLine(dataGridView1.Rows[f].Cells[0].Value.ToString());
                file.WriteLine(dataGridView1.Rows[f].Cells[1].Value.ToString());
                file.WriteLine(dataGridView1.Rows[f].Cells[2].Value.ToString());
                file.WriteLine(dataGridView1.Rows[f].Cells[3].Value.ToString());
            }
            file.Close();
            Salvar();
            Atualizar();
        }

        //MOSTRAR MAUNUEL
        private void button4_Click_1(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void Atualizar()
        {
            dataGridView1.Rows.Clear();
            if (!File.Exists("Clientes.txt"))
            {
                StreamWriter file = new StreamWriter("Clientes.txt");
                file.Close();
            }
            else
            {
                StreamReader file = new StreamReader("Clientes.txt");
                while (!file.EndOfStream)
                {
                    String Nome = file.ReadLine();
                    String Email = file.ReadLine();
                    String Telefone = file.ReadLine();
                    String Placa = file.ReadLine();
                    dataGridView1.Rows.Add(Nome, Email, Telefone, Placa);
                }
                file.Close();
            }
        }
    }
}
