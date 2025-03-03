using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvaAzure01.Data
{
    [PrimaryKey("UtenteId", "CittaId")]
    public class CittaPreferita
    {
        public int UtenteId { get; set; }
        public int CittaId { get; set; }

        [ForeignKey("UtenteId")]
        public Utente? Utente { get; set; }
        [ForeignKey("CittaId")]
        public Citta? Citta { get; set; }
    }
}
