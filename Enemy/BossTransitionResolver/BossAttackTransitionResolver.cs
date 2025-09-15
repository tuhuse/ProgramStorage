using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
/// <summary>
/// ボスが攻撃ステート時のステート切り替え判断を担うクラス
/// </summary>
public class BossAttackTransitionResolver : ITransitionResolver<BossStateType>
{
    private readonly IBossStateFactory _factory;

    public BossAttackTransitionResolver(IBossStateFactory factory)
    {
        _factory = factory;
    }

    public IState<BossStateType> Resolve(IInput input, StateEvent stateEvent)
    {
        // 攻撃終了後Idle に戻す
        return _factory.CreateIdleState();
    }
}
