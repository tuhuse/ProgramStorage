using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;

namespace Tuhuse.PlayerSystem.StateMachines
{
    /// <summary>
    /// プレイヤーステートマシーン
    /// </summary>
    public class PlayerStateMachine : StateMachineBase<PlayerStateType>
    {
     
        protected override void Start()
        {
            PlayerDamageReceiver playerDamageReceiver = GetComponent<PlayerDamageReceiver>();
            PlayerAttack playerAttack = GetComponent<PlayerAttack>();
            SkillManager skillManager = FindObjectOfType<SkillManager>();
           
            _input = new PlayerInput(playerDamageReceiver);
            _mover = GetComponent<IMove>();
            _jumper = GetComponent<IJump>();
            _stateFactory = new PlayerStateFactory(_mover,_jumper,skillManager,playerAttack,playerDamageReceiver);

            base.Start();
        }


        protected override void Update()
        {
            _input.InputUpdate();
            base.Update();
        }

        protected override IState<PlayerStateType> GetInitialState()
        {
            return _stateFactory.CreateIdleState();
        }
      

    }
}