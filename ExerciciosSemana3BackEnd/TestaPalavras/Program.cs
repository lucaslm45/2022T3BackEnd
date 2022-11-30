using BackEnd.Semana3.Exercicio2;
public class FazTeste
{
    public static void Main(string[] args)
    {
        IndiceClasse indice = new();

        string textoParaLer = "C:\\Users\\lucas\\Documents\\GitHub\\2022T3BackEnd\\ExerciciosSemana3BackEnd\\IndiceRemissivo\\Palavras\\texto.txt";
        string textoParaIgnorar = "C:\\Users\\lucas\\Documents\\GitHub\\2022T3BackEnd\\ExerciciosSemana3BackEnd\\IndiceRemissivo\\Palavras\\ignore.txt";

        indice.IndiceRemissivo(textoParaLer, textoParaIgnorar);
        indice.Imprime();
    }
}