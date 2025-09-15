using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
/// <summary>
/// �v���C���[��p�̃X�e�[�g�t�@�N�g���[�C���^�[�t�F�[�X
/// </summary>
public interface IPlayerStateFactory : IStateFactory<PlayerStateType>
{
    IState<PlayerStateType> CreateMoveState(float dir);
    IState<PlayerStateType> CreateJumpState();
    IState<PlayerStateType> CreateAttackState();
    IState<PlayerStateType> CreateSkillState(int skillIndex);
    IState<PlayerStateType> CreateHitState();
}
