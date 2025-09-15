using Tuhuse.Shared.StateSystem;

namespace Tuhuse.Shared.Interfaces
{
    /// <summary>
    /// 敵、プレイヤー共通のステートファクトリーインターフェース
    /// </summary>
    /// <typeparam name="TStateType"></typeparam>
    public interface IStateFactory<TStateType>
    {
        IState<TStateType> CreateIdleState();
        IState<TStateType> CreateDeadState();
        
    }
}
