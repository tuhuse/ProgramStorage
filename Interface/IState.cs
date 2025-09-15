using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;

namespace Tuhuse.Shared.StateSystem
{
    /// <summary>
    /// �v���C���[�X�e�[�g
    /// </summary>
    public enum PlayerStateType
    {
        Idle,
        Move,
        Jump,
        Attack,
        Skill,
        Hit,
        Dead

    }
    /// <summary>
    /// �{�X�X�e�[�g
    /// </summary>
    public enum BossStateType
    {
        Idle,
        Chase,
        Attack,
        RangeAttack,
        JumpAttack,
        Dead

    }
}

namespace Tuhuse.Shared.StateSystem
{
    /// <summary>
    /// �X�e�[�g�C���^�[�t�F�[�X
    /// </summary>
    /// <typeparam name="TStateType">�v���C���[���{�X�̃X�e�[�g</typeparam>
    public interface IState<TStateType>
    {
        TStateType GetCurrentState { get; }

        void OnStateChanged();
        void OnStateBegin();
        void OnStateEnd();
        void Update(float deltTime, StateEvent inputEvent, IInput input);
        void SetNextState(IState<TStateType> nextState);
        IState<TStateType> GetNextState();
    }
}