using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewCrudCars.Models;
using NewCrudCars.Services;

namespace NewCrudCars.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private readonly CarService _carService;

        public CarController(CarService carService)
        {
            _carService = carService;
        }
        [HttpGet]
        public Task<List<CarModel>> Get()
        {
            return _carService.GetAll();
        }
        [HttpGet("{id}")]
        public Task<CarModel> Get(int id)
        {
            return _carService.GetById(id);
        }
        [HttpPost]
        public async Task Post([FromBody] CarModel idCar)
        {
            await _carService.CreateCar(idCar);
        }
        [HttpPut("{id}")]
        public async Task Put([FromBody] CarModel car)
        {
            await _carService.PutCar(car);
        }
        [HttpDelete("{id}")]
        public async Task Delete(CarModel idCar)
        {
            await _carService.DeleteCar(idCar);
        }
    }
}