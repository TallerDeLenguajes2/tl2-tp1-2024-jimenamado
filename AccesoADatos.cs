using System.Text.Json.Nodes;
using ServicioCadeteria;
using System.Text.Json;

public abstract class AccesoADatos
{
    protected string rutaCadetes;
    protected string rutaCadeteria;

    protected AccesoADatos(string rutaCadetes, string rutaCadeteria)
    {
        this.rutaCadetes = rutaCadetes;
        this.rutaCadeteria = rutaCadeteria;
    }

    public abstract List<Cadete> ObtenerCadetes();
    public abstract Cadeteria ObtenerCadeteria();
    public bool ExisteArchivo(string rutaArchivo)
    {
        var infoArchivo = new FileInfo(rutaArchivo);        //obtener información detallada sobre un archivo

        if (File.Exists(rutaArchivo) && infoArchivo.Length > 0) //Length: Obtiene el tamaño del archivo en bytes.
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class AccesoCSV : AccesoADatos   //clase derivada de la clase base AccesoADatos
{
    public AccesoCSV() : base("Cadetes.csv", "Cadeteria.csv") // le doy valor a las variables heredadas de la clase base
    {

    }

    public override List<Cadete> ObtenerCadetes()       //Implementamos el metodo Abstracto "override"
    {
        List<Cadete> cadetes = new List<Cadete>();

        if (ExisteArchivo(rutaCadetes))
        {
            using (var infoCadeteStream = new StreamReader(rutaCadetes))//leer archivo y guardarlo
            {
                while (!infoCadeteStream.EndOfStream)    //no sea el final del flujo archivo
                {
                    string linea = infoCadeteStream.ReadLine(); //leer archivos línea por línea y guardamos en un string
                    string[] datosCadete = linea.Split(';');    //separamos y guardamos la linea en un arreglo

                    int id = int.Parse(datosCadete[0]);
                    string nombre = datosCadete[1];
                    string direccion = datosCadete[2];
                    string telefono = datosCadete[3];

                    cadetes.Add(new Cadete(id, nombre, direccion, telefono));
                }
                infoCadeteStream.Close();
            }
        }
        return cadetes;
    }

    public override Cadeteria ObtenerCadeteria()
    {
        Cadeteria cadeteria = null;

        if (ExisteArchivo(rutaCadeteria))
        {
            string textoArchivo = File.ReadAllText(rutaCadeteria);
            string[] datosCadeteria = textoArchivo.Split(';');
            string nombre = datosCadeteria[0].ToString();
            string telefono = datosCadeteria[1];

            List<Cadete> cadetes = ObtenerCadetes();
            cadeteria = new Cadeteria(nombre, telefono, cadetes);
        }
        return cadeteria;
    }
    
}


public class AccesoJSON : AccesoADatos
{
    public AccesoJSON():base("Cadetes.json","Cadeteria.json")
    {

    }

    public override List<Cadete> ObtenerCadetes()
    {
        List<Cadete> listado = new List<Cadete>();

        if (ExisteArchivo(rutaCadetes))
        {
            string contenidoJson = File.ReadAllText(rutaCadetes);
            listado = JsonSerializer.Deserialize<List<Cadete>>(contenidoJson);
        }
        return listado;

    }

    public override Cadeteria ObtenerCadeteria()
    {
        Cadeteria cadeteria = null;

        if (ExisteArchivo(rutaCadeteria))
        {
            string contenidoJsonCadetera = File.ReadAllText(rutaCadeteria); // leer el contenido del archivo json

            cadeteria = JsonSerializer.Deserialize<Cadeteria>(contenidoJsonCadetera);

            List<Cadete> cadetes = ObtenerCadetes();

            cadeteria = new Cadeteria(cadeteria.Nombre, cadeteria.Telefono, cadetes);

        }
        return cadeteria;
    }

}