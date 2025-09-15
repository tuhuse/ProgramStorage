using Tuhuse.PlayerSystem.StateMachines;
using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
using UnityEngine;
namespace Tuhuse.PlayerSystem.States
{
    /// <summary>
    /// �X�L���g�p���̂ӂ�܂�
    /// </summary> 
    public class SkillState : PlayerStateBase
    {
        public override PlayerStateType GetCurrentState => PlayerStateType.Skill;

        private readonly ITransitionResolver<PlayerStateType> _resolver;
        private readonly SkillManager _skill;

        public SkillState(ITransitionResolver<PlayerStateType> resolver, SkillManager skill)
        {
            _resolver = resolver;
            _skill = skill;
        }

        public override void OnStateBegin()
        {
            base.OnStateBegin();
            
           
        }

        public override void Update(float deltaTime, StateEvent stateEvent, IInput input)
        {
            if (IsEndState) return;
            
            
            // �X�L�����I������� Idle �ɖ߂�
            if (_skill.IsFinished)
            {
                _nextState = _resolver.Resolve(input, stateEvent);
                return;
            }   

            // �܂����s���Ȃ�J�ڔ���͒ʏ�ǂ���
            _nextState = _resolver.Resolve(input, stateEvent);
        }
    }
}
