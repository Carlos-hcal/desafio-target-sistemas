using DesafioTarget.Comissao;

var caminho = "src/Comissao/vendas.json";
var service = new ComissaoService(caminho);

var resultado = service.CalcularComissoes();

foreach (var item in resultado)
{
    Console.WriteLine(item);
}

