using UnityEngine;

/// <summary>
/// アイテム効果の実装
/// </summary>
public interface IItemEffect 
{
    /// <summary>
    /// アイテム効果
    /// </summary>
    /// <param name="target">攻撃対象</param>
    void ApplyEffect(GameObject target,GameObject mySelf);
}
