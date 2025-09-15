using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
/// <summary>
/// �{�X���U���X�e�[�g���̃X�e�[�g�؂�ւ����f��S���N���X
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
        // �U���I����Idle �ɖ߂�
        return _factory.CreateIdleState();
    }
}
