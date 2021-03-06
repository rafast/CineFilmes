using System.ComponentModel.DataAnnotations;

namespace CineFilmes.API.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="O campo nome é obrigatório")]
        public string Nome { get; set; }
        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
        public virtual Gerente Gerente { get; set; }
        public int GerenteId { get; set; }
    }
}
