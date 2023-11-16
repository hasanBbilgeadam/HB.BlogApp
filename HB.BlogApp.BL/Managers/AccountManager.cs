using AutoMapper;
using HB.BlogApp.BL.Services;
using HB.BlogApp.Dto;
using HB.BlogApp.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.BL.Managers
{
    public class AccountManager : IAccountService
    {

        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper _mapper;
        private readonly IEmailService _mailService;

        public AccountManager(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IMapper mapper, IEmailService mailService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            _mapper = mapper;
            _mailService = mailService;
        }

        public async Task<List<string>>  Regiser(UserCreateDto dto)
        {
            //void => Task
         
            var user = _mapper.Map<AppUser>(dto);


         var result =   await  userManager.CreateAsync(user, dto.Password);


            if (result.Succeeded)
            {
                //aktivasyon maili gönder

                //<a href ="link">Hesap Aktivasyon Buraya Tıklayınız </a>
               

                var registredUser =  await userManager.FindByEmailAsync(dto.Email);

                var token = await userManager.GenerateEmailConfirmationTokenAsync(registredUser);
                var userID = registredUser.Id;

                var url = EmailComfirmLinkGenerator(token,userID);
                var html = $@"<html><head></head>
                    
                        <body>

                                    <h2>HOŞGELDİN</h2>
                            <a href = {url}> Hesap Aktivasyon Buraya Tıklayınız </a>
                        </body>
    
    
    
                       </html>";


                _mailService.SendMail(user.Email, "Email Confirm",html);

                return new List<string>();
            }


           var errorList =  result.Errors.Select(x => 
            
            x.Description
            ).ToList();

            return errorList;
        }


        private string EmailComfirmLinkGenerator(string token, string UserId)
        {

            var link = "https://localhost:7185/Account/ConfirmEmail";





            link += "?" + "userId=" + UserId + "&token=" + token;

            return link;
            
        }
    }



}
