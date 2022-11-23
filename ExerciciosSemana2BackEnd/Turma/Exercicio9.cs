using BackEnd.Semana2.Excecoes;

namespace BackEnd.Semana2.Exercicio9
{
    public class Aluno
    {
        private string nome;
        private long matricula;
        private float nota1, nota2, notaFinal;
        public Aluno(string nomeAluno, long matriculaAluno)
        {
            Nome = nomeAluno;
            Matricula = matriculaAluno;
        }
        public string Nome { get; set; }
        public long Matricula { get; set; }

        public float Nota1
        {
            get => nota1;
            set
            {
                nota1 = value;
                NotaFinal = (value + Nota2) / 2;
            }
        }
        public float Nota2
        {
            get => nota2;
            set
            {
                nota2 = value;
                NotaFinal = (Nota1 + value) / 2;
            }
        }
        public float NotaFinal { get; set; }
        public override bool Equals(object? obj)
        {
            //return obj != null && GetType() == obj.GetType() && (Nome == ((Aluno)obj).Nome) && (Matricula == ((Aluno)obj).Matricula);
            return obj != null && GetType() == obj.GetType() && (Matricula == ((Aluno)obj).Matricula);
        }
    }
    public class Turma
    {
        List<Aluno> alunos;
        public Turma()
        {
            alunos = new List<Aluno>();
        }
        public List<Aluno> Alunos { get; set; }
        public void AdicionarAluno(Aluno a1)
        {
            try
            {
                foreach (var aluno in alunos)
                {
                    if (aluno.Equals(a1))
                    {
                        throw new ExcecaoAlunoExisteNaTurma(a1.Matricula);
                    }
                }
                alunos.Add(a1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void RemoverAluno(Aluno a1)
        {
            try
            {
                if (!alunos.Contains(a1))
                {
                    throw new ExcecaoAlunoNaoExisteNaTurma(a1.Matricula);
                }
                alunos.Remove(a1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void LancarNota1(Aluno a1, float nota)
        {
            if (!alunos.Contains(a1))
            {
                return;
            }
            alunos[alunos.IndexOf(a1)].Nota1 = nota;
        }
        public void LancarNota2(Aluno a1, float nota)
        {
            if (!alunos.Contains(a1))
            {
                return;
            }
            alunos[alunos.IndexOf(a1)].Nota2 = nota;
        }
        public void ImprimeAlunos()
        {
            alunos.Sort((x, y) => x.Nome.CompareTo(y.Nome));

            foreach (var aluno in alunos)
            {
                Console.WriteLine($"{aluno.Nome} {aluno.Matricula}  NF = {aluno.NotaFinal}");
            }
        }
        public void ImprimeEstatisticas()
        {
            float MediaP1 = alunos.Sum(a => a.Nota1) / alunos.Count;
            float MediaP2 = alunos.Sum(a => a.Nota2) / alunos.Count;
            float MediaTurma = alunos.Sum(a => a.NotaFinal) / alunos.Count;

            IEnumerable<Aluno> aluno = alunos.Where(a1 => a1.NotaFinal == alunos.Max(a => a.NotaFinal));

            Console.WriteLine($"Média da P1: {MediaP1}, Média da P2: {MediaP2}, Média da Turma: {MediaTurma}");
            foreach (var a1 in aluno)
            {
                Console.WriteLine($"Maior Nota: {a1.Nome}, {a1.Matricula}, NF = {a1.NotaFinal}");
            }
        }

    }
    public class FazTurma
    {
        public static void Main(string[] args)
        {
            Turma t1 = new();
            Aluno a1 = new("Jose", 1774271);
            Aluno a2 = new("Lucao", 1774271);
            Aluno a3 = new("Joaquim", 1774272);
            Aluno a4 = new("Adalto", 1774273);

            t1.AdicionarAluno(a1);
            t1.AdicionarAluno(a2);
            t1.AdicionarAluno(a3);
            t1.LancarNota1(a1, 12);
            t1.LancarNota2(a1, 12);
            t1.LancarNota1(a3, 50);
            t1.LancarNota2(a3, 50);
            t1.ImprimeAlunos();
            t1.AdicionarAluno(a2);
            t1.RemoverAluno(a2);
            t1.ImprimeAlunos();
            t1.AdicionarAluno(a4);
            t1.LancarNota1(a4, 60);
            t1.LancarNota1(a4, 60);

            t1.AdicionarAluno(a3);
            t1.ImprimeAlunos();
            t1.ImprimeEstatisticas();
            //t1.ImprimeAlunos();

        }
    }

}