using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyresStore.Repository.Interfaces;
using TyresStore.Repository.Models;

namespace TyresStore.Repository
{
    public class TyresRepository : ITyresRepository
    {
        TyresStoreContext tyresContext = new TyresStoreContext();

        public Tyre GetTyreById(int tyreId) {
            return tyresContext.Tyres.FirstOrDefault(x => x.ID == tyreId);
        }

        public List<Tyre> GetTyres()
        {
            return tyresContext.Tyres.ToList();
        }

        public List<Tyre> GetTyresByVehicleId(int vehicleId)
        {
            return tyresContext.Tyres.Where(t => t.VehicleId == vehicleId).ToList();
        }
    }
}
