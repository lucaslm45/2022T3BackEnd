using System.Collections.Generic;

namespace BackEnd.Semana3.Exercicio4
{
    public static class MetodosDeExtensao
    {
        public static List<T> RemoveRepetidos<T>(this List<T> lista)
        {
            return lista.Distinct().ToList();
        }
    }
}