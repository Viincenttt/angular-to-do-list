﻿using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Data.Dtos;
using TodoList.Api.Data.Dtos.Request;
using TodoList.Api.Data.Dtos.Response;
using TodoList.Api.Framework.Extensions;
using TodoList.Api.Services;
using IAuthorizationService = TodoList.Api.Services.IAuthorizationService;

namespace TodoList.Api.Controllers {
    [Route("api/user")]
    public class UserController : ControllerBase {
        private readonly IAuthorizationService _authorizationService;

        public UserController(IAuthorizationService authorizationService) {
            this._authorizationService = authorizationService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]UserRegistrationRequestModel model) {
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

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]UserLoginRequestModel model) {
            if (!this.ModelState.IsValid) {
                return this.BadRequest(this.ModelState);
            }

            UserLoginResponseModel response = await this._authorizationService.Login(model);
            if (!response.Succeeded) {
                this.ModelState.AddModelError("", "Invalid username or password");
                return this.BadRequest(this.ModelState);
            }

            return this.Ok(response);
        }

        [HttpGet]
        [Route("authorize-test")]
        [Authorize]
        public IActionResult AuthorizeTest() {
            return this.Ok("Success!");
        }
    }
}