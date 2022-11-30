using BackEnd.Semana3.Exercicio3;
public class FazTesteArmstrong
{
    public static void Main(string[] args)
    {
        for (int i = 1; i <= 10000; i++)
        {
            if (i.IsArmstrong())
            {
                Console.WriteLine($"O número {i} é um número de Armstrong? {i.IsArmstrong()}");
            }
        }

    }
}