using System.ComponentModel.DataAnnotations;

namespace CineFilmes.API.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual Filme Filme { get; set; }
        public int FilmeId { get; set; }
        public DateTime HorarioEncerramento { get; set; }
    }
}