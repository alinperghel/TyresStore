using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyresStore.Repository.Interfaces;
using TyresStore.Repository.Models;

namespace TyresStore.Repository
{
    public class BasketRepository : IBasketRepository
    {
        TyresStoreContext tyresContext = new TyresStoreContext();

        public void StoreTyre(int tyreId, string brand, string season, string article, double price)
        {
            Basket item = new Basket();

            item.TyreId = tyreId;
            item.Brand = brand;
            item.Season = season;
            item.ArticleCode = article;
            item.Price = price;
            item.AddedDate = new DateTime().ToShortDateString();

            tyresContext.BasketItems.Add(item);
            tyresContext.SaveChanges();
        }

        public List<Basket> GetItems()
        {
            return tyresContext.BasketItems.ToList();
        }

        public bool TyreAlreadyAdded(int tyreId)
        {
            List<Basket> items = this.GetItems();
            var item = items.SingleOrDefault(x => x.TyreId == tyreId);

            return item != null;
        }

        public void RemoveItem(int itemId)
        {
            var item = tyresContext.BasketItems.SingleOrDefault(x => x.ID == itemId);

            tyresContext.BasketItems.Remove(item);
            tyresContext.SaveChanges();
        }

        public void RemoveItems()
        {
            tyresContext.BasketItems.RemoveRange(tyresContext.BasketItems.ToList());
            tyresContext.SaveChanges();
        }
    }
}
