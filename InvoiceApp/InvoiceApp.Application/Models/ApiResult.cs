using System.Text.Json.Serialization;

namespace InvoiceApp.Application.Models;

public class ApiResult<T>
{
    private ApiResult() { }

    private ApiResult(bool succeeded, T result, Dictionary<string, List<string>> errors)
    {
        Succeeded = succeeded;
        Result = result;
        Errors = errors;
    }
    
    private ApiResult(bool succeeded, T result, string error)
    {
        Succeeded = succeeded;
        Result = result;
        ErrorMessage = error;
    }

    public bool Succeeded { get; set; }
    public T Result { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, List<string>> Errors { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ErrorMessage { get; set; }

    public static ApiResult<T> Success(T result)
    {
        return new ApiResult<T>(true, result, new Dictionary<string, List<string>>());
    }

    public static ApiResult<T> Failure(Dictionary<string, List<string>> errors)
    {
        return new ApiResult<T>(false, default, errors);
    }
    
    public static ApiResult<T> Failure(string error)
    {
        return new ApiResult<T>(false, default, error);
    }
}