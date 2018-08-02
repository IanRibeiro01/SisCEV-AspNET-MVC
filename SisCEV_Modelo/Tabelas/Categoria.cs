using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SisCEV_Modelo.Cadastros;

namespace SisCEV_Modelo.Tabelas
{
    public class Categoria
    {
        [Key]
        [Display(Name = "Id")]
        public int CategoriaId { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

    }
}