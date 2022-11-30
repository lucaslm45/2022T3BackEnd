namespace BackEnd.Semana3.Exercicio1.UI
{
    public class InterfaceUI
    {
        public string? Nome { get; private set; }
        public string? CPF { get; private set; }
        public string? Nascimento { get; private set; }
        public string? RendaMensal { get; private set; }
        public string? EstadoCivil { get; private set; }
        public string? Dependentes { get; private set; }
        public int NumeroCampos { get; private set; }

        public InterfaceUI()
        {
            NumeroCampos = 6;
        }

        public void LerDados(bool[]? VetorParaLer = null)
        {
            if (VetorParaLer == null)
            {
                VetorParaLer = new bool[NumeroCampos];
            }
            int i = 0;
            if (!VetorParaLer[i++])
            {
                Console.Write("Digite o nome da pessoa: ");
                Nome = Console.ReadLine();
            }
            if (!VetorParaLer[i++])
            {
                Console.Write("Digite o CPF da pessoa: ");
                CPF = Console.ReadLine();
            }
            if (!VetorParaLer[i++])
            {
                Console.Write("Digite a Data de Nascimento (DD/MM/AAAA) da pessoa: ");
                Nascimento = Console.ReadLine();
            }
            if (!VetorParaLer[i++])
            {
                Console.Write("Digite a Renda Mensal da pessoa: ");
                RendaMensal = Console.ReadLine();
            }
            if (!VetorParaLer[i++])
            {
                Console.Write("Digite o Estado Cívil (C, S, V ou D) da pessoa: ");
                EstadoCivil = Console.ReadLine();
            }
            if (!VetorParaLer[i++])
            {
                Console.Write("Digite o número de dependentes (0 a 10) da pessoa: ");
                Dependentes = Console.ReadLine();
            }
        }
    }
}
