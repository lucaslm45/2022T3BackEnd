using BackEnd.Semana2.Excecoes;
using System.Numerics;

namespace BackEnd.Semana2.Exercicio12
{
    public class CarrosAtivos
    {
        public CarrosAtivos()
        {
            Motores = new List<Motor>();
            Carros = new List<Carro>();
            Excecoes = new List<Exception>();
        }
        public List<Motor> Motores { get; set; }
        public List<Carro> Carros { get; set; }
        public List<Exception> Excecoes { get; set; }

        public void AdicionarCarro(Carro carro)
        {
            Excecoes.Clear();
            try
            {
                if (Carros.Contains(carro))
                {
                    Excecoes.Add(new ExcecaoCarroExiste(carro.Modelo, carro.Placa));
                }
                if (Motores.Contains(carro.Motor))
                {
                    Excecoes.Add(new ExcecaoMotorEmUso(carro.Modelo, carro.Placa));
                }

                if (Excecoes.Count > 0)
                {
                    throw new AggregateException(Excecoes);
                }
                Carros.Add(carro);
                Motores.Add(carro.Motor);
            }
            catch (AggregateException aEx)
            {
                foreach (var ex in aEx.InnerExceptions)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }
    }
    public class Motor
    {
        public Motor(double cilindrada)
        {
            Cilindrada = cilindrada;
        }
        public double Cilindrada { get; private set; }
        public override bool Equals(object? obj)
        {
            return obj != null && GetType() == obj.GetType() && (Cilindrada == ((Motor)obj).Cilindrada);
        }

    }
    public class Carro : Motor
    {
        public Carro(string placa, string modelo, Motor? motor)
            : base(motor.Cilindrada)
        {
            Placa = placa;
            Modelo = modelo;
            Motor = motor;
        }
        public string Placa { get; private set; }
        public string Modelo { get; private set; }
        public Motor Motor { get; private set; }
        public override bool Equals(object? obj)
        {
            return obj != null && GetType() == obj.GetType() && (Placa == ((Carro)obj).Placa);
        }
        public void AlterarMotor(Motor motorCarro)
        {
            Motor = motorCarro;
        }
    }
    public class FazCarros
    {
        public static void Main(string[] args)
        {
            CarrosAtivos carros = new();
            Motor m1 = new(1.2);
            Motor m2 = new(1.3);
            //Motor? m2 = null;
            Carro c1 = new("AWB", "Gol", m1);
            Carro c2 = new("AWBD", "Gol", m2);

            carros.AdicionarCarro(c1);
            carros.AdicionarCarro(c2);
            carros.AdicionarCarro(c2);

        }
    }
}