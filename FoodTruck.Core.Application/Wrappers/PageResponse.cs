namespace FoodTruck.Core.Application.Wrappers
{
    public class PageResponse<T> : Response<T>
    {
        public PageResponse(T data, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data;
            Message = null;
            Errors = null;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }


    }
}
