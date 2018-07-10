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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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


            new HeroiRepositorio().Inserir(heroi); //É feita o insert

        }
    }
}
