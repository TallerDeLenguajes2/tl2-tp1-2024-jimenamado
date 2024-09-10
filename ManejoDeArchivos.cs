using System.Reflection.Metadata.Ecma335;
using ServicioCadeteria;

public class ManejoDeArchivos
{
    private string rutaCadetes;
    private string rutaCadeteria;

    public ManejoDeArchivos()
    {
        this.rutaCadetes = "Cadetes.csv";
        this.rutaCadeteria = "Cadeteria.csv";
    }

    private List<Cadete> ObtenerCadetes(){

        List<Cadete> cadetes = new List<Cadete>();

        var infoCadete = new FileInfo(rutaCadetes); //obtener información detallada sobre un archivo

        if (File.Exists(rutaCadetes) && infoCadete.Length > 0 ) //Length: Obtiene el tamaño del archivo en bytes.
        {
            using (var infoCadeteStream = new StreamReader(rutaCadetes))
            {
                while (!infoCadeteStream.EndOfStream)    //leer archivo y guardarlo
                {
                    string linea = infoCadeteStream.ReadLine(); //leer archivos línea por línea y guardamos en un string
                    string[] datosCadete = linea.Split(';');    //separamos y guardamos cada linea en un arreglo

                    int id = int.Parse(datosCadete[0]);
                    string nombre = datosCadete[1];
                    string direccion = datosCadete[2];
                    string telefono =datosCadete[3];
                    
                    cadetes.Add(new Cadete(id,nombre,direccion,telefono,new List<Pedido>()));
                }
                infoCadeteStream.Close();
            }
        }
        return cadetes;
    }

    public Cadeteria obtenerCadeteria(){

        Cadeteria cadeteria = null;

        if (File.Exists(rutaCadeteria) && new FileInfo(rutaCadeteria).Length > 0)
        {
            string[] textoArchivo = File.ReadAllLines(rutaCadeteria);
            string primeraLinea = textoArchivo[0];
            string[] datosCadeteria = primeraLinea.Split(';');
            string nombre = datosCadeteria[0];
            string telefono = datosCadeteria[1];
            List<Cadete> cadetes = ObtenerCadetes();
            
            cadeteria = new Cadeteria(nombre, telefono,cadetes);
        }
        return cadeteria;
    }

}