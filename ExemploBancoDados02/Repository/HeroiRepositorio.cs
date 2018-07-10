using ExemploBancoDados02.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploBancoDados02.Repository
{
    public class HeroiRepositorio
    {
        private string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\100314\Documents\ExemploBancoDados02.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection connection = null;

        public HeroiRepositorio()
        {
            connection = new SqlConnection(connectionString); //Faz a conexão do C# com o SQL
        }

        public bool Inserir(Heroi heroi) {
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO herois (nome, escuridao, nome_pessoa, raca, conta_bancaria, data_nascimento, sexo, quantidade_filmes, descricao) VALUES (@NOME, @ESCURIDAO, @NOME_PESSOA, @RACA, @CONTA_BANCARIA, @DATA_NASCIMENTO, @SEXO, @QUANTIDADE_FILMES, @DESCRICAO)"; //Ele faz o insert no banco de dados

            command.Parameters.AddWithValue("@NOME", heroi.Nome); //Adiciona o valor nome para o heroi 
            command.Parameters.AddWithValue("@ESCURIDAO", heroi.Escuridao);//Adiciona o valor escuridão para o herói
            command.Parameters.AddWithValue("@NOME_PESSOA", heroi.NomePessoa);//Adiciona o valor nome de cidadão do herói
            command.Parameters.AddWithValue("@RACA", heroi.Raca);//Adiciona a raça do herói
            command.Parameters.AddWithValue("@CONTA_BANCARIA", heroi.ContaBancaria);//Adiciona a conta bancária do herói
            command.Parameters.AddWithValue("@DATA_NASCIMENTO", heroi.DataNascimento);//Adiciona a data de nascimento do herói
            command.Parameters.AddWithValue("@SEXO", heroi.Sexo);//Adiciona o sexo do herói
            command.Parameters.AddWithValue("@QUANTIDADE_FILMES", heroi.QuantidadeFilmes);//Adiciona a quantidade de filmes do herói
            command.Parameters.AddWithValue("@DESCRICAO", heroi.Descricao);//Adiciona a descrição do herói
            int quantidade = command.ExecuteNonQuery(); 
            connection.Close();
            return quantidade == 1; }

            public bool Edit(Heroi heroi) {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = @"UPDATE herois SET nome = @NOME, data_nascimento = @DATA_NASCIMENTO,
conta_bancaria = @CONTA_BANCARIA, nome_pessoa = @NOME_PESSOA, raca= @RACA, sexo = @SEXO,
quantidade_filmes = @QUANTIDADE_FILMES, escuridao = @ESCURIDAO, descricao = @DESCRICAO
WHERE id = @ID";

                command.Parameters.AddWithValue("@NOME", heroi.Nome);
                command.Parameters.AddWithValue("@DATA_NASCIMENTO", heroi.DataNascimento);
                command.Parameters.AddWithValue("@CONTA_BANCARIA", heroi.ContaBancaria);
                command.Parameters.AddWithValue("@NOME_PESSOA", heroi.NomePessoa);
                command.Parameters.AddWithValue("@RACA", heroi.Raca);
                command.Parameters.AddWithValue("@SEXO", heroi.Sexo);
                command.Parameters.AddWithValue("@QUANTIDADE_FILMES", heroi.QuantidadeFilmes);
                command.Parameters.AddWithValue("@ESCURIDAO", heroi.Escuridao);
                command.Parameters.AddWithValue("@DESCRICAO", heroi.Descricao);
                command.Parameters.AddWithValue("@ID", heroi.Id);
                int quantidadeAlterada = command.ExecuteNonQuery();
                connection.Close();
                return quantidadeAlterada == 1; }

        public List<Heroi> ObterTodos(

            string textoParaPesquisar = "%%",
            string colunaOrdenacao = "nome",
            string tipoOrdenacao = "ASC") {
            textoParaPesquisar = "%" + textoParaPesquisar + "%";
           
            List<Heroi> herois = new List<Heroi>();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = @"SELECT  id ,nome, raca, conta_bancaria FROM herois WHERE nome LIKE @PESQUISA OR raca LIKE
            @PESQUISA ORDER BY " + colunaOrdenacao + " " + tipoOrdenacao;

            command.Parameters.AddWithValue("@PESQUISA", textoParaPesquisar);

            DataTable tabelaEmMemoria = new DataTable();
            tabelaEmMemoria.Load(command.ExecuteReader());
            for (int i = 0; i < tabelaEmMemoria.Rows.Count; i++)
            {
                Heroi heroi = new Heroi();
                heroi.Id = Convert.ToInt32(tabelaEmMemoria.Rows[i][0].ToString());
                heroi.Nome = tabelaEmMemoria.Rows[i][1].ToString();
                heroi.Raca = tabelaEmMemoria.Rows[i][2].ToString();
                heroi.ContaBancaria = Convert.ToDouble(tabelaEmMemoria.Rows[i][3].ToString());
                herois.Add(heroi);

            }
            connection.Close();
            return herois; }
        public Heroi ObterPeloCodigo(int codigo) {
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = @"SELECT id,nome,raca,conta_bancaria,nome_pessoa, quantidade_filmes, data_nascimento, sexo, escuridao, descricao FROM herois WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", codigo);

            DataTable tabelaEmMemoria = new DataTable();
            tabelaEmMemoria.Load(command.ExecuteReader());

            Heroi heroi = new Heroi();

            heroi.Id = Convert.ToInt32(tabelaEmMemoria.Rows[0][0].ToString());
            heroi.Nome = tabelaEmMemoria.Rows[0][1].ToString();
            heroi.Raca = tabelaEmMemoria.Rows[0][2].ToString();
            heroi.ContaBancaria = Convert.ToDouble(tabelaEmMemoria.Rows[0][3].ToString());
            heroi.NomePessoa = tabelaEmMemoria.Rows[0][4].ToString();
            heroi.QuantidadeFilmes = Convert.ToByte(tabelaEmMemoria.Rows[0][5].ToString());
            heroi.DataNascimento = Convert.ToDateTime(tabelaEmMemoria.Rows[0][6].ToString());
            heroi.Sexo = Convert.ToChar(tabelaEmMemoria.Rows[0][7].ToString());
            heroi.Escuridao = Convert.ToBoolean(tabelaEmMemoria.Rows[0][8].ToString());
            heroi.Descricao = tabelaEmMemoria.Rows[0][9].ToString();
            connection.Close();
            return heroi; }


        public bool Apagar(int codigo) {
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "DELETE FROM herois WHERE id = @CODIGO";
            command.Parameters.AddWithValue("@CODIGO", codigo);
            int quantidade = command.ExecuteNonQuery();
            connection.Close();
            return quantidade == 1;  }


        public string Descricao{ get; set; }

        public double ObterTotalContas()
        {
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT SUM(conta_bancaria) FROM herois";
            double total = Convert.ToDouble(command.ExecuteScalar());
            connection.Close();
            return total;

        }
    }
}
