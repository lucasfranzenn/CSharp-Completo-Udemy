using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DecimoPrimeiro_Projeto;
internal class Controlador
{
    BaseDeDados _dados;

    public Controlador(BaseDeDados dados)
    {
        _dados = dados;
    }

    public enum Resultados
    {
        Sucesso = 0,
        Sair,
        Excecao
    }

    public void MostraMensagem(string mensagem)
    {
        Console.WriteLine(mensagem);
        Console.WriteLine("Pressione qualquer tecla para continuar");
        Console.ReadKey(true);
        Console.Clear();
    }
    public Resultados PegaString(ref string minhaString, string mensagem)
    {
        Resultados retorno;
        Console.WriteLine(mensagem);
        string temp = Console.ReadLine();

        if(temp.ToLower() == "s")
        {
            retorno = Resultados.Sair;
        }
        else
        {
            minhaString = temp;
            retorno = Resultados.Sucesso;
        }
        Console.Clear();
        return retorno;
    }
    public Resultados PegaData(ref DateTime data, string mensagem)
    {
        Resultados retorno;
        do
        {
            try
            {
                Console.WriteLine(mensagem);
                string temp = Console.ReadLine();
                if (temp.ToLower() == "s")
                {
                    retorno = Resultados.Sair;
                }
                else
                {
                    data = Convert.ToDateTime(temp);
                    retorno = Resultados.Sucesso;
                }
            }
            catch (Exception e)
            {
                MostraMensagem($"EXCEÇÃO {e.Message}");
                retorno = Resultados.Excecao;
            }

        } while (retorno == Resultados.Excecao);
        Console.Clear();
        return retorno;
    }
    public Resultados PegaUInt32(ref uint numero, string mensagem)
    {
        Resultados retorno;
        do
        {
            try
            {
                Console.WriteLine(mensagem);
                string temp = Console.ReadLine();
                if (temp.ToLower() == "s")
                {
                    retorno = Resultados.Sair;
                }
                else
                {
                    numero = Convert.ToUInt32(temp);
                    retorno = Resultados.Sucesso;
                }
            }
            catch (Exception e)
            {
                MostraMensagem($"EXCEÇÃO {e.Message}");
                retorno = Resultados.Excecao;
            }

        } while (retorno == Resultados.Excecao);
        Console.Clear();
        return retorno;
    }
    public void ImprimeDados(CadastroPessoa pessoa)
    {
        Console.WriteLine($"Nome: {pessoa.Nome}");
        Console.WriteLine($"Data de nascimento: {pessoa.DataNascimento}");
        Console.WriteLine($"Numero do documento: {pessoa.NumeroDocumento}");
        Console.WriteLine($"Nome da rua: {pessoa.NomeRua}");
        Console.WriteLine($"Numero da rua: {pessoa.NumeroRua} \r\n");
    }

    public void ImprimeDados(List<CadastroPessoa> listaPessoas)
    {
        foreach (CadastroPessoa pessoa in listaPessoas)
        {
            ImprimeDados(pessoa);
        }
    }

    public Resultados CadastraUsuario()
    {
        Console.Clear();

        string nome = "";
        DateTime data = new();
        string numeroDocumento="";
        string nomeRua = "";
        UInt32 numeroCasa = default(UInt32);

        if (PegaString(ref nome, "Digite seu nome completo ou digite S para sair") == Resultados.Sair) return Resultados.Sair;
        if (PegaData(ref data, "Digite a data de nascimento no formato mm/dd/yyyy ou digite S para sair") == Resultados.Sair) return Resultados.Sair;
        if (PegaString(ref numeroDocumento, "Digite o numero do documento ou digite S para sair") == Resultados.Sair) return Resultados.Sair;
        if (PegaString(ref nomeRua, "Digite o nome da rua ou digite S para sair") == Resultados.Sair) return Resultados.Sair;
        if (PegaUInt32(ref numeroCasa, "Digite o numero da rua ou digite S para sair") == Resultados.Sair) return Resultados.Sair;

        CadastroPessoa usuarioTemp = new(nome, numeroDocumento, data, nomeRua, numeroCasa);

        _dados.AdicionarPessoa(usuarioTemp);

        Console.Clear();
        Console.WriteLine("Adicionando usuário: ");
        ImprimeDados(usuarioTemp);
        MostraMensagem("");

        return Resultados.Sucesso;
    }

    public void BuscaUsuario()
    {
        Console.Clear();
        Console.WriteLine("Digite o numero do documento para buscar um usuario ou digite S para sair");
        string temp = Console.ReadLine();

        if(temp.ToLower() == "s")
        {
            return;
        }
            
        List<CadastroPessoa> pessoasTemp = _dados.BuscarPessoa(temp);
        Console.Clear();

        if(pessoasTemp != null)
        {
            Console.WriteLine($"Usuario(s) com documento {temp} encontrado(s): ");
            ImprimeDados(pessoasTemp);
        }
        else
        {
            Console.WriteLine($"Nenhum usuário com o documento {temp} foi encontrado!");
        }
        MostraMensagem("");
    }

    public void RemoveUsuario()
    {
        Console.Clear();
        Console.WriteLine("Digite o numero do documento para remover um usuario ou digite S para sair");
        string temp = Console.ReadLine();

        if (temp.ToLower() == "s")
        {
            return;
        }

        List<CadastroPessoa> pessoasTemp = _dados.ExcluirPessoa(temp);
        Console.Clear();

        if (pessoasTemp != null)
        {
            Console.WriteLine($"Usuario(s) com documento {temp} removido(s): ");
            ImprimeDados(pessoasTemp);
        }
        else
        {
            Console.WriteLine($"Nenhum usuário com o documento {temp} foi encontrado!");
        }
        MostraMensagem("");
    }

    public void Sair()
    {
        Console.Clear();
        MostraMensagem("Encerrando o programa");
    }

    public void OpcaoDesconhecida()
    {
        Console.Clear();
        MostraMensagem("Opção deconhecida");
    }

    public void IniciaControlador()
    {
        string temp = "";

        do
        {
            Console.WriteLine("Digite C para cadastrar um novo usuário");
            Console.WriteLine("Digite B para buscar um usuário");
            Console.WriteLine("Digite R para remover um usuário");
            Console.WriteLine("Digite S para sair");
            temp = Console.ReadKey(true).KeyChar.ToString().ToLower();

            switch (temp)
            {
                case "c":
                    CadastraUsuario();
                    break;
                case "b":
                    BuscaUsuario();
                    break;
                case "r":
                    RemoveUsuario();
                    break;
                case "s":
                    Sair();
                    break;
                default:
                    OpcaoDesconhecida();
                    break;
            }

        } while (temp != "s");
    }

}