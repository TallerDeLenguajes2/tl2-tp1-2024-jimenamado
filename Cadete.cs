public class Cadete
{

    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedido> listadoPedidos;


    public int Id { get => id; }
    public string Nombre { get => nombre; }
    public string Direccion { get => direccion; }
    public string Telefono { get => telefono; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos; }

    /*
        public Cadete(int id,string nombre, string direccion, string telefono){
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            listadoPedidos = new List<Pedido>();
        }
    */
    public Cadete(int id, string nombre, string direccion, string telefono, List<Pedido> pedidos)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        listadoPedidos = pedidos;
    }

    public void AgregarPedidoListado(Pedido pedido)
    {      //accedemos al listado para agregar un pedido al cadete

        listadoPedidos.Add(pedido);
    }

    public void EliminarPedidoCadete(int nroPedido)//Un cadete quita de su lista un pedido por Id
    {
        Pedido pedidoBuscado = null;
        foreach (var pedidoX in listadoPedidos)
        {
            if (nroPedido == pedidoX.NroPedido)
            {
                pedidoBuscado = pedidoX;
            }
        }

        if (pedidoBuscado != null)
        {
            listadoPedidos.Remove(pedidoBuscado);
        }
    }
    public int CantidadPedidos(){

        return ListadoPedidos.Count;
    }
     public int JornalACobrar()
    {

        int cantidadPedidos = CantidadPedidos();
        int montoPorPedido = 500;
        int montoACobrar = cantidadPedidos * montoPorPedido;

        return montoACobrar;
    }

    public int CantidadPedidosRecibidosCadete(){

        return (ListadoPedidos.Count);
    }
    public int CantidadPedidosEnviadosCadete(){

        int contador=0;
        foreach (var pedidosX in ListadoPedidos)
        {
            if (pedidosX.Estado == Estado.entregado)
            {
                contador++;
            }
        }
        return contador;
    }

    public float PromedioPedidosCadete(){

        int pedidosRecibidos = CantidadPedidosRecibidosCadete();
        int pedidosEnviados = CantidadPedidosEnviadosCadete();

        if (pedidosRecibidos == 0)
        {
            return 0;                               //evitar division en 0
        }else
        {
            return (float)pedidosEnviados/pedidosRecibidos;
        }
    }

}






