using Tuhuse.PlayerSystem.StateMachines;
using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
namespace Tuhuse.PlayerSystem.States
{
    /// <summary>
    /// UŒ‚‚Ì‚Ó‚é‚Ü‚¢
    /// </summary>
    public class AttackState : PlayerStateBase
    {
        public override PlayerStateType GetCurrentState => PlayerStateType.Attack;
        private readonly ITransitionResolver<PlayerStateType> _resolver = default;
        private readonly PlayerAttack _attack = default;
        public AttackState(ITransitionResolver<PlayerStateType> resolver,PlayerAttack attack)
        {
            _resolver = resolver;
            _attack = attack;
        }
        public override void Update(float deltaTime, StateEvent stateEvent, IInput input)
        {
            if (IsEndState)
            {
                return;
            }
            if (_attack.IsAttack)
            {
                return;
            }
            _nextState = _resolver.Resolve(input, stateEvent);
        }
    }
}