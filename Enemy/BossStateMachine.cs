using Tuhuse.EnemySystem.Factory;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
using UnityEngine;
/// <summary>
/// �{�X�X�e�[�g�}�V�[���N���X
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
        _input.InputUpdate(); // AI�̓��͍X�V
        base.Update();
    }

    protected override IState<BossStateType> GetInitialState()
    {
        return _stateFactory.CreateIdleState();
    }
}
