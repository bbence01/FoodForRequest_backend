using FoodForRequest.Data;
using FoodForRequest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FoodForRequest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Numerics;
using System.Security.Claims;
using System.Text;

namespace FoodForRequest.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OfferController : Controller
    {
        IFoodRequestRepository foodRepo;
        IOfferRepository offerRepo;
        private readonly UserManager<FoodUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public OfferController(IFoodRequestRepository foodRepo, IOfferRepository offerRepo, UserManager<FoodUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.foodRepo = foodRepo;
            this.offerRepo = offerRepo;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }



         //GET: api/<WordController>
        [HttpGet("all")]
        public async Task<IEnumerable<Offer>> GetAllWord()
        {
            return  offerRepo.GetAll();
          }

         //GET api/<WordController>/5
        [HttpGet("{id}")]
        public Offer? GetWord(string id)
        {
            return offerRepo.GetOne(id);
        }

        
      

        // POST api/<WordController>
        [HttpPost]
        public async void AddWord([FromBody] Offer value)
        {

            offerRepo.Create(value);
        }




        /*
        // PUT api/<WordController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditWord(int id, [FromBody] Offer value)
        {

            offerRepo.UpdateWord(value);
            return Ok();
        }*/

        // DELETE api/<WordController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWord(string id)
        {
            offerRepo.Delete(id);
            return Ok();

        }







        /*
        [HttpPost]
        public IActionResult Create(string productId)
        {
            var product = this.foodRepo.GetOne(productId);

            if (product != null)
            {
                BiddingViewModel vm = new BiddingViewModel();
                vm.ProductId = productId;
                vm.Value = (product.HighestBid != null ? product.HighestBid.Value : 0) + 1;
                return View(vm);
            }
            else
            {
                return Ok();
            }
        }
        
        [HttpPost]
        public IActionResult Create(BiddingViewModel newBid)
        {
            FoodRequest p = this.productRepo.GetOne(newBid.ProductId);
            int maxBid = p.HighestBid != null ? p.HighestBid.Value : 0;
            if (ModelState.IsValid && maxBid < newBid.Value)
            {
                Offer bid = new Offer()
                {
                    Value = newBid.Value,
                    ProductId = newBid.ProductId,
                    UserId = userManager.GetUserId(FoodUser)
                };

                this.bidRepo.Create(bid);

                return Ok();
            }
            else { return Ok(newBid); }
        }*/
    }
}
