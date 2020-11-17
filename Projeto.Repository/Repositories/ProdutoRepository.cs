using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace Projeto.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDCrud;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void Alterar(Produto produto)
        {
            var query = "update Produto set Nome = @Nome, Preco = @Preco, Quantidade = @Quantidade"
                + " where IdProduto = @IdProduto";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, produto);
            }
        }

        public List<Produto> Consultar()
        {
            var query = "select * from Produto";
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Produto>(query).ToList();
            }
        }

        public void Excluir(Produto produto)
        {
            var query = "delete from Produto where IdProduto = @IdProduto";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, produto);
            }
        }

        public void Inserir(Produto produto)
        {
            var query = "insert into Produto(Nome, Preco, Quantidade)"
                 + "values(@Nome, @Preco, @Quantidade)";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, produto);
            }
        }

        public Produto ObterPorId(int idProduto)
        {
            var query = "select * from Produto where IdProduto = @IdProduto";
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Produto>(query, new { idProduto }).FirstOrDefault();
            }
        }
    }
}
