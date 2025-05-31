// programa de lista de compras
using ListaDeCompras.Models;
using ListaDeCompras.Utils;
using ListaDeCompras.Services;

List<Itens> lista = [];
GerenciarLista gerenciador = new(lista);
Menu menu = new(lista);
//int item = 0;

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
            gerenciador.AdicionandoItemNovo();
            break;
        case "2":
            bool funciona = true;

            do
            {
                // Console.WriteLine("Digite o numero do item que deseja alterar ou digite 'voltar' para voltar ao menu anterior: ");
                // gerenciador.MostrandoLista(lista);
                // response = Utilitatios.ResponseIsNull();
                // if (response.ToLower().Trim() == "voltar") break;

                try
                {
                    //item = Utilitatios.ConverterParaInt(response, lista);
                    menu.Alteracoes();
                    funciona = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                    Console.WriteLine("Tecle ENTER para continuar");
                    funciona = false;
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                    Console.WriteLine("Tecle ENTER para continuar");
                    funciona = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "Tecle ENTER");
                    Console.ReadLine();
                    break;
                }
                // } while (!funciona);

                // Console.WriteLine($"O que você deseja fazer com o item {lista[item]}");
                // Console.WriteLine("1. Deletar");
                // Console.WriteLine("2. Marcar como comprado");
                // Console.WriteLine("3.Adicionar quantidade que deve ser comprada");
                // Console.WriteLine(" Digite 'Voltar' para voltar ao menu anterior ");

                // response = Utilitatios.ResponseIsNull();

                // switch (response)
                // {
                //     case "1":
                //         gerenciador.DeletandoItem(item, lista);
                //         response = "voltar";
                //         break;

                //     case "2":
                //         gerenciador.MarcarComoComprado(item, lista);
                //         break;
                //     case "3":
                //         //criar method para adicionar quantidade 
                //         break;
                //     default:
                //         Console.WriteLine($"{response} Não é uma opção válida\n");
                //         break;
                // }
                if(!funciona) Console.ReadLine();
            } while (!funciona);

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