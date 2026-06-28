namespace EspacioId3v1Tag;


public class Id3v1Tag
{
    private string titulo;

    private string artista;

    private string album;

    private int anio;

    private string comentario;

    private string genero;

    public string Titulo {get => titulo;}

    public string Artista {get => artista;}

    public string Album {get => album;}

    public int Anio {get => anio;}

    public string Comentario {get => comentario;}

    public string Genero {get => genero;}

    public Id3v1Tag(string titulo, string artista, string album, int anio, string comentario, string genero)
    {
        this.titulo = titulo;
        this.artista = artista;
        this.album = album;
        this.anio = anio;
        this.comentario = comentario;
        this.genero = genero;
    }
}
