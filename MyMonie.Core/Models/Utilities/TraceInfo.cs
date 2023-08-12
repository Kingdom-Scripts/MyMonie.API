namespace MyMonie.Core.Models.Utilities;

public class TraceInfo
{
    public string FileName { get; set; }
    public string MethodName { get; set; }
    public int LineNumber { get; set; }
    public int ColumnNumber { get; set; }
}