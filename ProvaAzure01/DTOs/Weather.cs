namespace ProvaAzure01.DTOs
{
    public class Weather
    {
        public string[] Stages = new string[] { "Nuvoloso", "Soleggiato", "" };//la completerò
        public int Temperature {  get; set; }
        private Random random=new Random();
        public Weather()
        {
            Temperature = random.NextDouble(3.66, 40);
        }
    }
}
