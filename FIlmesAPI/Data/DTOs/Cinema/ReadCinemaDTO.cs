using System.ComponentModel.DataAnnotations;

namespace FIlmesAPI.Data.DTOs.Cinema
{
    public class ReadCinemaDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatorio")]
        public string Nome { get; set; }
    }
}
