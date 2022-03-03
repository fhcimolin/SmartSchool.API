using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SmartSchool.API.Helpers
{
    public static class Extensions
    {
        public static void AddPagination(this HttpResponse response, 
            int currentPage, int itemsPerPage, int pageSize, int totalItems)
        {
            var paginationHeader = new PaginationHeader(
                currentPage,itemsPerPage,pageSize,totalItems);

            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader));
            response.Headers.Add("Access-Control-Expose-Header", "Pagination");
        }
    }
}