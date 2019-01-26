using System.ComponentModel.DataAnnotations;

namespace TodoList.Api.Data.Dtos.Response {
    public class TodoItemResponse {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string SortOrder { get; set; }
    }
}