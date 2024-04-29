namespace Quinto_Projeto;

class Program
{
    static void Main(string[] args)
    {
        string opcao = "";
        do
        {
            Console.WriteLine("Pressione C para cadastrar um usuário ou S para sair");
            opcao = Console.ReadKey(true).KeyChar.ToString().ToLower();

            if(opcao == "c")
            {
                Console.Write("Digite seu nome completo: ");
                string? nome = Console.ReadLine();

                Console.WriteLine("Pressione M para Masculino e F para Feminino");
                char genero = Console.ReadKey(true).KeyChar;

                Console.WriteLine("Digite sua data de nascimento (dd/MM/yyyy): ");
                DateTime dataNascimento = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Digite o nome da sua rua: ");
                string? rua = Console.ReadLine();

                Console.WriteLine("Digite o numero da casa: ");
                int numeroCasa = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Nome: {nome}\n" +
                    $"Genero: {genero}\n" +
                    $"Data de nascimento: {dataNascimento.ToString()}\n" +
                    $"Rua: {rua}, número {numeroCasa}");

                Console.ReadKey(true);
                Console.Clear();
            }
            else if(opcao == "s")
            {
                Console.WriteLine("Encerrando programa!");
            }
            else
            {
                Console.WriteLine("Opcão desconhecida.");
            }
        } while (opcao != "s");
    }
}
