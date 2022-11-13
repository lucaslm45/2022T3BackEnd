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
    public class Triangulo : Vertice
    {
        double z, perimetro, area;

        TrianguloTipo tipo;

        public Triangulo(double _x, double _y, double _z)
            : base(_x, _y)
        {
            try
            {
                z = _z;
                tipo = TrianguloTipo.Nenhum;
                ValidaXYZ(this);
                perimetro = Perimetro();
                area = Area();
                tipo = FormatoTriangulo();
            }
            catch (ValoresInvalidosTrianguloException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public double GetZ()
        {
            return z;
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
        public static void ValidaXYZ(Triangulo _triangulo)
        {
            double x = _triangulo.GetX();
            double y = _triangulo.GetY();
            double z = _triangulo.GetZ();

            if (x + y <= z || x + z <= y || z + y <= x)
            {
                throw new ValoresInvalidosTrianguloException(x, y, z);
            }
        }
        public void TestaTriangulo(Triangulo _triangulo)
        {
            if (_triangulo.GetX() == GetX() && _triangulo.GetY() == GetY() && _triangulo.GetZ() == z)
            {
                Console.WriteLine($"O Triangulo ({_triangulo.GetX()}, {_triangulo.GetY()}, {_triangulo.GetZ()}) é igual ao ({GetX()}, {GetY()}, {z})");
                return;
            }
            Console.WriteLine($"O Triangulo ({_triangulo.GetX()}, {_triangulo.GetY()}, {_triangulo.GetZ()}) não é igual ao ({GetX()}, {GetY()}, {z})");
        }
        private double Perimetro()
        {
            return GetX() + GetY() + z;
        }
        private double Area()
        {
            double S = Perimetro() / 2;
            return Math.Sqrt(S * (S - GetX()) * (S - GetY()) * (S - z));
        }

        private TrianguloTipo FormatoTriangulo()
        {
            if (GetX() == GetY() && GetY() == z)
            {
                return TrianguloTipo.Equilatero;
            }
            else if (GetX() == GetY() || GetX() == z || GetY() == z)
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
            Triangulo t1 = new(2, 3, 2);
            Console.WriteLine($"Valor: {t1.GetTipo()}");
        }
    }
}
