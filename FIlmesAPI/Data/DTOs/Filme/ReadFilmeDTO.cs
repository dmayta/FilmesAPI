using System;
using System.ComponentModel.DataAnnotations;

namespace FIlmesAPI.Data.DTOs
{
    public class ReadFilmeDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Titulo é obrigatório.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo Diretor é obrigatorio.")]
        public string Diretor { get; set; }

        [StringLength(30, ErrorMessage = "O genero nao pode ultrapassar 30 caracteres")]
        public string Genero { get; set; }

        [Range(1, 60, ErrorMessage = "A duração deve ter no minimo 1 e no maximo 60 minutos")]
        public int Duracao { get; set; }
    }
}
