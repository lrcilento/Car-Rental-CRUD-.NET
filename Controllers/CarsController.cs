using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD_Car_Rental.Models;
using CRUD_Car_Rental.Services;

namespace CRUD_Car_Rental.Controllers
{
    [Route("api/Cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarService _context;

        public CarsController(CarService context)
        {
            _context = context;
        }

        // GET: api/Cars
        [HttpGet]
        public ActionResult<List<Car>> Get()
        {
            return _context.Get();
        }

        // GET: api/Cars/5
        [HttpGet("{plate}", Name = "GetCar")]
        public ActionResult<Car> Get(string plate)
        {
            var car = _context.Get(plate);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Car carIn)
        {
            var car = _context.Get(id);

            if (car == null)
            {
                return NotFound();
            }

            _context.Update(id, carIn);

            return NoContent();
        }

        // POST: api/Cars
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Car> Create(Car car)
        {
            _context.Create(car);

            return CreatedAtRoute("GetCar", new { id = car.Id.ToString() }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var car = _context.Get(id);

            if (car == null)
            {
                return NotFound();
            }

            _context.Remove(car.Id);

            return NoContent();
        }
    }
}
