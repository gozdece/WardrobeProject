using Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validations
{
    public class PasswordValidator : IPasswordValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
        {
            List<IdentityError> errors = new List<IdentityError>();
            if (password.Length < 8) //Password karakter sayısı
                errors.Add(new IdentityError { Code = "PasswordLength", Description = "Passwordlength must be greater than 8" });

            if (password.Length > 20) //Password karakter sayısı
                errors.Add(new IdentityError { Code = "PasswordLength", Description = "Passwordlength must be lower than 20" });

            if (!errors.Any())
                return Task.FromResult(IdentityResult.Success);
            else
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
        }
    }

}
    

