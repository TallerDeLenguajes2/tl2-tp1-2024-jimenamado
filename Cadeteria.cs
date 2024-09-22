using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
namespace ServicioCadeteria;
public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes;
    private List<Pedido> listadoPedidos;

    public string Nombre { get => nombre; }
    public string Telefono { get => telefono; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos; }

    public Cadeteria(string nombre, string telefono, List<Cadete> cadetes)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        listadoCadetes = cadetes;
        listadoPedidos = new List<Pedido>();
    }
    public Cadeteria()
    {
    }

    public void TomarPedido(int nroPedido, string observacion, Estado estado, string nombre, string direccion, string telefono, string datosReferencia)
    {
        Pedido nuevoPedido = new Pedido(nroPedido, observacion, estado, direccion, nombre, telefono, datosReferencia);
        listadoPedidos.Add(nuevoPedido);
    }
    public Pedido BuscarPedido(int nroPedido)
    {
        Pedido pedidoBuscado = listadoPedidos.Find(p => p.NroPedido == nroPedido);    //forma de recorrer la lista con una condicion
        return pedidoBuscado;
    }
    public void asignarCadeteAPedido(int idCadete, int idPedido)
    {
        Cadete cadete = null;
        //A1 Buscar cadete
        foreach (var cadeteX in listadoCadetes)
        {
            if (cadeteX.Id == idCadete)
            {
                cadete = cadeteX;
            }
        }

        //A2 verficar  que existe el cadete
        if (cadete != null)
        {
            //A3 Buscar pedido
            foreach (var pedidoX in listadoPedidos)
            {
                //A4 Asignar cadete
                if (pedidoX.NroPedido == idPedido)
                {
                    pedidoX.AsignarCadete(cadete);
                }
            }
        }

    }
    public int JornalAPagarCadete(int idCadete)
    {
        int cantPedidosCadete = 0, montoACobrar;

        foreach (var pedidoX in listadoPedidos)
        {
            if (pedidoX.Cadete.Id == idCadete)
            {
                cantPedidosCadete++;
            }
        }
        montoACobrar = cantPedidosCadete * 500;

        return montoACobrar;
    }
    public int TotalPagoSueldo(){

        int montoAcumulado=0;
        foreach (var cadeteX in listadoCadetes)
        {
            montoAcumulado = montoAcumulado + JornalAPagarCadete(cadeteX.Id);
        }
        return montoAcumulado;
    }
    public Cadete BuscarCadete(int idCadete)
    {
        Cadete cadeteBuscado = null;

        foreach (var cadeteX in listadoCadetes)
        {
            if (idCadete == cadeteX.Id)
            {
                return cadeteX;
            }
        }
        return cadeteBuscado;
    }
    public void cambiarEstado(Estado nuevoEstado, int nroPedido)
    {

        foreach (var pedidoX in listadoPedidos)
        {
            if (nroPedido == pedidoX.NroPedido)
            {
                pedidoX.cambiarEstado(nuevoEstado);
            }
        }
    }
    public void ReasignarCadete(int idNuevoCadete, int nroPedido)
    {

        asignarCadeteAPedido(idNuevoCadete, nroPedido);

    }

    public int TotalPedidosRecibidos()
    {
        int contadorPedidos = 0;

        foreach (var pedidoX in listadoPedidos)
        {
            contadorPedidos++;
        }

        return contadorPedidos;
    }

    public int TotalPedidosEntregados()
    {
        int contador = 0;

        foreach (var pedidoX in listadoPedidos)
        {
            if (pedidoX.Estado == Estado.entregado)
            {
                contador++;
            }
        }
        return contador;
    }

    public int TotalPedidosCancelados(){

        int totalPedidos = TotalPedidosRecibidos();
        int totalEnviados = TotalPedidosEntregados();
        int totalCancelados = totalPedidos - totalEnviados;

        return totalCancelados;
    }
}





