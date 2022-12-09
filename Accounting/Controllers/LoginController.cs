using Accounting.Interfaces;
using Accounting.Models.Model;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService= loginService;
        }

        [HttpPost("ValidateUser")]
        public async Task<IActionResult> ValidateUser([FromBody]UserLoginModel data)
        {
            var validateData = await _loginService.GetUserAsync(data.Username);
            if(validateData != null && validateData.Password.Equals(data.Password))
            {
                ResUserLogin res = new ResUserLogin()
                {
                    code =  "200",
                    message = "Success"
                };
                return Ok(res);
            }
            return BadRequest("Fail Login");
        }
    }
}
