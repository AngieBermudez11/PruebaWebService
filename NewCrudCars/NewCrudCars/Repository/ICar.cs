using System.Collections.Generic;
using System.Threading.Tasks;
using NewCrudCars.Models;

namespace NewCrudCars.Repository
{
    public interface ICar
    {
        Task<List<CarModel>> GetAll();
        Task<CarModel> GetCarById(int idCar);
        Task<CarModel> InsertCar(CarModel car);
        Task<CarModel> UpdateCar(CarModel car);
        Task<int> DeleteCar(CarModel car);
    }
}