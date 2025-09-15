using Tuhuse.Shared.Events;
using Tuhuse.Shared.StateSystem;

namespace Tuhuse.Shared.Interfaces
{
    /// <summary>
    /// ステート切り替えインターフェース
    /// </summary>
    public interface ITransitionResolver<TStateType>
    {
        /// <summary>
        /// 切り替え処理
        /// </summary>
        /// <param name="input">IInput入力</param>
        /// <param name="stateEvent">イベント</param>
        /// <returns></returns>
        IState<TStateType> Resolve(IInput input, StateEvent stateEvent);
    }
}