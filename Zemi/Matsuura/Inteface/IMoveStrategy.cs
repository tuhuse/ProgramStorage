using UnityEngine;
/// <summary>
/// 移動ストラテジー
/// </summary>
public interface IMoveStrategy
{
    /// <summary>
    /// 移動処理
    /// </summary>
    /// <param name="input">インプットシステムの入力値</param>
    /// <param name="rb">リジッドボディの取得</param>
　　void Move(float input,Rigidbody2D rb);

}
