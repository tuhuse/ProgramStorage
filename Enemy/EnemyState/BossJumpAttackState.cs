using Tuhuse.EnemySystem.StateMachines;
using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
using UnityEngine;

/// <summary>
/// ƒ{ƒXƒWƒƒƒ“ƒvUŒ‚‚Ì‚Ó‚é‚Ü‚¢
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

    // ’…’n‚·‚é‚Ü‚Å‚ÍŸ‚Ì‘JˆÚ‚ğŒˆ‚ß‚È‚¢
    if (_hasJumped && _jumper.IsGrounded)
    {
        // ’…’n‚µ‚½uŠÔ‚É‚Ì‚İŸ‚Ì‘JˆÚ‚ğŒˆ‚ß‚é
        _nextState = _resolver.Resolve(input, stateEvent);
    }
}

}
