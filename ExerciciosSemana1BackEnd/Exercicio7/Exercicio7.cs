using System.ComponentModel;
using System.Text.RegularExpressions;
using BackEnd.Semana1.Exercicio5;

namespace BackEnd.Semana1.Exercicio7
{
    public class Pessoa
    {
        string Nome;
        long CPF;
        DateTime Nascimento;
        float RendaMensal;
        char EstadoCivil;
        int Dependentes;

        public Pessoa()
        {
            SolicitaInfos();
        }
        public Pessoa(string nome, string cpf, string nascimento, string renda, string estadoCivil, string dependentes)
        {
            SetNome(nome);
            SetCPF(cpf);
            SetNascimento(nascimento);
            SetRenda(renda);
            SetEstadoCivil(estadoCivil);
            SetDependentes(dependentes);
        }
        public void SolicitaInfos()
        {
            Console.Write("Digite o nome da pessoa: ");
            SetNome(Console.ReadLine());
            Console.Write("Digite o CPF da pessoa: ");
            SetCPF(Console.ReadLine());
            Console.Write("Digite a Data de Nascimento (DD/MM/AAAA) da pessoa: ");
            SetNascimento(Console.ReadLine());
            Console.Write("Digite a Renda Mensal da pessoa: ");
            SetRenda(Console.ReadLine());
            Console.Write("Digite o Estado Cívil (C, S, V ou D) da pessoa: ");
            SetEstadoCivil(Console.ReadLine());
            Console.Write("Digite o número de dependentes (0 a 10) da pessoa: ");
            SetDependentes(Console.ReadLine());
        }
        public void Imprime()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"CPF: {CPF}");
            Console.WriteLine($"Data de nascimento: {Nascimento}");
            Console.WriteLine($"Renda mensal: {RendaMensal}");
            Console.WriteLine($"Estado civil: {EstadoCivil}");
            Console.WriteLine($"Dependentes: {Dependentes}");
        }
        private void SetNome(string nome)
        {
            while (nome.Length < 5)
            {
                Console.Write("Nome menor que cinco caracteres. Digite novamente: ");
                nome = Console.ReadLine();
            }
            Nome = nome;
        }
        private void SetCPF(string cpf)
        {
            cpf = Regex.Replace(cpf, "[^0-9]+", "", RegexOptions.Compiled);
            while (cpf.Length != 11)
            {
                Console.Write("CPF diferente de 11 números. Digite novamente: ");
                cpf = Regex.Replace(Console.ReadLine(), "[^0-9]+", "", RegexOptions.Compiled);
            }
            CPF = Convert.ToInt64(cpf);
        }
        private void SetNascimento(string dataNascimento)
        {
            DateTime nascimento;
            while (!(DateTime.TryParse(dataNascimento, out nascimento)))
            {
                Console.Write("A data de nascimento não está no formato DD/MM/AAAA. Digite novamente: ");
                dataNascimento = Console.ReadLine();
            }
            DateTime date1 = new DateTime(2000, 6, 3, 22, 00, 0);
            DateTime date2 = new DateTime(2018, 6, 3, 22, 00, 0);

            Intervalo idade18 = new(date1, date2);

            DateTime dataNasc = nascimento;// Convert.ToDateTime(nascimento);
            DateTime hoje = DateTime.Today;

            Intervalo intervalo = new(dataNasc, hoje);

            while (intervalo.GetDuracao() < idade18.GetDuracao())
            {
                Console.Write("A pessoa precisa ter pelo menos 18 anos completos hoje. Digite novamente: ");
                dataNascimento = Console.ReadLine();

                while (!(DateTime.TryParse(dataNascimento, out nascimento)))
                {
                    Console.Write("A data de nascimento não está no formato DD/MM/AAAA. Digite novamente: ");
                    dataNascimento = Console.ReadLine();
                }
                intervalo = new(nascimento, hoje);
            }
            Nascimento = intervalo.GetDataHoraInicial();
        }
        private void SetRenda(string renda)
        {
            float _renda;
            while (!(float.TryParse(renda, out _renda)))
            {
                Console.Write("Não é um número. Digite novamente: ");
                renda = Console.ReadLine();
            }
            RendaMensal = (float)Math.Round(_renda, 2);
        }
        private void SetEstadoCivil(string estadoCivil)
        {
            estadoCivil = estadoCivil.ToUpper();

            while (!(estadoCivil == "C" || estadoCivil == "S" || estadoCivil == "V" || estadoCivil == "D"))
            {
                Console.Write("Não é um Estado Cívil aceito. Digite novamente: ");
                estadoCivil = Console.ReadLine().ToUpper();
            }
            EstadoCivil = Convert.ToChar(estadoCivil);
        }
        private void SetDependentes(string depend)
        {
            int dependentes;
            while (!(int.TryParse(depend, out dependentes) && (dependentes >= 0 && dependentes <= 10)))
            {
                Console.Write("Não é um número ou não é um valor entre 0 e 10. Digite novamente: ");
                depend = Console.ReadLine();
            }
            Dependentes = dependentes;
        }

    }
    public class FazPessoa
    {
        public static void Main(string[] args)
        {
            Pessoa p1 = new("Lucas", "099.017.299-6", "01/08/1997", "1500.256", "C", "1");
            p1.Imprime();

            Pessoa p2 = new();
            p2.Imprime();

        }
    }
}