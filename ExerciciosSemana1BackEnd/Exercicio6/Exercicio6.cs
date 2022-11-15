using BackEnd.Semana1.Exercicio5;

namespace BackEnd.Semana1.Exercicio6
{
    public class DateTimeComparer : IComparer<DateTime?>
    {
        public int Compare(DateTime? x, DateTime? y)
        {
            DateTime nx = x ?? DateTime.MaxValue;
            DateTime ny = y ?? DateTime.MaxValue;

            return nx.CompareTo(ny);
        }
    }
    public class ListaIntervalo
    {
        List<Intervalo> intervalos;

        DateTime inicialMin;
        DateTime finalMax;

        public ListaIntervalo(List<Intervalo> _intervalos)
        {
            intervalos = new List<Intervalo>(_intervalos);

            inicialMin = DateTime.MaxValue;
            finalMax = DateTime.MinValue;
            //if (intervalos.Count > 0)
            //{
            //    inicialMin = DateTime.MaxValue;
            //    finalMax = DateTime.MinValue;
            //}
            //else
            //{
            //    inicialMin = DateTime.MinValue;
            //    finalMax = DateTime.MinValue;
            //}

            foreach (Intervalo intervalo in intervalos)
            {
                if (intervalo.GetDataHoraInicial() < inicialMin)
                {
                    inicialMin = intervalo.GetDataHoraInicial();
                }
                if (intervalo.GetDataHoraFinal() > finalMax)
                {
                    finalMax = intervalo.GetDataHoraFinal();
                }
            }
        }
        public void AddInvervalo(Intervalo value)
        {
            try
            {
                foreach (Intervalo intervalo in intervalos)
                {
                    if (intervalo.TemIntersecao(value))
                    {
                        return;
                    }
                }
                intervalos.Add(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Imprime()
        {
            foreach (Intervalo item in intervalos)
            {
                Console.WriteLine($"Antes: {item.GetDataHoraInicial()}, {item.GetDataHoraFinal()}");
            }
            Console.WriteLine("");
            intervalos.Sort((x, y) => (x.GetDataHoraInicial()).CompareTo(y.GetDataHoraInicial()));

            foreach (Intervalo item in intervalos)
            {
                Console.WriteLine($"Depois: {item.GetDataHoraInicial()}, {item.GetDataHoraFinal()}");
            }
        }
    }
    public class FazListaIntervalo
    {
        public static void Main(string[] args)
        {
            DateTime date1 = new DateTime(1996, 6, 3, 22, 00, 0);
            DateTime date2 = new DateTime(1996, 6, 3, 23, 00, 0);
            DateTime date3 = new DateTime(1996, 6, 3, 20, 00, 0);
            DateTime date4 = new DateTime(1996, 6, 3, 21, 00, 0);
            DateTime date5 = new DateTime(1995, 6, 3, 20, 00, 0);
            DateTime date6 = new DateTime(1995, 6, 3, 21, 00, 0);

            Intervalo i1 = new(date1, date2);
            Intervalo i2 = new(date3, date4);
            Intervalo i3 = new(date5, date6);

            List<Intervalo> l1 = new List<Intervalo>();

            ListaIntervalo lista1 = new(l1);

            lista1.AddInvervalo(i1);
            lista1.AddInvervalo(i3);
            lista1.AddInvervalo(i2);

            lista1.Imprime();
        }
    }
}