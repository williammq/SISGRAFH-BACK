namespace SISGRAFH.Api.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            DataResponse = data;
        }
        public T DataResponse { get; set; }
    }
}
