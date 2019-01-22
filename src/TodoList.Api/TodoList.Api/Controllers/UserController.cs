using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Data.Dtos;
using TodoList.Api.Framework.Extensions;
using TodoList.Api.Services;

namespace TodoList.Api.Controllers {
    [Route("api/user")]
    public class UserController : ControllerBase {
        private readonly IAuthorizationService _authorizationService;

        public UserController(IAuthorizationService authorizationService) {
            this._authorizationService = authorizationService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]UserRegistrationModel model) {
            if (!this.ModelState.IsValid) {
                return this.BadRequest(this.ModelState);
            }

            IdentityResult registrationResult = await this._authorizationService.Register(model);
            if (!registrationResult.Succeeded) {
                this.ModelState.AddIdentityErrors(registrationResult);
                return this.BadRequest(this.ModelState);
            }
            
            return this.StatusCode((int)HttpStatusCode.Created);
        }
    }
}