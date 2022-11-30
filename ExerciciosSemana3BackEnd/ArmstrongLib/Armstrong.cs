namespace BackEnd.Semana3.Exercicio3
{
    public static class ArmstrongLib
    {
        //Refs: https://www.criandobits.com.br/numeros-de-armstrong-em-java/
        public static bool IsArmstrong(this int n)
        {
            if (n < 0) return false;

            int a, b, c, d, e, f;

            int digitos = n.CalculaQuantidadeDigitos();

            a = n / 10000;
            b = (n - a * 10000) / 1000;
            c = (n - a * 10000 - b * 1000) / 100;
            d = (n - a * 10000 - b * 1000 - c * 100) / 10;
            e = (n - a * 10000 - b * 1000 - c * 100 - d * 10);

            f = (int)(Math.Pow(a, digitos) + Math.Pow(b, digitos) + Math.Pow(c, digitos) + Math.Pow(d, digitos) + Math.Pow(e, digitos));

            return f == n;
        }
        private static int CalculaQuantidadeDigitos(this int n)
        {
            int quantidade;

            if (n / 10000 > 0)
            {
                quantidade = 5;
            }
            else if (n / 1000 > 0)
            {
                quantidade = 4;
            }
            else if (n / 100 > 0)
            {
                quantidade = 3;
            }
            else if (n / 10 > 0)
            {
                quantidade = 2;
            }
            else
            {
                quantidade = 1;
            }
            return quantidade;
        }
    }
}