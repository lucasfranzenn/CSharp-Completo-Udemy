using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DecimoPrimeiro_Projeto;
[DataContract]
internal class BaseDeDados
{
    [DataMember]
    private List<CadastroPessoa> _listaPessoas;
    private string _caminhoBaseDeDados;

    internal List<CadastroPessoa> ListaPessoas { get => _listaPessoas; set => _listaPessoas = value; }

    public void AdicionarPessoa(CadastroPessoa pessoa)
    {
        ListaPessoas.Add(pessoa);
        Serializador.Serializa(_caminhoBaseDeDados, this);
    }

    public List<CadastroPessoa> BuscarPessoa(string pDocumento)
    {
        List<CadastroPessoa> pessoasEncontradas = ListaPessoas.Where((x) => x.NumeroDocumento == pDocumento).ToList();

        if (pessoasEncontradas.Count > 0)
            return pessoasEncontradas;
        else
            return null;
    }
    public List<CadastroPessoa> ExcluirPessoa(string pDocumento)
    {
        List<CadastroPessoa> pessoasEncontradas = ListaPessoas.Where((x) => x.NumeroDocumento == pDocumento).ToList();

        if (pessoasEncontradas.Count > 0)
        {
            foreach (CadastroPessoa pessoa in pessoasEncontradas)
            {
                ListaPessoas.Remove(pessoa);
            }
            Serializador.Serializa(_caminhoBaseDeDados, this);
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
        BaseDeDados temp = Serializador.Deserializa(caminhoBaseDeDados);
        if (temp != null)
        {
            ListaPessoas = temp.ListaPessoas;
        }
        else
        {
            ListaPessoas = new();
        }
    }
}

