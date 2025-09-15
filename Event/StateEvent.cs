using System;
using UnityEngine;
namespace Tuhuse.Shared.Events
{
    /// <summary>
    /// ステートで使うイベントクラス
    /// </summary>
    public class StateEvent
    {
        private Action _onDead = default;
        private Action<int> _onMove = default;
        private Action _onAttack = default;
        private Action _onMeleeAttack = default;
        private Action _onRangeAttack = default;
        private Action _onJumpAttack = default;
        private Action _onSkill = default;
        private Action _onJump = default;
        public event Action<int> OnMove
        {
            add => _onMove += value;
            remove => _onMove -= value;
        }
        public event Action OnJump
        {
            add => _onJump += value;
            remove => _onJump -= value;
        }
        public event Action OnAttack
        {
            add => _onAttack += value;
            remove => _onAttack -= value;
        }
        public event Action OnMeleeAttack
        {
            add => _onMeleeAttack += value;
            remove => _onMeleeAttack -= value;
        }
        public event Action OnRangeAttack
        {
            add => _onRangeAttack += value;
            remove => _onRangeAttack -= value;
        }
        public event Action OnJumpAttack
        {
            add => _onJumpAttack += value;
            remove => _onJumpAttack -= value;
        }
        public event Action OnDead
        {
            add => _onDead += value;
            remove => _onDead -= value;
        }
        public event Action OnSkill
        {
            add => _onSkill += value;
            remove => _onSkill -= value;
        }

        public void HandleDeath()
        {
            if (_onDead == null)
            {
               
                return;
            }
            _onDead.Invoke();
        }
        public void HandleMove()
        {
            if (_onMove == null)
            {
           
                return;
            }

            _onMove.Invoke(-1);
        }
        public void HandleAttack()
        {
            if (_onAttack == null)
            {
          
                return;
            }

            _onAttack.Invoke();
        } public void HandleMeleeAttack()
        {
            if (_onMeleeAttack == null)
            {
              
                return;
            }

            _onMeleeAttack.Invoke();
        } public void HandleRangeAttack()
        {
            if (_onRangeAttack == null)
            {
                
                return;
            }

            _onRangeAttack.Invoke();
        } public void HandleJumpAttack()
        {
            if (_onJumpAttack == null)
            {
               
                return;
            }

            _onJumpAttack.Invoke();
        }
        public void HandleSkill()
        {
            if (_onSkill == null)
            {
                
                return;
            }

            _onSkill.Invoke();
        }
        public void HandleJump()
        {
            if (_onJump == null)
            {
               
                return;
            }

            _onJump.Invoke();
        }
    }
}