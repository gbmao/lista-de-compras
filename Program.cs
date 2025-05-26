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
            // aqui ele vai perguntar qual item vai entrar na lista
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


            MostrandoLista(lista);


            ConverterParaInt(response, lista);


            switch (response)
            {
                case "1":

                    break;
            }
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal");
            Console.ReadLine();
            break;
        case "3":
            // mostra os itens
            MostrandoLista(lista);
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal");
            Console.ReadLine();
            break;
    }
} while (response.ToLower().Trim() != "sair");

// checar se é valido a conversao e converter para int


int ConverterParaInt(string response, string[] lista)
{
    int intResponse = 0;
    bool Valido = false;
    do
    {
        Console.WriteLine("Digite o numero do item que deseja alterar");
        response = ResponseIsNull();

        try
        {
            intResponse = int.Parse(response);
            Valido = true;
        }
        catch (FormatException)
        {
            Console.WriteLine("Você deve digitar um número válido");
        }
        if (intResponse > lista.Length || intResponse <= 0)
        {
            throw new ArgumentOutOfRangeException($"O número digitado ({intResponse}) não é válido ");
            
        }
    } while (Valido != true);
    return intResponse - 1;
}



// mostrar a lista
void MostrandoLista(string[] lista)
{
    Console.WriteLine("\nLista:\n");
    for (int i = 0; i < lista.Length; i++)
    {
        if (lista[i] != null)
        {
            Console.WriteLine($"{i + 1}. {lista[i]} ");

        }
    }
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