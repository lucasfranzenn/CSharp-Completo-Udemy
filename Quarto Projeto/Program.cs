using System.Reflection.Metadata.Ecma335;

namespace Quarto_Projeto;

class Program
{
    static void Main(string[] args)
    {
        InsereUsuario:

        Console.Write("Digite o nome do usuário: ");
        string? usuario = Console.ReadLine();

        Console.Write("Digite a sua senha: ");
        string? senha = "";

        while (true)
        {
            ConsoleKeyInfo tecla = Console.ReadKey(true);
            if(tecla is { Key: ConsoleKey.Enter })
            {
                Console.WriteLine("");
                break;
            }
            else if(tecla is { Key: ConsoleKey.Backspace })
            {
                if (senha.Length == 0) { continue; }

                senha = senha.Remove(senha.Length - 1);
                Console.Write("\b \b");
                continue;
            }
            else
            {
                Console.Write("*");
                senha += tecla.KeyChar;
            }
        }

        #region ValidaUsuario
        if (usuario is not null && usuario.Equals("Lucas", StringComparison.OrdinalIgnoreCase) && senha.Equals("123"))
        {
            Console.WriteLine("Logado com sucesso!\nBem-vindo Lucas ♥");
        }
        else
        {
            Console.Write("Login incorreto!\nPressione qualquer tecla para tentar novamente");
            Console.ReadKey(true);
            Console.Clear();
            goto InsereUsuario;
        }
        Console.Write("Pressione qualquer tecla para finalizar o programa!");
        Console.ReadKey(true);
        #endregion
    }
}
