namespace ListaDeCompras.Utils;

using ListaDeCompras.Models;

public class Utilitatios
{
    // private List<Itens> lista;

    // public Conversor(List<Itens> listaInicial)
    // {
    //     lista = listaInicial;
    // }
    public static int ConverterParaInt()
    {
        int intResponse = 0;
        bool Valido = false;
        do
        {
            string? response = Utilitatios.ResponseIsNull();
            if (response.ToLower().Trim() == "voltar") { throw new Exception("Voltando ao menu anterior..."); }            
            Valido = int.TryParse(response, out intResponse);

            if (Valido != true)
            {
                Console.WriteLine("Número inválido");

            }
            //lista.Lenght está pegando todos os numeros
            // else if (intResponse > lista.Count || intResponse <= 0)
            // {
            //    throw new IndexOutOfRangeException($"O número digitado ({intResponse}) não faz parte da lista ");

            // }
        } while (Valido != true);
        return intResponse;
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