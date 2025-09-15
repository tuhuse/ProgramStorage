using UnityEngine;
using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.EnemySystem.StateMachines;
using Tuhuse.Shared.StateSystem;

namespace Tuhuse.EnemySystem.States
{
    /// <summary>
    /// ボスがプレイヤーを追尾時のふるまい
    /// </summary>
    public class BossChaseState : BossStateBase
    {
        private readonly ITransitionResolver<BossStateType> _resolver=default;
        private readonly IMove _mover=default;
        private readonly Transform _target=default;
        private readonly float _moveSpeed=default;

        public BossChaseState(ITransitionResolver<BossStateType> resolver, IMove mover, Transform target, float speed = 3f)
        {
            _resolver = resolver;
            _mover = mover;
            _target = target;
            _moveSpeed = speed;
        }

        public override BossStateType GetCurrentState => BossStateType.Chase;

        public override void Update(float deltaTime, StateEvent stateEvent, IInput input)
        {
            if (IsEndState)
            {
                return;
            }
            // プレイヤー方向に移動
            Vector3 dir = (_target.position - _mover.Position).normalized;
            _mover.Move(dir.x * _moveSpeed, dir.z * _moveSpeed);
            // 遷移チェック
            _nextState = _resolver.Resolve(input, stateEvent);
        }
    }
}
