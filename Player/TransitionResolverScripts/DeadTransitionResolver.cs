using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;

namespace Tuhuse.PlayerSystem.Transitions
{
    /// <summary>
    /// プレイヤーが攻撃ステート時のステート切り替え判断を担うクラス
    /// </summary>
    public class DeadTransitionResolver : ITransitionResolver<PlayerStateType>
    {
        private readonly IPlayerStateFactory _factory;

        public DeadTransitionResolver(IPlayerStateFactory factory)
        {
            _factory = factory;
        }

        public IState<PlayerStateType> Resolve(IInput input, StateEvent stateEvent)
        {
            throw new System.NotImplementedException();
        }
    }
}
