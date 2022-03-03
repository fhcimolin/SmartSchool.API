namespace SmartSchool.API.Helpers
{
    public class PaginationHeader
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        
        public PaginationHeader(int currentPage, int itemsPerPage, int pageSize, int totalItems)
        {
            this.CurrentPage = currentPage;
            this.ItemsPerPage = itemsPerPage;
            this.PageSize = pageSize;
            this.TotalItems = totalItems;
        }
    }
}