using System.Collections;
using Tuhuse.Shared.Interfaces;
using UnityEngine;
/// <summary>
/// �{�X�̋ߐڍU���̋��������N���X
/// </summary>
public class BossMeleedAttack : MonoBehaviour,ITimeAffectable
{
    [SerializeField]
    private GameObject _meleeObj = default;
    [SerializeField]
    private Animator _meleeAttackAnimation = default;
    private Transform _player;
    private bool _isCoolTime = default;
    private bool _isStopped = false;
    private float _attackTimer = 0f;
    private float _coolTimer = 0f;
    private const float ATTACK_TIME = 1.5f;
    private const float COOL_TIME = 2f;
    void Start()
    {
        BossStateMachine stateMachine = GameObject.FindFirstObjectByType<BossStateMachine>();
        stateMachine.StateEvent.OnMeleeAttack += MeleeAttack;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (_isStopped) return; // ���~�ߒ��͏����~�߂�

        if (_attackTimer > 0f)
        {
            _attackTimer -= Time.deltaTime;
            if (_attackTimer <= 0f)
            {
                _meleeObj.SetActive(false);
                _coolTimer = COOL_TIME;
            }
        }
        else if (_coolTimer > 0f)
        {
            _coolTimer -= Time.deltaTime;
            if (_coolTimer <= 0f)
            {
                _isCoolTime = false;
            }
        }
    }
    /// <summary>
    /// �ߐڍU������
    /// </summary>
    private void MeleeAttack()
    {
        if (!_isCoolTime && !_isStopped)
        {
            // �v���C���[�̕���������
            Vector3 dir = (_player.position - transform.position).normalized;
            dir.y = 0f; // ��������������]
            transform.forward = -dir; 


            // �U�������L����
            _meleeObj.SetActive(true);
            _attackTimer = ATTACK_TIME;
            _isCoolTime = true;
        }
    }
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerDamageReceiver playerStatus = other.GetComponent<PlayerDamageReceiver>();
            EnemyStatus enemyStatus = this.GetComponent<EnemyStatus>();
            playerStatus.ReceiveDamage(enemyStatus.Status.Attack,this.transform);
        }
    }

    public void OnTimeStop()
    {
        _isStopped = true;
        if (_meleeAttackAnimation != null)
        {
            _meleeAttackAnimation.speed = 0f; // �A�j���[�V������~
        }
    }

    public void OnTimeResume()
    {
        _isStopped = false;
        if (_meleeAttackAnimation != null)
        {
            _meleeAttackAnimation.speed = 1f; // �A�j���[�V�����ĊJ
        }
    }

}
