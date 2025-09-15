using Tuhuse.Shared.StateSystem;

namespace Tuhuse.Shared.Interfaces
{
    /// <summary>
    /// �G�A�v���C���[���ʂ̃X�e�[�g�t�@�N�g���[�C���^�[�t�F�[�X
    /// </summary>
    /// <typeparam name="TStateType"></typeparam>
    public interface IStateFactory<TStateType>
    {
        IState<TStateType> CreateIdleState();
        IState<TStateType> CreateDeadState();
        
    }
}
