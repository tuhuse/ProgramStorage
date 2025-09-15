using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;

namespace Tuhuse.PlayerSystem.Transitions
{
    /// <summary>
    /// プレイヤーがジャンプステート時のステート切り替え判断を担うクラス
    /// </summary>
    public class JumpTransitionResolver : ITransitionResolver<PlayerStateType>
    {
        private readonly IPlayerStateFactory _factory;
        private readonly IJump _jumper;

        public JumpTransitionResolver(IPlayerStateFactory factory, IJump jumper)
        {
            _factory = factory;
            _jumper = jumper;
        }

        public IState<PlayerStateType> Resolve(IInput input, StateEvent stateEvent)
        {
            if (_jumper.IsGrounded) // ← ここで着地判定
            {
                if (input.IsLeftWalk || input.IsRightWalk || input.IsForward || input.IsBack)
                {
                    return _factory.CreateMoveState(1);
                }
                return _factory.CreateIdleState();
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
            if (input.IsAttack)
            {
                stateEvent.HandleAttack();
                return _factory.CreateAttackState();
            }
            return null;
        }
    }
}
