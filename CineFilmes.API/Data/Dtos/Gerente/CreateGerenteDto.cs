﻿using System.ComponentModel.DataAnnotations;

namespace CineFilmes.API.Data.Dtos.Gerente
{
    public class CreateGerenteDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
    }
}
