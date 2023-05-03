using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodForRequest.Data;
using FoodForRequest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;

namespace FoodForRequest.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class FoodrequestController : Controller
    {
        private readonly IFoodRequestRepository repository;

        private readonly UserManager<FoodUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public FoodrequestController(IFoodRequestRepository repository, UserManager<FoodUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.repository = repository;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        
      
  
        [AllowAnonymous]
        [HttpGet("GetAll")]
        public IEnumerable<FoodRequest> GetAllProduct()
        {
            return repository.GetAll();
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public FoodRequest? GetTopic(string id)
        {
            return repository.GetOne(id);
        }

        [AllowAnonymous]
        [HttpPost("Create")]
        public IActionResult Create([FromBody] FoodRequest food, IFormFile picture)
        {
            if (ModelState.IsValid)
            {
                FoodRequest f = new FoodRequest()
                {
                    Name = food.Name,
                    Description = food.Description,
                    RequestorId = userManager.GetUserId(User),
                };
                using (var stream = picture.OpenReadStream())
                {
                    byte[] buffer = new byte[picture.Length];
                    stream.Read(buffer, 0, (int)picture.Length);
                    f.Picture = buffer;
                    f.PictureContentType = picture.ContentType;
                }

                this.repository.Create(f);
                return Ok();
            }
            return Ok(food);
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var food = this.repository.GetOne(id);
            if (food != null && (food.Requestor.Id == userManager.GetUserId(User) || User.IsInRole("Admin")))
            {
                return Ok(food);
            }
            return Ok();
        }
        [AllowAnonymous]
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(string id, [FromBody] FoodRequest food)
        {
            if (ModelState.IsValid)
            {
                var old = this.repository.GetOne(id);

                if (old.Requestor.Id != userManager.GetUserId(User) && !User.IsInRole("Admin"))
                    return RedirectToAction(nameof(Index));

                old.Name = food.Name;
                old.Description = food.Description;
                old.IsDone = food.IsDone;

                this.repository.Update(old);
                return Ok(food);
            }

            return Ok(food);
        }
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var food = this.repository.GetOne(id);

            if (food != null && (food.Requestor.Id == userManager.GetUserId(User) || User.IsInRole("Admin")))
            {
                this.repository.Delete(food);
            }

            return Ok();


        }

        [Authorize]
        [HttpGet("Sell")]
        public IActionResult Sell(string foodid)
        {
            var food = this.repository.GetOne(foodid);

            if (food == null || food.Requestor.Id != userManager.GetUserId(User))
                return Ok();

            food.IsDone = true;
            this.repository.Update(food);

            return Ok();
        }
        [AllowAnonymous]
        [HttpGet("Image")]
        public IActionResult GetImage(string id)
        {
            FoodRequest p = this.repository.GetOne(id);
            if (p == null)
            {
                return NotFound();
            }

            return new FileContentResult(p.Picture, p.PictureContentType);
        }
        /*
        [Authorize]
        [HttpGet("purchused")]
        public IActionResult GetPurchasedItems()
        {
            var food = this.repository.GetPurchasedItems(userManager.GetUserId(FoodUser));

            return Ok(food);
        }*/
        
    }
}

