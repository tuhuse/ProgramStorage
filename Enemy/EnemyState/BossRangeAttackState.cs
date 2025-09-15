using UnityEngine;
using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
using Tuhuse.EnemySystem.StateMachines;

namespace Tuhuse.EnemySystem.States
{
    /// <summary>
    /// ‰“‹——£ƒuƒŒƒXUŒ‚‚Ì‚Ó‚é‚Ü‚¢
    /// </summary>
    public class BossRangeAttackState : BossStateBase
    {
        public override BossStateType GetCurrentState => BossStateType.RangeAttack;

        private readonly ITransitionResolver<BossStateType> _resolver=default;
        private readonly Transform _player=default;
        private readonly float _attackDuration=default;
        private float _elapsed=default;

        public BossRangeAttackState(ITransitionResolver<BossStateType> resolver, Transform player, float attackDuration = 2f)
        {
            _resolver = resolver;
            _player = player;
            _attackDuration = attackDuration;
        }

        public override void OnStateBegin()
        {
            _elapsed = 0f;
        }

        public override void Update(float deltaTime, StateEvent stateEvent, IInput input)
        {
            _elapsed += deltaTime;
            if (_elapsed >= _attackDuration)
            {
                _nextState = _resolver.Resolve(input, stateEvent);
            }
        }
    }
}
