/// <summary>
/// アイテムデータを受けとる手段
/// </summary>
public interface IItemReceiver 
{
    /// <summary>
    /// アイテムデータ受け取り
    /// </summary>
    /// <param name="itemData">取得したアイテムデータ</param>
    void ReceiveItem(ItemData itemData);
}
