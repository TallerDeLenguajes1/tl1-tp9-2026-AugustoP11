using System.IO;

string path;

do
{
    Console.WriteLine("Ingrese un path válido de un directorio para analizar:");
    path = Console.ReadLine();
    path = $@"{path}";
} while (!Directory.Exists(path));

DirectoryInfo informacionDirectorio = new DirectoryInfo(path);

//Lo hice de esta forma primero, pero quiero probar con DirectoryInfo y FileInfo
//string[] carpetas = Directory.GetDirectories(path);

DirectoryInfo[] subdirectorios = informacionDirectorio.GetDirectories();

Console.WriteLine("CARPETAS ENCONTRADAS:");

foreach (DirectoryInfo carpeta in subdirectorios)
{
    Console.WriteLine($"- {carpeta.Name}");
}

Console.WriteLine("\nARCHIVOS ENCONTRADOS:");
Console.WriteLine("|---NOMBRE---|---TAMAÑO---|");
FileInfo[] archivos = informacionDirectorio.GetFiles();

foreach (FileInfo archivo in archivos)
{
    double tamanioKB = archivo.Length / 1024.0;

    Console.WriteLine($"{archivo.Name} | {tamanioKB:F2} KB");
}

string archivoReporte = path + @"/reporte_archivos.csv";

if (!File.Exists(archivoReporte))
{
    using (FileStream fs = new FileStream(archivoReporte, FileMode.Create))
    {
    }
}

string pathActual = @"e:/GitHub/Taller-de-lenguajes-1/tl1-tp9-2026-AugustoP11/LectorDirectorio";
string pathRelativo = Path.GetRelativePath(pathActual, archivoReporte);


using (StreamWriter escribirReporte = new StreamWriter(archivoReporte))
{
    escribirReporte.WriteLine("Nombre del archivo;Tamaño (KB);Ultima modificación");
    foreach (FileInfo archivo in archivos)
    {
        double tamanioKB = archivo.Length / 1024.0;
        escribirReporte.WriteLine($"{archivo.Name};{tamanioKB:F2};{archivo.LastWriteTime}");
    }
}
