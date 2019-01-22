using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TodoList.Api.Data.Dtos;
using TodoList.Api.Data.Models;
using TodoList.Api.Data.Repositories;

namespace TodoList.Api.Services {
    public interface IAuthorizationService {
        Task<IdentityResult> Register(UserRegistrationModel registrationModel);
    }

    public class AuthorizationService : IAuthorizationService {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthorizationService(UserManager<ApplicationUser> userManager) {
            this._userManager = userManager;
        }

        public async Task<IdentityResult> Register(UserRegistrationModel registrationModel) {
            ApplicationUser applicationUser = new ApplicationUser() {
                Email = registrationModel.Email,
                UserName = registrationModel.Email,
                FirstName = registrationModel.FirstName,
                LastName = registrationModel.LastName
            };

            return await this._userManager.CreateAsync(applicationUser, registrationModel.Password);
        }
    }
}