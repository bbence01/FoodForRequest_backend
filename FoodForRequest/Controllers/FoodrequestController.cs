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
using FoodForRequest.Migrations;

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
        private readonly IingridientRepository ingredientRepository;


        private readonly UserManager<FoodUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public FoodrequestController(IingridientRepository ingredientRepository,IFoodUserRepository foodUserRepository, IFoodRequestRepository repository, IOfferRepository offerRepository, ICommentRepository commentrep, UserManager<FoodUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.foodrepository = repository;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.commentRepository = commentrep;
            this.offerrepository = offerRepository;
            this.foodUserRepository = foodUserRepository;
            this.ingredientRepository = ingredientRepository;
        }



        [AllowAnonymous]
        [HttpGet("GetAll")]
        public IEnumerable<FoodRequestViewModel> GetAllProduct()
        {
            var requestors = foodrepository.GetAll();

            var rInfos = new List<FoodRequestViewModel>();
            foreach (var r in requestors)
            {
                rInfos.Add(new FoodRequestViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    Payment = r.Payment,
                    IsDone = r.IsDone,
                    InProgress = r.InProgress,
                    Deliveryoptions = r.Deliveryoptions,
                    RequestorId = r.RequestorId,
                    PictureURL = r.PictureURL


                });
            }

            return rInfos;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public FoodRequestViewModel? GetFood(string id)
        {

            var rInfos = new FoodRequestViewModel();
            var r = foodrepository.GetOne(id);

            rInfos = (new FoodRequestViewModel
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Payment = r.Payment,
                IsDone = r.IsDone,
                InProgress = r.InProgress,
                Deliveryoptions = r.Deliveryoptions,
                RequestorId = r.RequestorId,
                PictureURL = r.PictureURL


            });



            return rInfos;
        }

        [AllowAnonymous]
        [HttpPost("CreateFd")]
        public IActionResult Create([FromBody] FoodrequestCreateViewmodel food /*IFormFile picture*/)
        {
            if (ModelState.IsValid)
            {
                FoodRequest f = new FoodRequest()
                {
                    
                    Name = food.Name,
                    Description = food.Description,
                    Payment = food.Payment,
                    Deliveryoptions = food.Deliveryoptions,
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

                FoodRequest newr = this.foodrepository.Create(f);



                foreach (var item in food.Ingredients)
                {
                    Ingredient i = ingredientRepository.GetOne(item);

                   
                        Ingredient newi = new Ingredient();
                        newi.Name = i.Name;
                    newi.Description = i.Name;

                    var foodlist = foodrepository.GetAll();

                    foreach (var fooditem in foodlist)
                    {
                        if (foodrepository.GetOneName(f.Name).Description == f.Description && foodrepository.GetOneName(f.Name).RequestorId == f.RequestorId)
                        {
                            newi.FoodId = newr.Id;
                        }
                        

                    }




                    ingredientRepository.Create(newi);
                  


                }


                return Ok();
            }
            return Ok(food);
        }


        [AllowAnonymous]
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] FoodrequestCreateViewmodel food)
        {


            if (ModelState.IsValid)
            {

                FoodRequest f = foodrepository.GetOne(id); // Retrieve existing food request

               


                    if (f == null)
                {
                    return NotFound(); // No food request with this id
                }

                if (userManager.GetUserId(User) == f.RequestorId)

                {

                    // Update properties
                    f.Name = food.Name;
                    f.Description = food.Description;
                    f.Payment = food.Payment;
                    f.Deliveryoptions = food.Deliveryoptions;
                    f.RequestorId = userManager.GetUserId(User);
                    f.PictureURL = food.PictureURL;

                    // Update the ingredients
                    // This is a simple way and might not work in all scenarios
                    // You would need to check for added/removed ingredients

                    var ingredients = ingredientRepository.GetAll();

                    foreach (var item in ingredients)
                    {
                        if (item.FoodId == f.Id )
                        {
                            item.FoodId = null;
                        }
                    }

                    foreach (var item in food.Ingredients)
                    {
                        Ingredient i = ingredientRepository.GetOne(item);


                        Ingredient newi = new Ingredient();
                        newi.Name = i.Name;
                        newi.Description = i.Name;

                        var foodlist = foodrepository.GetAll();

                        newi.FoodId = id;





                        ingredientRepository.Create(newi);



                    }

                    // Save updated request back to the repository
                    foodrepository.Update(f);

                    return Ok();



                }


             
            }

            return BadRequest(ModelState); // Model was not valid





        }


        /*
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
        }*/
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var food = this.foodrepository.GetOne(id);

            if (food != null && (food.RequestorId == userManager.GetUserId(User) || User.IsInRole("Admin")))
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
        [HttpPut("ChooseOffer")]

        public async Task<IActionResult> ChooseOffer(string foodId, string offerId)
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
        [HttpGet("SeeAcceptedOffers")]
        public async Task<IActionResult> SeeAcceptedOffers()
        {
            var foodrequest = this.foodrepository.SeeAcceptedOffers(userManager.GetUserId(User));

            return Ok(foodrequest);
        }


        [Authorize]
        [HttpGet("SeeOtherAcceptedOffers/{id}")]

        public async Task<IActionResult> SeeOtherAcceptedOffers(string id)
        {
            var foodrequest = this.foodrepository.SeeAcceptedOffers(id);

            return Ok(foodrequest);
        }


        [Authorize]
        [HttpPut("CompleteRequest/{id}")]

        public async Task<IActionResult> CompleteRequest(string foodId)
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
        [HttpPut("CancelRequest/{id}")]

        public async Task<IActionResult> CancelRequest(string foodId)
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

