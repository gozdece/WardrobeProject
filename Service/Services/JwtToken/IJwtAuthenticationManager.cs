using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.JwtToken
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(User user);
    }
}
