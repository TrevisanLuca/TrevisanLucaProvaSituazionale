namespace TrevisanLucaProvaSituazionale.Exceptions;

public class FilmVietatoException : Exception
{
    public FilmVietatoException()
    {
    }

    public FilmVietatoException(string movieName) 
        : base(string.Format("Lo spettatore non può accedere al film {0}", movieName))
    {
    }
}