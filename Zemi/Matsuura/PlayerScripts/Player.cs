public class Player : ICharacter
{
    public Player(CharacterData data,CharacterGameData gameData)
    {
        Character = data;
        CharacterGameData = gameData;
    }

    public CharacterData Character { get; }

    public CharacterGameData CharacterGameData { get; }

    public void SetData()
    {

    }
}
