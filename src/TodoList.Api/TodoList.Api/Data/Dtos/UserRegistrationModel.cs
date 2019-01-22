using System.ComponentModel.DataAnnotations;

namespace TodoList.Api.Data.Dtos {
    public class UserRegistrationModel {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 200 characters")]
        public string Password { get; set; }
    }
}