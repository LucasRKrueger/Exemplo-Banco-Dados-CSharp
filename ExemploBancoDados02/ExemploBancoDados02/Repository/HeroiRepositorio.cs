using ExemploBancoDados02.Model;
using System;
using System.Collections.Generic;
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
        public bool Edit(Heroi heroi) { return false; }
        public List<Heroi> ObterTodos() { return null; }
        public Heroi ObterPeloCodigo(int codigo) { return null; }
        public bool Apagar(int codigo) { return false; }
        public string Descricao{ get; set; }
    }
}
