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
    [Route("api/Clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientService _context;

        public ClientsController(ClientService context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        public ActionResult<List<Client>> Get()
        {
            return _context.Get();
        }

        // GET: api/Clients/5
        [HttpGet("{CPF}", Name = "GetClient")]
        public ActionResult<Client> Get(string CPF)
        {
            var client = _context.Get(CPF);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Client clientIn)
        {
            var client = _context.Get(id);

            if (client == null)
            {
                return NotFound();
            }

            _context.Update(id, clientIn);

            return NoContent();
        }

        // POST: api/Clients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Client> Create(Client client)
        {
            _context.Create(client);

            return CreatedAtRoute("GetClient", new { id = client.Id.ToString() }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var client = _context.Get(id);

            if (client == null)
            {
                return NotFound();
            }

            _context.Remove(client.Id);

            return NoContent();
        }
    }
}
