using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;

namespace Tuhuse.EnemySystem.Transitions
{
    /// <summary>
    /// �{�X���������U���X�e�[�g���̃X�e�[�g�؂�ւ����f��S���N���X
    /// </summary>
    public class BossRangeAttackTransitionResolver : ITransitionResolver<BossStateType>
    {
        private readonly IStateFactory<BossStateType> _factory;

        public BossRangeAttackTransitionResolver(IStateFactory<BossStateType> factory)
        {
            _factory = factory;
        }

        public IState<BossStateType> Resolve(IInput input, StateEvent stateEvent)
        {
            return _factory.CreateIdleState();
        }
    }
}
