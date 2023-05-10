﻿using FoodForRequest.Models;

namespace FoodForRequest.Data
{
    public class IngridientRepository: IingridientRepository
    {
        ApplicationDbContext context;

        public IngridientRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(Ingredient c)
        {
            context.Ingredients.Add(c);
            context.SaveChanges();
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return context.Ingredients;
        }

        public Ingredient GetOne(string id)
        {
            return context.Ingredients.FirstOrDefault(p => p.Id == id);
        }

        public void Delete(Ingredient c)
        {
            this.context.Ingredients.Remove(c);
            this.context.SaveChanges();
        }

        public void Delete(string id)

        {
            var word = context.Ingredients.Find(id);
            if (word != null)
            {
                context.Ingredients.Remove(word);
                context.SaveChanges();
            }
        }

    }
}
