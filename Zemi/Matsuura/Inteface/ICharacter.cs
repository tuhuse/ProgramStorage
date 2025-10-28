public interface ICharacter
{

    CharacterData Character { get; }
    CharacterGameData CharacterGameData { get; } 
    void SetData();
}
