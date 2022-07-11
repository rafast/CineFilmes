﻿using System.ComponentModel.DataAnnotations;

namespace CineFilmes.API.Data.Dtos.Cinema
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo enderecoId é obrigatório")]
        public int EnderecoId { get; set; }
        public int GerenteId { get; set; }
    }
}
