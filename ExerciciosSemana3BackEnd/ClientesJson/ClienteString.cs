
using System.Text.RegularExpressions;

namespace BackEnd.Semana3.Exercicio1.ClientesString
{
    public class ClienteString
    {
        public ClienteString()
        {
        }
        public string? Nome { get; set; }

        private string? cpf;
        public string? CPF
        {
            get
            {
                return cpf;
            }
            set
            {
                cpf = Regex.Replace(value, "[^0-9]+", "", RegexOptions.Compiled);
            }
        }
        public string? Nascimento { get; set; }
        public string? RendaMensal { get; set; }

        private string? estadoCivil;
        public string? EstadoCivil
        {
            get
            {
                return estadoCivil;
            }
            set
            {
                estadoCivil = value.ToUpper();
            }
        }
        public string? Dependentes { get; set; }

        public override bool Equals(object? obj)
        {
            return obj != null && GetType() == obj.GetType() && (CPF == ((ClienteString)obj).CPF);
        }
    }

    public class ClienteStringSaida
    {
        public ClienteStringSaida()
        {
            dados = new ClienteString();
            erros = new List<object>();

        }
        public ClienteString dados { get; set; }

        public List<object> erros { get; set; }

    }
    public class Name
    {
        public Name(string erro)
        {
            nome = erro;
        }
        public string nome { get; set; }
    }
    public class CPF
    {
        public CPF(string erro)
        {
            cpf = erro;
        }
        public string cpf { get; set; }
    }
    public class Nascimento
    {
        public Nascimento(string erro)
        {
            dt_nascimento = erro;
        }
        public string dt_nascimento { get; set; }
    }
    public class Renda
    {
        public Renda(string erro)
        {
            renda_mensal = erro;
        }
        public string renda_mensal { get; set; }
    }
    public class EstadoCivil
    {
        public EstadoCivil(string erro)
        {
            estado_civil = erro;
        }
        public string estado_civil { get; set; }
    }
    public class Dependentes
    {
        public Dependentes(string erro)
        {
            dependentes = erro;
        }
        public string dependentes { get; set; }
    }


}
