//using BackEnd.Semana2.Exercicio9;

using BackEnd.Semana2.Excecoes;
using BackEnd.Semana2.Exercicio9;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;

namespace BackEnd.Semana2.Exercicio10
{
    public class Aluno
    {
        public Aluno(string nomeAluno, long matriculaAluno)
        {
            Nome = nomeAluno;
            Matricula = matriculaAluno;
        }
        public string Nome { get; set; }
        public long Matricula { get; set; }
        public override bool Equals(object? obj)
        {
            //return obj != null && GetType() == obj.GetType() && (Nome == ((Aluno)obj).Nome) && (Matricula == ((Aluno)obj).Matricula);
            return obj != null && GetType() == obj.GetType() && (Matricula == ((Aluno)obj).Matricula);
        }
    }
    public class Turma
    {
        //private long codigoTurma;
        //List<Aluno> alunos;
        public Turma(long turmaCodigo)
        {
            CodigoTurma = turmaCodigo;
            Alunos = new List<Aluno>();
        }
        public long CodigoTurma { get; set; }
        public List<Aluno> Alunos { get; set; }
        public override bool Equals(object? obj)
        {
            return obj != null && GetType() == obj.GetType() && (CodigoTurma == ((Turma)obj).CodigoTurma);
        }
    }

    public class Curso
    {
        public Curso(string cursoNome)
        {
            NomeCurso = cursoNome;
            CodigoTurma = 0;
            Turmas = new List<Turma>();
            Alunos = new List<Aluno>();
        }
        public string NomeCurso { get; set; }
        public long CodigoTurma { get; set; }
        public List<Aluno> Alunos { get; set; }
        public List<Turma> Turmas { get; set; }


        public void MatricularAluno(Aluno a1) //OK
        {
            try
            {
                foreach (var aluno in Alunos)
                {
                    //Não pode haver dois alunos com a mesma matrícula
                    if (aluno.Equals(a1))
                    {
                        throw new ExcecaoAlunoExisteNoCurso(a1.Matricula);
                    }
                }
            }
            catch (ExcecaoAlunoExisteNoCurso ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void RemoverAlunoDoCurso(Aluno a1) //OK
        {
            //Se existem turmas no curso
            if (Turmas.Count > 0)
            {
                try
                {
                    //Remover um aluno do curso (somente se aluno não está associado a uma turma).
                    foreach (var turma in Turmas)
                    {
                        foreach (Aluno aluno in turma.Alunos)
                        {
                            //Se aluno esta em alguma turma
                            if (aluno.Equals(a1))
                            {
                                throw new ExcecaoAlunoEstaEmUmaTurma();
                            }
                        }
                    }
                    Alunos.Remove(a1);
                }
                catch (ExcecaoAlunoEstaEmUmaTurma ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Alunos.Remove(a1);
            }
        }
        public void AdicionarTurma(Turma t1) //Ok
        {
            try
            {
                foreach (var turma in Turmas)
                {
                    if (turma.Equals(t1))
                    {
                        throw new ExcecaoTurmaExiste(t1.CodigoTurma);
                    }
                }
                //Atualiza valor CodigoTurma disponível no curso
                CodigoTurma += 1;
                Turmas.Add(t1);
            }
            catch (ExcecaoTurmaExiste ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void RemoverTurmaDoCurso(Turma t1) //(somente se a turma não tiver nenhum aluno associado a ela).
        {
            try
            {
                if (t1.Alunos.Count > 0)
                {
                    throw new ExcecaoPeloMenosUmAlunoNaTurma();
                }
                Turmas.Remove(t1);
            }
            catch (ExcecaoPeloMenosUmAlunoNaTurma ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Inserir e remover aluno de uma turma (o mesmo aluno não pode ser inserido duas vezes na mesma turma
        public void InserirAlunoTurma(Turma t1, Aluno a1)
        {
            try
            {
                foreach (Aluno aluno in t1.Alunos)
                {
                    if (aluno.Equals(a1))
                    {
                        throw new ExcecaoAlunoExisteNaTurma(a1.Matricula);
                    }
                }
                t1.Alunos.Add(a1);
            }
            catch (ExcecaoAlunoExisteNaTurma ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void RemoverAlunoTurma(Turma t1, Aluno a1)
        {
            try
            {
                if (!t1.Alunos.Contains(a1))
                {
                    throw new ExcecaoAlunoNaoExisteNaTurma(a1.Matricula);
                }
                t1.Alunos.Remove(a1);
            }
            catch (ExcecaoAlunoNaoExisteNaTurma ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ListarAlunosTurma(Turma t1)
        {
            if (t1.Alunos.Count > 0)
            {
                t1.Alunos.Sort((x, y) => x.Nome.CompareTo(y.Nome));

                Console.WriteLine($"Alunos na Turma {t1.CodigoTurma}");

                foreach (var aluno in t1.Alunos)
                {
                    Console.WriteLine($"{aluno.Nome} {aluno.Matricula}");
                }
            }
        }
        public void ListarTodasTurmas()
        {
            if (Turmas.Count > 0)
            {
                Turmas.Sort((x, y) => x.CodigoTurma.CompareTo(y.CodigoTurma));

                IEnumerable<Turma> turmasAux = Turmas.Where(t => t.Alunos.Count > 0);

                foreach (Turma turma in turmasAux)
                {
                    ListarAlunosTurma(turma);
                }
            }
        }
    }
    public class FazCurso
    {
        public static void Main(string[] args)
        {
            Curso c1 = new("Engenharia");

            Turma t1 = new(c1.CodigoTurma);
            Aluno a1 = new("Lucas", 177);
            Aluno a2 = new("Lucas", 17);

            c1.AdicionarTurma(t1);
            c1.MatricularAluno(a1);
            c1.MatricularAluno(a2);

            c1.InserirAlunoTurma(t1, a1);

            Turma t2 = new(c1.CodigoTurma);

            c1.AdicionarTurma(t2);
            c1.InserirAlunoTurma(t2, a1);
            c1.InserirAlunoTurma(t2, a2);

            c1.InserirAlunoTurma(t1, a1);
            c1.InserirAlunoTurma(t1, a2);

            c1.ListarAlunosTurma(t1);
            c1.ListarTodasTurmas();

            c1.RemoverAlunoDoCurso(a1);
            c1.ListarTodasTurmas();
        }
    }
}
