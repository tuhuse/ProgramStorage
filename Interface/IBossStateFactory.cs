using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
/// <summary>
/// ボス専用で使うステートファクトリーインターフェースクラス
/// </summary>
public interface IBossStateFactory : IStateFactory<BossStateType>
{
    IState<BossStateType> CreateChaseState();
    IState<BossStateType> CreateAttackState();
    IState<BossStateType> CreateRangeAttackState();
    IState<BossStateType> CreateJumpAttackState();
}
