namespace BackEnd.Semana2.Excecoes;

[Serializable]
public class ExcecaoCampoComValorIncorreto : Exception
{
    public ExcecaoCampoComValorIncorreto(string campo, string valor)
        : base(string.Format($"O campo {campo} com valor {valor} é inválido"))
    {

    }
}
public class ExcecaoAlunoExisteNoCurso : Exception
{
    public ExcecaoAlunoExisteNoCurso(long matricula)
        : base(string.Format($"Já existe aluno com a matricula {matricula} no curso"))
    {

    }
}
public class ExcecaoAlunoNaoExisteNoCurso : Exception
{
    public ExcecaoAlunoNaoExisteNoCurso(long matricula)
        : base(string.Format($"A pessoa com a matricula {matricula} não faz parte desse curso"))
    {

    }
}
public class ExcecaoAlunoEstaEmUmaTurma : Exception
{
    public ExcecaoAlunoEstaEmUmaTurma()//long matricula)
        : base(string.Format("O aluno está associado a uma turma"))
    {

    }
}
public class ExcecaoAlunoExisteNaTurma : Exception
{
    public ExcecaoAlunoExisteNaTurma(long matricula)
        : base(string.Format($"Já existe aluno com a matricula {matricula} na turma"))
    {

    }
}
public class ExcecaoAlunoNaoExisteNaTurma : Exception
{
    public ExcecaoAlunoNaoExisteNaTurma(long matricula)
        : base(string.Format($"A pessoa com a matricula {matricula} não faz parte dessa turma"))
    {

    }
}
public class ExcecaoPeloMenosUmAlunoNaTurma : Exception
{
    public ExcecaoPeloMenosUmAlunoNaTurma()
        : base(string.Format(""))
    {

    }
}
public class ExcecaoTurmaExiste : Exception
{
    public ExcecaoTurmaExiste(long codigo)
        : base(string.Format($"Já existe uma turma com o código {codigo}"))
    {

    }
}
public class ExcecaoTurmaNaoExiste : Exception
{
    public ExcecaoTurmaNaoExiste(long codigo)
        : base(string.Format($"Não existe uma turma com o código {codigo}"))
    {

    }
}
public class ExcecaoPessoaPossuiCertidao : Exception
{
    public ExcecaoPessoaPossuiCertidao()
        : base(string.Format($"Essa pessoa já possui Certidão."))
    {

    }
}
public class ExcecaoCarroExiste : Exception
{
    public ExcecaoCarroExiste(string modelo, string placa)
        : base(string.Format($"O carro modelo {modelo} e placa {placa} já está ativo."))
    {

    }
}
public class ExcecaoMotorEmUso : Exception
{
    public ExcecaoMotorEmUso(string modelo, string placa)
        : base(string.Format($"Esse motor já está em uso pelo carro modelo {modelo} e placa {placa}."))
    {

    }
}
