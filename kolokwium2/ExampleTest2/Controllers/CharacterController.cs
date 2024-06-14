using System.Collections;
using ExampleTest2.Services;
using Microsoft.AspNetCore.Mvc;


namespace os.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CharactersController : ControllerBase
{
    private readonly IDbService _dbService;
    public CharactersController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet("{characterId}")]
    public async Task<IActionResult> GetCharacter(int characterId)
    {
        var character = await _dbService.GetCharacter(characterId);
        return Ok(character);
    }
    
    [HttpPost("{characterId}/backpacks")]
    public async Task<IActionResult> AddItemToCharactersBackpack(int characterId,[FromBody] List<int> itemIds)
    {
        var items = await _dbService.ItemsToList(itemIds);
        if (items.Count != itemIds.Count)
        {
            return BadRequest("Niepoprawna lista przedmiotow");
        }
        
        var character = await _dbService.DoesCharacterExsist(characterId);
        if (character == null)
        {
            return NotFound("Nie ma takiej postaci");
        }
        
        
        var itemsWeight = items.Sum(i => i.Weight);
        if (character.CurrentWeight + itemsWeight > character.MaxWeight)
        {
            return BadRequest("Waga postaci jest mniejsza niz waga podanych rzeczy");
        }

        var result = await _dbService.AddItemsToCharactersBackpack(items,itemIds,character);
        
        return Ok(result);
    }

}