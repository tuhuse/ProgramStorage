using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
namespace Tuhuse.PlayerSystem.Transitions
{
    /// <summary>
    /// プレイヤーが攻撃ステート時のステート切り替え判断を担うクラス
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