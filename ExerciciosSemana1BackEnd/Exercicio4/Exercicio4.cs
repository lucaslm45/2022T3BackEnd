using BackEnd.Semana1.Exercicio2;
using BackEnd.Semana1.Excecoes;

namespace BackEnd.Semana1.Exercicio4
{
    public class Poligono
    {
        List<Vertice> vertices;
        int NumVertices;
        double perimetro;

        public Poligono(List<Vertice> _vertices)
        {
            vertices = new List<Vertice>();
            perimetro = 0;

            try
            {
                ValidaVertices(_vertices);
                int i = 0;

                for (i = 0; i < _vertices.Count; i++)
                {
                    vertices.Add(_vertices[i]);
                }
                NumVertices = vertices.Count;
                i = 0;
                for (int j = 1; j < vertices.Count; j++)
                {
                    perimetro += vertices[i].Distancia(vertices[j]);
                    i++;
                }
                perimetro += vertices[i].Distancia(vertices[0]);
            }
            catch (ExcecaoQuantidadeInvalidaVertices ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ValidaVertices(List<Vertice> _vertices)
        {
            if (_vertices.Count < 3)
            {
                throw new ExcecaoQuantidadeInvalidaVertices();
            }
        }
        public int GetNumVertices()
        {
            return NumVertices;
        }
        public bool AddVertice(Vertice _vertice)
        {
            if (vertices.Contains(_vertice))
            {
                return false;
            }
            else
            {
                int ultimoElemento = vertices.Count - 1;
                //Decrementa a distância do último elemento até o primeiro
                perimetro -= vertices[ultimoElemento].Distancia(vertices[0]);
                //Incrementa com a distância do último até o novo elemento
                perimetro += vertices[ultimoElemento].Distancia(_vertice);
                vertices.Add(_vertice);

                //Incrementa com a distância do novo vertice até o primeiro
                perimetro += vertices[ultimoElemento + 1].Distancia(vertices[0]);
                return true;
            }
        }
        public void RemoveVertice(Vertice _vertice)
        {
            try
            {
                // Se o número de vertices não for maior do que 3, não remover o vertice
                if (!(vertices.Count > 3))
                {
                    throw new ExcecaoRemocaoInvalidaVertice();
                }
                int index = vertices.IndexOf(_vertice);

                if (index >= 0)
                {
                    //Decrementa a distância até o vertice anterior
                    perimetro -= vertices[index].Distancia(vertices[index - 1]);
                    if (index < vertices.Count - 1)
                    {
                        //Decrementa a distância até o próximo vertice
                        perimetro -= vertices[index].Distancia(vertices[index + 1]);
                        //Incrementa com a distância do anterior até o proximo do vertice removido
                        perimetro += vertices[index - 1].Distancia(vertices[index + 1]);
                    }
                    else
                    {
                        //Decrementa a distância até o primeiro vertice
                        perimetro -= vertices[index].Distancia(vertices[0]);
                        //Incrementa com a distância do anterior até o proximo do vertice removido
                        perimetro += vertices[index - 1].Distancia(vertices[0]);

                    }


                    vertices.RemoveAt(index);
                }
            }
            catch (ExcecaoRemocaoInvalidaVertice ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public double Perimetro()
        {
            return perimetro;
        }


    }
    class FazPoligono
    {
        public static void Main(string[] args)
        {
            //Vertice v1 = new(0, 0);
            //Vertice v2 = new(1, 1);
            //Vertice v3 = new(2, 0);
            Vertice v1 = new(0, 0);
            Vertice v2 = new(4, 7);
            Vertice v3 = new(8, 0);
            Vertice v4 = new(4, -2);


            List<Vertice> v = new List<Vertice>();

            v.Add(v1);
            v.Add(v2);
            v.Add(v3);
            v.Add(v4);

            Poligono p1 = new(v);
            Console.WriteLine($"Valor: {p1.Perimetro()}");
            p1.RemoveVertice(v4);
            Console.WriteLine($"Valor: {p1.Perimetro()}");
            p1.AddVertice(v4);
            Console.WriteLine($"Valor: {p1.Perimetro()}");
        }
    }
}