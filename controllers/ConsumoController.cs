using Microsoft.AspNetCore.Mvc;
using calculadoraagua.Models;

namespace calculadoraagua.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsumoController : ControllerBase
    {
        [HttpPost("calcular")]
        public IActionResult Calcular([FromBody] ConsumoRequest request)
        {
            var resultado = CalcularConsumo(request.MetrosCubicos);
            return Ok(resultado);
        }

        private ResultadoCalculo CalcularConsumo(int metrosCubicos)
        {
            var resultado = new ResultadoCalculo();
            int restante = metrosCubicos;

            var faixas = new List<(int Limite, decimal Tarifa)>
            {
                (10, 2.00m),
                (10, 3.00m),
                (10, 5.00m),
                (int.MaxValue, 8.00m),
            };

            foreach (var faixa in faixas)
            {
                if (restante <= 0) break;
                int consumoNaFaixa = Math.Min(restante, faixa.Limite);
                resultado.Faixas.Add(new FaixaCalculo
                {
                    Quantidade = consumoNaFaixa,
                    Tarifa = faixa.Tarifa
                });
                restante -= consumoNaFaixa;
            }

            return resultado;
        }
    }
}
