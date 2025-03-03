namespace ProvaAzure01.Data
{
    public class Citta
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        
        public required string Nazione { get; set; }
        public List<CittaPreferita>? CittaPreferite { get; set; }
    }
}
