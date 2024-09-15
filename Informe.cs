/*public class InformeIndividual
{
    private int idCadete;
    private string nombreCadete;
    private int cantidadPedidosRecibidos;
    private int cantidadPedidosEnviadosCadete;
    private float promedio;

    public int IdCadete { get => idCadete;}
    public string NombreCadete { get => nombreCadete;}
    public int CantidadPedidosRecibidos { get => cantidadPedidosRecibidos;}
    public int CantidadPedidosEnviadosCadete { get => cantidadPedidosEnviadosCadete;}
    public float Promedio { get => promedio;}

    public InformeIndividual(Cadete cadete)
    {
        idCadete = cadete.Id;
        nombreCadete = cadete.Nombre;
        cantidadPedidosRecibidos = cadete.CantidadPedidosRecibidosCadete();
        cantidadPedidosEnviadosCadete = cadete.CantidadPedidosEnviadosCadete();
        promedio = cadete.PromedioPedidosCadete();
    }

    public void MostrarInformeIndividual()
    {
        System.Console.WriteLine($"Id:{idCadete}");
        System.Console.WriteLine($"Nombre:{nombreCadete}");
        System.Console.WriteLine($"Pedidos Recibidos:{cantidadPedidosRecibidos}");
        System.Console.WriteLine($"Pedidos Enviados:{cantidadPedidosEnviadosCadete}");
        System.Console.WriteLine($"Promedio Pedidos entregados:{promedio}");

    }
}
public class Informe
{
    private List<Cadete> cadetes;
    private int jornalAPagar;

    public Informe(List<Cadete> cadetes)
    {
        this.cadetes = cadetes;
    }

    public List<InformeIndividual> GenerarListaDeDatos()
    {
        List<InformeIndividual> listaInforme = new List<InformeIndividual>();

        foreach (var cadeteX in cadetes)
        {
            var informeCadete = new InformeIndividual(cadeteX);
            listaInforme.Add(informeCadete);
        }
        return listaInforme;
    }

    public void Mostrar(){

        var listadoGral = GenerarListaDeDatos();

        System.Console.WriteLine("---------- Informe -------");
        foreach (var elementoX in listadoGral)
        {
            elementoX.MostrarInformeIndividual();
        }
    }


}*/