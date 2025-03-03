using ProvaAzure01.Data;
using System.ComponentModel.DataAnnotations;

namespace ProvaAzure01.DTOs
{
    public class UtenteDTO
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public List<CittaDTO>? Citta { get; set; }
    }
}
