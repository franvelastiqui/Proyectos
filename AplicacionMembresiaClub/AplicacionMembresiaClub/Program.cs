using AplicacionMembresiaClub.Vistas;

namespace AplicacionMembresiaClub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IVista vistaPrincipal = Factory.GetObjetoVistaPrincipal();

            vistaPrincipal.CorrerVista();
        }
    }
}