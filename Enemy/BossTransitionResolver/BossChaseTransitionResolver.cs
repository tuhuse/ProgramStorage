using UnityEngine;
using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
/// <summary>
/// ボスが追尾ステート時のステート切り替え判断を担うクラス
/// </summary>
public class BossChaseTransitionResolver : ITransitionResolver<BossStateType>
{
    private readonly IBossStateFactory _factory;
    private readonly Transform _boss;
    private readonly Transform _player;
    private float _closerTime;
    private const float CLOSER_TIME=3f;
    public BossChaseTransitionResolver(IBossStateFactory factory, Transform boss, Transform player, float closerTime=3f)
    {
        _factory = factory;
        _boss = boss;
        _player = player;
        _closerTime = closerTime;
    }

    public IState<BossStateType> Resolve(IInput input, StateEvent stateEvent)
    {
        if (input is not BossAIInput aiInput)
            return _factory.CreateChaseState();

        float dist = Vector3.Distance(_boss.position, _player.position);

        // 近接攻撃（候補あり & 距離十分近いときのみ遷移）
        if (aiInput.CandidateAttack)
        {
            if (dist <= 2.5f||_closerTime<=0) // 攻撃が届く距離まで近づいてたら
            {
                stateEvent.HandleMeleeAttack();
                _closerTime = CLOSER_TIME;
                return _factory.CreateAttackState();
            }
            else
            {
                _closerTime -= Time.deltaTime;
                //追尾継続
                return _factory.CreateChaseState();
            }
        }

        // ジャンプ攻撃
        if (aiInput.CandidateJump && Random.value < 0.3f)
        {
            stateEvent.HandleJumpAttack();
            return _factory.CreateJumpAttackState();
        }

        // 遠距離攻撃
        if (aiInput.CandidateSkill)
        {
            stateEvent.HandleRangeAttack();
            Debug.Log("遠距離攻撃");
            return _factory.CreateRangeAttackState();
        }

        // デフォルトは追尾
        return _factory.CreateChaseState();
    }
}
