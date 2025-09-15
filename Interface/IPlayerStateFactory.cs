using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
/// <summary>
/// プレイヤー専用のステートファクトリーインターフェース
/// </summary>
public interface IPlayerStateFactory : IStateFactory<PlayerStateType>
{
    IState<PlayerStateType> CreateMoveState(float dir);
    IState<PlayerStateType> CreateJumpState();
    IState<PlayerStateType> CreateAttackState();
    IState<PlayerStateType> CreateSkillState(int skillIndex);
    IState<PlayerStateType> CreateHitState();
}
