﻿using CRUD_Car_Rental.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace CRUD_Car_Rental.Services
{
    public class CarService
    {

        private readonly IMongoCollection<Car> _cars;

        public CarService(ICarRentalDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _cars = database.GetCollection<Car>(settings.CarsCollectionName);
        }

        public List<Car> Get() =>
            _cars.Find(car => true).ToList();

        public Car Get(string plate) =>
            _cars.Find(car => car.Plate == plate).FirstOrDefault();

        public Car Create(Car car)
        {
            _cars.InsertOne(car);
            return car;
        }

        public void Update(string id, Car carIn) =>
            _cars.ReplaceOne(car => car.Id == id, carIn);

        public void Remove(Car carIn) =>
            _cars.DeleteOne(car => car.Id == carIn.Id);

        public void Remove(string id) =>
            _cars.DeleteOne(car => car.Id == id);

    }
}
