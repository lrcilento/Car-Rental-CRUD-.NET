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
    [Route("api/Rents")]
    [ApiController]
    public class RentsController : ControllerBase
    {
        private readonly RentService _context;

        public RentsController(RentService context)
        {
            _context = context;
        }

        // GET: api/Rents
        [HttpGet]
        public ActionResult<List<Rent>> Get()
        {
            return _context.Get();
        }

        // GET: api/Rents/5
        [HttpGet("{id}", Name = "GetRent")]
        public ActionResult<Rent> Get(string id)
        {
            var rent = _context.Get(id);

            if (rent == null)
            {
                return NotFound();
            }

            return rent;
        }

        // PUT: api/Rents/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Rent rentIn)
        {
            var rent = _context.Get(id);

            if (rent == null)
            {
                return NotFound();
            }

            _context.Update(id, rentIn);

            return NoContent();
        }

        // POST: api/Rents
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Rent> Create(Rent rent)
        {
            _context.Create(rent);

            return CreatedAtRoute("GetRent", new { id = rent.Id.ToString() }, rent);
        }

        // DELETE: api/Rents/5
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var rent = _context.Get(id);

            if (rent == null)
            {
                return NotFound();
            }

            _context.Remove(rent.Id);

            return NoContent();
        }
    }
}
