using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Entities
{
   public class Produto
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get; set; }


        public Produto()
        {
            //construtor default
        }

        public Produto(int idProduto, string nome, decimal preco, int quantidade)
        {
            IdProduto = idProduto;
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
            Total = preco * quantidade;

        }
    }
}
