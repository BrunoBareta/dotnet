using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using API_CSV.database;
using API_CSV.database.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimaisController : ControllerBase
    {
        private readonly DBContext _dbContext;
        public AnimaisController(DBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet]
        public ActionResult<List<Animal>> GetAll()
        {
            return Ok(_dbContext.Animais);
        }

        //retorna um animal especifico
        [HttpGet("{id}")]
        public ActionResult<Animal> GetById(int id)
        {
            try
            {
                Animal animal =
                    _dbContext
                    .Animais.Find(animal => animal.id == id);

                if (animal == null)
                    return NotFound(); //404

                return Ok(animal); //200
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message); // 400
            }
        }

        //deleta os animais
        [HttpDelete("{id}")]
        public ActionResult DeleteById(int id)
        {
            try
            {
                Animal animal =
                    _dbContext
                    .Animais.Find(animal => animal.id == id);

                if (animal == null)
                    return NotFound(); //404
                _dbContext.Animais.Remove(animal);

               return NoContent(); //204
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message); // 400
            }
        }

        //altera 
        [HttpPatch("AlterarNome")]
        public ActionResult<Animal> AlterarNome(
            [FromBody] Animal body)

        {
            if ((body == null) ||
                (string.IsNullOrEmpty(body.Name)))
                return BadRequest();

            Animal animal =
                    _dbContext
                    .Animais.Find(a => a.id == body.id);

            if (animal == null)
                return NotFound();

            animal.Name = body.Name;
            return Ok(animal);

        }

        //Atualiza os animais
        [HttpPut("{id}")]
        public ActionResult<Animal> Update(int id, [FromBody] Animal updatedAnimal)
        {
            if (updatedAnimal == null || updatedAnimal.id != id)
                return BadRequest("Dados inconsistentes.");

            Animal existingAnimal = _dbContext.Animais.Find(a => a.id == id);

            if (existingAnimal == null)
                return NotFound(); // 404

            existingAnimal.Name = updatedAnimal.Name;
            

            return Ok(existingAnimal); // 200
        }

        //Cria um novo animal
        [HttpPost]
        public ActionResult<Animal> Create([FromBody] Animal newAnimal)
        {
            if (newAnimal == null || string.IsNullOrEmpty(newAnimal.Name))
                return BadRequest("Dados inválidos.");

            
            int nextId = _dbContext.Animais.Count > 0 ? _dbContext.Animais.Max(a => a.id) + 1 : 1;
            newAnimal.id = nextId;

            _dbContext.Animais.Add(newAnimal);
            return CreatedAtAction(nameof(GetById), new { id = newAnimal.id }, newAnimal); // 201
        }

    }
}
