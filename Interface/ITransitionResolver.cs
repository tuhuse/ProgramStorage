using Tuhuse.Shared.Events;
using Tuhuse.Shared.StateSystem;

namespace Tuhuse.Shared.Interfaces
{
    /// <summary>
    /// �X�e�[�g�؂�ւ��C���^�[�t�F�[�X
    /// </summary>
    public interface ITransitionResolver<TStateType>
    {
        /// <summary>
        /// �؂�ւ�����
        /// </summary>
        /// <param name="input">IInput����</param>
        /// <param name="stateEvent">�C�x���g</param>
        /// <returns></returns>
        IState<TStateType> Resolve(IInput input, StateEvent stateEvent);
    }
}