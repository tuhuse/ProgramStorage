using Tuhuse.EnemySystem.Factory;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
using UnityEngine;
/// <summary>
/// ボスステートマシーンクラス
/// </summary>
public class BossStateMachine : StateMachineBase<BossStateType>
{
    [SerializeField]
    private Transform _player=default;
    private BossJumpAttack _bossJumpAttack=default;
    protected override void Start()
    {
        _input = new BossAIInput(_player, this.transform);
        _mover = GetComponent<IMove>();
        _bossJumpAttack = GetComponent<BossJumpAttack>();
        _stateFactory = new BossStateFactory(_mover,_bossJumpAttack, this.transform, _player);
        base.Start();
    }

    protected override void Update()
    {
        _input.InputUpdate(); // AIの入力更新
        base.Update();
    }

    protected override IState<BossStateType> GetInitialState()
    {
        return _stateFactory.CreateIdleState();
    }
}
