using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto.Presentation.Models;
using Projeto.Data.Repositories;
using Projeto.Data.Entities;

namespace Projeto.Presentation.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastro(CadastrarProdutoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var produto = new Produto();
                    produto.Nome = model.Nome;
                    produto.Quantidade = model.Quantidade;
                    produto.Preco = model.Preco;
                    

                    var produtoRepository = new ProdutoRepository();
                    produtoRepository.Inserir(produto);

                    TempData["Mensagem"] = "Produto Cadastrado com sucesso.";
                    ModelState.Clear();
                }

                catch(Exception e)
                {
                    TempData["Mensagem"] = "Ocorreu um erro: " + e.Message;
                }
            }
            
            return View();
        }

        public IActionResult Consulta()
        {

            var lista = new List<Produto>();

            try
            {
                var produtoRepository = new ProdutoRepository();
                lista = produtoRepository.Consultar();
            }
            catch(Exception e)
            {
                TempData["Mensagem"] = "Ocorreu um erro" + e.Message;
            }

            return View(lista);
        }

        public IActionResult Exclusao(int id)
        {
            try
            {
                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.ObterPorId(id);

                    if(produto != null)
                {
                    produtoRepository.Excluir(produto);
                    TempData["Mensagem"] = "Produto " + produto.Nome + " Excluído com sucesso!";
                }
                else
                {
                    TempData["Mensagem"] = "Erro: Nenhum produto foi encontrado";
                }
            }
            catch(Exception e)
            {
                TempData["Mensagem"] = "Ocorreu um erro " + e.Message;
            }

            return RedirectToAction("Consulta");
        }


        public IActionResult Edicao(int id)
        {
            var model = new EditarProdutoModel();

            try
            {
                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.ObterPorId(id);

                if (produto != null)
                {
                    model.IdProduto = produto.IdProduto;
                    model.Nome = produto.Nome;
                    model.Preco = produto.Preco;
                    model.Quantidade = produto.Quantidade;
                }
                else
                {
                    TempData["Mensagem"] = "Produto não encontrado";
                }
                            
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = "Ocorreu um erro " + e.Message;
            }



            return View(model);
        }
        [HttpPost]
        public IActionResult Edicao(EditarProdutoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var produto = new Produto();
                    produto.IdProduto = model.IdProduto;
                    produto.Nome = model.Nome;
                    produto.Quantidade = model.Quantidade;
                    produto.Preco = model.Preco;

                    var produtoRepository = new ProdutoRepository();
                    produtoRepository.Alterar(produto);
                    TempData["Mensagem"] = "Produto alterado com sucesso";
                }
                catch(Exception e)
                {
                    TempData["Mensagem"] = "Ocorreu um erro: " + e.Message;
                }

            }
            return View();
            
           

        }
    }
}