using Tuhuse.PlayerSystem.StateMachines;
using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
namespace Tuhuse.PlayerSystem.States
{
    /// <summary>
    /// ‘Ò‹@Žž‚Ì‚Ó‚é‚Ü‚¢
    /// </summary>
    public class IdleState : PlayerStateBase
    {
        private readonly ITransitionResolver<PlayerStateType> _resolver;

        public IdleState(ITransitionResolver<PlayerStateType> resolver)
        {
            _resolver = resolver;
        }

        public override PlayerStateType GetCurrentState => PlayerStateType.Idle;

        public override void Update(float deltaTime, StateEvent stateEvent, IInput input)
        {
            if (IsEndState) return;
            _nextState = _resolver.Resolve(input, stateEvent);
        }
    }
}