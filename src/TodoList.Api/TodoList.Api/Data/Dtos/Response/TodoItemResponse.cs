namespace TodoList.Api.Data.Dtos.Response {
    public class TodoItemResponse {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SortOrder { get; set; }
    }
}