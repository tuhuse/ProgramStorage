using Tuhuse.PlayerSystem.StateMachines;
using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
namespace Tuhuse.PlayerSystem.States
{
    /// <summary>
    /// Ž€–SŽž‚Ì‚Ó‚é‚Ü‚¢
    /// </summary>
    public class DeadState : PlayerStateBase
    {
        public override PlayerStateType GetCurrentState => PlayerStateType.Dead;
        private readonly ITransitionResolver<PlayerStateType> _resolver = default;
        public DeadState(ITransitionResolver<PlayerStateType> resolver)
        {
            _resolver = resolver;
        }
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