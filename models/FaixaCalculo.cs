namespace calculadoraagua.Models
{
    public class FaixaCalculo
    {
        public int Quantidade { get; set; }
        public decimal Tarifa { get; set; }
        public decimal Total => Quantidade * Tarifa;
    }
}