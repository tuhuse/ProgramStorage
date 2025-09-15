namespace Tuhuse.Shared.Interfaces
{
    /// <summary>
    /// ジャンプインターフェース
    /// </summary>
    public interface IJump
    {
        /// <summary>
        /// ジャンプ処理
        /// </summary>
        /// <param name="force">飛ぶ力</param>
        void Jump(float force);
        /// <summary>
        /// 地面についているか
        /// </summary>
        bool IsGrounded { get; }
    }
}
