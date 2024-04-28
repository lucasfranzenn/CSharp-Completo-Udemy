 namespace Primeiro_Projeto;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite seu nome: ");
        string? Nome = Console.ReadLine();

        Console.WriteLine("Digite sua idade: ");
        UInt16 Idade;
        UInt16.TryParse(Console.ReadLine(), out Idade);

        Console.WriteLine("Digite o numero do seu documento: ");
        string? Document = Console.ReadLine();

        Console.WriteLine("Digite o nome da sua rua: ");
        string? NomeRua = Console.ReadLine();

        Console.WriteLine("Digite o numero da sua casa: ");
        UInt32 NumeroCasa = Convert.ToUInt32(Console.ReadLine());

        Console.WriteLine("Informe o seu genêro. F => Feminino // M => Masculino: ");
        char genero = Console.ReadKey(true).KeyChar;

        Console.WriteLine($"\r\nOlá {Nome}\nVocê tem {Idade} anos de idade");
        Console.WriteLine("O número do seu documento é " + Document);
        Console.WriteLine("O nome da sua rua é " + NomeRua);
        Console.WriteLine($"O número da sua casa é {NumeroCasa}");
        Console.WriteLine("Seu genero é " + genero);

        Console.WriteLine("Pressione qualquer tecla para acabar");
        Console.ReadKey(true);
    }
}
