namespace Schedule.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string className) : base(className + ". Not found object... :(")
    {
    }

    public NotFoundException(string className, object? key) : base(className + ". Not found object... :(" + key){}
}