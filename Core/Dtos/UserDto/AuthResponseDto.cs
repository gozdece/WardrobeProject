using System;
namespace Core.Dtos.UserDto
{
    public class AuthResponseDto<T>
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
        public T Data { get; set; }
    }
}
