using Tuhuse.EnemySystem.Factory;
using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
using UnityEngine;

namespace Tuhuse.EnemySystem.Transitions
{
    /// <summary>
    /// ボスが待機ステート時のステート切り替え判断を担うクラス
    /// </summary>
    public class BossIdleTransitionResolver : ITransitionResolver<BossStateType>
    {
        private readonly IBossStateFactory _factory;
        private readonly Transform _boss;
        private readonly Transform _player;
        private readonly float _detectRange;

        public BossIdleTransitionResolver(IBossStateFactory factory, Transform boss, Transform player, float detectRange = 10f)
        {
            _factory = factory;
            _boss = boss;
            _player = player;
            _detectRange = detectRange;
        }

        public IState<BossStateType> Resolve(IInput input, StateEvent stateEvent)
        {
            if (input.IsForward)
            {
                return _factory.CreateChaseState();
            }
            if (input.IsAttack)
            {
                return _factory.CreateAttackState();
            }
            return null;
        }
    }
}
