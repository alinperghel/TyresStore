using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyresStore.Repository.Models;

namespace TyresStore.Repository.Interfaces
{
    public interface IBasketRepository
    {
        void StoreTyre(int tyreId, string brand, string season, string article, double price);

        List<Basket> GetItems();

        bool TyreAlreadyAdded(int tyreId);

        void RemoveItem(int itemId);
    }
}
