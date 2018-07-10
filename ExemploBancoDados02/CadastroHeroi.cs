using ExemploBancoDados02.Model;
using ExemploBancoDados02.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExemploBancoDados02
{
    public partial class CadastroHeroi : Form
    {
        private int codigo;

        public CadastroHeroi()
        {
            InitializeComponent();
        }

        public CadastroHeroi(int codigo)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.codigo = codigo;
            Heroi heroi = new HeroiRepositorio().ObterPeloCodigo(codigo);
            txtNome.Text = heroi.Nome;
            txtNomePessoa.Text = heroi.NomePessoa;
            txtCodigo.Text = Convert.ToString(heroi.Id);
            txtContaBancaria.Text = Convert.ToString(heroi.ContaBancaria);
            txtQuantidadeFilmes.Text = Convert.ToString(heroi.QuantidadeFilmes);
            cbMulher.Checked = heroi.Sexo == 'm';
            cbRaca.SelectedItem = heroi.Raca;
            richTextBox1.Text = heroi.Descricao;
            if (heroi.Escuridao)
            {
                rbSim.Checked = true;  
            }
            else
            {
                rbNao.Checked = true;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
 
            Heroi heroi = new Heroi(); 
            heroi.Nome = txtNome.Text; //Nome do herói
            heroi.NomePessoa = txtNomePessoa.Text;//Nome de cidadão do herói
            heroi.ContaBancaria = Convert.ToDouble(txtContaBancaria.Text);//Conta bancária do herói
            heroi.DataNascimento = dtpDataNascimento.Value;//Data de nascimento do herói
            heroi.Escuridao = rbSim.Checked;//Se ele é da escuridão ou não, atribuir true significa que ele é 
            heroi.QuantidadeFilmes = 10;//Quantidade de filmes do herói
            heroi.Raca = cbRaca.SelectedItem.ToString();//Raça do herói
            heroi.Sexo = cbMulher.Checked ? 'm' : 'h';//Sexo do herói
            heroi.Descricao = richTextBox1.Text; //Descrição do herói


            bool cadastrou = new HeroiRepositorio().Inserir(heroi);
            if (cadastrou)
            {
                MessageBox.Show("Registro cadastrado com sucesso");
            }
            else
            {
                MessageBox.Show("Deu ruim filhão");
            }

        }
    }
}
