using Tuhuse.PlayerSystem.StateMachines;
using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;

namespace Tuhuse.PlayerSystem.States
{
    /// <summary>
    /// ダメージを受けて吹っ飛んでいる状態
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

            // ノックバックが終わったら次へ遷移
            if (!_damageReceiver.IsKnockback)
            {
                _nextState = _resolver.Resolve(input, stateEvent);
            }
        }
    }
}
