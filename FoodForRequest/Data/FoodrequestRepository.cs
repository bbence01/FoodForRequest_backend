using FoodForRequest.Models;

namespace FoodForRequest.Data
{
    public class FoodrequestRepository : IFoodRequestRepository
    {
        ApplicationDbContext context;

        public FoodrequestRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(FoodRequest product)
        {
            context.Foodrequests.Add(product);
            context.SaveChanges();
        }

        public IEnumerable<FoodRequest> GetAll()
        {
            return context.Foodrequests;
        }

        public FoodRequest GetOne(string id)
        {
            return context.Foodrequests.FirstOrDefault(p => p.Id == id);
        }

        public void Update(FoodRequest product)
        {
            FoodRequest old = this.GetOne(product.Id);
            old.IsSold = product.IsSold;
            old.Description = product.Description;
            old.Name = product.Name;
            this.context.SaveChanges();
        }

        public IEnumerable<FoodRequest> GetPurchasedItems(string userId)
        {
            return this.GetAll().Where(p => p.IsSold && p.HighestBid != null && p.HighestBid.UserId == userId);
        }

        public void Delete(FoodRequest product)
        {
            this.context.Foodrequests.Remove(product);
            this.context.SaveChanges();
        }
    }
}
