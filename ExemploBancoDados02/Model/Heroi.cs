﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploBancoDados02.Model
{
    public class Heroi
    {
        public int  Id { get; set; }
        public string Nome{ get; set; }
        public bool Escuridao{ get; set; }        
        public string NomePessoa { get; set; }
        public string Raca { get; set; }
        public double ContaBancaria { get; set; }
        public char Sexo { get; set; }
        public DateTime DataNascimento{ get; set; }
        public byte QuantidadeFilmes{ get; set; }
        public string Descricao{ get; set; }

    }
}
