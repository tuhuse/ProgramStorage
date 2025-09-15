using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
/// <summary>
/// �{�X��p�Ŏg���X�e�[�g�t�@�N�g���[�C���^�[�t�F�[�X�N���X
/// </summary>
public interface IBossStateFactory : IStateFactory<BossStateType>
{
    IState<BossStateType> CreateChaseState();
    IState<BossStateType> CreateAttackState();
    IState<BossStateType> CreateRangeAttackState();
    IState<BossStateType> CreateJumpAttackState();
}
