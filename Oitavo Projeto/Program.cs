using System.Reflection.Metadata.Ecma335;
using System.Text;

#pragma warning disable CS8600
#pragma warning disable CS8601 

namespace Oitavo_Projeto;
class Program
{
    static readonly string delimitadorInicio = "##### INICIO #####";
    static readonly string delimitadorFim = "##### FIM #####";
    static readonly string tagNome = "NOME: ";
    static readonly string tagDataNascimento = "DATA_NASCIMENTO: ";
    static readonly string tagNomeRua = "NOME_RUA: ";
    static readonly string tagNumeroCasa = "NUMERO_RUA: ";

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
        string temp = Console.ReadLine();
        if (temp == "s")
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
                string temp = Console.ReadLine();
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
                string temp = Console.ReadLine();
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

    public static Resultado_e CadastraUsuario(ref List<DadosCadastrais> lista)
    {
        DadosCadastrais cadastroUsuario;
        cadastroUsuario.Nome = "";
        cadastroUsuario.DataNascimento = new DateTime();
        cadastroUsuario.NomeRua = "";
        cadastroUsuario.NumeroCasa = 0;

        
        if (PegaString(ref cadastroUsuario.Nome, "Digite seu nome completo ou digite S para sair") == Resultado_e.Sair) return Resultado_e.Sair;
        if (PegaData(ref cadastroUsuario.DataNascimento, "Digite a data de nascimento no formato mm/dd/yyyy ou digite S para sair") == Resultado_e.Sair) return Resultado_e.Sair;
        if (PegaString(ref cadastroUsuario.NomeRua, "Digite o nome da rua ou digite S para sair") == Resultado_e.Sair) return Resultado_e.Sair;
        if (PegaUInt32(ref cadastroUsuario.NumeroCasa, "Digite o numero da rua ou digite S para sair") == Resultado_e.Sair) return Resultado_e.Sair;

        lista.Add(cadastroUsuario);

        return Resultado_e.Sucesso;
    }

    public static void GravaDados(string arquivo, List<DadosCadastrais> lista)
    {
        try
        {
            StringBuilder usuarios = new();

            foreach (DadosCadastrais usuario in lista)
            {
                usuarios.AppendLine(delimitadorInicio);
                usuarios.AppendLine(tagNome + usuario.Nome);
                usuarios.AppendLine(tagDataNascimento + usuario.DataNascimento);
                usuarios.AppendLine(tagNomeRua + usuario.NomeRua);
                usuarios.AppendLine(tagNumeroCasa + usuario.NumeroCasa);
                usuarios.AppendLine(delimitadorFim);
            }

            File.WriteAllText(arquivo, usuarios.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine("EXCEÇÃO: " + e.Message);
        }
    }
    private static void CarregaDados(string meuArquivo, ref List<DadosCadastrais> lista)
    {
        try
        {
            if (File.Exists(meuArquivo))
            {
                string[] conteudoArquivo = File.ReadAllLines(meuArquivo);
                DadosCadastrais usuario = new();

                foreach (string linha in conteudoArquivo)
                {
                    if (linha.Contains(delimitadorInicio)) continue;
                    else if (linha.Contains(delimitadorFim)) lista.Add(usuario);
                    else if (linha.Contains(tagNome)) usuario.Nome = linha.Replace(tagNome, "");
                    else if (linha.Contains(tagDataNascimento)) usuario.DataNascimento = Convert.ToDateTime(linha.Replace(tagDataNascimento, ""));
                    else if (linha.Contains(tagNomeRua)) usuario.NomeRua = linha.Replace(tagNomeRua, "");
                    else if (linha.Contains(tagNumeroCasa)) usuario.NumeroCasa = Convert.ToUInt32(linha.Replace(tagNumeroCasa, ""));
                }

            }
        }
        catch (Exception e)
        {
            Console.WriteLine("EXCEÇÃO: " + e.Message);
        }
    }

    static void Main()
    {
        List<DadosCadastrais> lista = [];
        string opcao;
        
        string meuArquivo = @"DadosUsuarios.txt";

        CarregaDados(meuArquivo, ref lista);

        do
        {
            Console.WriteLine("Pressione C para cadastrar e S para sair");
            opcao = Console.ReadKey(true).KeyChar.ToString().ToLower();

            if (opcao == "c")
            {
                if (CadastraUsuario(ref lista) == Resultado_e.Sucesso)
                {
                    GravaDados(meuArquivo, lista);
                }
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
