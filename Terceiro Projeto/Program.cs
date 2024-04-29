namespace Terceiro_Projeto;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Pressione S para sair ou um número para calcular a fatorial");
            string opcao = Console.ReadLine();

            if( opcao == "s" || opcao == "S")
            {
                break;
            }
            else
            {
                Int32.TryParse(opcao, out int valor);

                if (valor == 0)
                {
                    Console.WriteLine("0! = 1");
                }else if(valor < 0)
                {
                    Console.WriteLine("Impossível calcular fatorial de número negativo");
                }
                else
                {
                    Console.Write($"{valor}! = {valor} ");
                    for (int i=valor; i>1; i--)
                    {
                        Console.Write($"* {i-1} ");
                        valor = valor * (i - 1);
                    }

                    Console.WriteLine($"= {valor}");
                }
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
        Console.WriteLine("Pressione qualquer tecla para sair");
        Console.ReadKey(true);
    }
}
