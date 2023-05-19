using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodForRequest.Models
{
    public class OfferViewModel
    {
        [ForeignKey(nameof(Models.FoodRequest))]
        public string FoodId { get; set; }


        public bool Choosen { get; set; }
    }
}
