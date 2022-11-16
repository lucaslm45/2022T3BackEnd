using BackEnd.Semana1.Excecoes;

namespace BackEnd.Semana1.Exercicio1
{
    public class Piramide
    {
        int N;

        public Piramide(int _N)
        {
            try
            {
                ValidaN(_N);
                N = _N;
            }
            catch (ExcecaoValorInvalidoPiramide ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public int GetN()
        {
            return N;
        }
        private void ValidaN(int _N)
        {
            if (_N < 1)
                throw new ExcecaoValorInvalidoPiramide(_N);
        }
        public void Desenha()
        {
            //Refs: https://www.c-sharpcorner.com/blogs/creating-pyramid-in-c-sharp1
            int espacos, numero;
            for (int i = 1; i <= N; i++) // Número de camadas da piramide
            {
                for (espacos = 1; espacos <= (N - i); espacos++) // Desenha Espacos
                    Console.Write(" ");
                for (numero = 1; numero <= i; numero++) //Incrementa o valor
                    Console.Write(numero);
                for (numero = (i - 1); numero >= 1; numero--) //Decrementa o valor
                    Console.Write(numero);
                Console.WriteLine();
            }
        }
    }
    public class FazPiramide
    {
        public static void Main(string[] args)
        {
            Piramide p = new(-1);
            p.Desenha();
        }
    }
}