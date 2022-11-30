using BackEnd.Semana3.Exercicio1.ClientesString;

namespace BackEnd.Semana3.Exercicio1.Valida
{
    public class Validador
    {
        public Validador()
        {
            ClientesSaida = new List<ClienteStringSaida>();
        }

        public List<ClienteStringSaida> ClientesSaida { get; private set; }

        public void ValidaDados(List<ClienteString> Clientes)
        {
            foreach (ClienteString cli in Clientes)
            {
                ClienteStringSaida saida = new();
                saida.dados = cli;

                if (cli.Nome.Length < 5)
                {
                    saida.erros.Add(new Name("Nome deve ter pelo menos 5 caracteres"));
                }
                if (cli.CPF.Length != 11)
                {
                    saida.erros.Add(new CPF("CPF deve ter 11 numeros"));
                }
                DateTime nascimento;

                if (!(DateTime.TryParse(cli.Nascimento, out nascimento)))
                {
                    saida.erros.Add(new Nascimento("Data de nascimento invalida"));
                }
                else
                {
                    if (!(Convert.ToDateTime(nascimento).AddYears(18) < DateTime.Now))
                    {
                        saida.erros.Add(new Nascimento("Data de nascimento invalida"));
                    }
                }

                float renda;

                if (!float.TryParse(cli.RendaMensal, out renda))
                {
                    saida.erros.Add(new Renda("Nao e um numero"));
                }

                if (!(cli.EstadoCivil == "C" || cli.EstadoCivil == "S" || cli.EstadoCivil == "V" || cli.EstadoCivil == "D"))
                {
                    saida.erros.Add(new EstadoCivil("Estado Civil invalido"));
                }

                int dependentes;

                if (!(int.TryParse(cli.Dependentes, out dependentes) && (dependentes >= 0 && dependentes <= 10)))
                {
                    saida.erros.Add(new Dependentes("Numero de Dependentes invalido"));
                }

                ClientesSaida.Add(saida);
            }
        }
    }
}
