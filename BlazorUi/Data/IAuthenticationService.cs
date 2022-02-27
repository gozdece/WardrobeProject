using Core.Dtos;
using Core.Dtos.UserDto;
using System.Threading.Tasks;

namespace BlazorUi.Data
{
    public interface IAuthenticationService
    {
       // Task<AuthResponseDto<UserRegisterDto>> RegisterUser(UserRegisterDto userForRegistration);
        Task<AuthResponseDto<UserLoginDto>> Login(UserLoginDto userForAuthentication);
        Task Logout();
    }
}
