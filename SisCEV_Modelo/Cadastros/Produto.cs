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
        public string Nome { get; set; }

        public int? CategoriaId { get; set; }
        public int? FabricanteId { get; set; }

        [Display(Name = "Categoria")]
        public Categoria Categoria { get; set; }

        [Display(Name = "Fabricante")]
        public Fabricante Fabricante { get; set; }
    }
}