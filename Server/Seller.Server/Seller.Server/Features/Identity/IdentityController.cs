namespace Seller.Server.Features.Identity
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Seller.Server.Data.Models;
    using Models;
    using Services.Interfaces;
    public class IdentityController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly IIdentityService identityService;
        private readonly AppSettings appSettings;

        public IdentityController(
            UserManager<User> userManager, 
            IOptions<AppSettings> appSettings,
            IIdentityService identityService)
        {
            this.userManager = userManager;
            this.identityService = identityService;
            this.appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterUserRequestModel model)
        {
            var user = await this.identityService.Register(model.Email, model.UserName, model.Password, model.PhoneNumber);

            var userSS = new UserSS
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserId = user.Id
            };

            var result = await identityService.CreateUserSS(model.FirstName, model.LastName, user.Id);


            if (result) return Ok();
            
            return BadRequest();
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginUserRequestModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.UserName);
            if (user == null) return Unauthorized();
            
            var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid) return Unauthorized();
            
            return new LoginResponseModel
            {
                UserId = user.Id,
                Username = user.UserName,
                Token = identityService.GenerateJwtToken(user.Id,user.UserName,this.appSettings.Secret)
            };
        }
    }
}
