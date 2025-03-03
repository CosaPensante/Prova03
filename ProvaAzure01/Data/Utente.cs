using System.ComponentModel.DataAnnotations;

namespace ProvaAzure01.Data
{
    public class Utente
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        [EmailAddress]//ci fidiamo di sironi
        public required string Email { get; set; }
        public List<CittaPreferita>? CittaPreferite { get; set; }
    }
}
