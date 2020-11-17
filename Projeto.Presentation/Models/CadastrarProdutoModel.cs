using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Models
{
    public class CadastrarProdutoModel
    {
     [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
     [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres")]
     [Required(ErrorMessage = "Por favor, informe um nome para o produto a ser cadastrado")]
        public string Nome { get; set; }

        [Range(1, 999999, ErrorMessage = "Por favor, informe o preço entre {1} e {2}.")]
        [Required(ErrorMessage = "Por favor, informe um preço para o produto")]
        public decimal Preco { get; set; }

        [Range(1, 99999, ErrorMessage = "Por favor, informe a quantidade de produtos a ser cadastrada entre {1} e {2}")]
        public int Quantidade { get; set; }


    }
}
