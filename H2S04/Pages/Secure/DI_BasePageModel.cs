using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using H2S04.Data;

namespace H2S04.Pages.Secure
{
    public class DI_BasePageModel: PageModel
    {
        protected BaseContext BaseContext;
        protected IAuthorizationService AuthorizationService;
        protected UserManager<ApplicationUser> UserManager;

        public DI_BasePageModel(BaseContext baseContext, IAuthorizationService authorizationService,
        UserManager<ApplicationUser> userManager) : base()
        {
            BaseContext = baseContext;
            AuthorizationService = authorizationService;
            UserManager = userManager;
        
        }


    }
}
