using System.Collections.Immutable;
using Microsoft.AspNetCore.Mvc;
using Tutorial4.Database;
using Tutorial4.Models;

namespace Tutorial4.Controllers;

[ApiController]
[Route("aniapi/animals")]
public class AnimalsController : ControllerBase
{
    //  private static List<Animal> _animals = new List<Animal>();

    [HttpGet]
    public IActionResult GetAnimals()
    {
        var animals =MockDb.getInstance().Animals;
        return Ok(animals);
    }
    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animals =MockDb.getInstance().Animals;
        var a=animals.FirstOrDefault(a=>a.Id==id);
        if (a == null)
        {
            return NotFound($"No Animal under this Id {id}");
        }
        return Ok(a);
    }

    [HttpPost]
    public IActionResult AddAnimal([FromBody] Animal animal)
    { 
        var animals = MockDb.getInstance().Animals;
        animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult EditAnimal(int id,[FromBody]Animal animal)
    {
        var animals=MockDb.getInstance().Animals;
        var animalToEdit = animals.FirstOrDefault(a => a.Id == id);
        if (animalToEdit == null)
        {
            return NotFound($"No Animal under this Id {id}");
        }

        animalToEdit.FirstName = animal.FirstName;
        animalToEdit.Weight = animal.Weight;
        animalToEdit.FurColour = animal.FurColour;
        animalToEdit.Category = animal.Category;
        return Ok(animalToEdit);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animals =MockDb.getInstance().Animals;
        var animalToDelete = animals.FirstOrDefault(a => a.Id == id);
        if (animalToDelete == null)
        {
            return NotFound();
        }
        animals.Remove(animalToDelete);
        return NoContent();
    }
}