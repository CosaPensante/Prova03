using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProvaAzure01.Data;
using ProvaAzure01.DTOs;

namespace ProvaAzure01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtenteController : ControllerBase
    {
        private readonly MeteoDbContext ctx;
        private readonly Mapper mapper;

        public UtenteController(MeteoDbContext ctx, Mapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        
        [HttpGet]
        [Route("{email}/Meteo")]
        public IActionResult GetPrevisioni(string email)
        {
            try
            {
                var cerco=ctx.Utenti.Include(u=> u.CittaPreferite).ThenInclude(p=>p.Citta).SingleOrDefault(u=>u.Email==email);
                if (cerco == null)
                    return NotFound();
                return Ok(mapper.MapEntityToDTO(cerco));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public IActionResult Create(UtenteDTO dto)//fare controllo validità email
        {
            try
            {
                if (ctx.Utenti.ToList().SingleOrDefault(u => u.Email == dto.Email) != null)
                    return BadRequest();
                ctx.Utenti.Add(mapper.MapDTOToEntity(dto));
                return ctx.SaveChanges() == 1
                    ? Created()
                    :BadRequest();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        [Route("NuovoPrefe")]
        public IActionResult NuovoPrefe(CittaPreferitaDTO prefe)
        {
            try
            {
                Utente utente = ctx.Utenti.SingleOrDefault(u => u.Email == prefe.Email);
                Citta citta = ctx.Citta.SingleOrDefault(c => c.Nome == prefe.Citta);
                if (utente == null || citta == null)
                    return NotFound();
                CittaPreferita relazione = mapper.MapDTOToEntity(utente, citta);
                //controllo che ci sia già aggiunta la città a preferite dell'utente:
                if (ctx.CittaPreferite.ToList().SingleOrDefault(cp => cp.CittaId == relazione.CittaId && cp.UtenteId == relazione.UtenteId) != null)
                    return BadRequest();
                ctx.CittaPreferite.Add(relazione);
                return ctx.SaveChanges() == 1
                    ? Created()
                    : BadRequest();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
