using UnityEngine;
using static UnityEngine.GraphicsBuffer;
/// <summary>
/// アイテムインベントリ
/// </summary>
public class ItemInventory : MonoBehaviour, IItemReceiver
{
    private ItemData _itemData = default;
    [SerializeField] private StickOutItemTongue _stickOutItemTongue = default;

    public void ReceiveItem(ItemData itemData)
    {
        _itemData = itemData;
    }
    /// <summary>
    /// アイテム舌を使うタイミングで呼び出す
    /// </summary>
    public void UseItem(int itemID)
    {
        _stickOutItemTongue.ReceiveInputToTongue(itemID);

    }

    /// <summary>
    /// アイテムが発動するときに呼び出す
    /// </summary>
    /// <param name="target">攻撃対象</param>
    public void ActivationItem(GameObject target)
    {
        _itemData.ItemEffect.ApplyEffect(target, this.gameObject);
    }

}
