namespace BackEnd.Semana1.Excecoes;

[Serializable]
public class ValorInvalidoPiramideException : Exception
{
    public ValorInvalidoPiramideException() { }

    public ValorInvalidoPiramideException(int N)
        : base(string.Format($"Valor inválido de N (N = {N})"))
    {

    }
}
public class ValoresInvalidosTrianguloException : SystemException
{
    public ValoresInvalidosTrianguloException() { }

    public ValoresInvalidosTrianguloException(double _x, double _y, double _z)
        : base(string.Format($"Os valores do vertice ({_x}, {_y}, {_z}) não formam um Triangulo"))
    {

    }
}