using UnityEngine;
using Tuhuse.Shared.Events;
using Tuhuse.Shared.Interfaces;
using Tuhuse.Shared.StateSystem;
/// <summary>
/// �{�X���ǔ��X�e�[�g���̃X�e�[�g�؂�ւ����f��S���N���X
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

        // �ߐڍU���i��₠�� & �����\���߂��Ƃ��̂ݑJ�ځj
        if (aiInput.CandidateAttack)
        {
            if (dist <= 2.5f||_closerTime<=0) // �U�����͂������܂ŋ߂Â��Ă���
            {
                stateEvent.HandleMeleeAttack();
                _closerTime = CLOSER_TIME;
                return _factory.CreateAttackState();
            }
            else
            {
                _closerTime -= Time.deltaTime;
                //�ǔ��p��
                return _factory.CreateChaseState();
            }
        }

        // �W�����v�U��
        if (aiInput.CandidateJump && Random.value < 0.3f)
        {
            stateEvent.HandleJumpAttack();
            return _factory.CreateJumpAttackState();
        }

        // �������U��
        if (aiInput.CandidateSkill)
        {
            stateEvent.HandleRangeAttack();
            Debug.Log("�������U��");
            return _factory.CreateRangeAttackState();
        }

        // �f�t�H���g�͒ǔ�
        return _factory.CreateChaseState();
    }
}
