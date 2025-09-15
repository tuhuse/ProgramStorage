using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;

namespace Tuhuse.PlayerSystem.Transitions
{
    /// <summary>
    /// プレイヤーがスキル使用ステート時のステート切り替え判断を担うクラス
    /// </summary>
    public class SkillTransitionResolver : ITransitionResolver<PlayerStateType>
    {
        private readonly IPlayerStateFactory _factory;

        public SkillTransitionResolver(IPlayerStateFactory factory)
        {
            _factory = factory;
        }
        public IState<PlayerStateType> Resolve(IInput input, StateEvent stateEvent)
        {
           
            return _factory.CreateIdleState();
        }

    }
}