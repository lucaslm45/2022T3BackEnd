namespace BackEnd.Semana1.Exercicio2
{
    public class Vertice
    {
        double x, y;

        public Vertice() { }

        public Vertice(double _x, double _y)
        {
            x = _x;
            y = _y;
        }
        public double GetX()
        {
            return x;
        }

        public double GetY()
        {
            return y;
        }
        protected void SetX(double _x)
        {
            x = _x;
        }
        protected void SetY(double _y)
        {
            y = _y;
        }
        public double Distancia(Vertice _vertice)
        {
            return Math.Sqrt((Math.Pow(_vertice.GetX() - x, 2) + Math.Pow(_vertice.GetY() - y, 2)));
            //Console.WriteLine($"A distância euclidiana entre ({_vertice.GetX()}, {_vertice.GetY()}) e ({x}, {y}) é: {distancia:0.00}");
        }
        public void Move(double _x, double _y)
        {
            double auxX = x;
            double auxY = y;

            SetX(_x);
            SetY(_y);

            Console.WriteLine($"O Vertice era ({auxX}, {auxY}) e mudou para ({x}, {y})");

        }
        public virtual void TestaVertice(Vertice _vertice)
        {
            if (_vertice.GetX() == x && _vertice.GetY() == y)
            {
                Console.WriteLine($"O Vertice ({_vertice.GetX()}, {_vertice.GetY()}) é igual ao ({x}, {y})");
                return;
            }
            Console.WriteLine($"O Vertice ({_vertice.GetX()}, {_vertice.GetY()}) não é igual ao ({x}, {y})");
        }
    }
    class FazVertice
    {
        public static void Main(string[] args)
        {
            Vertice v1 = new(2.2, 8.1);
            Vertice v2 = new(2.1, 3.2);
            Vertice v3 = new(2.1, 3.2);

            v1.Distancia(v2);
            v1.Move(v2.GetX(), v2.GetY());
            v2.TestaVertice(v3);
        }
    }


}
