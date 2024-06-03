using Microsoft.AspNetCore.Mvc;
using University.WebAPI.Dto;
using University.WebAPI.Models;
using University.WebAPI.Persistance;

namespace University.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        [HttpGet]
        public IEnumerable<ClientDto> Get()
        {
            var clients = ClientStore.Elements;

            List<ClientDto> result = new List<ClientDto>();
            foreach (var client in clients)
            {
                result.Add(new ClientDto()
                {
                    ClientId = client.ClientId,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    Email = client.Email,
                });
            }
            return result;
        }

        [HttpGet("{id}", Name = "GetClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ClientDto> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var client = ClientStore.Elements
                .FirstOrDefault(s => s.ClientId == id);

            if (client == null)
            {
                return NotFound();
            }

            var result = new ClientDto()
            {
                ClientId = client.ClientId,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
            };

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create([FromBody] CreateClientDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var id = ClientStore.Elements.Max(c => c.ClientId) + 1;

            var client = new Client()
            {
                ClientId = id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email
            };
            ClientStore.Elements.Add(client);

            var routeValues = new { id = client.ClientId };
            return CreatedAtRoute("GetClient", routeValues, client);
            }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id) 
        {
            var client = ClientStore.Elements
                .FirstOrDefault(c => c.ClientId == id);

            if (client == null)
            {
                return NotFound();
            }

            ClientStore.Elements.Remove(client);
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Update(int id, [FromBody] UpdateClientDto dto)
        {
            if ((dto == null) || (dto.ClientId != id))
            {
                return BadRequest();
            }

            var client = ClientStore.Elements.FirstOrDefault(s => s.ClientId == id);
            if (client == null) 
            { 
                return NotFound();
            }

            client.FirstName = dto.FirstName;
            client.LastName = dto.LastName;
            client.Email = dto.Email;
            return NoContent();
        }
    }
}
