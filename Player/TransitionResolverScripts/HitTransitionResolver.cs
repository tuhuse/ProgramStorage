using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;

/// <summary>
/// �v���C���[���U�����󂯂��X�e�[�g���̃X�e�[�g�؂�ւ����f��S���N���X
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
