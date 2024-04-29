namespace Sexto_Projeto;

class Program
{
    struct DadosCadastrais_Struct
    {
        public string Nome;
        public string NomeRua;
        public UInt32 NumeroCasa;
        public string NumeroDocumento;
    }

    static void Main(string[] args)
    {
        List<DadosCadastrais_Struct> ListaCadastros = new List<DadosCadastrais_Struct> ();
        string opcao;

        do
        {
            Console.WriteLine("Pressione C para cadastrar um novo usuário e S para sair");
            opcao = Console.ReadKey(true).KeyChar.ToString().ToLower();

            if (opcao == "c")
            {
                DadosCadastrais_Struct userTemp;

                Console.WriteLine("Insira seu nome: ");
                userTemp.Nome = Console.ReadLine();
                Console.WriteLine("Insira o nome da sua rua: ");
                userTemp.NomeRua = Console.ReadLine();
                Console.WriteLine("Insira o numero da sua casa: ");
                userTemp.NumeroCasa = UInt32.Parse(Console.ReadLine());
                Console.WriteLine("Insira o numero do seu documento: ");
                userTemp.NumeroDocumento = Console.ReadLine();

                ListaCadastros.Add(userTemp);
                Console.Clear();

            }
            else if (opcao == "s")
            {
                Console.WriteLine("Saindo do programa...");
            }
            else
            {
                Console.WriteLine("Opcão inválida!");
            }

        } while (opcao != "s");

        Console.WriteLine("Pressione qualquer tecla para sair!");
        Console.ReadKey(true);
    }
}
