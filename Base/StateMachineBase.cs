using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
using UnityEngine;
/// <summary>
/// �v���C���[�A�{�X�ł��g�����ʂ̃X�e�[�g�}�V�[�����N���X
/// </summary>
/// <typeparam name="TStateType">�{�X��v���C���[�̃X�e�[�g�^�C�v</typeparam>
public abstract class StateMachineBase<TStateType> : MonoBehaviour
{
    public StateEvent StateEvent { get; set; } = new StateEvent();
    protected IStateFactory<TStateType> _stateFactory = default;
    protected IInput _input = default;
    protected IState<TStateType> _currentState =default;
    protected IMove _mover = default;
    protected IJump _jumper = default;
    protected ISkill _skill = default;
  protected virtual void Start()
    { 
        _currentState =GetInitialState();
        _currentState.OnStateBegin();
    }

    protected virtual void Update()
    {
        _currentState.Update(Time.deltaTime, StateEvent,_input);

        IState<TStateType> nextState = _currentState.GetNextState();
        if (nextState != null)
        {
            _currentState.OnStateEnd();

            _currentState = nextState;   

            _currentState.OnStateChanged();
            _currentState.OnStateBegin();
        }
    }
    protected abstract IState<TStateType> GetInitialState();

}
