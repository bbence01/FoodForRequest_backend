using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodForRequest.Models
{
    public class FoodRequest
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        [MinLength(5)]
        public string Description { get; set; }

        [DefaultValue(false)]
        public bool IsSold { get; set; }

        [Required]
        public byte[] Picture { get; set; }

        [Required]
        public string PictureContentType { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string SellerId { get; set; }
        [NotMapped]
        public virtual User Seller { get; set; }

        [NotMapped]
        public virtual List<Offer> Bids { get; set; }

        [NotMapped]
        public Offer? HighestBid { get => Bids?.MaxBy(b => b.Value); }

        public FoodRequest()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
