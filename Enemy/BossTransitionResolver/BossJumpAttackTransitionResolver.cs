using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;

namespace Tuhuse.EnemySystem.Transitions
{
    /// <summary>
    /// ボスがジャンプ攻撃ステート時のステート切り替え判断を担うクラス
    /// </summary>
    public class BossJumpAttackTransitionResolver : ITransitionResolver<BossStateType>
    {
        private readonly IStateFactory<BossStateType> _factory;

        public BossJumpAttackTransitionResolver(IStateFactory<BossStateType> factory)
        {
            _factory = factory;
        }

        public IState<BossStateType> Resolve(IInput input, StateEvent stateEvent)
        {
            return _factory.CreateIdleState();
        }
    }
}
