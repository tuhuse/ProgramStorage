public class Enemy :ICharacter
{
    public Enemy(CharacterData character,CharacterGameData gameData)
    {
        Character = character;
        CharacterGameData = gameData;
    }
    public CharacterData Character { get; }
    public CharacterGameData CharacterGameData { get;}

    public void SetData()
    {
        
    }
}
