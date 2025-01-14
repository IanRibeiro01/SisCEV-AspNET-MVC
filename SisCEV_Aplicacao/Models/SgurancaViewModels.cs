﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SisCEV_Aplicacao.Models
{
    public class UsuarioViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Nome de Usuário")]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}