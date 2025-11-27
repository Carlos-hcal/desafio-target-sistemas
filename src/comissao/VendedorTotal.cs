namespace DesafioTarget.Comissao
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
        }
    }
}
