﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace juve.Models
{
    public class IdentityModels
    {
        public class ApplicationUser : IdentityUser
        {
            public UserData UserData { get; set; }

            public async Task<ClaimsIdentity>GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
            {
                    var userIdentity
                        = await manager.CreateIdentityAsync
                        (this, DefaultAuthenticationTypes
                        .ApplicationCookie);
                    return userIdentity;
            }  
                 
            
            
        }
    }
}