namespace MyMonie.Core.Models.Utilities;

public class ErrorResult : Result
{
    public ErrorResult() : base(false)
    {
        Status = 500;
        Title = "Error Occurred";
    }

    public ErrorResult(string message) : base(false, message)
    {
        Status = 500;
        Title = "Error Occurred";
    }

    public ErrorResult(string title, string message) : base(false, message)
    {
        Status = 500;
        Title = title;
    }

    public ErrorResult(string message, int status) : base(false, message)
    {
        Status = status;
    }

    public ErrorResult(string title, string message, int status) : base(false, message)
    {
        Status = status;
        Title = title;
    }

}

public class ErrorResult<T> : Result<T>
{
    public ErrorResult() : base(false)
    {
        Status = 500;
    }

    public ErrorResult(string message) : base(false, message)
    {
        Status = 500;
    }
    public ErrorResult(string message, int status) : base(false, message)
    {
        Status = status;
    }
}