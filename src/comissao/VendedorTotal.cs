namespace Comissao
{
    public class VendedorTotal
    {
        public string Nome { get; set; }
        public decimal TotalComissao { get; set; }
        public decimal SomaVendas { get; set; }
        public int QuantidadeVendas { get; set; }

        public VendedorTotal(string nome)
        {
            Nome = nome;
            TotalComissao = 0;
            SomaVendas = 0;
            QuantidadeVendas = 0;
        }

        public void AdicionarVenda(decimal valorVenda, decimal comissao)
        {
            SomaVendas += valorVenda;
            TotalComissao += comissao;
            QuantidadeVendas++;
        }

        public override string ToString()
        {
            return $"{Nome} | Vendas: {QuantidadeVendas} | Total R${SomaVendas:F2} | Comissão R${TotalComissao:F2}";
        }
    }
}
