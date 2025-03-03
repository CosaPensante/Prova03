using ProvaAzure01.Data;
using System.Data;
using System;

namespace ProvaAzure01.DTOs
{
    public class CittaDTO
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Nazione { get; set; }
        public List<string> Meteo { get; set; }
        public CittaDTO()
        {
            Meteo = Previsioni();
        }

        public List<string> Previsioni()
        {
            Random rnd = new Random();
            var previsioni = new List<string>();
            for (int i = 1; i <= 3; i++) // Genera previsioni per i prossimi 3 giorni
            {
                previsioni.Add($"{DateTime.Now.AddDays(i).ToShortDateString()} - meteo: {rnd.Next(-20, 50)}°C");
            }
            return previsioni;
        }
    }
}
