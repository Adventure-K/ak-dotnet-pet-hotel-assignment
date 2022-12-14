using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        // * GET all pets to show on table
        [HttpGet]
        public IEnumerable<Pet> GetPets() {
            Console.WriteLine("GET ALL PETS");
            // return new List<Pet>();
            return _context.Pets.Include(Owner => Owner.petOwner);
            // return _context.Pets;
        }

        [HttpPost]
        public IActionResult Post(Pet pet) {
            _context.Add(pet);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Post), new {id = pet.id}, pet);
        }

        // * DELETE route

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            Pet pet = _context.Pets.SingleOrDefault(p => p.id == id);

            if (pet is null) {
                return NotFound();
            }

            _context.Pets.Remove(pet);
            _context.SaveChanges();

            return NoContent();
        }




        // [HttpGet]
        // [Route("test")]
        // public IEnumerable<Pet> GetPets() {
        //     PetOwner blaine = new PetOwner{
        //         name = "Blaine"
        //     };

        //     Pet newPet1 = new Pet {
        //         name = "Big Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Black,
        //         breed = PetBreedType.Poodle,
        //     };

        //     Pet newPet2 = new Pet {
        //         name = "Little Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Golden,
        //         breed = PetBreedType.Labrador,
        //     };

        //     return new List<Pet>{ newPet1, newPet2};
        // }
    }
}
