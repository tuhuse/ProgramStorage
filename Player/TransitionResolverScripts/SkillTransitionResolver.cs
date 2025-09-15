using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;

namespace Tuhuse.PlayerSystem.Transitions
{
    /// <summary>
    /// �v���C���[���X�L���g�p�X�e�[�g���̃X�e�[�g�؂�ւ����f��S���N���X
    /// </summary>
    public class SkillTransitionResolver : ITransitionResolver<PlayerStateType>
    {
        private readonly IPlayerStateFactory _factory;

        public SkillTransitionResolver(IPlayerStateFactory factory)
        {
            _factory = factory;
        }
        public IState<PlayerStateType> Resolve(IInput input, StateEvent stateEvent)
        {
           
            return _factory.CreateIdleState();
        }

    }
}