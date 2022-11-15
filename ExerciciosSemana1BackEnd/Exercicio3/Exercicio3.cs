using BackEnd.Semana1.Exercicio2;
using BackEnd.Semana1.Excecoes;

namespace BackEnd.Semana1.Exercicio3
{
    public enum TrianguloTipo
    {
        Equilatero,
        Isosceles,
        Escaleno,
        Nenhum
    }
    public class Triangulo
    {
        double a, b, c, perimetro, area;

        TrianguloTipo tipo;

        Vertice[] vertices;

        public Triangulo(Vertice[] _vertices)
        {
            vertices = new Vertice[3];

            try
            {
                for (int i = 0; i < _vertices.Length; i++)
                {
                    vertices[i] = _vertices[i];
                }
                tipo = TrianguloTipo.Nenhum;
                ValidaXYZ(this);

                a = this.vertices[0].Distancia(this.vertices[1]);
                b = this.vertices[1].Distancia(this.vertices[2]);
                c = this.vertices[2].Distancia(this.vertices[0]);

                perimetro = Perimetro();
                area = Area();
                tipo = FormatoTriangulo();
            }
            catch (ExcecaoValoresInvalidosTriangulo ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void ValidaXYZ(Triangulo _triangulo)
        {
            double a, b, c;

            if (_triangulo.vertices.Length < 3)
            {
                throw new ExcecaoValoresInvalidosTriangulo();
            }
            else
            {
                a = _triangulo.vertices[0].Distancia(_triangulo.vertices[1]);
                b = _triangulo.vertices[1].Distancia(_triangulo.vertices[2]);
                c = _triangulo.vertices[2].Distancia(_triangulo.vertices[0]);

                if (a + b <= c || a + c <= b || c + b <= a)
                {
                    throw new ExcecaoValoresInvalidosTriangulo(a, b, c);
                }
            }
        }
        public double GetA()
        {
            return a;
        }
        public double GetB()
        {
            return b;
        }
        public double GetC()
        {
            return c;
        }
        public double GetPerimetro()
        {
            return perimetro;
        }
        public double GetArea()
        {
            return area;
        }
        public TrianguloTipo GetTipo()
        {
            return tipo;
        }

        public void TestaTriangulo(Triangulo _triangulo)
        {
            double x = _triangulo.vertices[0].Distancia(_triangulo.vertices[1]);
            double y = _triangulo.vertices[1].Distancia(_triangulo.vertices[2]);
            double z = _triangulo.vertices[2].Distancia(_triangulo.vertices[0]);

            if (x == GetA() && y == GetB() && x == GetC())
            {
                Console.WriteLine($"O Triangulo ({x}, {y}, {z}) é igual ao ({GetA()}, {GetB()}, {GetC()})");
                return;
            }
            Console.WriteLine($"O Triangulo ({x}, {y}, {z}) não é igual ao ({GetA()}, {GetB()}, {GetC()})");
        }
        double Perimetro()
        {
            return GetA() + GetB() + GetC();
        }
        double Area()
        {
            double S = Perimetro() / 2;
            return Math.Sqrt(S * (S - GetA()) * (S - GetB()) * (S - GetC()));
        }

        TrianguloTipo FormatoTriangulo()
        {
            double x = GetA();
            double y = GetB();
            double z = GetC();

            if (x == y && y == z)
            {
                return TrianguloTipo.Equilatero;
            }
            else if (x == y || x == z || y == z)
            {
                return TrianguloTipo.Isosceles;
            }
            else
            {
                return TrianguloTipo.Escaleno;
            }
        }
    }
    class FazTriangulo
    {
        public static void Main(string[] args)
        {
            Vertice v1 = new(0, 0);
            Vertice v2 = new(4, 7);
            Vertice v3 = new(8, 0);

            Vertice[] _vertices = new Vertice[] { v1, v2, v3 };
            Triangulo t1 = new(_vertices);
            Console.WriteLine($"Valor: {t1.GetPerimetro()}");
            //Console.WriteLine($"Valor: {t1.GetA()}");
            //Console.WriteLine($"Valor: {t1.GetB()}");
            //Console.WriteLine($"Valor: {t1.GetC()}");
        }
    }
}
