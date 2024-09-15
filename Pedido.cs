public enum Estado{    
    pendiente,
    entregado, 
    cancelado,
}
public class Pedido{
    private int nroPedido;
    private string observacion;
    private Cliente cliente;
    private Estado estado;
    private Cadete cadete;

    public int NroPedido { get => nroPedido; } //get: obtenemos el dato
    public string Observacion { get => observacion;}
    public Cliente Cliente { get => cliente; }
    public Estado Estado { get => estado;}
    public Cadete Cadete { get => cadete; }

    public Pedido(int nroPedido, string observacion, Estado estado, string nombre, string direccion, string telefono, string datosReferenciaDireccion){
        this.nroPedido = nroPedido;
        this.observacion = observacion;
        cliente = new Cliente(nombre,direccion,telefono,datosReferenciaDireccion);
        this.estado = estado;
    }  
    public void cambiarEstado(Estado nuevoEstado){ //hacemos un metodo para no usar la propiedad set por que queda muy vulnerable

        estado = nuevoEstado;
    }
    
    public string VerDireccionCliente(){

        return Cliente.Direccion;
    } 
    public void verDatosCliente(){

        System.Console.WriteLine("Nombre Cliente:"+Cliente.Nombre);
        System.Console.WriteLine("Direccion:"+Cliente.Direccion);
        System.Console.WriteLine("Telefono:"+Cliente.Telefono);
        System.Console.WriteLine("Datos Referencia:"+Cliente.DatosReferenciaDireccion);

    }

    public void AsignarCadete(Cadete cadete)
    {
        this.cadete = cadete;
    }
    

}






