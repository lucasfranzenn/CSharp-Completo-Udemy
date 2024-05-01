using System.Reflection.Metadata.Ecma335;
using System.Text;

#pragma warning disable CS8600
#pragma warning disable CS8601 

namespace Nono_Projeto;
class Program
{
    static readonly string delimitadorInicio = "##### INICIO #####";
    static readonly string delimitadorFim = "##### FIM #####";
    static readonly string tagNome = "NOME: ";
    static readonly string tagDataNascimento = "DATA_NASCIMENTO: ";
    static readonly string tagNomeRua = "NOME_RUA: ";
    static readonly string tagNumeroCasa = "NUMERO_RUA: ";
    static readonly string tagNumeroDocumento = "NUMERO_DOCUMENTO: ";
    static readonly string meuArquivo = @"DadosUsuarios.txt";

    public struct DadosCadastrais
    {
        public string Nome;
        public DateTime DataNascimento;
        public string NomeRua;
        public UInt32 NumeroCasa;
        public string NumeroDocumento;
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

    public static void CadastraUsuario(ref List<DadosCadastrais> lista)
    {
        DadosCadastrais cadastroUsuario = new();

        if (PegaString(ref cadastroUsuario.Nome, "Digite seu nome completo ou digite S para sair") == Resultado_e.Sair) return;
        if (PegaData(ref cadastroUsuario.DataNascimento, "Digite a data de nascimento no formato mm/dd/yyyy ou digite S para sair") == Resultado_e.Sair) return;
        if (PegaString(ref cadastroUsuario.NumeroDocumento, "Digite o numero do documento ou digite S para sair") == Resultado_e.Sair) return;
        if (PegaString(ref cadastroUsuario.NomeRua, "Digite o nome da rua ou digite S para sair") == Resultado_e.Sair) return;
        if (PegaUInt32(ref cadastroUsuario.NumeroCasa, "Digite o numero da rua ou digite S para sair") == Resultado_e.Sair) return;

        lista.Add(cadastroUsuario);
        GravaDados(meuArquivo, lista);
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
                usuarios.AppendLine(tagNumeroDocumento + usuario.NumeroDocumento);
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
                    else if (linha.Contains(tagNumeroDocumento)) usuario.NumeroDocumento = linha.Replace(tagNumeroDocumento, "");
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

        CarregaDados(meuArquivo, ref lista);

        do
        {
            Console.WriteLine("Pressione C para cadastrar um usuario");
            Console.WriteLine("Pressione B para buscar um usuario");
            Console.WriteLine("Pressione E para excluir um usuario");
            Console.WriteLine("Pressione S para sair");
            opcao = Console.ReadKey(true).KeyChar.ToString().ToLower();

            switch (opcao)
            {
                case "c":
                    CadastraUsuario(ref lista);
                    break;
                case "b":
                    BuscarUsuario(lista);
                    break;
                case "e":
                    ExcluirUsuario(ref lista);
                    break;
                case "s":
                    MostrarMensagem("Encerrado o programa");
                    break;
                default:
                    MostrarMensagem("Opção desconhecida");
                    break;
            }
          

        } while (opcao != "s");

    }

    private static void ExcluirUsuario(ref List<DadosCadastrais> lista)
    {
        string numeroDoc = "";
        bool alguemFoiExcluido = false;
        if (PegaString(ref numeroDoc, "Digite o numero do documento para excluir ou digite S para sair") == Resultado_e.Sair) return;

        List<DadosCadastrais> ListaUsuariosEncontrados = lista.Where((x) => x.NumeroDocumento == numeroDoc).ToList();

        if (ListaUsuariosEncontrados.Count > 0)
        {
            foreach (DadosCadastrais usuario in ListaUsuariosEncontrados)
            {
                lista.Remove(usuario);
                alguemFoiExcluido = true;
            }
            if (alguemFoiExcluido)
            {
                GravaDados(meuArquivo, lista);
                Console.WriteLine($"{ListaUsuariosEncontrados.Count} usuário(s) com o documento {numeroDoc} excluído(s)");
            }
        }
        else
        {
            Console.WriteLine($"Usuário com o documento '{numeroDoc}' não encontrado");
        }

        MostrarMensagem("");
    }

    private static void BuscarUsuario(List<DadosCadastrais> lista)
    {
        string numeroDoc="";
        if (PegaString(ref numeroDoc, "Digite o numero do documento para buscar ou digite S para sair") == Resultado_e.Sair) return;

        List<DadosCadastrais> ListaUsuariosEncontrados = lista.Where((x) => x.NumeroDocumento == numeroDoc).ToList();

        if (ListaUsuariosEncontrados.Count > 0)
        {
            foreach (DadosCadastrais usuario in ListaUsuariosEncontrados)
            {
                Console.WriteLine(tagNome + usuario.Nome);
                Console.WriteLine(tagDataNascimento + usuario.DataNascimento.ToString("mm/dd/yyyy"));
                Console.WriteLine(tagNumeroDocumento + usuario.NumeroDocumento);
                Console.WriteLine(tagNomeRua + usuario.NomeRua);
                Console.WriteLine(tagNumeroCasa + usuario.NumeroCasa + "\n");
            }
        }
        else
        {
            Console.WriteLine($"Usuário com o documento '{numeroDoc}' não encontrado");
        }

        MostrarMensagem("");
    }
}
