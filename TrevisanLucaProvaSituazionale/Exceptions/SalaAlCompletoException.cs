namespace TrevisanLucaProvaSituazionale.Exceptions;

public class SalaAlCompletoException : Exception
{
    public SalaAlCompletoException()
    {

    }
    public SalaAlCompletoException(string hallName) 
        : base(string.Format("{0} è al completo", hallName))
    {

    }
}