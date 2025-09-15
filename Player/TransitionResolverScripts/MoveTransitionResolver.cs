using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;

namespace Tuhuse.PlayerSystem.Transitions
{
    /// <summary>
    /// プレイヤーが移動ステート時のステート切り替え判断を担うクラス
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
            // 移動キーを離したら Idle
            if (!input.IsLeftWalk && !input.IsRightWalk && !input.IsForward && !input.IsBack)
            {
                return _factory.CreateIdleState();
            }

            // ジャンプ入力 → JumpStateへ
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
            // 攻撃入力 → AttackStateへ
            if (input.IsAttack)
            {
                stateEvent.HandleAttack();
                return _factory.CreateAttackState();
            }

            return null;
        }
    }
}
