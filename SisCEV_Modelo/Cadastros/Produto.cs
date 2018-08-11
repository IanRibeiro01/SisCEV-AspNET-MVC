using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SisCEV_Modelo.Tabelas;

namespace SisCEV_Modelo.Cadastros
{
    public class Produto
    {
        [Key]
        [Display(Name ="Id")]
        public int? ProdutoID { get; set; }

        [Display(Name ="Nome")]
        [Required(ErrorMessage = "Nome do Produto é Obrigatório")]
        public string Nome { get; set; }

        [Display(Name ="Data")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Data de Cadastro do Produto de ser Informada")]
        public DateTime? DataCadastro { get; set; }

        [Display(Name = "Categoria")]
        public int? CategoriaId { get; set; }

        [Display(Name = "Fabricante")]
        public int? FabricanteId { get; set; }

        public Categoria Categoria { get; set; }
        public Fabricante Fabricante { get; set; }

    }
}