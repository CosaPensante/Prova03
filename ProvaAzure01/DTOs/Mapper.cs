using ProvaAzure01.Data;

namespace ProvaAzure01.DTOs
{
    public class Mapper
    {
        public UtenteDTO MapEntityToDTO(Utente entity)
        {
            return new UtenteDTO
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Email = entity.Email,
                Citta = entity.CittaPreferite?.ConvertAll(MapCittaPrefToCitta)
            };
        }
        public Utente MapDTOToEntity(UtenteDTO dto)
        {
            return new Utente
            {
                Nome = dto.Nome,
                Email = dto.Email
            };
        }
        public CittaPreferita MapDTOToEntity(Utente u, Citta c)
        {
            return new CittaPreferita
            {
                CittaId = c.Id,
                UtenteId = u.Id
            };
        }
        public CittaDTO MapCittaPrefToCitta(CittaPreferita entity)
        {
            return new CittaDTO
            {
                Id = entity.CittaId,
                Nome = entity.Citta.Nome,
                Nazione = entity.Citta.Nazione,

            };
        }
    }
}
