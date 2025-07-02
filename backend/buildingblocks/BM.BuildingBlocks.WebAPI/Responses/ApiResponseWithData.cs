namespace BM.BuildingBlocks.WebAPI.Responses
{
    public class ApiResponseWithData<T> : ApiResponse
    {
        public T? Data { get; set; }
    }
}
