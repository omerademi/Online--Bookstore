using BookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Service.Interfaces
{
    public interface IEmailService
    {
        void SendMail(Email email);
    }
}
