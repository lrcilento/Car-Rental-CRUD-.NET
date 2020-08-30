using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Car_Rental.Models
{
    public class CarRentalDatabaseSettings : ICarRentalDatabaseSettings
    {

        public string CarsCollectionName { get; set; }
        public string ClientsCollectionName { get; set; }
        public string RentsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
    public interface ICarRentalDatabaseSettings
    {

        string CarsCollectionName { get; set; }
        string ClientsCollectionName { get; set; }
        string RentsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}