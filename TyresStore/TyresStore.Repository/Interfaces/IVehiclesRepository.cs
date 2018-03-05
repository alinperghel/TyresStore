using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyresStore.Repository.Models;

namespace TyresStore.Repository.Interfaces
{
    interface IVehiclesRepository
    {
        Vehicle GetVehicleById(int vehicleId);
        List<Vehicle> GetVehicles();
    }
}
