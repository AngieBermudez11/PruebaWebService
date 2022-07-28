using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using NewCrudCars.Client;
using NewCrudCars.Models;
using Npgsql;

namespace NewCrudCars.Repository
{
    public class CarRepository
    {
        private readonly NpgsqlClient _npgsqlClient;

        public CarRepository(NpgsqlClient npgsqlClient)
        {
            _npgsqlClient = npgsqlClient;
        }
        public async Task<CarModel> GetCarById(int idCar)
        {
            NpgsqlConnection npgsqlConnection = await _npgsqlClient.GetConnection();
            const string query = @"SELECT idCar IdCar, color Color, brand Brand, doors Doors " +
                                  "FROM cars " +
                                  "WHERE idCar = @idCar ";
            var parameters = new DynamicParameters();
            parameters.Add("@idCar", idCar);

            return await npgsqlConnection.QuerySingleAsync<CarModel>(query, parameters);
        }
        public async Task<List<CarModel>> GetAll()
        {
            NpgsqlConnection npgsqlConnection = await _npgsqlClient.GetConnection();
            const string query = @"SELECT idCar IdCar, color Color, brand Brand, doors Doors " +
                                 "FROM cars ";

            return (List<CarModel>)await npgsqlConnection.QueryAsync<CarModel>(query, new { });
        }
        public async Task<CarModel> InsertCar(CarModel car)
        {
            NpgsqlConnection npgsqlConnection = await _npgsqlClient.GetConnection();
            const string query = @"INSERT INTO cars(idCar,color,brand,doors) " +
                                 "VALUES(@idcar,@color,@brand,@doors) ";
            var parameters = new DynamicParameters();
            parameters.Add("@idCar", car.IdCar);
            parameters.Add("@color", car.Color);
            parameters.Add("@brand", car.Brand);
            parameters.Add("@doors", car.Doors);
            var carConnection = await npgsqlConnection.ExecuteAsync(query,parameters);
            
            return car;
        }

        public async Task<CarModel> UpdateCar(CarModel car)
        {
            NpgsqlConnection npgsqlConnection = await _npgsqlClient.GetConnection();
            const string query = @"UPDATE cars SET idCar=@idCar, color=@color, brand=@brand, doors=@doors " +
                                 "WHERE idCar = @idCar ";
            var parameters = new DynamicParameters();
            parameters.Add("@idCar", car.IdCar);
            var carConnection = await npgsqlConnection.ExecuteAsync(query,parameters);
            
            return car;
        }

        public async Task<int> DeleteCar(CarModel car)
        {
            NpgsqlConnection npgsqlConnection = await _npgsqlClient.GetConnection();
            const string query = @" DELETE FROM cars WHERE idCar = @idCar";;
            var result = await npgsqlConnection.ExecuteAsync(query, new { idCar = car.IdCar });
            return car.IdCar;
        }
    }
}