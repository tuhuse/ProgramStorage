using UnityEngine;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
using Tuhuse.Shared.Events;
using Tuhuse.PlayerSystem.StateMachines;

namespace Tuhuse.PlayerSystem.States
{
    /// <summary>
    /// à⁄ìÆéûÇÃÇ”ÇÈÇ‹Ç¢
    /// </summary>
    public class MoveState : PlayerStateBase
    {
        private IMove _mover;
        private ITransitionResolver<PlayerStateType> _resolver;
        private float _speed = default;

        public MoveState(IMove mover, ITransitionResolver<PlayerStateType> resolver, float speed)
        {
            _mover = mover;
            _speed = speed;
            _resolver = resolver;
        }

        public override PlayerStateType GetCurrentState => PlayerStateType.Move;

        public override void Update(float deltaTime, StateEvent stateEvent, IInput input)
        {
            if (IsEndState)
            {
                return;
            }
            Vector2 moveDir = Vector2.zero;
            if (input.IsLeftWalk)
            {
                moveDir.x -= 1;
            }
            if (input.IsRightWalk)
            {
                moveDir.x += 1;
            }
            if (input.IsForward)
            {
                moveDir.y += 1;
            }
            if (input.IsBack)
            {
                moveDir.y -= 1;
            }

            moveDir = moveDir.normalized; // éŒÇﬂÇÃë¨ìxí≤êÆ
            _mover.Move(moveDir.x * _speed, moveDir.y * _speed);



            _nextState = _resolver.Resolve(input, stateEvent);
        }
    }
}