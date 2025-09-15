namespace Tuhuse.PlayerSystem.StateMachines
{
    using Tuhuse.Shared.Events;
    using Tuhuse.Shared.Interfaces;
    using Tuhuse.Shared.StateSystem;
    /// <summary>
    /// プレイヤー用の共通ステート内処理を書いた基底クラス
    /// </summary>
    public abstract class PlayerStateBase : IState<PlayerStateType>
    {
        protected float _elapsedTime;
        protected IState<PlayerStateType> _nextState;

        public bool IsEndState { get; protected set; }
        public abstract PlayerStateType GetCurrentState { get; }

        public virtual void OnStateChanged() { }
        public virtual void OnStateBegin() => IsEndState = false;
        public virtual void OnStateEnd() => IsEndState = true;

        public void SetNextState(IState<PlayerStateType> nextState) => _nextState = nextState;
        public IState<PlayerStateType> GetNextState() => _nextState;

        public abstract void Update(float deltaTime, StateEvent stateEvent, IInput input);
    }
}
