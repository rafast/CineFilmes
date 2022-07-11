using System.ComponentModel.DataAnnotations;

namespace CineFilmes.API.Data.Dtos.Filme
{
    public class CreateFilmeDto
    {
        [Required(ErrorMessage = "O campo Titulo é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Duração é obrigatório")]
        [Range(1, 600, ErrorMessage = "A duração deve ser entre 1 e 600 minutos.")]
        public int Duracao { get; set; }
        [StringLength(50, ErrorMessage = "O nome do diretor não pode exceder 50 caracteres.")]
        public string Diretor { get; set; }
        public string Genero { get; set; }
        public int ClassificacaoEtaria { get; set; }
    }
}
