namespace CleanArchitecture.Application.Features.Shared.Queries
{
    //Es la clase base de lo que se le retornara al cliente
    public class PaginationVm<T> where T : class
    {
        public int Count { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public IReadOnlyList<T>? Data { get; set; }
        public int PageCount { get; set; }
    }
}
