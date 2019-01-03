using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using H2S04.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace H2S04.Pages
{

    [Authorize(Roles = "ProductAdministrators")]
    public class PrivacyModel : PageModel
    {
        public void OnGet()
        {


    }
    }
}