using Tuhuse.EnemySystem.StateMachines;
using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;

namespace Tuhuse.EnemySystem.States
{
    /// <summary>
    /// ƒ{ƒX‘Ò‹@Žž‚Ì‚Ó‚é‚Ü‚¢
    /// </summary>
    public class BossIdleState : BossStateBase
    {
        private readonly ITransitionResolver<BossStateType> _resolver=default;
        public BossIdleState(ITransitionResolver<BossStateType> resolver)
        {
            _resolver = resolver;
        }

        public override BossStateType GetCurrentState => BossStateType.Idle;

        public override void Update(float deltaTime, StateEvent stateEvent, IInput input)
        {
            if (IsEndState)
            {
                return;
            }
            _nextState = _resolver.Resolve(input, stateEvent);
        }
    }
}
