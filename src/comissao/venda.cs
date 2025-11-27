namespace Comissao
{
    public class Venda
    {
        public string Vendedor { get; set; }
        public decimal Valor { get; set; }

        public Venda(string vendedor, decimal valor)
        {
            Vendedor = vendedor;
            Valor = valor;
        }

        public override string ToString()
        {
            return $"{Vendedor} - R${Valor:F2}";
        }
    }
}
