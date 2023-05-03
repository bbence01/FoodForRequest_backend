using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodForRequest.Models
{
    public class Offer
    {
        public string Id { get; set; }

        [Range(1, int.MaxValue)]
        public int Value { get; set; }

        [ForeignKey(nameof(Models.FoodRequest))]
        public string ProductId { get; set; }

        [ForeignKey(nameof(Models.User))]
        public string UserId { get; set; }

        public virtual FoodRequest Product { get; set; }

        public virtual User User { get; set; }

        public Offer()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
