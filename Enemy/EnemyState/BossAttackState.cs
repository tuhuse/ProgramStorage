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
    /// �{�X�ߐڍU�����̂ӂ�܂�
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
            // �U���J�n���͈ړ��X�g�b�v
            _mover.Move(0f, 0f);

        }

        public override void Update(float deltaTime, StateEvent stateEvent, IInput input)
        {
            if (IsEndState)
            {
                return;
            }
            _elapsed += deltaTime;

            // �U�����[�V�����I��������J�ڃ`�F�b�N
            if (_elapsed >= _attackDuration)
            {              
                    _nextState = _resolver.Resolve(input, stateEvent);     
               
            }
        }
    }
}
