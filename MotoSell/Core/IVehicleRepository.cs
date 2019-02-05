using System.Threading.Tasks;
using MotoSell.Core.Models;

namespace MotoSell.Core

{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id, bool includeRelated = true);
        void Add(Vehicle vehicle);
        void Remove(Vehicle vehicle);
    }
}