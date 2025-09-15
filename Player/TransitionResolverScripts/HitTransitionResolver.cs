using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;

/// <summary>
/// プレイヤーが攻撃を受けたステート時のステート切り替え判断を担うクラス
/// </summary>
public class HitTransitionResolver :ITransitionResolver<PlayerStateType>
{
    private readonly IPlayerStateFactory _factory;

    public HitTransitionResolver(IPlayerStateFactory factory)
    {
        _factory = factory;
    }

    public IState<PlayerStateType> Resolve(IInput input, StateEvent stateEvent)
    {
        return _factory.CreateIdleState();
    }
}
