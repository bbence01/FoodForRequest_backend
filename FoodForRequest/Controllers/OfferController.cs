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
        IFoodRequestRepository productRepo;
        IOfferRepository bidRepo;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public OfferController(IFoodRequestRepository productRepo, IOfferRepository bidRepo, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.productRepo = productRepo;
            this.bidRepo = bidRepo;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Create(string productId)
        {
            var product = this.productRepo.GetOne(productId);

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
                    UserId = userManager.GetUserId(User)
                };

                this.bidRepo.Create(bid);

                return Ok();
            }
            else { return Ok(newBid); }
        }
    }
}
