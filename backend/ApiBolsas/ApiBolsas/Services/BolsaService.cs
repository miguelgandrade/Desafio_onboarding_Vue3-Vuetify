namespace ApiBolsas.Services
{
    public class BolsaService
    {
        private readonly string[] _bolsas =
        {
            "Bolsa Matrícula",
            "Parcelamento de Matrícula",
            "Bolsa Mensalidade"
        };

        public string[] ObterBolsas()
        {
            return _bolsas;
        }
    }
}