using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;

namespace Tuhuse.PlayerSystem.Transitions
{
    /// <summary>
    /// プレイヤーが待機ステート時のステート切り替え判断を担うクラス
    /// </summary>
    public class IdleTransitionResolver : ITransitionResolver<PlayerStateType>
    {
        private readonly IPlayerStateFactory _factory = default;
        public IdleTransitionResolver(IPlayerStateFactory factory)
        {
            _factory = factory;
        }

        public IState<PlayerStateType> Resolve(IInput input, StateEvent stateEvent)
        {
            if (input.IsLeftWalk || input.IsBack|| input.IsRightWalk || input.IsForward)
            {
                stateEvent.HandleMove();
                return _factory.CreateMoveState(3);
            }

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
            if (input.IsAttack)
            {
                stateEvent.HandleAttack();
                return _factory.CreateAttackState();
            }

            return null;
        }
    }
}