// programa de lista de compras


using System.Reflection.Metadata.Ecma335;

List<Itens> lista = [];
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
                if (letraInicial != 'n' && letraInicial != 's')
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
                Console.WriteLine("3.Adicionar quantidade que deve ser comprada");
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




void MarcarComoComprado(int item, List<Itens> lista)
{
    lista[item].FoiComprado = true;
}

void DeletandoItem(int item, List<Itens> lista)
{
    Console.WriteLine($"O item: {lista[item]} foi removido!");
    lista.Remove(lista[item]);
    //lista =  OrdenandoItensDaLista(lista);
}

int ConverterParaInt(string response, List<Itens> lista)
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

//melhorar apresentação!!!!!
void MostrandoLista(List<Itens> lista)
{
    int contagemDaQuantidadeItens = 1;
    Console.WriteLine("\nLista:\n");
    foreach (var item in lista)
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
                lista.Add(new Itens(nomeFormatado, false, 1, null));
            }
        }

    }
    else
    {
        lista.Add(new Itens(response, false, 1, null));
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


public class Itens(string nome, bool comprado, int quantidade, DateOnly? validade)
{
    public string NomeDoItem { get; set; } = nome;

    public bool FoiComprado { get; set; } = comprado;

    public int QuantosComprou { get; set; } = quantidade;

    public DateOnly? HoraValidade { get; set; } = validade;

    public override string ToString()
    {
        return $"{NomeDoItem.ToUpper()}({ReturnComprado(FoiComprado)})  Quantidade: {QuantosComprou} Validade: {ReturnData()} ";
    }
    string ReturnComprado(bool FoiComprado)
    {
        if (FoiComprado)
        {
            return "(Comprado)";
        }
        else
        {
            return "Falta Comprar";
        }
    }

    string ReturnData()
    {
        if (HoraValidade != null)
        {
            return $"{HoraValidade}";
        }
        else
        {
            return "Sem validade";
        }
    }
}