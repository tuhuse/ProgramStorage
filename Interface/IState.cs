using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;

namespace Tuhuse.Shared.StateSystem
{
    /// <summary>
    /// プレイヤーステート
    /// </summary>
    public enum PlayerStateType
    {
        Idle,
        Move,
        Jump,
        Attack,
        Skill,
        Hit,
        Dead

    }
    /// <summary>
    /// ボスステート
    /// </summary>
    public enum BossStateType
    {
        Idle,
        Chase,
        Attack,
        RangeAttack,
        JumpAttack,
        Dead

    }
}

namespace Tuhuse.Shared.StateSystem
{
    /// <summary>
    /// ステートインターフェース
    /// </summary>
    /// <typeparam name="TStateType">プレイヤーかボスのステート</typeparam>
    public interface IState<TStateType>
    {
        TStateType GetCurrentState { get; }

        void OnStateChanged();
        void OnStateBegin();
        void OnStateEnd();
        void Update(float deltTime, StateEvent inputEvent, IInput input);
        void SetNextState(IState<TStateType> nextState);
        IState<TStateType> GetNextState();
    }
}