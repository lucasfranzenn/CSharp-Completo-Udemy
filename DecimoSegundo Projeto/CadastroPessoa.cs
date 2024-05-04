using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DecimoSegundo_Projeto;
[DataContract]
internal class CadastroPessoa
{
    [DataMember]
    private string _nome;
    [DataMember]
    private string _numeroDocumento;
    [DataMember]
    private DateTime _dataNascimento;
    [DataMember]
    private string _nomeRua;
    [DataMember]
    private uint _numeroRua;

    public string Nome { get => _nome; set => _nome = value; }
    public string NumeroDocumento { get => _numeroDocumento; set => _numeroDocumento = value; }
    public DateTime DataNascimento { get => _dataNascimento; set => _dataNascimento = value; }
    public string NomeRua { get => _nomeRua; set => _nomeRua = value; }
    public uint NumeroRua { get => _numeroRua; set => _numeroRua = value; }

    public CadastroPessoa(string nome, string numeroDocumento, DateTime dataNascimento, string nomeRua, uint numeroRua)
    {
        _nome = nome;
        _numeroDocumento = numeroDocumento;
        _dataNascimento = dataNascimento;
        _nomeRua = nomeRua;
        _numeroRua = numeroRua;
    }

}