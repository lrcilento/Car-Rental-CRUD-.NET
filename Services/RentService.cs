using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using CRUD_Car_Rental.Models;

namespace CRUD_Car_Rental.Services
{
    public class RentService
    {
        private readonly IMongoCollection<Rent> _rents;

        public RentService(ICarRentalDatabaseSettings settings)
        {
            var rent = new MongoClient(settings.ConnectionString);
            var database = rent.GetDatabase(settings.DatabaseName);

            _rents = database.GetCollection<Rent>(settings.RentsCollectionName);
        }

        public List<Rent> Get() =>
            _rents.Find(rent => true).ToList();

        public Rent Get(string id) =>
            _rents.Find(rent => rent.Id == id).FirstOrDefault();

        public Rent Create(Rent rent)
        {
            _rents.InsertOne(rent);
            return rent;
        }

        public void Update(string id, Rent rentIn) =>
            _rents.ReplaceOne(rent => rent.Id == id, rentIn);

        public void Remove(Rent rentIn) =>
            _rents.DeleteOne(rent => rent.Id == rentIn.Id);

        public void Remove(string id) =>
            _rents.DeleteOne(rent => rent.Id == id);
    }
}
