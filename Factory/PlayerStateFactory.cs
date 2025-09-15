using System.Collections.Generic;
using Tuhuse.PlayerSystem.States;
using Tuhuse.PlayerSystem.Transitions;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
/// <summary>
/// プレイヤーのステート、切り替えクラスを生成するクラス
/// </summary>
public class PlayerStateFactory : IPlayerStateFactory
{
    private readonly IMove _mover;
    private readonly IJump _jumper;
    private readonly List<ITimeAffectable> _timeTargets;
    private readonly SkillManager _skillManager;
    private readonly PlayerAttack _playerAttack;
    private readonly Dictionary<PlayerStateType, ITransitionResolver<PlayerStateType>> _resolvers;
    private readonly PlayerDamageReceiver _damageReceiver = default;

    public PlayerStateFactory(IMove mover, IJump jumper, SkillManager skillManager, PlayerAttack playerAttack, PlayerDamageReceiver damageReceiver)
    {
        _mover = mover;
        _jumper = jumper;
        _skillManager = skillManager;
        _timeTargets = skillManager.TimeTargets;
        _playerAttack = playerAttack;
        _damageReceiver = damageReceiver;

        _resolvers = new Dictionary<PlayerStateType, ITransitionResolver<PlayerStateType>>
    {
        { PlayerStateType.Idle, new IdleTransitionResolver(this) },
        { PlayerStateType.Move, new MoveTransitionResolver(this) },
        { PlayerStateType.Jump, new JumpTransitionResolver(this,_jumper)},
        { PlayerStateType.Attack, new AttackTransitionResolver(this) },
        { PlayerStateType.Skill, new SkillTransitionResolver(this) },
        { PlayerStateType.Hit, new HitTransitionResolver(this) },   
        { PlayerStateType.Dead, new DeadTransitionResolver(this) },
    };
    }

    


    public IState<PlayerStateType> CreateIdleState()
        => new IdleState(_resolvers[PlayerStateType.Idle]);

    public IState<PlayerStateType> CreateMoveState(float dir)
        => new MoveState(_mover, _resolvers[PlayerStateType.Move], dir);

    public IState<PlayerStateType> CreateJumpState()
        => new JumpingState(_resolvers[PlayerStateType.Jump], _mover, _jumper);

    public IState<PlayerStateType> CreateAttackState()
        => new AttackState(_resolvers[PlayerStateType.Attack],_playerAttack);

    public IState<PlayerStateType> CreateSkillState(int skillIndex)
    {
        if (_skillManager.IsOnCooldown)
        {
            return CreateIdleState();
        }

        switch (skillIndex)
        {
            case 1:
                _skillManager.ActivateRewind();
                break;
            case 2:
                _skillManager.ActivateTimeStop();
                break;
        }

        return new SkillState(_resolvers[PlayerStateType.Skill], _skillManager);
    }
    public IState<PlayerStateType> CreateHitState()
        => new HitState(_resolvers[PlayerStateType.Hit], _damageReceiver);

    public IState<PlayerStateType> CreateDeadState()
        => new DeadState(_resolvers[PlayerStateType.Dead]);
}
