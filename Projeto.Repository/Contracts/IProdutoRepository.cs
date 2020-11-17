using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Data.Entities;

namespace Projeto.Data.Contracts
{
    public interface IProdutoRepository
    {
        //métodos abstratos
        
        void Inserir(Produto produto);
        void Alterar(Produto produto);
        void Excluir(Produto produto);
        List<Produto> Consultar();
        Produto ObterPorId(int idProduto);
    }
}
