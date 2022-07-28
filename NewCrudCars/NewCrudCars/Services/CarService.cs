using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using NewCrudCars.Models;
using NewCrudCars.Repository;

namespace NewCrudCars.Services
{
    public class CarService
    {
        private readonly CarRepository _carRepository;

        public CarService(CarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<List<CarModel>> GetAll()
        {
            return await _carRepository.GetAll();
        }
        public async Task<CarModel> GetById(int idCar)
        {
            var car = await _carRepository.GetCarById(idCar);
            if(car == null) throw new ValidationException("The information is empty");
            return car;
        }
        public async Task<CarModel> CreateCar(CarModel car)
        {
            if (car == null) throw new ValidationException("The Car do Not exist");
            return  await _carRepository.InsertCar(car);
        }
        public async Task<int> DeleteCar(CarModel car)
        {
            return await _carRepository.DeleteCar(car);
        }
        public async Task<CarModel> PutCar(CarModel car)
        {
            if(car != null)
            {
                return await _carRepository.UpdateCar(car);
            }
            throw new ValidationException("The Car do not exist");
        }
    }
}