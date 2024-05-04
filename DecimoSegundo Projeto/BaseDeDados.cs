using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DecimoSegundo_Projeto;
[DataContract]
internal class BaseDeDados
{
    [DataMember]
    private List<CadastroPessoa> _listaPessoas;
    private string _caminhoBaseDeDados;
    private bool baseDisponivel;
    private Mutex mutexLista;
    private Mutex mutexArquivo;

    internal List<CadastroPessoa> ListaPessoas { get => _listaPessoas; set => _listaPessoas = value; }

    public void AdicionarPessoa(CadastroPessoa pessoa)
    {
        mutexLista.WaitOne();
        ListaPessoas.Add(pessoa);
        mutexLista.ReleaseMutex();

        new Thread(() =>
        {
            baseDisponivel = false;
            mutexArquivo.WaitOne();
            Serializador.Serializa(_caminhoBaseDeDados, this);
            mutexArquivo.ReleaseMutex();
            baseDisponivel = true;
        }).Start();
    }

    public List<CadastroPessoa> BuscarPessoa(string pDocumento)
    {
        mutexLista.WaitOne();
        List<CadastroPessoa> pessoasEncontradas = ListaPessoas.Where((x) => x.NumeroDocumento == pDocumento).ToList();
        mutexLista.ReleaseMutex();

        if (pessoasEncontradas.Count > 0)
            return pessoasEncontradas;
        else
            return null;
    }
    public List<CadastroPessoa> ExcluirPessoa(string pDocumento)
    {
        mutexLista.WaitOne();
        List<CadastroPessoa> pessoasEncontradas = ListaPessoas.Where((x) => x.NumeroDocumento == pDocumento).ToList();
        mutexLista.ReleaseMutex();

        if (pessoasEncontradas.Count > 0)
        {
            foreach (CadastroPessoa pessoa in pessoasEncontradas)
            {
                mutexLista.WaitOne();
                ListaPessoas.Remove(pessoa);
                mutexLista.ReleaseMutex();
            }

            new Thread(() =>
            {
                baseDisponivel = false;
                mutexArquivo.WaitOne();
                Serializador.Serializa(_caminhoBaseDeDados, this);
                mutexArquivo.ReleaseMutex();
                baseDisponivel = true;
            }).Start();

            return pessoasEncontradas;
        }
        else
        {
            return null;
        }
    }

    public BaseDeDados(string caminhoBaseDeDados)
    {
        _caminhoBaseDeDados = caminhoBaseDeDados;
        mutexArquivo = new();
        mutexLista = new();
        baseDisponivel = true;

        new Thread(() =>
        {
            baseDisponivel = false;
            mutexArquivo.WaitOne();
            BaseDeDados temp = Serializador.Deserializa(caminhoBaseDeDados);
            mutexArquivo.ReleaseMutex();

            mutexLista.WaitOne();
            if (temp != null)
            {
                ListaPessoas = temp.ListaPessoas;
            }
            else
            {
                ListaPessoas = new();
            }
            mutexLista.ReleaseMutex();
            baseDisponivel = true;
        }).Start();
    }

    public bool BaseDisponivel()
    {
        return baseDisponivel;
    }
}

