﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mail
{
    public interface IMailSender
    {
        Task SendEmailAsync(string email,string subject,string message);
    }
}
