public class PedidosTemp
{
    private List<Pedido> pedidosRecibidos;
    public PedidosTemp()
    {
        pedidosRecibidos = new List<Pedido>()
        {
            new Pedido(1,"aaa",Estado.pendiente,"aaa","aaa","1234","aaaa"),
            new Pedido(2,"aaa",Estado.pendiente,"aaa","aaa","1234","aaaa"),
            new Pedido(3,"aaa",Estado.pendiente,"aaa","aaa","1234","aaaa"),
            new Pedido(4,"aaa",Estado.pendiente,"aaa","aaa","1234","aaaa"),
            new Pedido(5,"aaa",Estado.pendiente,"aaa","aaa","1234","aaaa"),
            new Pedido(6,"aaa",Estado.pendiente,"aaa","aaa","1234","aaaa"),
        };



    }


    public void TomarPedido(int nroPedido, string observacion, Estado estado, string nombre, string direccion, string telefono, string datosReferencia)
    {
        Pedido nuevoPedido = new Pedido(nroPedido, observacion, estado, direccion, nombre, telefono, datosReferencia);
        pedidosRecibidos.Add(nuevoPedido);
    }

    public Pedido BuscarPedido(int nroPedido)
    {
        Pedido pedidoBuscado = pedidosRecibidos.Find(p => p.NroPedido == nroPedido);    //forma de recorrer la lista con una condicion
        return pedidoBuscado;
    }

    public void EliminarPedidoTemp(Pedido pedido){

        pedidosRecibidos.Remove(pedido);
        
    }

}