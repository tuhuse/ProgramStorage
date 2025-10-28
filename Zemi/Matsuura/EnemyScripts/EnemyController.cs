using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private CharacterData _characterData = default;
    [SerializeField] private ItemInventory _itemInventory = default;
   [SerializeField] private CharacterGameData _gameData = default;
    private Enemy _enemy= default;
    public ItemInventory ItemInventory => _itemInventory;
    public Enemy Enemy => _enemy;
    void Start()
    {
        _enemy = new Enemy(_characterData,_gameData);
    }
    private void Update()
    {
       
    }
    public void SetRank(int rank)
    {

    }
}
