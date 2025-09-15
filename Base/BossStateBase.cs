namespace Tuhuse.EnemySystem.StateMachines
{
    using Tuhuse.Shared.Events;
    using Tuhuse.Shared.Interfaces;
    using Tuhuse.Shared.StateSystem;
    /// <summary>
    /// ボス用の共通ステート内処理を書いた基底クラス
    /// </summary>
    public abstract class BossStateBase : IState<BossStateType>
    {
        protected float _elapsedTime;
        protected IState<BossStateType> _nextState;

        public bool IsEndState { get; protected set; }
        public abstract BossStateType GetCurrentState { get; }

        public virtual void OnStateChanged() { }
        public virtual void OnStateBegin() => IsEndState = false;
        public virtual void OnStateEnd() => IsEndState = true;

        public void SetNextState(IState<BossStateType> nextState) => _nextState = nextState;
        public IState<BossStateType> GetNextState() => _nextState;

        public abstract void Update(float deltaTime, StateEvent stateEvent, IInput input);
    }
}
