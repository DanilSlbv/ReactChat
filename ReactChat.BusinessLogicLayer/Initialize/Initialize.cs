using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReactChat.BusinessLogicLayer.Services;
using ReactChat.BusinessLogicLayer.Services.Interfaces;
using ReactChat.DataAccessLayer;
using ReactChat.DataAccessLayer.Entities;
using ReactChat.DataAccessLayer.Repositories;
using ReactChat.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.BusinessLogicLayer.Initialize
{
    public class Initialize
    {

        public static void DbInit(IServiceCollection service, IConfiguration _configuration)
        {
            service.AddDbContext<ApplicationContext>(options => options.UseLazyLoadingProxies().UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            service.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationContext>();
        }

        public static void RepositoryInitialize(IServiceCollection service)
        {
            service.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            service.AddScoped<IChatRepository, ChatRepository>();
            service.AddScoped<IMemberRepository, MemberRepository>();
            service.AddScoped<IMessageRepository, MessageRepository>();
            service.AddScoped<IVerificationCodeRepository, VerificationCodeRepository>();
        }

        public static void ServicesInitialize(IServiceCollection service)
        {
            service.AddScoped<IChatService, ChatService>();
            service.AddScoped<IApplicationUserService, ApplicationUserService>();
            service.AddScoped<IMemberService, MemberService>();
            service.AddScoped<IMessageService, MessageService>();
            service.AddScoped<IVerificationCodeService, VerificationCodeService>();
        }

    }
}
