namespace Décimo_Projeto;

class Program
{
    static void Main(string[] args)
    {
        BaseDeDados dados = new();
        Controlador controlador = new(dados);

        controlador.IniciaControlador();
    }
}
