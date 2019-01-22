using System.ComponentModel.DataAnnotations;

namespace TodoList.Api.Data.Dtos.Request {
    public class UserLoginRequestModel {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}