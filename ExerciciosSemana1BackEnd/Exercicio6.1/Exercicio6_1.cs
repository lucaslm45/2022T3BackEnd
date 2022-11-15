using BackEnd.Semana1.Exercicio5;

namespace BackEnd.Semana1.Exercicio6_1
{
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
        private void UpMinMaxInvervalo(Intervalo value)
        {
            if (value.GetDataHoraInicial() < inicialMin)
            {
                inicialMin = value.GetDataHoraInicial();
            }
            if (value.GetDataHoraFinal() > finalMax)
            {
                finalMax = value.GetDataHoraFinal();
            }
        }

        public void AddInvervalo(Intervalo value)
        {
            Intervalo periodoBloqueado = new(inicialMin, finalMax);

            if (!periodoBloqueado.TemIntersecao(value))
            {
                intervalos.Add(value);
                UpMinMaxInvervalo(value);
            }
        }
    }
    public class FazListaIntervalo
    {
        public static void Main(string[] args)
        {
            DateTime date1 = new DateTime(1996, 6, 3, 22, 00, 0);
            DateTime date2 = new DateTime(1996, 6, 3, 23, 00, 0);

            Intervalo intervalo = new(date1, date2);

            List<Intervalo> l1 = new List<Intervalo>();

            ListaIntervalo lista1 = new(l1);

            lista1.AddInvervalo(intervalo);
        }
    }
}