using BackEnd.Semana3.Exercicio1.UI;
using BackEnd.Semana3.Exercicio1.ArquivoJson;
using BackEnd.Semana3.Exercicio1.Valida;

namespace BackEnd.Semana3.Exercicio1.Controle
{
    public class Controlador
    {
        public Controlador()
        {
            Validador = new();
            JsonArquivo = new();
        }

        public Validador Validador { get; set; }
        public JsonArquivo JsonArquivo { get; set; }

        public void Start()
        {
            JsonArquivo.CarregarJson();
            Validador.ValidaDados(JsonArquivo.ClientesJson);
            JsonArquivo.SalvarArquivosJson(Validador.ClientesSaida);
        }
    }
}
