using System;
using System.Net;
using H2S04.Data;
using H2S04.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace H2S04.Controllers
{
    [Route("api/bag/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        private UserManager<ApplicationUser> _userManager;

        public ProductController(ProductService productService, UserManager<ApplicationUser> userManager)
        {
            _productService = productService;
            _userManager = userManager;

        }
        [HttpPut]
        public ActionResult Put(int productId)
        {   

            if(productId == 0)
            {
                return BadRequest();
            }
            string id = _userManager.GetUserId(User);

            if ( id== null)
            {
                return Unauthorized();
            }

            try
            {
                var bag = _productService.Get(id);
                if (bag != null)
                {
                    bag.Products.Add(productId);
                    _productService.Update(bag);
                }
                else
                {
                    bag = new Models.Bag { UserId = id };
                    bag.Products.Add(productId);
                    _productService.Insert(bag);
                }
            }catch(Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }


            return StatusCode((int)HttpStatusCode.OK);

        }
        [HttpGet]
        public ActionResult Get()
        {
            return Content("hello world!");
        }

    }
    }

