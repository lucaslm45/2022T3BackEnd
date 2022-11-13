namespace BackEnd.Semana1.Exercicio1
{
    [Serializable]
    class InvalidPiramideValueException : Exception
    {
        public InvalidPiramideValueException() { }

        public InvalidPiramideValueException(int N)
            : base(string.Format($"Valor inválido de N (N = {N})"))
        {

        }
    }
    public class Piramide
    {
        int N;

        public Piramide(int _N)
        {
            try
            {
                N = _N;

                ValidaN(_N);
            }
            catch (InvalidPiramideValueException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public int GetN()
        {
            return N;
        }
        private static void ValidaN(int _N)
        {
            if (_N < 1)
                throw new InvalidPiramideValueException(_N);
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