using BackEnd.Semana1.Excecoes;

namespace BackEnd.Semana1.Exercicio5
{
    public class Intervalo
    {
        DateTime DataHoraInicial, DataHoraFinal;
        TimeSpan Duracao;
        public Intervalo(DateTime inicial, DateTime final)
        {
            try
            {
                if (inicial > final)
                {
                    throw new ExcecaoDataInicialFinalInvalida();
                }
                DataHoraInicial = inicial;
                DataHoraFinal = final;
                Duracao = DataHoraFinal.Subtract(DataHoraInicial);
            }
            catch (ExcecaoDataInicialFinalInvalida ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public TimeSpan GetDuracao()
        {
            return Duracao;
        }
        public DateTime GetDataHoraInicial()
        {
            return DataHoraInicial;
        }
        public DateTime GetDataHoraFinal()
        {
            return DataHoraFinal;
        }
        public bool VerificaDataHora(Intervalo value)
        {
            if (GetDuracao() == value.Duracao)
            {
                return true;
            }
            return false;
        }
        public bool TemIntersecao(Intervalo value)
        {
            //https://stackoverflow.com/questions/13513932/algorithm-to-detect-overlapping-periods
            return DataHoraInicial < value.GetDataHoraFinal() && value.GetDataHoraInicial() < DataHoraFinal;
        }
    }
    class FazIntervalo
    {
        public static void Main(string[] args)
        {
            DateTime date1 = new DateTime(1996, 6, 3, 22, 00, 0);
            DateTime date2 = new DateTime(1996, 6, 3, 23, 00, 0);
            DateTime date3 = new DateTime(1996, 6, 3, 22, 00, 0);
            DateTime date4 = new DateTime(1996, 6, 3, 23, 00, 0);


            Intervalo i1 = new(date1, date2);
            Intervalo i2 = new(date3, date4);
            Console.WriteLine($"Valor: {i1.GetDataHoraInicial()}");
            Console.WriteLine($"Valor: {i1.GetDataHoraFinal()}");

            Console.WriteLine($"Valor: {i2.GetDataHoraInicial()}");
            Console.WriteLine($"Valor: {i2.GetDataHoraFinal()}");

            Console.WriteLine($"Valor: {i1.TemIntersecao(i2)}");

            Console.WriteLine($"Valor: {i1.VerificaDataHora(i2)}");


        }
    }
}