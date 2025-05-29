// programa de lista de compras


var lista = new List<string> { };
string? response = "";
do
{
    Console.Clear();
    Console.WriteLine("Escolha a opção:");
    Console.WriteLine("1. Adicionar item para lista");
    Console.WriteLine("2. Marcar item como comprado");
    Console.WriteLine("3. Mostre a lista");
    Console.WriteLine("Digite sair para sair.-");
    response = ResponseIsNull();

    switch (response)
    {
        case "1":
           // ConsoleKeyInfo tecla = Console.ReadKey(true);
            do
            {
                Console.WriteLine("Digite o nome do item(Separe por , se for mais de 1) ou aperte ESC para sair");
                response = ResponseIsNull();

                AdicionandoItemNovo(response);
                // colocar try e respostas invalidas
                Console.WriteLine($"Item adicionado! Deseja adicionar mais? s/n");
                response = ResponseIsNull();
                char letraInicial = response.First();
                if (letraInicial != 'n')
                {
                    Console.WriteLine("Resposta inválida");
                }


            } while (response != "n");

            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal");
            Console.ReadLine();


            break;
        case "2":
            // onde iremos marcar os itens que comprar
            while (true)
            {
                MostrandoLista(lista);
                Console.WriteLine("Digite o numero do item que deseja alterar ou digite 'voltar' para voltar ao menu anterior: ");

                // resolver problema de digitar 2x
                response = ResponseIsNull();
                if (response.ToLower().Trim() == "voltar") break;
                int item = ConverterParaInt(response, lista);
                Console.WriteLine($"O que você deseja fazer com o item {lista[item]}");

                //     do
                //      {

                Console.WriteLine("1. Deletar");
                Console.WriteLine("2. Marcar como comprado");
                Console.WriteLine(" Digite 'Voltar' para voltar ao menu anterior ");

                response = ResponseIsNull();

                switch (response)
                {
                    case "1":
                        DeletandoItem(item, lista);
                        response = "voltar";
                        break;

                    case "2":
                        MarcarComoComprado(item, lista);
                        //response = "voltar";
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
            MostrandoLista(lista);
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal");
            Console.ReadLine();
            break;
            //adicionar um default em caso de digitação errado
    }
} while (response.ToLower().Trim() != "sair");



// criar uma lista



void MarcarComoComprado(int item, List<string> lista)
{
    lista[item] += " (Comprado)";
}

void DeletandoItem(int item, List<string> lista)
{
    Console.WriteLine($"O item: {lista[item]} foi removido!");
    lista.Remove(lista[item]);
    //lista =  OrdenandoItensDaLista(lista);
}


// impossivel alterar local de itens dentro de um array
// criar uma array nova?
// List<string> OrdenandoItensDaLista(List<string> lista)
// {
//     // percorrer lista e encontrar a quantidade de itens  != null
//     int indice = 0;
//     string[] novaLista = new string[TamanhoDaLista(lista)];
//     //alocar os itens != null de lista na novaLista
//     for (int i = 0; i < lista.Count; i++)
//     {
//         if (lista[i] != null)
//         {
//             novaLista[indice] = lista[i];
//             indice++;
//         }
//     }
//     //recriar lista com os novos itens
//     lista = new string[TamanhoDaLista(novaLista)];
//     // alocar itens de novalista para lista
//     for (int i = 0; i < novaLista.Length; i++)
//     {
//         lista[i] = novaLista[i];
//     }
//     /*   int totalDeIndices = lista.Length - 1;
// for (int i = 0; i < lista.Length; i++)
// {
//     lista[i] = lista[totalDeIndices];
//     lista[totalDeIndices] = null;
//     totalDeIndices--;
// }*/
//     return lista;
// }
// checar se é valido a conversao e converter para int


int ConverterParaInt(string response, List<string> lista)
{
    int intResponse = 0;
    bool Valido = false;
    do
    {

        //response = ResponseIsNull();


        Valido = int.TryParse(response, out intResponse);


        if (Valido != true)
        {
            Console.WriteLine("Você deve digitar um número válido");
            Console.WriteLine("Digite um número válido: ");

        }
        //lista.Lenght está pegando todos os numeros
        else if (intResponse > lista.Count || intResponse <= 0)
        {
            Console.WriteLine($"O número digitado ({intResponse}) não é válido ");
            Console.WriteLine("Digite um número válido: ");
            Valido = false;
        }
    } while (Valido != true);
    return intResponse - 1;
}

// int TamanhoDaLista(string[] lista)
// {
//     int quantidadeTotalDeItens = 0;
//     foreach (string items in lista)
//     {
//         if (items != null)
//         {
//             quantidadeTotalDeItens++;
//         }
//     }
//     return quantidadeTotalDeItens;
// }


//melhorar apresentação!!!!!
void MostrandoLista(List<string> lista)
{
    int contagemDaQuantidadeItens = 0;
    Console.WriteLine("\nLista:\n");
    foreach (string item in lista)
    {
        Console.WriteLine($".{contagemDaQuantidadeItens} {item}");
        contagemDaQuantidadeItens++;
    }
    Console.WriteLine();
}



// criar um metodo de alocar novos itens no array
void AdicionandoItemNovo(string response)
{
    if (response.Contains(','))
    {
        string[] nomesCompostos = response.Split(',');
        foreach (string nome in nomesCompostos)
        {
            string? nomeFormatado = nome.ToLower().Trim();
            if (!string.IsNullOrEmpty(nomeFormatado))
            {
                lista.Add(nomeFormatado);
            }
        }

    }
    else
    {
        lista.Add(response);
    }
}

string ResponseIsNull()

{
    string? entrada;
    do
    {
        entrada = Console.ReadLine();
        if (string.IsNullOrEmpty(entrada))
        {
            Console.WriteLine("Resposta inválida, favor digitar novamente:");
        }
    } while (string.IsNullOrEmpty(entrada));
    return entrada.ToLower().Trim();
}