using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        // [HttpGet]
        // public IEnumerable<PetOwner> GetPets() {
        //     return new List<PetOwner>();
        // }

        [HttpGet] // /api/breads
        public IEnumerable<PetOwner> GetAll() {
            // include the joined Baker for each bread
            return _context.PetOwners;
        }

        [HttpGet("{id}")]
        public ActionResult<PetOwner> GetById(int id) {
            PetOwner petOwner = _context.PetOwners.SingleOrDefault( b => b.id == id);
            
            if(petOwner is null) {
                // can't find it
                return NotFound(); // status 404
            }

            return petOwner;
        }

         [HttpPost]
        public IActionResult Post(PetOwner petOwner) {
            _context.Add(petOwner);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Post), new {id = petOwner.id}, petOwner);  
        }

         [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            // select the bread from Db
            // SingleOrDefault is like array.filter()
            PetOwner petOwner = _context.PetOwners.SingleOrDefault( b => b.id == id );

            if(petOwner is null) {
                // no bread with this id
                return NotFound();
            }

            _context.PetOwners.Remove(petOwner);
            _context.SaveChanges();

            return NoContent(); // 204
        }

        [HttpPut("{id}")] // req.params.id
        public IActionResult Put(int id, PetOwner petOwner) {
            Console.WriteLine("updating petOwner");

            if(id != petOwner.id) {
                // does not match the given bread id
                return BadRequest();
            }

            // update the DB
            _context.Update(petOwner);
            _context.SaveChanges();

            return Ok(petOwner);
        }
    }
}
