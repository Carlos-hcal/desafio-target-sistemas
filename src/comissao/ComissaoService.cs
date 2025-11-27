using System.Text.Json;

namespace Comissao
{
    public class ComissaoService
    {
        private const decimal TAXA_1 = 0.01m;
        private const decimal TAXA_2 = 0.05m;

        /// <summary>
        /// Lê o JSON e retorna lista de vendas.
        /// </summary>
        public List<Venda> LerVendas(string caminhoArquivo)
        {
            if (!File.Exists(caminhoArquivo))
                throw new FileNotFoundException("Arquivo de vendas não encontrado.", caminhoArquivo);

            string json = File.ReadAllText(caminhoArquivo);

            var root = JsonSerializer.Deserialize<VendasRoot>(json);

            return root?.Vendas ?? new List<Venda>();
        }

        /// <summary>
        /// Calcula a comissão de uma única venda.
        /// </summary>
        public decimal CalcularComissao(decimal valor)
        {
            if (valor < 100) return 0;
            if (valor < 500) return valor * TAXA_1;
            return valor * TAXA_2;
        }

        /// <summary>
        /// Gera o total de comissão por vendedor.
        /// </summary>
        public List<VendedorTotal> CalcularTotaisPorVendedor(List<Venda> vendas)
        {
            var vendedores = new Dictionary<string, VendedorTotal>();

            foreach (var venda in vendas)
            {
                if (!vendedores.ContainsKey(venda.Vendedor))
                    vendedores[venda.Vendedor] = new VendedorTotal(venda.Vendedor);

                decimal comissao = CalcularComissao(venda.Valor);

                vendedores[venda.Vendedor].AdicionarVenda(venda.Valor, comissao);
            }

            return vendedores.Values.ToList();
        }
    }

    /// <summary>
    /// Modelo auxiliar para deserializar JSON exatamente como enviado.
    /// </summary>
    public class VendasRoot
    {
        public List<Venda> Vendas { get; set; } = new List<Venda>();
    }
}
