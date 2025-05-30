// programa de lista de compras
using ListaDeCompras.Models;
using ListaDeCompras.Utils;
using ListaDeCompras.Services;

List<Itens> lista = [];
GerenciarLista gerenciador = new(lista);
//Conversor converter = new(lista);
string? response = "";
do
{
    Console.Clear();
    Console.WriteLine("Escolha a opção:");
    Console.WriteLine("1. Adicionar item para lista");
    Console.WriteLine("2. Marcar item como comprado");
    Console.WriteLine("3. Mostre a lista");
    Console.WriteLine("Digite sair para sair.-");
    response = Utilitatios.ResponseIsNull();

    switch (response)
    {
        case "1":

            // do
            // {
            //     Console.WriteLine("Digite o nome do item(Separe por , se for mais de 1) ou aperte ESC para sair");
            //     response = Utilitatios.ResponseIsNull();

                gerenciador.AdicionandoItemNovo(response);
                // colocar try e respostas invalidas
                // Console.WriteLine($"Item adicionado! Deseja adicionar mais? s/n");
                // response = Utilitatios.ResponseIsNull();
                // char letraInicial = response.First();
                // if (letraInicial != 'n' && letraInicial != 's')
                // {
                //     Console.WriteLine("Resposta inválida");
                // }


            // } while (response != "n");

            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal");
            Console.ReadLine();


            break;
        case "2":
            // onde iremos marcar os itens que comprar
            while (true)
            {
                Console.WriteLine("Digite o numero do item que deseja alterar ou digite 'voltar' para voltar ao menu anterior: ");
                gerenciador.MostrandoLista(lista);
                // resolver problema de digitar 2x
                response = Utilitatios.ResponseIsNull();
                if (response.ToLower().Trim() == "voltar") break;
                int item = Utilitatios.ConverterParaInt(response, lista);
                Console.WriteLine($"O que você deseja fazer com o item {lista[item]}");

                //     do
                //      {

                Console.WriteLine("1. Deletar");
                Console.WriteLine("2. Marcar como comprado");
                Console.WriteLine("3.Adicionar quantidade que deve ser comprada");
                Console.WriteLine(" Digite 'Voltar' para voltar ao menu anterior ");

                response = Utilitatios.ResponseIsNull();

                switch (response)
                {
                    case "1":
                        gerenciador.DeletandoItem(item, lista);
                        response = "voltar";
                        break;

                    case "2":
                        gerenciador.MarcarComoComprado(item, lista);
                        //response = "voltar";
                        break;
                    case "3":
                        //criar method para adicionar quantidade 
                        break;
                    default:
                        Console.WriteLine($"{response} Não é uma opção válida\n");
                        break;
                }

                //   } while (response != "voltar");


            }

            break;
        case "3":
            // mostra os itens
            gerenciador.MostrandoLista(lista);
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal");
            Console.ReadLine();
            break;
            //adicionar um default em caso de digitação errado
    }
} while (response.ToLower().Trim() != "sair");



// criar uma lista



// int ConverterParaInt(string response, List<Itens> lista)
// {
//     int intResponse = 0;
//     bool Valido = false;
//     do
//     {

//         //response = Utilitatios.ResponseIsNull();


//         Valido = int.TryParse(response, out intResponse);


//         if (Valido != true)
//         {
//             Console.WriteLine("Você deve digitar um número válido");
//             Console.WriteLine("Digite um número válido: ");

//         }
//         //lista.Lenght está pegando todos os numeros
//         else if (intResponse > lista.Count || intResponse <= 0)
//         {
//             Console.WriteLine($"O número digitado ({intResponse}) não é válido ");
//             Console.WriteLine("Digite um número válido: ");
//             Valido = false;
//         }
//     } while (Valido != true);
//     return intResponse - 1;
// }

//melhorar apresentação!!!!!
// void MostrandoLista(List<Itens> lista)
// {

//     //criar modo de não mostrar lista em caso de vazia
//     if (lista.Count == 0)
//     {
//         Console.WriteLine("A lista está vazia");

//         return;
//     }
//     int contagemDaQuantidadeItens = 1;
//     Console.WriteLine("\nLista:\n");
//     foreach (var item in lista)
//     {
//         Console.WriteLine($".{contagemDaQuantidadeItens} {item}");
//         contagemDaQuantidadeItens++;
//     }
//     Console.WriteLine();
// }


// void AdicionandoItemNovo(string response)

// {
//     if (!response.Contains(','))
//     {
//         lista.Add(new Itens(response, false, 1, null));
//     }
//     else
//     {
//         string[] nomesCompostos = response.Split(',');
//         foreach (string nome in nomesCompostos)
//         {
//             string? nomeFormatado = nome.ToLower().Trim();
//             if (!string.IsNullOrEmpty(nomeFormatado))
//             {
//                 lista.Add(new Itens(nomeFormatado, false, 1, null));
//             }
//         }
//     }
//}

// string ResponseIsNull()
// {
//     string? entrada;
//     do
//     {
//         entrada = Console.ReadLine();
//         if (string.IsNullOrEmpty(entrada))
//         {
//             Console.WriteLine("Resposta inválida, favor digitar novamente:");
//         }
//     } while (string.IsNullOrEmpty(entrada));
//     return entrada.ToLower().Trim();
// }
// public class GerenciarLista 
// {
//     private List<Itens> lista;

//     public GerenciarLista(List<Itens> listaInicial)
//     {
//         lista = listaInicial;
//     }
//     public void MarcarComoComprado(int item, List<Itens> lista)
//     {
//         lista[item].FoiComprado = true;
//     }

//     public void DeletandoItem(int item, List<Itens> lista)
//     {
//         Console.WriteLine($"O item: {lista[item]} foi removido!");
//         lista.Remove(lista[item]);

//         //lista =  OrdenandoItensDaLista(lista);
//     }
// }
// public class Itens(string nome, bool comprado, int quantidade, DateOnly? validade)
// {
//     public string NomeDoItem { get; set; } = nome;

//     public bool FoiComprado { get; set; } = comprado;

//     public int QuantosComprou { get; set; } = quantidade;

//     public DateOnly? HoraValidade { get; set; } = validade;

//     public override string ToString()
//     {
//         return $"{NomeDoItem.ToUpper()}({ReturnComprado(FoiComprado)})  Quantidade: {QuantosComprou} Validade: {ReturnData()} ";
//     }
//     string ReturnComprado(bool FoiComprado)
//     {
//         if (FoiComprado)
//         {
//             return "Comprado";
//         }
//         else
//         {
//             return "Falta Comprar";
//         }
//     }

//     string ReturnData()
//     {
//         if (HoraValidade != null)
//         {
//             return $"{HoraValidade}";
//         }
//         else
//         {
//             return "Sem validade";
//         }
//     }
// }