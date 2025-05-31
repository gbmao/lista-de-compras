namespace ListaDeCompras.Services;

using ListaDeCompras.Models;
using ListaDeCompras.Utils;
using ListaDeCompras.Services;
public class GerenciarLista
{
    private List<Itens> lista;

    public GerenciarLista(List<Itens> listaInicial)
    {
        lista = listaInicial;
    }
    public void MarcarComoComprado(int item, List<Itens> lista)
    {
        lista[item].FoiComprado = true;
    }

    public void DeletandoItem(int item, List<Itens> lista)
    {
        Console.WriteLine($"O item: {lista[item]} foi removido!");
        lista.Remove(lista[item]);

        //lista =  OrdenandoItensDaLista(lista);
    }
    public void MostrandoLista(List<Itens> lista)
    {

        //criar modo de não mostrar lista em caso de vazia
        if (lista.Count == 0)
        {
            Console.WriteLine("A lista está vazia");

            return;
        }
        int contagemDaQuantidadeItens = 1;
        Console.WriteLine("\nLista:\n");
        foreach (var item in lista)
        {
            Console.WriteLine($".{contagemDaQuantidadeItens} {item}");
            contagemDaQuantidadeItens++;
        }
        Console.WriteLine();
    }

    public void AdicionandoItemNovo()

    {
        string response;
        do
        {
            Console.WriteLine("Digite o nome do item(Separe por , se for mais de 1) ou aperte ESC para sair");
            response = Utilitatios.ResponseIsNull();
            if (!response.Contains(','))
            {
                lista.Add(new Itens(response, false, 1, null));
            }
            else
            {
                string[] nomesCompostos = response.Split(',');
                foreach (string nome in nomesCompostos)
                {
                    string? nomeFormatado = nome.ToLower().Trim();
                    if (!string.IsNullOrEmpty(nomeFormatado))
                    {
                        lista.Add(new Itens(nomeFormatado, false, 1, null));
                    }
                }
            }
            Console.WriteLine($"Item adicionado! Deseja adicionar mais? s/n");
            response = Utilitatios.ResponseIsNull();
            char letraInicial = response.First();
            if (letraInicial != 'n' && letraInicial != 's')
            {
                Console.WriteLine("Resposta inválida");
            }
        } while (response != "n");
        Console.WriteLine("Aperte qualquer tecla para voltar ao menu anterior");
        Console.ReadLine();

    }
    public void AdicionarOuRemoverQuantidade(int item)
    {
        Console.WriteLine($"Qual a quantidade total de {lista[item]} ?");


    }

}

public class Menu(List<Itens> listaInicial)
{
    private readonly GerenciarLista gerenciador = new(listaInicial);

    public void Alteracoes()
    {
        while (true)
        {
            int item;
            bool valido = true;
            do
            {
                Console.WriteLine("Digite o numero do item que deseja alterar ou digite 'voltar' para voltar ao menu anterior: ");
                gerenciador.MostrandoLista(listaInicial);

                item = Utilitatios.ConverterParaInt();
                if (item > listaInicial.Count || item <= 0)
                {
                    Console.WriteLine($"O número digitado ({item}) não faz parte da lista ");
                    valido = false;
                }
                else
                {
                    valido = true;
                    item--;
                }
            } while (!valido);



             Console.WriteLine($"O que você deseja fazer com o item {listaInicial[item]}");
            Console.WriteLine("1. Deletar");
            Console.WriteLine("2. Marcar como comprado");
            Console.WriteLine("3.Adicionar quantidade que deve ser comprada");
            Console.WriteLine(" Digite 'Voltar' para voltar ao menu anterior ");

            string? response = Utilitatios.ResponseIsNull();

            switch (response)
            {// saindo direto ao menu inicial
                case "1":
                    gerenciador.DeletandoItem(item, listaInicial);

                    break;

                case "2":
                    gerenciador.MarcarComoComprado(item, listaInicial);
                    break;
                case "3":
                    //criar method para adicionar quantidade 
                    break;
                case "voltar":
                    throw new Exception("Voltando ao menu anterior...");


                default:
                    Console.WriteLine($"{response} Não é uma opção válida\n");
                    break;
            }
        }
    }
}