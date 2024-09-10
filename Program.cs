using ServicioCadeteria;

internal class Program
{
    private static void Main(string[] args)
    {

        int opcionMenu;
        string menu;
        bool bandera = true;
        PedidosTemp recepcionPedido = new PedidosTemp();

        var manejoDeArchivos = new ManejoDeArchivos();      
        var cadetesYCadeteria = manejoDeArchivos.obtenerCadeteria(); //obtenemos cadetes y datos cadeteria
        
        /*
        List<Cadete> listadoCadetes = new List<Cadete>();
        listadoCadetes.Add(new Cadete(1, "jimena", "prospero mena", "12345", new List<Pedido>()));
        listadoCadetes.Add(new Cadete(2, "enzo", "garmendia", "12345", new List<Pedido>()));
        listadoCadetes.Add(new Cadete(3, "javier", "san juan", "12345", new List<Pedido>()));
        Cadeteria cadeteria = new Cadeteria("Cadeteria","3817373",listadoCadetes);*/

        while (bandera)
        {
            System.Console.WriteLine("------------MENU-----------");
            System.Console.WriteLine("1.Dar de alta un pedido");
            System.Console.WriteLine("2.Asignar a cadete");
            System.Console.WriteLine("3.Cambiar Estado del pedido");
            System.Console.WriteLine("4.Reasignar Pedido a otro cadete");
            System.Console.WriteLine("5.Finalizar");

            do
            {
                System.Console.WriteLine("Ingrese una opcion:");
                menu = Console.ReadLine();

            } while (string.IsNullOrEmpty(menu));

            bool resutado = int.TryParse(menu, out opcionMenu);


            if (resutado == true && opcionMenu >= 1 && opcionMenu <= 5)
            {
                switch (opcionMenu)
                {
                    case 1:
                        string numPedido;
                        int nroPedido;
                        string observacion;
                        string nombre, direccion, telefono, datosReferenciaDireccion;
                        bool resultado;

                        do
                        {
                            System.Console.WriteLine("Ingrese numero de pedido:");
                            numPedido = Console.ReadLine();
                            resultado = int.TryParse(numPedido, out nroPedido);
                        } while (!resultado);

                        System.Console.WriteLine("Ingrese observacion:");
                        observacion = Console.ReadLine();
                        System.Console.WriteLine("Ingrese Nombre cliente:");
                        nombre = Console.ReadLine();
                        System.Console.WriteLine("Ingrese Direccion:");
                        direccion = Console.ReadLine();
                        System.Console.WriteLine("Ingrese telefono:");
                        telefono = Console.ReadLine();
                        System.Console.WriteLine("Datos de referencia:");
                        datosReferenciaDireccion = Console.ReadLine();

                        recepcionPedido.TomarPedido(nroPedido, observacion, Estado.pendiente, nombre, direccion, telefono, datosReferenciaDireccion);

                        break;
                    case 2:
                        string inputId, inputPedido;
                        int idCadete, nroPedidoBuscar;

                        System.Console.WriteLine("Asignar Cadete:");
                        System.Console.WriteLine("Ingrese Id cadete");
                        inputId = Console.ReadLine();
                        bool result = int.TryParse(inputId, out idCadete);

                        System.Console.WriteLine("Ingrese el nro pedido");
                        inputPedido = Console.ReadLine();
                        bool result1 = int.TryParse(inputPedido, out nroPedidoBuscar);

                        if (result && result1)
                        {
                           Pedido pedidoBuscado = recepcionPedido.BuscarPedido(nroPedidoBuscar);
                           cadetesYCadeteria.asignarPedidoCadete(idCadete,pedidoBuscado);
                           recepcionPedido.EliminarPedidoTemp(pedidoBuscado);
                        }else
                        {
                            System.Console.WriteLine("no se puedo asignar");
                        }
                        break;
                    case 3:
                        string nuevoEstado, inputPed;
                        int nroPedidoCambiar, opcionEstado;
                        
                        System.Console.WriteLine("Ingrese el numero de pedido a cambiar");
                        inputPed = Console.ReadLine();
                        bool result2 = int.TryParse(inputPed, out nroPedidoCambiar);

                        System.Console.WriteLine("Seleccione el nuevo estado:\n1:Entregado\n2:Cancelado");
                        nuevoEstado = Console.ReadLine();
                        bool result3 = int.TryParse(nuevoEstado,out opcionEstado);

                        if (result2 && result3 && opcionEstado >= 1 && opcionEstado <=3 )
                        {
                            Estado nuevoestado = (Estado)opcionEstado; //casteamos el entero por el enum
                            cadetesYCadeteria.cambiarEstado(nuevoestado,nroPedidoCambiar);
                        }else
                        {
                            System.Console.WriteLine("No se pudo modificar el estado");
                        }
                        break;
                    case 4:

                        string inputID, inputPedidoAsig;
                        int idCadeteAsignar, nroPedidoAsignar;

                        System.Console.WriteLine("Ingrese el id del nuevo cadete");
                        inputID = Console.ReadLine();
                        bool result4 = int.TryParse(inputID, out idCadeteAsignar);

                        System.Console.WriteLine("Ingrese nro pedido a reasignar");
                        inputPedidoAsig = Console.ReadLine();
                        bool result5 = int.TryParse(inputPedidoAsig, out nroPedidoAsignar);

                        if (result4 && result5)
                        {
                            cadetesYCadeteria.ReasignarCadete(idCadeteAsignar,nroPedidoAsignar);
                        }else
                        {
                            System.Console.WriteLine("No se pudo reasignar el pedido al nuevo cadete");
                        }
                        break;
                        case 5:
                            bandera = false;
                            break;
                }
            }

        }

        Informe informeFinal = new Informe(cadetesYCadeteria.ListadoCadetes);
        informeFinal.Mostrar();

    }
}