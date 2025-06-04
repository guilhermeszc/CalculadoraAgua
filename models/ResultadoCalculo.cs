namespace calculadoraagua.Models
{
    public class ResultadoCalculo
    {
        public List<FaixaCalculo> Faixas { get; set; } = new();
        public decimal Total => Faixas.Sum(f => f.Total);
    }
}