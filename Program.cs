using ServicioCadeteria;

internal class Program
{
    private static void Main(string[] args)
    {
        int opcionMenu, opcionEntrada;
        string menu, entrada;
        bool bandera = true;
        Cadeteria cadeteria = null;
        AccesoADatos acceso = null;

        do
        {
            System.Console.WriteLine("Ingrese la entrada de datos:\n1:Archivo CSV\n2:Archivo JSON");
            entrada = Console.ReadLine();

        } while (string.IsNullOrEmpty(entrada));

        bool respuesta = int.TryParse(entrada, out opcionEntrada);


        switch (opcionEntrada)
        {
            case 1:
                acceso = new AccesoCSV();
                break;
            case 2:
                acceso = new AccesoJSON();
                break;

            default:
                System.Console.WriteLine("Opcion invalida");
                break;
        }

        cadeteria = acceso.ObtenerCadeteria();

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

                        cadeteria.TomarPedido(nroPedido, observacion, Estado.pendiente, nombre, direccion, telefono, datosReferenciaDireccion);

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
                            cadeteria.asignarCadeteAPedido(idCadete, nroPedidoBuscar);

                        }
                        else
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
                        bool result3 = int.TryParse(nuevoEstado, out opcionEstado);

                        if (result2 && result3 && opcionEstado >= 1 && opcionEstado <= 3)
                        {
                            Estado nuevoestado = (Estado)opcionEstado; //casteamos el entero por el enum
                            cadeteria.cambiarEstado(nuevoestado, nroPedidoCambiar);
                        }
                        else
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
                            cadeteria.ReasignarCadete(idCadeteAsignar, nroPedidoAsignar);
                        }
                        else
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
        MostrarInforme(cadeteria);
    }

    private static void MostrarInforme(Cadeteria cadeteria)
    {
        Informe informeFinal = new Informe(cadeteria);
        System.Console.WriteLine("-----Informe FIN DE JORNADA - Cadeteria Ros----");
        System.Console.WriteLine("Total Pedidos recibidos:" + informeFinal.CantidadPedidos);
        System.Console.WriteLine("Total Pedidos Enviados:" + informeFinal.CantidadPedidosEntregados);
        System.Console.WriteLine("Total Pedidos Cancelados:" + informeFinal.CantidadPedidosCancelados);
        System.Console.WriteLine("Total sueldos a pagar:" + informeFinal.TotalSueldo);
        System.Console.WriteLine("-----------------");
    }
}