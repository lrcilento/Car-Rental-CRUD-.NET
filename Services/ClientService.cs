using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using CRUD_Car_Rental.Models;

namespace CRUD_Car_Rental.Services
{
    public class ClientService
    {
        private readonly IMongoCollection<Client> _clients;

        public ClientService(ICarRentalDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _clients = database.GetCollection<Client>(settings.ClientsCollectionName);
        }

        public List<Client> Get() =>
            _clients.Find(client => true).ToList();

        public Client Get(string CPF) =>
            _clients.Find(client => client.CPF == CPF).FirstOrDefault();

        public Client Create(Client client)
        {
            _clients.InsertOne(client);
            return client;
        }

        public void Update(string id, Client clientIn) =>
            _clients.ReplaceOne(client => client.Id == id, clientIn);

        public void Remove(Client clientIn) =>
            _clients.DeleteOne(client => client.Id == clientIn.Id);

        public void Remove(string id) =>
            _clients.DeleteOne(client => client.Id == id);
    }
}
