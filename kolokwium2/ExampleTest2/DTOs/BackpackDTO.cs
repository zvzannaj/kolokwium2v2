namespace ExampleTest2.DTOs;

public class BackpackDTO
{
    public string ItemName { get; set; }
    public int ItemWeight { get; set; }
    public int Amount { get; set; }
}


public class AddToBackpackDTO
{
    public int IdCharacter { get; set; }
    public int IdItem { get; set; }
    public int Amount { get; set; }
}