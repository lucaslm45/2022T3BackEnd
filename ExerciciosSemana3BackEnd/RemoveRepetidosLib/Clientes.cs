namespace BackEnd.Semana3.Exercicio4
{
    public class Clientes
    {
        public Clientes(string nome, long cpf)
        {
            Nome = nome;
            CPF = cpf;
        }
        public string Nome { get; set; }
        public long CPF { get; set; }

        public override bool Equals(object? obj)
        {
            return obj != null && GetType() == obj.GetType() && (CPF == ((Clientes)obj).CPF);
        }
        public void Imprime()
        {
            Console.WriteLine($"Nome: {Nome}, CPF: {CPF}");
        }
    }
}