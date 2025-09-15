using Tuhuse.PlayerSystem.StateMachines;
using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;

namespace Tuhuse.PlayerSystem.States
{
    /// <summary>
    /// �_���[�W���󂯂Đ������ł�����
    /// </summary>
    public class HitState : PlayerStateBase
    {
        public override PlayerStateType GetCurrentState => PlayerStateType.Hit;
        private readonly ITransitionResolver<PlayerStateType> _resolver;
        private readonly PlayerDamageReceiver _damageReceiver;

        public HitState(ITransitionResolver<PlayerStateType> resolver, PlayerDamageReceiver damageReceiver)
        {
            _resolver = resolver;
            _damageReceiver = damageReceiver;
        }

        public override void Update(float deltaTime, StateEvent stateEvent, IInput input)
        {
            if (IsEndState) return;

            // �m�b�N�o�b�N���I������玟�֑J��
            if (!_damageReceiver.IsKnockback)
            {
                _nextState = _resolver.Resolve(input, stateEvent);
            }
        }
    }
}
