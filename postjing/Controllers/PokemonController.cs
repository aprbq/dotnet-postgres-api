using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using postjing.Models;

namespace postjing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly PostjingContext _context;
        
        public PokemonController(PostjingContext context)
        {
            _context = context;
        }

        [HttpGet("GetPokemons")]
        public async Task<IActionResult> GetPokemons()
        {
            var result = await _context.Pokemon.Select(x => new Pokemon
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type,
            }).ToListAsync();

            return Ok(result);
        }

        [HttpPost("CreatePokemon")]
        public async Task<IActionResult> CreatePokemon([FromBody] Pokemon pokemon)
        {
            _context.Pokemon.Add(pokemon);
            await _context.SaveChangesAsync();

            return Ok(pokemon);
        }

        [HttpPut("EditPokemon")]
        public async Task<IActionResult> EditPokemon([FromBody] Pokemon pokemon)
        {
            var rows = await _context.Pokemon.Where(x => x.Id == pokemon.Id).ExecuteUpdateAsync(x => x.SetProperty(x => x.Name, pokemon.Name));

            return Ok(rows);
        }

        [HttpDelete("DeletePokemon")]
        public async Task<IActionResult> DeletePokemon(int pokemonId)
        {
            var rows = await _context.Pokemon.Where(x => x.Id == pokemonId).ExecuteDeleteAsync();

            return Ok(rows);
        }
    }
}
