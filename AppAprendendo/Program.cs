using System.Collections;


var diaDaSemana = new DiasDaSemana();
void PercorrendoComEnumeratorComWhile()
{
    var enumerator = diaDaSemana.GetEnumerator();
    while (enumerator.MoveNext())
    {
        var dia = enumerator.Current;
        Console.WriteLine(dia);
    }
}

void PercorrendoDiasDaSemanaComFor()
{
    

    foreach (string dia in diaDaSemana)
    {
        Console.WriteLine(dia);

    }
}

Console.WriteLine("Primeiro chama com for");
PercorrendoDiasDaSemanaComFor();
Console.WriteLine("Segundo chama com While");
PercorrendoComEnumeratorComWhile();
Console.WriteLine("Numero Pares");

var pares = NumeroPares(20);

foreach (var par in pares) Console.WriteLine(par);
IEnumerable<int> NumeroPares(int limite)
{
    var lista = new List<int>();
    for (int i = 0; i < limite; i++)
    {
        lista.Add(i * 2);
    }
    return lista;
}

class DiasDaSemanaEnumerator : IEnumerator<string>
{
    private int posicao = -1;
    private string[] dias = { "Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado" };

    public string Current => dias[posicao];

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        posicao++;
        return posicao < dias.Length;
    }

    public void Reset()
    {
        posicao = -1;
    }
}

class DiasDaSemana : IEnumerable<string>
{
    public IEnumerator<string> GetEnumerator()
    {
        yield return "Domingo";
        yield return "Segunda";
        yield return "Terça";
        yield return "Quarta";
        yield return "Quinta";
        yield return "Sexta";
        yield return "Sábado";
        //return new DiasDaSemanaEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}







