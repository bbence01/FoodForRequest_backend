using FoodForRequest.Models;

namespace FoodForRequest.Data
{
    public class OfferRepository : IOfferRepository
    {
        ApplicationDbContext context;

        public OfferRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(Offer bid)
        {
            context.Offers.Add(bid);
            context.SaveChanges();
        }

        public IEnumerable<Offer> GetAll()
        {
            return context.Offers;
        }

        public Offer GetOne(string id)
        {
            return context.Offers.FirstOrDefault(p => p.Id == id);
        }

        public void Delete(Offer bid)
        {
            this.context.Offers.Remove(bid);
            this.context.SaveChanges();
        }
    }
}
