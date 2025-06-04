async function calcular() {
    const metrosCubicos = parseInt(document.getElementById("metrosCubicos").value);
    const resposta = await fetch("/api/consumo/calcular", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ metrosCubicos })
    });

    const resultado = await resposta.json();
    let html = `<h3>Detalhamento:</h3><ul>`;
    resultado.faixas.forEach(faixa => {
        html += `<li>${faixa.quantidade} m³ x R$ ${faixa.tarifa.toFixed(2)} = R$ ${faixa.total.toFixed(2)}</li>`;
    });
    html += `</ul><strong>Total: R$ ${resultado.total.toFixed(2)}</strong>`;
    document.getElementById("resultado").innerHTML = html;
}