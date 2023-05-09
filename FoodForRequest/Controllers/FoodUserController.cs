﻿using System;
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
using System.Diagnostics;
using Microsoft.AspNetCore.SignalR;
using System.Numerics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WordQuiz.Controllers
{

    // [Authorize(Roles = "FoodUser, Admin")]
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class FoodUserController : ControllerBase
    {
        IFoodUserRepository fooduserRepository;

        private readonly UserManager<FoodUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public FoodUserController(IFoodUserRepository foodUserRepository, UserManager<FoodUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.fooduserRepository = foodUserRepository;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IFoodUserRepository FoodUser { get => fooduserRepository; set => fooduserRepository = value; }

        public UserManager<FoodUser> UserManager => userManager;

        public RoleManager<IdentityRole> RoleManager => roleManager;
        /*
        // GET: api/<PlayerController>/all
        [HttpGet("all")]
        public IEnumerable<FoodUser> GetAllFoodusers()
        {
            return fooduserRepository.GetAllFoodusers().Result;
        }*/

        // GET: api/<PlayerController>/all
        [HttpGet("all")]
        public async Task<IEnumerable<PlayerInfoViewModel>> GetAllPlayers()
        {
            var foodusers = fooduserRepository.GetAllFoodusers();

            var playerInfos = new List<PlayerInfoViewModel>();
            foreach (var fooduser in foodusers)
            {
                playerInfos.Add(new PlayerInfoViewModel
                {
                    Id = fooduser.Id,
                    Email = fooduser.Email,                   
                    UserName = fooduser.UserName,
                    FoodUserName = fooduser.FoodUserName,

                    IsAdmin = await userManager.IsInRoleAsync(fooduser, "Admin")


                });
            }

            return playerInfos;
        }


        // GET api/<PlayerController>/5
        [HttpGet("{id}")]
        public async Task<object> GetPlayer(string id)
        {
            FoodUser p = fooduserRepository.GetFooduserById(id);
            return new
            {
                email = p.Email,
                id = p.Id,
                foodUserName = p.FoodUserName,
                userName = p.UserName,
                admin = await this.userManager.IsInRoleAsync(p, "Admin")
            };
        }

        // GET api/<PlayerController>
        [HttpGet]
        [Authorize]
        public async Task<object> GetPlayer()
        {
            var authHeader = HttpContext.Request.Headers["Authorization"];
            System.Diagnostics.Debug.WriteLine("Authorization Header: " + authHeader); // Log the Authorization header

            FoodUser p = (await userManager.GetUserAsync(User));
            System.Diagnostics.Debug.WriteLine("User: " + p); // Log the User object

            return new
            {
                email = p.Email,
                id = p.Id,
                foodUserName = p.FoodUserName,
                userName = p.UserName,
                admin = await this.userManager.IsInRoleAsync(p, "Admin")
            };
        }


        //// POST api/<PlayerController>
        //[HttpPost]
        //public async void AddPlayer([FromBody] FoodUser value)
        //{
        //     fooduserRepository.CreateFooduser(value);

        //}

        // PUT api/<PlayerController>/5

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPlayer(int id, [FromBody] FoodUser value)
        {
            fooduserRepository.UpdateFooduser(value);
            return Ok();
        }

        // DELETE api/<PlayerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(string id)
        {
            fooduserRepository.DeleteFooduser(id);
            return Ok();
        }
    }
}
