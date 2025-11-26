using UnityEngine;
/// <summary>
/// アイテム効果のベース
/// </summary>
public abstract class ItemEffectBase : ScriptableObject,IItemEffect
{
    [SerializeField]
    private float _itemCoolTime = default;
    /// <summary>
    /// アイテムの使用クールタイム
    /// </summary>
    public float ItemCoolTime => _itemCoolTime;
    public abstract void ApplyEffect(GameObject target,GameObject mySelf);
}
