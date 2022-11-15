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
                N = _N;

                ValidaN();
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
        private void ValidaN()
        {
            if (N < 1)
                throw new ExcecaoValorInvalidoPiramide(N);
        }
        public void Desenha()
        {
            int[] values = new int[N - 1];

            //for(int i = 0; i <)

        }

    }
    class FazPiramide
    {
        public static void Main(string[] args)
        {
            Piramide p = new(0);
            Console.WriteLine(p.GetN());
        }
    }
}