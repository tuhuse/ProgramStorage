using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;

namespace Tuhuse.PlayerSystem.Transitions
{
    /// <summary>
    /// �v���C���[���ړ��X�e�[�g���̃X�e�[�g�؂�ւ����f��S���N���X
    /// </summary>
    public class MoveTransitionResolver : ITransitionResolver<PlayerStateType>
    {
        private readonly IPlayerStateFactory _factory;

        public MoveTransitionResolver(IPlayerStateFactory factory)
        {
            _factory = factory;
        }

        public IState<PlayerStateType> Resolve(IInput input, StateEvent stateEvent)
        {
            // �ړ��L�[�𗣂����� Idle
            if (!input.IsLeftWalk && !input.IsRightWalk && !input.IsForward && !input.IsBack)
            {
                return _factory.CreateIdleState();
            }

            // �W�����v���� �� JumpState��
            if (input.IsJump)
            {
                stateEvent.HandleJump();
                return _factory.CreateJumpState();
            }
            if (input.IsSkill)
            {
                stateEvent.HandleSkill();
                return _factory.CreateSkillState(input.ActiveSkillIndex);
            }
            if (input.IsHit)
            {
                return _factory.CreateHitState();
            }
            // �U������ �� AttackState��
            if (input.IsAttack)
            {
                stateEvent.HandleAttack();
                return _factory.CreateAttackState();
            }

            return null;
        }
    }
}
