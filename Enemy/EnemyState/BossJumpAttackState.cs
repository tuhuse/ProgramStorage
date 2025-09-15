using Tuhuse.EnemySystem.StateMachines;
using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
using UnityEngine;

/// <summary>
/// �{�X�W�����v�U�����̂ӂ�܂�
/// </summary>
public class BossJumpAttackState : BossStateBase
{
    public override BossStateType GetCurrentState => BossStateType.JumpAttack;

    private readonly ITransitionResolver<BossStateType> _resolver;
    private readonly BossJumpAttack _jumper;  
    private readonly Transform _player;
    private bool _hasJumped;

    public BossJumpAttackState(ITransitionResolver<BossStateType> resolver, BossJumpAttack jumper, Transform player)
    {
        _resolver = resolver;
        _jumper = jumper;
        _player = player;
    }

    public override void OnStateBegin()
    {
        _hasJumped = false;
    }

   public override void Update(float deltaTime, StateEvent stateEvent, IInput input)
{
    if (!_hasJumped)
    {
        _jumper.SetTarget(_player);
        _jumper.Jump(0); 
        _hasJumped = true;
    }

    // ���n����܂ł͎��̑J�ڂ����߂Ȃ�
    if (_hasJumped && _jumper.IsGrounded)
    {
        // ���n�����u�Ԃɂ̂ݎ��̑J�ڂ����߂�
        _nextState = _resolver.Resolve(input, stateEvent);
    }
}

}
