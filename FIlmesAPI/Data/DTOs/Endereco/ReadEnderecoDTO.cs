using System.ComponentModel.DataAnnotations;

namespace FIlmesAPI.Data.DTOs.Endereco
{
    public class ReadEnderecoDTO
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
    }
}
