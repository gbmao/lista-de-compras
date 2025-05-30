namespace ListaDeCompras.Models;
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
            return "Comprado";
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