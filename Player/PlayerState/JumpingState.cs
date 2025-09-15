using Tuhuse.PlayerSystem.StateMachines;
using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;

namespace Tuhuse.PlayerSystem.States
{
    /// <summary>
    /// �W�����v���̂ӂ�܂�
    /// </summary>
    public class JumpingState : PlayerStateBase
    {
        private readonly ITransitionResolver<PlayerStateType> _resolver;
        private readonly IMove _mover;
        private readonly IJump _jumper;
        
        private bool _hasJumped = false;

        private const float JUMP_FORCE = 5f;
        public JumpingState(ITransitionResolver<PlayerStateType> resolver, IMove mover, IJump jumper)
        {
            _resolver = resolver;
            _mover = mover;
            _jumper = jumper;
        }

        public override PlayerStateType GetCurrentState => PlayerStateType.Jump;

        public override void OnStateBegin()
        {
            base.OnStateBegin();

            if (!_hasJumped)
            {
                _jumper.Jump(JUMP_FORCE);   // ������̗͂�������͈̂�x����
                _hasJumped = true;
            }
        }

        public override void Update(float deltaTime, StateEvent stateEvent, IInput input)
        {
            if (IsEndState) return;

            // �󒆂ł��ړ��͉\�i���x�𗎂Ƃ��Ȃǒ����j

            int x = 0;
            if (input.IsRightWalk)
            {
                x += 1;
            }
            if (input.IsLeftWalk)
            {
                x -= 1;
            }

            int y = 0;
            if (input.IsForward)
            {
                y += 1;
            }
            if (input.IsBack)
            {
                y -= 1;
            }
            _mover.Move(x, y);


            // �J�ڔ���
            _nextState = _resolver.Resolve(input, stateEvent);
        }
    }
}
