using System.ComponentModel.DataAnnotations;

namespace FIlmesAPI.Data.DTOs.Cinema
{
    public class CreateCinemaDTO
    {
        [Required(ErrorMessage = "O campo de nome é obrigatorio")]
        public string Nome { get; set; }
    }
}
