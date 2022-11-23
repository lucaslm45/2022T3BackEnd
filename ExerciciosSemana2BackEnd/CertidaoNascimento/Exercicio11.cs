using BackEnd.Semana2.Excecoes;

namespace BackEnd.Semana2.Exercicio11
{
    public class CertidaoNascimento : Pessoa
    {
        public CertidaoNascimento(DateTime dataEmissao, string Nome)
            : base(Nome)
        {
            DataEmissao = dataEmissao;
        }

        public DateTime? DataEmissao { get; private set; }
    }
    public class Pessoa
    {
        public Pessoa(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
        public CertidaoNascimento? Certidao { get; private set; }
        public void AdicionarCertidao(DateTime emissao)
        {
            try
            {
                if (Certidao != null)
                {
                    throw new ExcecaoPessoaPossuiCertidao();
                }
                Certidao = new CertidaoNascimento(emissao, Nome);
            }
            catch (ExcecaoPessoaPossuiCertidao ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    public class FazPessoa
    {
        public static void Main(string[] args)
        {
            Pessoa p1 = new("Lucas de Lima");
            DateTime emissao = DateTime.Now;
            DateTime emissao2 = DateTime.MinValue;


            Console.WriteLine($"Nome {p1.Nome}");
            //Console.WriteLine($"{p1.Certidao.DataEmissao}");
            p1.AdicionarCertidao(emissao);
            Console.WriteLine($"{p1.Certidao.DataEmissao}");
        }
    }
}
