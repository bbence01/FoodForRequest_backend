using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodForRequest.Models
{
    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }


        public string Name { get; set; }



        public string Description { get; set; }



        [ForeignKey(nameof(Models.FoodRequest))]
        public string ProductId { get; set; }



        [NotMapped]
        public virtual FoodRequest Product { get; set; }


        public Ingredient()
        {
            this.Id = Guid.NewGuid().ToString();
        }



    }
}
