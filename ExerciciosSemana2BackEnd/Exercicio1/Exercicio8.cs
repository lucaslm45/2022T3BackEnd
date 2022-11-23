using BackEnd.Semana2.Excecoes;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace BackEnd.Semana2.Exercicio8
{
    public class Pessoa
    {
        /*private string nome;
        private long cpf;
        private DateTime nascimento;
        private float rendaMensal;
        private char estadoCivil;
        private int dependentes;*/

        public string Nome { get; set; }
        public long CPF { get; set; }
        public DateTime Nascimento { get; set; }
        public float RendaMensal { get; set; }
        public char EstadoCivil { get; set; }
        public int Dependentes { get; set; }

        public Pessoa() { }

        public Pessoa(string nome, long cpf, DateTime nascimento, float renda, char estadoCivil, int dependentes)
        {
            Nome = nome;
            CPF = cpf;
            Nascimento = nascimento;
            RendaMensal = renda;
            EstadoCivil = estadoCivil;
            Dependentes = dependentes;
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


    }
    public class FazPessoa
    {
        private List<ExcecaoCampoComValorIncorreto> excecoes;
        private Pessoa pessoaCriada;

        public FazPessoa()
        {
            excecoes = new List<ExcecaoCampoComValorIncorreto>();
            pessoaCriada = new Pessoa();

            while (!TudoOk)
            {
                SolicitaInfos();
            }
            pessoaCriada.Imprime();
        }
        public List<ExcecaoCampoComValorIncorreto> Excecoes { get; private set; }
        public Pessoa PessoaCriada { get; private set; }
        public Container DadosPessoa { get; private set; }

        public bool DadosValidos { get; private set; }
        public bool NomeOk { get; private set; }
        public bool CpfOk { get; private set; }
        public bool NascimentoOk { get; private set; }
        public bool RendaOk { get; private set; }
        public bool EstadoCivilOk { get; private set; }
        public bool DependentesOk { get; private set; }
        public bool TudoOk { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Nascimento { get; private set; }
        public string RendaMensal { get; private set; }
        public string EstadoCivil { get; private set; }
        public string Dependentes { get; private set; }

        public void SolicitaInfos()
        {
            if (!NomeOk)
            {
                Console.Write("Digite o nome da pessoa: ");
                Nome = Console.ReadLine();
            }
            if (!CpfOk)
            {
                Console.Write("Digite o CPF da pessoa: ");
                CPF = Console.ReadLine();
            }
            if (!NascimentoOk)
            {
                Console.Write("Digite a Data de Nascimento (DD/MM/AAAA) da pessoa: ");
                Nascimento = Console.ReadLine();
            }
            if (!RendaOk)
            {
                Console.Write("Digite a Renda Mensal da pessoa: ");
                RendaMensal = Console.ReadLine();
            }
            if (!EstadoCivilOk)
            {
                Console.Write("Digite o Estado Cívil (C, S, V ou D) da pessoa: ");
                EstadoCivil = Console.ReadLine();
            }
            if (!DependentesOk)
            {
                Console.Write("Digite o número de dependentes (0 a 10) da pessoa: ");
                Dependentes = Console.ReadLine();
            }
            ValidaCampos();
        }
        public void ValidaCampos()
        {
            excecoes.Clear();
            try
            {
                if (!NomeOk)
                {
                    if (Nome.Length < 5)
                    {
                        excecoes.Add(new ExcecaoCampoComValorIncorreto("Nome", Nome));
                    }
                    else
                    {
                        NomeOk = true;
                        pessoaCriada.Nome = Nome;
                    }

                }
                if (!CpfOk)
                {
                    CPF = Regex.Replace(CPF, "[^0-9]+", "", RegexOptions.Compiled);

                    if (CPF.Length != 11)
                    {
                        excecoes.Add(new ExcecaoCampoComValorIncorreto("CPF", CPF));
                    }
                    else
                    {
                        CpfOk = true;
                        pessoaCriada.CPF = Convert.ToInt64(CPF);
                    }
                }
                if (!NascimentoOk)
                {
                    DateTime nascimento;

                    if (!(DateTime.TryParse(Nascimento, out nascimento)))
                    {
                        excecoes.Add(new ExcecaoCampoComValorIncorreto("Data de Nascimento", Nascimento));
                    }
                    else
                    {
                        if (Convert.ToDateTime(nascimento).AddYears(18) < DateTime.Now)
                        {
                            NascimentoOk = true;
                            pessoaCriada.Nascimento = nascimento;
                        }
                        else
                        {
                            excecoes.Add(new ExcecaoCampoComValorIncorreto("Data de Nascimento", Nascimento));
                        }
                    }
                }
                if (!RendaOk)
                {
                    float renda;

                    if (float.TryParse(RendaMensal, out renda))
                    {
                        RendaOk = true;
                        pessoaCriada.RendaMensal = (float)Math.Round(renda, 2);
                    }
                    else
                    {
                        excecoes.Add(new ExcecaoCampoComValorIncorreto("Renda Mensal", RendaMensal));
                    }
                }
                if (!EstadoCivilOk)
                {
                    EstadoCivil = EstadoCivil.ToUpper();

                    if (EstadoCivil == "C" || EstadoCivil == "S" || EstadoCivil == "V" || EstadoCivil == "D")
                    {
                        EstadoCivilOk = true;
                        pessoaCriada.EstadoCivil = Convert.ToChar(EstadoCivil);
                    }
                    else
                    {
                        excecoes.Add(new ExcecaoCampoComValorIncorreto("Estado Cívil", EstadoCivil));
                    }
                }
                if (!DependentesOk)
                {
                    int dependentes;

                    if (int.TryParse(Dependentes, out dependentes) && (dependentes >= 0 && dependentes <= 10))
                    {
                        DependentesOk = true;
                        pessoaCriada.Dependentes = dependentes;
                    }
                    else
                    {
                        excecoes.Add(new ExcecaoCampoComValorIncorreto("Dependentes", Dependentes));
                    }
                }

                if (excecoes.Count > 0)
                {
                    throw new AggregateException(excecoes);
                }
                else
                {
                    TudoOk = true;
                }
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
    public class TestaPessoa
    {
        public static void Main(string[] args)
        {
            FazPessoa p1 = new();
        }
    }
}