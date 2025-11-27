using System.Text.Json;

namespace DesafioTarget.Comissao
{
    public class ComissaoService
    {
        private readonly string _caminhoJson;

        public ComissaoService(string caminhoJson)
        {
            _caminhoJson = caminhoJson;
        }

        public List<VendedorTotal> CalcularComissoes()
        {
            var json = File.ReadAllText(_caminhoJson);

            var wrapper = JsonSerializer.Deserialize<VendasWrapper>(json);

            var vendas = wrapper?.Vendas ?? new List<Venda>();

            var totais = new Dictionary<string, VendedorTotal>();

            foreach (var venda in vendas)
            {
                decimal comissao = venda.Valor switch
                {
                    < 100m => 0,
                    < 500m => venda.Valor * 0.01m,
                    _ => venda.Valor * 0.05m
                };

                if (!totais.ContainsKey(venda.Vendedor))
                    totais[venda.Vendedor] = new VendedorTotal(venda.Vendedor);

                totais[venda.Vendedor].SomaVendas += venda.Valor;
                totais[venda.Vendedor].TotalComissao += comissao;
                totais[venda.Vendedor].QuantidadeVendas++;
            }

            return totais.Values.ToList();
        }
    }
}
