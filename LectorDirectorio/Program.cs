using System.IO;

string path;

do
{
    Console.WriteLine("Ingrese un path válido de un directorio para analizar:");
    path = Console.ReadLine();
} while (!Directory.Exists(path));

