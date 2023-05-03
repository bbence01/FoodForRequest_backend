using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodForRequest.Models
{
    public class FoodRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }


        [StringLength(100)]
        public string Name { get; set; }

        
        [StringLength(1000)]
        [MinLength(5)]
        public string Description { get; set; }

        [NotMapped]
        public string[] ingridients { get; set; }

        [DefaultValue(false)]
        public bool IsDone { get; set; }

        [NotMapped]
        public byte[] Picture { get; set; }

        public string PictureContentType { get; set; }

        [ForeignKey(nameof(FoodUser))]
        public string RequestorId { get; set; }




        [NotMapped]
        public virtual FoodUser Requestor { get; set; }







        [NotMapped]
        public virtual List<Offer> Offers { get; set; }

       

        public FoodRequest()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
