using ExampleTest2.Data;
using ExampleTest2.DTOs;
using ExampleTest2.Models;
using ExampleTest2.Services;
using Microsoft.EntityFrameworkCore;

namespace os.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<ICollection<CharacterDTO>> GetCharacter(int id)
    {
        var result = await _context.Characters
            .Include(c => c.Backpacks)
            .ThenInclude(b => b.Item)
            .Include(c => c.CharacterTitle)
            .ThenInclude(ct => ct.Title)
            .Where(c => c.Id == id)
            .Select(c=> new CharacterDTO
            {
              FirstName=c.FirstName,
              LastName=c.LastName,
              CurrentWeight = c.CurrentWeight,
              MaxWeight = c.MaxWeight,
              BackpackItems = c.Backpacks.Select(b=> new BackpackDTO
                                          {
                                              ItemName = b.Item.Name,
                                              ItemWeight = b.Item.Weight,
                                              Amount = b.Amount
                                          }).ToList(),
              Titles = c.CharacterTitle.Select(ct=> new TitleDTO
                                            {
                                              Title = ct.Title.Name,
                                              AquiredAt = ct.AcquiredAt
                                              
                                          }).ToList()
            })
            .ToListAsync();
        
        return result;

    }
    public async Task<ICollection<AddToBackpackDTO>> AddItemsToCharactersBackpack(ICollection<Items> items,List<int> itemIds, Characters character)
    {
        foreach (var item in items)
        {
            var existingItem = await _context.Backpacks
                .FirstOrDefaultAsync(b => b.CharacterId == character.Id && b.ItemId == item.Id);

            if (existingItem == null) 
            {
                var backpackItem = new Backpacks
                {
                    CharacterId = character.Id,
                    ItemId = item.Id,
                    Amount = 1
                };
                _context.Backpacks.Add(backpackItem);
            }
            else { existingItem.Amount += 1; }
            
        }

        var itemsWeight = items.Sum(i => i.Weight);
        character.CurrentWeight += itemsWeight;
        await _context.SaveChangesAsync();

        var result = await _context.Backpacks
            .Where(b => b.CharacterId == character.Id && itemIds.Contains(b.ItemId))
            .Select(b => new AddToBackpackDTO{ Amount=b.Amount, IdItem=b.ItemId, IdCharacter = b.CharacterId })
            .ToListAsync();
        return result;
    }
    
    public async Task<Characters> DoesCharacterExsist(int id)
    { return await _context.Characters.FirstOrDefaultAsync(c => c.Id == id); }

    public async Task<ICollection<Items>> ItemsToList(List<int> ids)
    {
        var result = await _context.Items.Where(i => ids.Contains(i.Id)).ToListAsync();
        return result;
    }
    
   
}
