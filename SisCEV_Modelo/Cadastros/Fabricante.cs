using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SisCEV_Modelo.Cadastros
{
    public class Fabricante
    {
        [Key]
        [Display(Name = "Id")]
        public int? FabricanteId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome do Fabricante é Obrigatório")]
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}