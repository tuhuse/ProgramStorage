using UnityEngine;
using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
using Tuhuse.EnemySystem.StateMachines;
using Unity.VisualScripting;
using UnityEngine.Rendering;

namespace Tuhuse.EnemySystem.States
{
    /// <summary>
    /// ボス近接攻撃時のふるまい
    /// </summary>
    public class BossAttackState : BossStateBase
    {
        private readonly ITransitionResolver<BossStateType> _resolver;
        private readonly IMove _mover;
        private readonly float _attackDuration;
        private float _elapsed;

        public BossAttackState(ITransitionResolver<BossStateType> resolver, IMove mover, float duration = 3.5f)
        {
            _resolver = resolver;
            _mover = mover;
            _attackDuration = duration;
        }

        public override BossStateType GetCurrentState => BossStateType.Attack;

        public override void OnStateBegin()
        {
            _elapsed = 0f;
            // 攻撃開始時は移動ストップ
            _mover.Move(0f, 0f);

        }

        public override void Update(float deltaTime, StateEvent stateEvent, IInput input)
        {
            if (IsEndState)
            {
                return;
            }
            _elapsed += deltaTime;

            // 攻撃モーション終了したら遷移チェック
            if (_elapsed >= _attackDuration)
            {              
                    _nextState = _resolver.Resolve(input, stateEvent);     
               
            }
        }
    }
}
