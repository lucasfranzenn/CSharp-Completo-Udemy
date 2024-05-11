using Biblioteca;
using System.Drawing.Imaging;

namespace Decimo_Terceiro_Projeto;

public partial class Form1 : Form
{
    BaseDeDados baseDeDados;

    public Form1()
    {
        InitializeComponent();
        baseDeDados = new("BaseDeDados.xml");
    }

    private void btnCadastrar_Click(object sender, EventArgs e)
    {
        CadastroPessoa pessoa = new CadastroPessoa(txtNomeInserido.Text, txtNumeroDocumentoInserido.Text, Convert.ToDateTime(txtDataNascimento.Text), txtRua.Text, Convert.ToUInt32(txtNumeroCasa.Text));

        baseDeDados.AdicionarPessoa(pessoa);
        MessageBox.Show("Usuário cadastrado", "Cadastro concluído");
    }

    private void btnBsucar_Click(object sender, EventArgs e)
    {
        List<CadastroPessoa> listaPessoas = baseDeDados.BuscarPessoa(txtBuscaNumeroDocumento.Text);
        if(listaPessoas is not null and {Count: > 0 })
        {
            lblNome.Text = listaPessoas[0].Nome;
            lblDataNascimento.Text = listaPessoas[0].DataNascimento.ToString();
            lblRua.Text = listaPessoas[0].NomeRua;
            lblNumeroCasa.Text =listaPessoas[0].NumeroRua.ToString();
        }
        else
        {
            MessageBox.Show("Usuário não encontrado", "Excecao");
        }
    }

    private void btnExcluir_Click(object sender, EventArgs e)
    {
        List<CadastroPessoa> listaPessoas = baseDeDados.ExcluirPessoa(txtBuscaNumeroDocumento.Text);
        if (listaPessoas is not null and { Count: > 0 })
        {
            lblNome.Text = listaPessoas[0].Nome;
            lblDataNascimento.Text = listaPessoas[0].DataNascimento.ToString();
            lblNome.Text = listaPessoas[0].NomeRua;
            lblNumeroCasa.Text = listaPessoas[0].NumeroRua.ToString();
            MessageBox.Show("Usuário removido com sucesso", "Usuário removido");
        }
        else
        {
            MessageBox.Show("Usuário não encontrado", "Excecao");
        }

    }
}
