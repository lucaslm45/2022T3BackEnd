namespace BackEnd.Semana1.Exercicio2
{
    public class Vertice
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Vertice(double _x, double _y)
        {
            X = _x;
            Y = _y;
        }
        public double Distancia(Vertice _vertice)
        {
            return Math.Sqrt((Math.Pow(_vertice.X - X, 2) + Math.Pow(_vertice.Y - Y, 2)));
        }
        public void Move(double _x, double _y)
        {
            double auxX = X;
            double auxY = Y;

            X = _x;
            Y = _y;

            Console.WriteLine($"O Vertice era ({auxX}, {auxY}) e mudou para ({X}, {Y})");

        }
        public override bool Equals(object? obj)
        {
            return obj != null && GetType() == obj.GetType() && (X == ((Vertice)obj).X) && (Y == ((Vertice)obj).Y);
            //if (obj == null || GetType() != obj.GetType())
            //{
            //    return false;
            //}
            //return (X == ((Vertice)obj).X) && (Y == ((Vertice)obj).Y);
        }
        public void Imprime()
        {
            Console.WriteLine($"this is {X}, {Y}");
        }
    }
    class FazVertice
    {
        public static void Main(string[] args)
        {
            Vertice v1 = new(2.2, 8.1);
            Vertice v2 = new(2.1, 3.2);
            Vertice v3 = new(2.1, 3.2);
            Vertice v4 = new(2.1, 3.3);

            Console.WriteLine($"v1 is {v1.X}, {v1.Y}");
            Console.WriteLine($"v2 is {v2.X}, {v2.Y}");
            Console.WriteLine($"v3 is {v3.X}, {v3.Y}");

            Console.WriteLine("Movendo v2 para v1");
            v2.Move(v1.X, v1.Y);

            Console.WriteLine($"v2 é igual a v3 = {v2.Equals(v3)}");
            Console.WriteLine($"v2 é igual a v1 = {v2.Equals(v1)}");
            Console.WriteLine($"v2 é igual a v1 = {v2.Equals(v4)}");

        }
    }


}
