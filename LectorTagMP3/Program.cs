using System.IO;

string pathCancion;

do
{
    Console.WriteLine("Ingrese la ruta de la cancion para leer su TAG:");
    pathCancion = Console.ReadLine();
    pathCancion = $@"{pathCancion}";
} while (!File.Exists(pathCancion));

using (FileStream fs = new FileStream(pathCancion, FileMode.Open))
{
    
}
