using FoodForRequest.Models;

namespace FoodForRequest.Data
{
    public interface IFoodRequestRepository
    {
        void Create(FoodRequest foodrequest);
        void Delete(FoodRequest foodrequest);
        IEnumerable<FoodRequest> GetAll();
        FoodRequest GetOne(string id);
        void Update(FoodRequest foodrequest);
    //    IEnumerable<FoodRequest> GetPurchasedItems(string userId);
    }
}