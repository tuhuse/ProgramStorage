using System.Collections.Generic;
using UnityEngine;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
using Tuhuse.EnemySystem.Transitions;
using Tuhuse.EnemySystem.States;

namespace Tuhuse.EnemySystem.Factory
{

    /// <summary>
    /// ボスのステート、切り替えクラスを生成するクラス
    /// </summary>
    public class BossStateFactory : IBossStateFactory
    {
        private readonly IMove _mover=default;
        private readonly BossJumpAttack _jumper; 
        private readonly Transform _boss=default;
        private readonly Transform _player=default;

        private readonly Dictionary<BossStateType, ITransitionResolver<BossStateType>> _resolvers;

        public BossStateFactory(IMove mover, BossJumpAttack jumper, Transform boss, Transform player)
        {
            _mover = mover;
            _jumper = jumper;
            _boss = boss;
            _player = player;

            _resolvers = new Dictionary<BossStateType, ITransitionResolver<BossStateType>>
        {
            { BossStateType.Idle, new BossIdleTransitionResolver(this, _boss, _player) },
            { BossStateType.Chase, new BossChaseTransitionResolver(this,_boss,_player) },
            { BossStateType.Attack, new BossAttackTransitionResolver(this) },
            { BossStateType.RangeAttack, new BossRangeAttackTransitionResolver(this) },
            { BossStateType.JumpAttack, new BossJumpAttackTransitionResolver(this) },
        };
        }

        public IState<BossStateType> CreateIdleState()
            => new BossIdleState(_resolvers[BossStateType.Idle]);

        public IState<BossStateType> CreateChaseState()
            => new BossChaseState(_resolvers[BossStateType.Chase], _mover, _player, 3f);

        public IState<BossStateType> CreateAttackState()
            => new BossAttackState(_resolvers[BossStateType.Attack],_mover);

        public IState<BossStateType> CreateRangeAttackState()
            => new BossRangeAttackState(_resolvers[BossStateType.RangeAttack],_player);

        public IState<BossStateType> CreateJumpAttackState()
       => new BossJumpAttackState(_resolvers[BossStateType.JumpAttack], _jumper, _player);

        public IState<BossStateType> CreateDeadState()
            => null;// new BossDeadState(_resolvers[BossStateType.Dead]);
    }
}
