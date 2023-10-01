#nullable enable
namespace CorePersistence.Responses;

public class CoreResponse<T> where T: class
{
    public T? DataObj { get; set; }
    public bool Status { get; set; }
    public string Message { get; set; }

    public CoreResponse(T dataObj, string message)
    {
        DataObj = dataObj;
        Message = message;
        Status = true;
    }
    
    public CoreResponse(string message)
    {
        DataObj = null;
        Message = message;
        Status = false;
    }
}