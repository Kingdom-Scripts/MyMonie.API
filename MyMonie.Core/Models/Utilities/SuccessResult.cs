namespace MyMonie.Core.Models.Utilities;

public class SuccessResult : Result
{
    public SuccessResult() : base(true)
    {
        Status = 200;
    }

    public SuccessResult(object content) : base(true, string.Empty, content)
    {
        Status = 200;
        Title = "Operation Successful";
    }

    public SuccessResult(string message) : base(true, message, null)
    {
        Status = 200;
        Title = "Operation Successful";
    }

    public SuccessResult(string message, object content) : base(true, message, content)
    {
        Status = 200;
        Title = "Operation Successful";
    }

    public SuccessResult(string message, object content, int statusCode) : base(true, message, content)
    {
        Status = statusCode;
        Title = "Operation Successful";
    }

    public SuccessResult(string title, string message, object content, int statusCode) : base(true, message, content)
    {
        Title = title;
        Status = statusCode;
    }
}

public class SuccessResult<T> : Result<T>
{
    public SuccessResult() : base(true)
    {
        Status = 200;
        Title = "Operation Successful";
    }

    public SuccessResult(T content) : base(true, string.Empty, content)
    {
        Status = 200;
        Title = "Operation Successful";
    }

    public SuccessResult(T content, string message) : base(true, message, content)
    {
        Status = 200;
        Title = "Operation Successful";
    }

    public SuccessResult(T content, string message, int statusCode) : base(true, message, content)
    {
        Status = statusCode;
        Title = "Operation Successful";
    }
}