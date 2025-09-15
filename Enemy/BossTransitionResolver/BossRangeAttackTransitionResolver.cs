using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;

namespace Tuhuse.EnemySystem.Transitions
{
    /// <summary>
    /// ボスが遠距離攻撃ステート時のステート切り替え判断を担うクラス
    /// </summary>
    public class BossRangeAttackTransitionResolver : ITransitionResolver<BossStateType>
    {
        private readonly IStateFactory<BossStateType> _factory;

        public BossRangeAttackTransitionResolver(IStateFactory<BossStateType> factory)
        {
            _factory = factory;
        }

        public IState<BossStateType> Resolve(IInput input, StateEvent stateEvent)
        {
            return _factory.CreateIdleState();
        }
    }
}
