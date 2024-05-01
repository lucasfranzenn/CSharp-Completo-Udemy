using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Décimo_Projeto
{
    internal class BaseDeDados
    {
        private List<CadastroPessoa> _listaPessoas;

        public void AdicionarPessoa(CadastroPessoa pessoa)
        {
            _listaPessoas.Add(pessoa);
        }

        public List<CadastroPessoa> BuscarPessoa(string pDocumento)
        {
            List<CadastroPessoa> pessoasEncontradas = _listaPessoas.Where((x) => x.NumeroDocumento == pDocumento).ToList();

            if (pessoasEncontradas.Count > 0)
                return pessoasEncontradas;
            else
                return null;
        }
        public List<CadastroPessoa> ExcluirPessoa(string pDocumento)
        {
            List<CadastroPessoa> pessoasEncontradas = _listaPessoas.Where((x) => x.NumeroDocumento == pDocumento).ToList();

            if (pessoasEncontradas.Count > 0)
            {
                foreach (CadastroPessoa pessoa in pessoasEncontradas)
                {
                    _listaPessoas.Remove(pessoa);
                }
                return pessoasEncontradas;
            }
            else
            {
                return null;
            }
        }

        public BaseDeDados()
        {
            _listaPessoas = new();
        }
    }
}
