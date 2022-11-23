using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace BackEnd.Semana2.Exercicio13
{
    public abstract class Progressao
    {
        protected int proximoValor;
        protected Progressao(int p, int r)
        {
            Primeiro = p;
            Razao = r;
            ProximoValor = p;
        }
        public int Primeiro { get; set; }
        public int Razao { get; set; }
        public abstract int ProximoValor { get; protected set; }

        public abstract int TermoAt(int index);
        /*
            é um método abstrato que retorna o termo da progressão que está na posição
                indicada, iniciando na posição 1.
         */
        public abstract void Imprime();

        public void Reinicializar()
        {
            ProximoValor = Primeiro;
        }
    }
    public class ProgressaoAritmetica : Progressao
    {
        public ProgressaoAritmetica(int p, int r)
            : base(p, r)
        {
        }
        public override int ProximoValor { get; protected set; }
        public override int TermoAt(int index)
        {
            return (Primeiro + Razao * (index - 1));
        }
        public override void Imprime()
        {
            Reinicializar();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Termo {i + 1}: {ProximoValor}");
                ProximoValor += Razao;
            }
        }
    }
    public class ProgressaoGeometrica : Progressao
    {
        public ProgressaoGeometrica(int p, int r)
            : base(p, r)
        {

        }
        public override int ProximoValor { get; protected set; }

        public override int TermoAt(int index)
        {
            return Primeiro * (int)Math.Pow(Razao, index - 1);
        }
        public override void Imprime()
        {
            Reinicializar();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Termo {i + 1}: {ProximoValor}");
                ProximoValor *= Razao;
            }
        }
    }
    public class FazProgressoes
    {
        public static void Main(string[] args)
        {
            ProgressaoAritmetica PA = new(3, 4);
            ProgressaoGeometrica PG = new(3, 4);

            PA.Imprime();
            Console.WriteLine("");
            int i = 9;
            Console.WriteLine($"Termo {i}: {PA.TermoAt(i)}");
            Console.WriteLine("");


            PG.Imprime();
            Console.WriteLine("");

            Console.WriteLine($"Termo {i}: {PG.TermoAt(i)}");

        }
    }
}
