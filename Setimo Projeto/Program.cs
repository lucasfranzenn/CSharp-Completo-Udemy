using System.Reflection.Metadata.Ecma335;

namespace Setimo_Projeto;

class Program
{
    public struct DadosCadastrais
    {
        public string Nome;
        public DateTime DataNascimento;
        public string NomeRua;
        public UInt32 NumeroCasa;
    }

    public enum Resultado_e
    {
        Sucesso = 0,
        Sair,
        Excecao
    }

    public static void MostrarMensagem(string mensagem)
    {
        Console.WriteLine(mensagem);
        Console.WriteLine("Pressione qualquer tecla para continuar");
        Console.ReadKey(true);
        Console.Clear();
    }

    public static Resultado_e PegaString(ref string minhaString, string mensagem)
    {
        Resultado_e retorno;
        Console.WriteLine(mensagem);
        string temp = Console.ReadLine().ToLower();
        if(temp == "s")
            retorno = Resultado_e.Sair;
        else
        {
            minhaString = temp;
            retorno = Resultado_e.Sucesso;
        }

        Console.Clear();
        return retorno;

    }

    public static Resultado_e PegaData(ref DateTime data, string mensagem)
    {
        Resultado_e retorno;
        do
        {
            try
            {
                Console.WriteLine(mensagem);
                string temp = Console.ReadLine().ToLower();
                if (temp == "s")
                {
                    retorno = Resultado_e.Sair;
                }
                else
                {
                    data = Convert.ToDateTime(temp);
                    retorno = Resultado_e.Sucesso;
                }
            }
            catch (Exception e)
            {
                MostrarMensagem(e.Message);
                retorno = Resultado_e.Excecao;
            }
        } while (retorno == Resultado_e.Excecao);
        Console.Clear();
        return retorno;
    }

    public static Resultado_e PegaUInt32(ref UInt32 numero, string mensagem)
    {
        Resultado_e retorno;
        do
        {
            try
            {
                Console.WriteLine(mensagem);
                string temp = Console.ReadLine().ToLower();
                if (temp == "s")
                {
                    retorno = Resultado_e.Sair;
                }
                else
                {
                    numero = Convert.ToUInt32(temp);
                    retorno = Resultado_e.Sucesso;
                }
            }
            catch (Exception e)
            {
                MostrarMensagem(e.Message);
                retorno = Resultado_e.Excecao;
            }
        } while (retorno == Resultado_e.Excecao);
        Console.Clear();
        return retorno;
    }

    public static void CadastraUsuario(ref List<DadosCadastrais> lista)
    {
        DadosCadastrais cadastroUsuario;
        cadastroUsuario.Nome = "";
        cadastroUsuario.DataNascimento = new DateTime();
        cadastroUsuario.NomeRua = "";
        cadastroUsuario.NumeroCasa = 0;

        if (PegaString(ref cadastroUsuario.Nome, "Digite seu nome completo ou digite S para sair") != Resultado_e.Sucesso) return;
        if (PegaData(ref cadastroUsuario.DataNascimento, "Digite a data de nascimento no formato dd/mm/yyyy ou digite S para sair") != Resultado_e.Sucesso) return;
        if (PegaString(ref cadastroUsuario.NomeRua, "Digite o nome da rua ou digite S para sair") != Resultado_e.Sucesso) return;
        if (PegaUInt32(ref cadastroUsuario.NumeroCasa, "Digite o numero da rua ou digite S para sair") != Resultado_e.Sucesso) return;

        lista.Add(cadastroUsuario);
    }

    static void Main(string[] args)
    {
        List<DadosCadastrais> lista = new List<DadosCadastrais>();
        string opcao;

        do
        {
            Console.WriteLine("Pressione C para cadastrar e S para sair");
            opcao = Console.ReadKey(true).KeyChar.ToString().ToLower();

            if(opcao == "c")
            {
                CadastraUsuario(ref lista);
            }
            else if (opcao == "s")
            {
                MostrarMensagem("Encerrado o programa");
            }
            else
            {
                MostrarMensagem("Opção desconhecida");
            }
        } while (opcao != "s");

    }
}
