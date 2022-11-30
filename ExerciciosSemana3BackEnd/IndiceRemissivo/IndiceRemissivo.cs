using System.Runtime.ConstrainedExecution;
using static System.Net.Mime.MediaTypeNames;

namespace BackEnd.Semana3.Exercicio2
{
    public class IndiceClasse
    {
        public IndiceClasse()
        {
            Palavras = new List<Palavra>();
            PalavrasParaIgnorar = new List<string>();
        }
        public List<Palavra>? Palavras;
        public List<string>? PalavrasParaIgnorar;
        public string[]? Texto { get; set; }
        public string[]? TextoParaIgnorar { get; set; }

        public void IndiceRemissivo(string pathTXT, string pathIgnore = "")
        {
            try
            {
                char[] separadores = new char[] { ' ', '.', ',', ';', '<', '>', ':', '\\', '/', '|', '^', '´', '`', '[', ']', '{', '}',
                    '‘', '“', '!', '@', '#', '$', '%', '&', '*', '(', ')', '_', '+', '=' };
                string linha;

                if (pathIgnore != "")
                {
                    string TextoTotal = "";

                    StreamReader textoIgnorado = new StreamReader(pathIgnore);

                    linha = textoIgnorado.ReadLine();

                    while (linha != null)
                    {
                        foreach (string palavraLinha in linha.Split(separadores, StringSplitOptions.RemoveEmptyEntries))
                        {
                            PalavrasParaIgnorar.Add(palavraLinha.ToUpper());
                        }
                        linha = textoIgnorado.ReadLine();
                    }
                }
                StreamReader textoPadrao = new StreamReader(pathTXT);

                linha = textoPadrao.ReadLine();

                int NumeroLinha = 1;

                while (linha != null)
                {
                    CriaRepertorio(linha.Split(separadores, StringSplitOptions.RemoveEmptyEntries), NumeroLinha++);

                    linha = textoPadrao.ReadLine();
                }

                //Fecha o arquivo
                textoPadrao.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
        public void CriaRepertorio(string[] Linha, int linha)
        {
            string palavraAux;
            foreach (string palavraLinha in Linha)
            {
                palavraAux = palavraLinha.ToUpper();

                Palavra palavra = new(palavraAux);

                //Se existem palavras para serem ignoradas e a palavra do repertório precisa ser ignorada
                if ((PalavrasParaIgnorar.Count > 0) && PalavrasParaIgnorar.Contains(palavraAux))
                {
                    continue;
                }
                int index = Palavras.FindIndex(a => a.Equals(palavra));

                if (index > -1)
                {
                    Palavras[index].Frequencia++;
                    if (!Palavras[index].LinhasOcorrencia.Contains(linha))
                    {
                        Palavras[index].LinhasOcorrencia.Add(linha);
                    }
                }
                else
                {
                    palavra.Frequencia = 1;
                    palavra.LinhasOcorrencia.Add(linha);

                    Palavras.Add(palavra);
                }
            }
        }
        public void Imprime()
        {
            Palavras.Sort((a, b) => a.PalavraValor.CompareTo(b.PalavraValor));

            foreach (Palavra palavra in Palavras)
            {
                string linhas = "";
                foreach (int linha in palavra.LinhasOcorrencia)
                {
                    linhas += $"{linha}, ";
                }
                linhas = linhas.Remove(linhas.Length - 2, 1);

                Console.WriteLine($"{palavra.PalavraValor} ({palavra.Frequencia}) {linhas}");
                Console.WriteLine("");
            }
        }
    }

    public class Palavra
    {
        public Palavra(string palavra)
        {
            PalavraValor = palavra;
            Frequencia = 1;
            LinhasOcorrencia = new List<int>();
        }
        public string? PalavraValor { get; set; }
        public int Frequencia { get; set; }

        public List<int>? LinhasOcorrencia { get; set; }

        public override bool Equals(object? obj)
        {
            return obj != null && GetType() == obj.GetType() && (PalavraValor == ((Palavra)obj).PalavraValor);
        }

    }

    public class FazTeste
    {
        public static void Main(string[] args)
        {
            IndiceClasse indice = new();

            indice.IndiceRemissivo("C:\\Users\\lucas\\Documents\\GitHub\\2022T3BackEnd\\ExerciciosSemana3BackEnd\\IndiceRemissivo\\Palavras\\texto2.txt");
            indice.Imprime();
        }
    }

}