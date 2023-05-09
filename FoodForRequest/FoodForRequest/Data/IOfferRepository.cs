using FoodForRequest.Models;

namespace FoodForRequest.Data
{
    public interface IOfferRepository
    {
        void Create(Offer offer);
        void Delete(Offer offer);
        void Delete(string id);
        IEnumerable<Offer> GetAll();
        Offer GetOne(string id);
    }
}