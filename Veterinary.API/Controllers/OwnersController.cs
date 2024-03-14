using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{


    [ApiController]
    [Route("/api/owners")]
    public class OwnersController : ControllerBase
    {

        private readonly DataContext _context;

        public OwnersController(DataContext context)
        {



            _context = context;
        }

        // Método Get- LISTA
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Owners.ToListAsync());


        }



        // Método Get- por Id
        [HttpGet("id:int")]
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
        [HttpDelete("id:int")]
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
    }

}
