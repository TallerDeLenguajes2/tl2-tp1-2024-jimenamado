using ServicioCadeteria;
public class Informe
{
    private int cantidadPedidos;
    private int cantidadPedidosEntregados;
    private int cantidadPedidosCancelados;
    private int totalSueldo;

    public Informe(Cadeteria cadeteria)
    {
        cantidadPedidos = cadeteria.TotalPedidosRecibidos();
        cantidadPedidosEntregados = cadeteria.TotalPedidosEntregados();
        cantidadPedidosCancelados = cadeteria.TotalPedidosCancelados();
        totalSueldo = cadeteria.TotalPagoSueldo();
    }

    public int CantidadPedidos { get => cantidadPedidos; }
    public int CantidadPedidosEntregados { get => cantidadPedidosEntregados;}
    public int CantidadPedidosCancelados { get => cantidadPedidosCancelados; }
    public int TotalSueldo { get => totalSueldo;}


    public void Mostrar(){

        System.Console.WriteLine("-----Informe FIN DE JORNADA - Cadeteria Ros----");
        System.Console.WriteLine("Total Pedidos recibidos:"+cantidadPedidos);
        System.Console.WriteLine("Total Pedidos Enviados:"+cantidadPedidosEntregados);
        System.Console.WriteLine("Total Pedidos Cancelados:"+cantidadPedidosCancelados);
        System.Console.WriteLine("Total sueldos a pagar:"+totalSueldo);
        System.Console.WriteLine("-----------------");
        
    }
}