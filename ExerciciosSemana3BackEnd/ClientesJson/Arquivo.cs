using System.Text.Json;
using BackEnd.Semana3.Exercicio1.ClientesString;

namespace BackEnd.Semana3.Exercicio1.ArquivoJson
{
    public class JsonArquivo
    {
        public string FileName { get; private set; }
        public List<ClienteString> ClientesJson { get; private set; }
        public byte[] Data { get; private set; }

        public JsonArquivo()
        {
            FileName = @"C:\Users\lucas\Documents\GitHub\2022T3BackEnd\RevisaoParte3\ClientesJson\ArquivosJson\clientes.json";
            Data = File.ReadAllBytes(FileName);
            ClientesJson = new List<ClienteString>();
        }
        public void CarregarJson()
        {

            Utf8JsonReader reader = new Utf8JsonReader(Data);

            ClienteString cliente = new();

            int i = 1;
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.StartObject:
                        cliente = new();
                        i = 1;
                        break;
                    case JsonTokenType.EndObject:
                        if ((cliente != null) && !ClientesJson.Contains(cliente))
                        {
                            ClientesJson.Add(cliente);
                        }
                        break;
                    case JsonTokenType.String:
                        if (i == 1)
                        {
                            cliente.Nome = reader.GetString();
                        }
                        else if (i == 2)
                        {
                            cliente.CPF = reader.GetString();
                        }
                        else if (i == 3)
                        {
                            cliente.Nascimento = reader.GetString();
                        }
                        else if (i == 4)
                        {
                            cliente.RendaMensal = reader.GetString();
                        }
                        else if (i == 5)
                        {
                            cliente.EstadoCivil = reader.GetString();
                        }
                        else
                        {
                            cliente.Dependentes = reader.GetString();
                        }
                        i++;
                        break;
                    default:
                        throw new ArgumentException();

                }
            }
        }
        public void SalvarArquivosJson(List<ClienteStringSaida> Clientes)
        {
            string json = JsonSerializer.Serialize(Clientes, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(@"C:\Users\lucas\Documents\GitHub\2022T3BackEnd\RevisaoParte3\ClientesJson\ArquivosJson\path.json", json);
        }

    }
}
