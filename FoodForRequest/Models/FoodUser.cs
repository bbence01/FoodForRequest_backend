using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodForRequest.Models
{
    public class FoodUser : IdentityUser
    {

      
        public string FirstName { get; set; }

        public string LastName { get; set; }



        [NotMapped]
        [ValidateNever]
        public virtual List<FoodRequest> FoodRequests { get; set; }

        [NotMapped]
        [ValidateNever]
        public virtual List<Offer> Offers { get; set; }
    }
}
