using ExampleTest2.DTOs;
using ExampleTest2.Models;

namespace ExampleTest2.Services;

public interface IDbService
{
    Task<ICollection<Items>> ItemsToList(List<int> itemsId);
    Task<ICollection<AddToBackpackDTO>> AddItemsToCharactersBackpack(ICollection<Items> items, List<int> itemsId, Characters character);
    Task<ICollection<CharacterDTO>> GetCharacter(int characterId);
    Task<Characters?> DoesCharacterExsist(int characterId); 
}