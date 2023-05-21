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
        private readonly IFoodRequestRepository foodrepository;
        private readonly IOfferRepository offerrepository;
        private readonly ICommentRepository commentRepository;
        private readonly IFoodUserRepository foodUserRepository;


        private readonly UserManager<FoodUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public FoodrequestController(IFoodUserRepository foodUserRepository, IFoodRequestRepository repository, IOfferRepository offerRepository, ICommentRepository commentrep, UserManager<FoodUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.foodrepository = repository;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.commentRepository = commentrep;
            this.offerrepository = offerRepository;
            this.foodUserRepository = foodUserRepository;
        }



        [AllowAnonymous]
        [HttpGet("GetAll")]
        public IEnumerable<RequestViewModel> GetAllProduct()
        {
            var requestors = foodrepository.GetAll();

            var rInfos = new List<RequestViewModel>();
            foreach (var r in requestors)
            {
                rInfos.Add(new RequestViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    RequestorId = r.RequestorId,

                 

                });
            }

            return rInfos;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public FoodRequest? GetFood(string id)
        {
            return foodrepository.GetOne(id);
        }

        [AllowAnonymous]
        [HttpPost("CreateFd")]
        public IActionResult Create([FromBody] FoodRequest food /*IFormFile picture*/)
        {
            if (ModelState.IsValid)
            {
                FoodRequest f = new FoodRequest()
                {
                    Name = food.Name,
                    Description = food.Description,
                    RequestorId = userManager.GetUserId(User),
                    PictureURL = food.PictureURL
                };
               /* using (var stream = picture.OpenReadStream())
                {
                    byte[] buffer = new byte[picture.Length];
                    stream.Read(buffer, 0, (int)picture.Length);
                    f.Picture = buffer;
                    f.PictureContentType = picture.ContentType;
                }*/

                this.foodrepository.Create(f);
                return Ok();
            }
            return Ok(food);
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var food = this.foodrepository.GetOne(id);
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
                var old = this.foodrepository.GetOne(id);

                if (old.Requestor.Id != userManager.GetUserId(User) && !User.IsInRole("Admin"))
                    return RedirectToAction(nameof(Index));

                old.Name = food.Name;
                old.Description = food.Description;
                old.IsDone = food.IsDone;

                this.foodrepository.Update(old);
                return Ok(food);
            }

            return Ok(food);
        }
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var food = this.foodrepository.GetOne(id);

            if (food != null && (food.Requestor.Id == userManager.GetUserId(User) || User.IsInRole("Admin")))
            {
                this.foodrepository.Delete(food);
            }

            return Ok();


        }

       /*
        [AllowAnonymous]
        [HttpGet("Image")]
        public IActionResult GetImage(string id)
        {
            FoodRequest p = this.foodrepository.GetOne(id);
            if (p == null)
            {
                return NotFound();
            }

            return new FileContentResult(p.Picture, p.PictureContentType);
        }*/

        [Authorize]
        public IActionResult ChooseOffer(string foodId, string offerId)
        {
            var food = this.foodrepository.GetOne(foodId);
            var offer = this.offerrepository.GetOne(offerId);
            var contractor = this.foodUserRepository.GetFooduserById(offer.ContractorId);
            var requestor = this.foodUserRepository.GetFooduserById(userManager.GetUserId(User));


            if (food == null || food.Requestor.Id != userManager.GetUserId(User))
                return RedirectToAction(nameof(Index));

            food.InProgress = true;
            offer.Choosen = true;
            food.Contractor = contractor;



            this.foodrepository.Update(food);
            this.offerrepository.Update(offer);


            return Ok();
        }

        [Authorize]
        public IActionResult SeeAcceptedOffers()
        {
            var foodrequest = this.foodrepository.SeeAcceptedOffers(userManager.GetUserId(User));

            return Ok(foodrequest);
        }


        [Authorize]
        public IActionResult SeeOtherAcceptedOffers(string id)
        {
            var foodrequest = this.foodrepository.SeeAcceptedOffers(id);

            return Ok(foodrequest);
        }


        [Authorize]
        public IActionResult CompleteRequest(string foodId)
        {
            var food = this.foodrepository.GetOne(foodId);
            var chosenOffer = food.Offers.FirstOrDefault(o => o.Choosen);
            var requestor = this.foodUserRepository.GetFooduserById(food.RequestorId);
            var contractor = this.foodUserRepository.GetFooduserById(userManager.GetUserId(User));

            if (food == null || chosenOffer.ContractorId != userManager.GetUserId(User))
                return RedirectToAction(nameof(Index));


            contractor.Founds = contractor.Founds + food.Payment;

            requestor.Founds = requestor.Founds - food.Payment;

            food.IsDone = true;
            this.foodrepository.Update(food);

            return Ok();
        }


        [Authorize]
        public IActionResult CancelRequest(string foodId)
        {
            var food = this.foodrepository.GetOne(foodId);
            var chosenOffer = food.Offers.Where(x => x.Choosen == true).First();

            if (food == null || (food.RequestorId != userManager.GetUserId(User) && chosenOffer.ContractorId != userManager.GetUserId(User)))
                return Ok();

            food.IsDone = false;
            food.InProgress = false;
            food.Contractor = null;


            if (chosenOffer != null)
            {
                chosenOffer.Choosen = false;
                this.offerrepository.Update(chosenOffer);
            }

            this.foodrepository.Update(food);

            return Ok();
        }

    }
}

