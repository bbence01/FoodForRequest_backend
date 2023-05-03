using FoodForRequest.Models;

namespace FoodForRequest.Data
{
    public interface IOfferRepository
    {
        void Create(Offer offer);
        void Delete(Offer offer);
        IEnumerable<Offer> GetAll();
        Offer GetOne(string id);
    }
}