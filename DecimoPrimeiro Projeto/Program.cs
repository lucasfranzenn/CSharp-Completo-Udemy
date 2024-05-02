namespace DecimoPrimeiro_Projeto;

class Program
{
    static void Main(string[] args)
    {
        BaseDeDados dados = new("BaseDeDados.xml");
        Controlador controlador = new(dados);

        controlador.IniciaControlador();
    }
}
