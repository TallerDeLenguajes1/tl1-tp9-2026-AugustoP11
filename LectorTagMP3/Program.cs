using System.IO;
using System.Text;
using EspacioId3v1Tag;

string pathCancion;

do
{
    Console.WriteLine("Ingrese la ruta de la cancion para leer su TAG:");
    pathCancion = Console.ReadLine();
    pathCancion = $@"{pathCancion}";
} while (!File.Exists(pathCancion));

//Segun el tp, la estructura Tag ID3v1 se encuentra en los ultimos 128 bytes del archivo, asi quie mi estrategia (o lo que intentaré) será aislar esos 128 bytes del final y analizarlos para extraer la información
using (FileStream fs = new FileStream(pathCancion, FileMode.Open))
{
    string titulo;
    string artista;
    string album;
    string anio;
    string comentario;
    string genero;

    using (var reader = new BinaryReader(fs, Encoding.GetEncoding("latin1"), false))
    {
        //Con esto desde el final me "muevo hacia la izquierda 128 bytes" por así decirlo 
        fs.Seek(-128, SeekOrigin.End);
        byte[] buffer = new byte[128];
        reader.Read(buffer, 0, 128);

        string tag = Encoding.GetEncoding("latin1").GetString(buffer, 0, 3).Trim(' ', '\0');
        titulo = Encoding.GetEncoding("latin1").GetString(buffer, 3, 30).Trim(' ', '\0');
        artista = Encoding.GetEncoding("latin1").GetString(buffer, 33, 30).Trim(' ', '\0');
        album = Encoding.GetEncoding("latin1").GetString(buffer, 63, 30).Trim(' ', '\0');
        anio = Encoding.GetEncoding("latin1").GetString(buffer, 93, 4).Trim(' ', '\0');
        comentario = Encoding.GetEncoding("latin1").GetString(buffer, 97, 30).Trim(' ', '\0');
        genero = Encoding.GetEncoding("latin1").GetString(buffer, 127, 1).Trim(' ', '\0');

    }
}
