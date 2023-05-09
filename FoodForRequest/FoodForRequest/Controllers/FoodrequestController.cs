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
        private readonly IFoodRequestRepository foodRepository;
        private readonly IOfferRepository offerRepository;
        private readonly ICommentRepository commentRepository;

        private readonly UserManager<FoodUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public FoodrequestController(IFoodRequestRepository repository, IOfferRepository offerRepository, ICommentRepository commentrep, UserManager<FoodUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.foodRepository = repository;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.commentRepository = commentrep;
            this.offerRepository = offerRepository;
        }



        [AllowAnonymous]
        [HttpGet("GetAll")]
        public IEnumerable<RequestorViewModel> GetAllProduct()
        {
            var requestors = foodRepository.GetAll();

            var rInfos = new List<RequestorViewModel>();
            foreach (var r in requestors)
            {
                rInfos.Add(new RequestorViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    RequestorId = r.RequestorId

                });
            }

            return rInfos;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public FoodRequest? GetFood(string id)
        {
            return foodRepository.GetOne(id);
        }

        [AllowAnonymous]
        [HttpPost("CreateFd")]
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

                this.foodRepository.Create(f);
                return Ok();
            }
            return Ok(food);
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var food = this.foodRepository.GetOne(id);
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
                var old = this.foodRepository.GetOne(id);

                if (old.Requestor.Id != userManager.GetUserId(User) && !User.IsInRole("Admin"))
                    return RedirectToAction(nameof(Index));

                old.Name = food.Name;
                old.Description = food.Description;
                old.IsDone = food.IsDone;

                this.foodRepository.Update(old);
                return Ok(food);
            }

            return Ok(food);
        }
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var food = this.foodRepository.GetOne(id);

            if (food != null && (food.Requestor.Id == userManager.GetUserId(User) || User.IsInRole("Admin")))
            {
                this.foodRepository.Delete(food);
            }

            return Ok();


        }

        [Authorize]
        [HttpGet("Sell")]
        public IActionResult Sell(string foodid)
        {
            var food = this.foodRepository.GetOne(foodid);

            if (food == null || food.Requestor.Id != userManager.GetUserId(User))
                return Ok();

            food.IsDone = true;
            this.foodRepository.Update(food);

            return Ok();
        }
        [AllowAnonymous]
        [HttpGet("Image")]
        public IActionResult GetImage(string id)
        {
            FoodRequest p = this.foodRepository.GetOne(id);
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
            var food = this.foodRepository.GetPurchasedItems(userManager.GetUserId(FoodUser));

            return Ok(food);
        }*/


        

    }
}

