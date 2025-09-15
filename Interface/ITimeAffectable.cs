namespace Tuhuse.Shared.Interfaces
{
    /// <summary>
    /// 時を止める対象につけるインターフェース
    /// </summary>
    public interface ITimeAffectable
    {
        /// <summary>
        /// 時間を止める
        /// </summary>
        void OnTimeStop();
        /// <summary>
        /// 時間を再開させる
        /// </summary>
        void OnTimeResume();
    }
}