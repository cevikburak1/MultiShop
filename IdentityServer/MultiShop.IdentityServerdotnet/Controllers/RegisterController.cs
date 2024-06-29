using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServerdotnet.Dtos;
using MultiShop.IdentityServerdotnet.Models;
using System.Threading.Tasks;

namespace MultiShop.IdentityServerdotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegisterDto userRegisterDto)
        {
            var result = new ApplicationUser()
            {
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname,
            };
            var value = await _userManager.CreateAsync(result,userRegisterDto.Password);
            if (value.Succeeded)
            {
                return Ok("Kullanıcı Başarı İle Eklendi✔👏🐱‍🏍");
            }
            else 
            {
                return Ok("😱Üzgünüz Bir Hata Oluştu Tekrar Deneyiniz😢");
            }
        }
    }
}
