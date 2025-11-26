using UnityEngine;
/// <summary>
/// アイテムデータ
/// </summary>
[CreateAssetMenu(fileName ="ItemName",menuName ="ScriptableObject/ItemData")]
public class ItemData :ScriptableObject
{
    [SerializeField]
    private int _itemId = default;
    [SerializeField]
    private string _itemName = default;
    [SerializeField,TextArea]
    private string _itemDescription = default;  
    [SerializeField]
    private Sprite _itemIcon = default;
    [SerializeField]
    private ItemEffectBase _itemEffect = default;
   /// <summary>
   /// アイテムID
   /// </summary>
    public int ItemID => _itemId;
    /// <summary>
    /// アイテム名
    /// </summary>
    public string ItemName => _itemName;
    /// <summary>
    /// アイテムについての説明
    /// </summary>
    public string ItemDescription => _itemDescription;
    /// <summary>
    /// アイテムの表示アイコン
    /// </summary>
    public Sprite ItemIcon => _itemIcon;
    /// <summary>
    /// アイテムの効果
    /// </summary>
    public ItemEffectBase ItemEffect => _itemEffect;
   
}
