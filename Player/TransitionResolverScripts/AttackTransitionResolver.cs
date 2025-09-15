using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
namespace Tuhuse.PlayerSystem.Transitions
{
    /// <summary>
    /// �v���C���[���U���X�e�[�g���̃X�e�[�g�؂�ւ����f��S���N���X
    /// </summary>
    public class AttackTransitionResolver : ITransitionResolver<PlayerStateType>
    {
        private readonly IPlayerStateFactory _factory;

        public AttackTransitionResolver(IPlayerStateFactory factory)
        {
            _factory = factory;
        }

        public IState<PlayerStateType> Resolve(IInput input, StateEvent stateEvent)
        {

            if (input.IsHit)
            {
                return _factory.CreateHitState();
            }
            return _factory.CreateIdleState();
            
        }
    }
}