namespace Tuhuse.Shared.Interfaces
{
    using UnityEngine;
    /// <summary>
    /// 移動インターフェース
    /// </summary>
    public interface IMove
    {
        /// <summary>
        /// 位置を返す
        /// </summary>
        Vector3 Position { get; } 
        /// <summary>
        /// 移動処理
        /// </summary>
        /// <param name="x"></param>
        /// <param name="z"></param>
        void Move(float x, float z);
    }
}