namespace ApiBolsas.DTOs
{
    public class BolsasDTO
    {
        public int Codigo {  get; set; }
        public string NumeroMatricula { get; set; } = string.Empty;
        public string TipoBolsa { get; set; } = string.Empty;
        public decimal ValorBolsa { get; set; }
        public DateTime Data {  get; set; }

    }
}
