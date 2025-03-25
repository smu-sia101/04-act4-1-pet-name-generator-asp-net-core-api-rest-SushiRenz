using Microsoft.AspNetCore.Mvc;
using PetNameGenerator.Controllers.Constants;

namespace PetNameGenerator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetNameController : ControllerBase
    {
        [HttpPost("generate")]
        public IActionResult Post([FromQuery] AnimalType animalType, bool hasLastName)
        {
            try
            {
                string name = GeneratePetName(animalType, hasLastName);
                return Ok(new { name });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception)
            {
                return BadRequest(new { error = "An unexpected error occurred." });
            }
        }

        private string GeneratePetName(AnimalType animalType, bool hasLastName)
        {
            Random random = new Random();
            int firstNameIndex = random.Next(0, 10);
            int lastNameIndex = random.Next(0, 10);

            return animalType switch
            {
                AnimalType.Dog => hasLastName
                    ? Constants.Names.Dog.First[firstNameIndex] + " " + Constants.Names.Dog.Last[lastNameIndex]
                    : Constants.Names.Dog.First[firstNameIndex],

                AnimalType.Cat => hasLastName
                    ? Constants.Names.Cat.First[firstNameIndex] + " " + Constants.Names.Cat.Last[lastNameIndex]
                    : Constants.Names.Cat.First[firstNameIndex],

                AnimalType.Bird => hasLastName
                    ? Constants.Names.Bird.First[firstNameIndex] + " " + Constants.Names.Bird.Last[lastNameIndex]
                    : Constants.Names.Bird.First[firstNameIndex],

                _ => throw new ArgumentException("Invalid animal type. Allowed values: Dog, Cat, Bird.")
            };
        }
    }
}