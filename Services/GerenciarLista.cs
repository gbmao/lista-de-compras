namespace ListaDeCompras.Services;

using ListaDeCompras.Models;
using ListaDeCompras.Utils;
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
        Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal");
        Console.ReadLine();

    }
}