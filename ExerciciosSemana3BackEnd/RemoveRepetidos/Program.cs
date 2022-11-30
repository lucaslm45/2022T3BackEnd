namespace BackEnd.Semana3.Exercicio4
{
    public class TestaRemocaoRepetidos
    {
        public static void Main(string[] args)
        {
            Clientes c1 = new("LUCAS", 123456789);
            Clientes c2 = new("LUCAS", 123456789);
            Clientes c3 = new("LUCAS", 123456789);

            List<Clientes> clientes = new() { c1, c2, c3 };

            foreach (Clientes cli in clientes)
            {
                cli.Imprime();
            }

            Console.WriteLine("");
            clientes = clientes.RemoveRepetidos();

            foreach (Clientes cli in clientes)
            {
                cli.Imprime();
            }
        }
    }
}