namespace BackEnd.Semana1.Excecoes;

[Serializable]
public class ExcecaoValorInvalidoPiramide : Exception
{
    public ExcecaoValorInvalidoPiramide(int N)
        : base(string.Format($"Valor inválido de N (N = {N})"))
    {

    }
}
public class ExcecaoValoresInvalidosTriangulo : Exception
{
    public ExcecaoValoresInvalidosTriangulo()
        : base(string.Format("Não forma um Triangulo"))
    {

    }

    public ExcecaoValoresInvalidosTriangulo(double _x, double _y, double _z)
        : base(string.Format($"Os valores do vertice ({_x}, {_y}, {_z}) não formam um Triangulo"))
    {

    }
}

public class ExcecaoQuantidadeInvalidaVertices : Exception
{
    public ExcecaoQuantidadeInvalidaVertices()
        : base(string.Format("A quantidade de vertices é inferior a 3"))
    {

    }
}
public class ExcecaoRemocaoInvalidaVertice : Exception
{
    public ExcecaoRemocaoInvalidaVertice()
        : base(string.Format("A quantidade de vertices é 3, portanto não é possível remover vertices"))
    {

    }
}
public class ExcecaoDataInicialFinalInvalida : Exception
{
    public ExcecaoDataInicialFinalInvalida()
        : base(string.Format("A data e hora inicial é maior que a data e hora final"))
    {

    }
}