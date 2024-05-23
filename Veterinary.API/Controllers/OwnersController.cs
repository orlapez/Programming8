using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{

    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class OwnersController : ControllerBase
    {

        private readonly DataContext _context;

        public OwnersController(DataContext context)
        {



            _context = context;
        }
        [AllowAnonymous]
        // Método Get- LISTA
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Owners.ToListAsync());


        }



        // Método Get- por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {



            var owner = await _context.Owners.FirstOrDefaultAsync(x => x.Id == id);

            if (owner == null)
            {


                return NotFound();

            }



            return Ok(owner);


        }






        [HttpPost]
        public async Task<ActionResult> Post(Owner owner)
        {

            _context.Add(owner);
            await _context.SaveChangesAsync();
            return Ok(owner);



        }



        // Método actualizar
        [HttpPut]

        public async Task<ActionResult> Put(Owner owner)
        {

            _context.Update(owner);
            await _context.SaveChangesAsync();
            return Ok(owner);



        }


        //Médoro eliminar registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {



            var Filasafectadas = await _context.Owners

                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (Filasafectadas == 0)
            {


                return NotFound();

            }


            return NoContent();

        }

        [AllowAnonymous]
        [HttpGet("combo")]
        public async Task<ActionResult> GetCombo()
        {
            return Ok(await _context.Owners.ToListAsync());
        }



[AllowAnonymous]
        [HttpGet("combo/{OwnerId:int}")]
        public async Task<ActionResult> GetCombo(int OwnerId)
        {
            return Ok(await _context.Owners
                .Where(x => x.Id == OwnerId)
                .ToListAsync());
        }

    }

}
