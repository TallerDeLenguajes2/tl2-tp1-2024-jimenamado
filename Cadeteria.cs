using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
namespace ServicioCadeteria;
public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes;

    public string Nombre { get => nombre; }
    public string Telefono { get => telefono; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; }

    public Cadeteria(string nombre, string telefono,  List<Cadete> cadetes)
    {

        this.nombre = nombre;
        this.telefono = telefono;
        listadoCadetes = cadetes;
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

    public void asignarPedidoCadete(int idCadete, Pedido nuevoPedido)
    {
        foreach (var cadeteX in listadoCadetes)
        {
            if (idCadete == cadeteX.Id)
            {
                cadeteX.AgregarPedidoListado(nuevoPedido);
            }
        }
    }


    public void cambiarEstado(Estado nuevoEstado, int nroPedido)
    {
        foreach (var cadeteX in ListadoCadetes)
        {
            foreach (var pedidoX in cadeteX.ListadoPedidos)
            {
                if (nroPedido == pedidoX.NroPedido)
                {
                    pedidoX.cambiarEstado(nuevoEstado);
                }
            }
        }
    }


    public Pedido BuscarPedidoCadete(int nroPedido)
    {

        foreach (var cadeteX in listadoCadetes)
        {
            foreach (var pedidoX in cadeteX.ListadoPedidos)
            {
                if (nroPedido == pedidoX.NroPedido)
                {
                    return pedidoX;
                }
            }

        }
        return null;
    }

    public void ReasignarCadete(int idNuevoCadete, int nroPedido)
    {
        Pedido pedidoBuscado = BuscarPedidoCadete(nroPedido);
        Cadete cadete2 = BuscarCadete(idNuevoCadete);

        if (pedidoBuscado != null && cadete2 != null)
        {
            var cadete1 = BuscarCadeteXPedido(pedidoBuscado);
            cadete1.EliminarPedidoCadete(pedidoBuscado.NroPedido);
            cadete2.AgregarPedidoListado(pedidoBuscado);
            
        }
    }

    private Cadete BuscarCadeteXPedido(Pedido pedido)
    {
        foreach (var cadeteX in listadoCadetes)
        {
            foreach (var pedidoX in cadeteX.ListadoPedidos)
            {
                if (pedidoX == pedido)
                {
                    return cadeteX;
                }
            }
        }
        return null;
    }

    public int TotalPedidosRecibidos(){

        int contadorPedidos = 0;
        foreach (var cadeteX in ListadoCadetes)
        {
            foreach (var pedidoX in cadeteX.ListadoPedidos)
            {
                contadorPedidos++;
            }
        }
        return contadorPedidos;
    }
    
    public int TotalPedidosEntregados(){
        
        int contador = 0;
        foreach (var cadeteX in listadoCadetes)
        {
            foreach (var pedidoX in cadeteX.ListadoPedidos)
            {
                if (pedidoX.Estado == Estado.entregado)
                {
                    contador++;
                }
            }
        }
        return contador;
    }


    }





