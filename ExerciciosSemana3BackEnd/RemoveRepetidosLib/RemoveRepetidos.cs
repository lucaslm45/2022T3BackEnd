using System.Collections.Generic;

namespace BackEnd.Semana3.Exercicio4
{
    public static class MetodosDeExtensao
    {
        public static List<T> RemoveRepetidos<T>(this List<T> lista)
        {
            return lista.Distinct().ToList();
        }
    }
    public class TestaRemocaoRepetidos
    {
        public static void Main(string[] args)
        {
            Clientes c1 = new("LUCAS", 09901729963);
            Clientes c2 = new("LUCAS", 09901729963);

            List<Clientes> clientes = new List<Clientes>();
            clientes.Add(c1);
            clientes.Add(c2);

            foreach (Clientes cli in clientes)
            {
                cli.Imprime();
            }
        }
    }
}