// programa de lista de compras



string[] lista = new string[50];
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

            do
            {
                Console.WriteLine("Digite o nome do item(Separe por , se for mais de 1)");
                response = ResponseIsNull();

                AdicionandoItemNovo(response);
                Console.WriteLine($"Item adicionado! Deseja adicionar mais? s/n");
                response = Console.ReadLine();


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



void MarcarComoComprado(int item, string[] lista)
{
    lista[item] += " (Comprado)";
}

void DeletandoItem(int item, string[] lista)
{
    Console.WriteLine($"O item: {lista[item]} foi removido!");
    OrdenandoItensDaLista(lista);
}

void OrdenandoItensDaLista(string[] lista)
{
    for (int i = 0; i < TamanhoDaLista(lista); i++)
    {
        lista[i] = lista[i + 1];
    }
}
// checar se é valido a conversao e converter para int


int ConverterParaInt(string response, string[] lista)
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
        else if (intResponse > TamanhoDaLista(lista) || intResponse <= 0)
        {
            Console.WriteLine($"O número digitado ({intResponse}) não é válido ");
            Console.WriteLine("Digite um número válido: ");
            Valido = false;
        }
    } while (Valido != true);
    return intResponse - 1;
}

int TamanhoDaLista(string[] lista)
{
    int quantidadeTotalDeItens = 0;
    foreach (string items in lista)
    {
        if (items != null)
        {
            quantidadeTotalDeItens++;
        }
    }
    return quantidadeTotalDeItens;
}


//melhorar apresentação!!!!!
void MostrandoLista(string[] lista)
{
    int contagemDaQuantidadeItens = 0;
    Console.WriteLine("\nLista:\n");
    for (int i = 0; i < lista.Length; i++)
    {
        if (lista[i] != null)
        {
            contagemDaQuantidadeItens++;
            Console.WriteLine($"{contagemDaQuantidadeItens}. {lista[i]} ");

        }
    }
    Console.WriteLine();
}


// void para adicionar o item a lista

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
                for (int i = 0; i < lista.Length; i++)
                {
                    if (lista[i] == null)
                    {
                        lista[i] = nomeFormatado;
                        break;
                    }
                }
            }
        }

    }
    else
        for (int i = 0; i < lista.Length; i++)
        {
            if (lista[i] == null)
            {
                lista[i] = response;
                break;
            }
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