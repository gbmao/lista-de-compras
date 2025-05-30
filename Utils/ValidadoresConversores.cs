namespace ListaDeCompras.Utils;

using ListaDeCompras.Models;

public class Utilitatios
{
    // private List<Itens> lista;

    // public Conversor(List<Itens> listaInicial)
    // {
    //     lista = listaInicial;
    // }
    public static int ConverterParaInt(string response, List<Itens> lista)
    {
        int intResponse = 0;
        bool Valido = false;
        do
        {
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
    public static string ResponseIsNull()
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
}