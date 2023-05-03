using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodForRequest.Models
{
    public class Offer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

     
        public bool Choosen { get; set; }





        [ForeignKey(nameof(Models.FoodRequest))]
        public string ProductId { get; set; }

        [ForeignKey(nameof(Models.FoodUser))]
        public string ContractorId { get; set; }








        public virtual FoodRequest Product { get; set; }

        public virtual FoodUser User { get; set; }

        public Offer()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
