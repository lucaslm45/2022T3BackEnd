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
        private double perimetro, a, b, c, area;

        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }
        public double Area
        {
            get { return area; }
            private set
            {
                double S = value / 2;
                area = Math.Sqrt(S * (S - A) * (S - B) * (S - C));
            }
        }

        public TrianguloTipo Tipo { get; private set; }

        public double Perimetro { get; private set; }

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
                Tipo = TrianguloTipo.Nenhum;
                ValidaXYZ(this);

                A = this.vertices[0].Distancia(this.vertices[1]);
                B = this.vertices[1].Distancia(this.vertices[2]);
                C = this.vertices[2].Distancia(this.vertices[0]);

                Perimetro = A + B + C;
                Area = Perimetro;
                Tipo = FormatoTriangulo();
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

        public void TestaTriangulo(Triangulo _triangulo)
        {
            double x = _triangulo.vertices[0].Distancia(_triangulo.vertices[1]);
            double y = _triangulo.vertices[1].Distancia(_triangulo.vertices[2]);
            double z = _triangulo.vertices[2].Distancia(_triangulo.vertices[0]);

            if (x == A && y == B && x == C)
            {
                Console.WriteLine($"O Triangulo ({x}, {y}, {z}) é igual ao ({A}, {B}, {C})");
                return;
            }
            Console.WriteLine($"O Triangulo ({x}, {y}, {z}) não é igual ao ({A}, {B}, {C})");
        }

        TrianguloTipo FormatoTriangulo()
        {
            if (A == B && B == C)
            {
                return TrianguloTipo.Equilatero;
            }
            else if (A == B || A == C || B == C)
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
            Console.WriteLine($"Valor: {t1.Perimetro}");
            Console.WriteLine($"Valor: {t1.Area}");
            //Console.WriteLine($"Valor: {t1.GetA()}");
            //Console.WriteLine($"Valor: {t1.GetB()}");
            //Console.WriteLine($"Valor: {t1.GetC()}");
        }
    }
}
