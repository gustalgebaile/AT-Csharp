using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AT.Models
{
    [Table("Jogador")]
    public class Jogador
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("Data")]
        [Display(Name = "Data")]
        public DateTime dataCriacao { get; set; } = DateTime.Now;

        [NotMapped] public IFormFile Imagem { get; set; }
    }
}
