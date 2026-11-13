using ApiBolsas.DTOs;

namespace ApiBolsas.Services
{
    public class BolsaService
    {
        private readonly string[] _tiposBolsas =
        {
            "Bolsa Matrícula",
            "Parcelamento de Matrícula",
            "Bolsa Mensalidade"
        };

        private readonly List<BolsasDTO> _bolsas = new();
        private int _proximoCodigo = 1;
        
        public List<BolsasDTO> Listar() => _bolsas;

        public BolsasDTO Adicionar(BolsasDTO bolsa)
        {
            bolsa.Codigo = _proximoCodigo++;
            _bolsas.Add(bolsa);
            return bolsa;
        }

        public BolsasDTO? Atualizar(int codigo, BolsasDTO dados)
        {
            var bolsa = _bolsas.FirstOrDefault(b => b.Codigo == codigo);
            if (bolsa == null) return null;
            bolsa.TipoBolsa = dados.TipoBolsa;
            bolsa.ValorBolsa = dados.ValorBolsa;
            return bolsa;
        }

        public bool Remover(int codigo)
        {
            return _bolsas.RemoveAll(b => b.Codigo == codigo) > 0;
        }

        public string[] ObterBolsas()
        {
            return _tiposBolsas;
        }
    }
}