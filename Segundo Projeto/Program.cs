namespace Segundo_Projeto;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Pressione A para alugar um filme ou S para sair da locadora");
        char opcao = Console.ReadKey(true).KeyChar;

        if(opcao == 'a' || opcao == 'A')
        {
            Console.WriteLine("1 - Top Gun");
            Console.WriteLine("2 - Bela e Fera");
            Console.WriteLine("3 - Homem aranha");
            int opcaoFilme = Convert.ToInt32(Console.ReadKey(true).KeyChar.ToString());

            switch(opcaoFilme)
            {
                case 1:
                    Console.WriteLine("Voce alugou TOP GUN");
                    break;
                case 2:
                    Console.WriteLine("Voce alugou A BELA E A FERA");
                    break;
                case 3:
                    Console.WriteLine("Voce alugou O HOMEM ARANHA");
                    break;
                default:
                    Console.WriteLine("Opcao de filme desconhecida");
                    break;

            }
        }
        else if (opcao == 's' || opcao == 'S')
        {
            Console.WriteLine("Saindo da locadora! Volte Sempre!");
        }
        else
        {
            Console.WriteLine("Opcao desconhecida...");
        }

        Console.WriteLine("Pressione qualquer tecla para sair");
        Console.ReadKey(true);
    }
}
