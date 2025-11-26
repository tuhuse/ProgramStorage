using UnityEngine;
[CreateAssetMenu(fileName = "ItemName", menuName = "ScriptableObject/SnakeEffect")]

/// <summary>
/// 蛇の実装　一番近くの敵を追尾し、攻撃する
/// 未完成　デバッグしてないです
/// </summary>
public class SnakeEffect : ItemEffectBase
{
    [Header("蛇のプレハブ（Snakeをアタッチ）")]
    [SerializeField]
    private GameObject _snakePrefab = default;

    private GameObject _instantiateSnake = default;

    public override void ApplyEffect(GameObject target,GameObject mySelf)
    {
        if (_instantiateSnake == null)
        {
            _instantiateSnake = Instantiate(_snakePrefab);
        }
        else
        {
            _instantiateSnake.SetActive(true);
        }
    }
}
