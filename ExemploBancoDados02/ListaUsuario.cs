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
    public partial class ListaHerois : Form
    {
        public ListaHerois()
        {
            InitializeComponent();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            new CadastroHeroi().ShowDialog();
        }

        private void AtualizarLista()
        {
            string coluna = "nome";

             if(rbRaca.Checked)
            {
                coluna = "raca";
            }
            else if(rbContaBancaria.Checked)
            {
                coluna = "conta_bancaria";
            }

            string tipoOrdenacao = "ASC";
            if (rbDesc.Checked)
            {
                tipoOrdenacao = "DESC";
            }
            dataGridView1.Rows.Clear();
            List<Heroi> herois = new HeroiRepositorio().ObterTodos(txtBusca.Text, coluna, tipoOrdenacao);
            foreach(Heroi heroi in herois)
            {
                dataGridView1.Rows.Add(new object[]{
                   heroi.Id,
                   heroi.Nome,
                   heroi.Raca,
                   heroi.ContaBancaria

            });
            }
         }


        private void ListaHerois_Load(object sender, EventArgs e)
        {
            AtualizarLista();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarLista();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int linhaSelecionada = dataGridView1.CurrentRow.Index;
            int codigo = Convert.ToInt32(dataGridView1.Rows[linhaSelecionada].Cells[0].Value.ToString());
            bool apagado = new HeroiRepositorio().Apagar(codigo);
            if (apagado)
            {
                dataGridView1.Rows.RemoveAt(linhaSelecionada);
                MessageBox.Show("Registro apagado com sucesso");
            }
            else
            {
                MessageBox.Show("Não foi possível apagar");
            }

              
        }

        private void btnEstatistica_Click(object sender, EventArgs e)
        {
            new EstatisticasHerois().ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int linhaSelecionada = dataGridView1.CurrentRow.Index;
            int codigo = Convert.ToInt32(dataGridView1.Rows[linhaSelecionada].Cells[0].Value.ToString());
            new CadastroHeroi(codigo).ShowDialog();
        }
    }
}
